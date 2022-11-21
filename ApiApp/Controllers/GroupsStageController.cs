using ApiApp.Dto;
using ApiApp.Mapper;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsStageController : ControllerBase
    {
        private IRead<GroupStage> _ucReadGroupStage;
        private ICreate<GroupStage> _ucCreateGroupStage;
        private IUpdate<GroupStage> _ucUpdateGroupStage;
        private IDelete<GroupStage> _ucDeleteGroupStage;

        private IReadFilterNationalTeams<NationalTeam> _ucNationalTeamFilter;
        private IReadFilterMatches<Match> _ucMatchFilter;

        private IRead<NationalTeam> _ucReadNationalTeam;
        private IAssign<GroupStage> _ucAssign;

        public GroupsStageController(
            IRead<GroupStage> ucReadGroupStage,
            IRead<NationalTeam> ucReadNationalTeam,
            IAssign<GroupStage> ucAssign,
            ICreate<GroupStage> ucCreateGroupStage,
            IUpdate<GroupStage> ucUpdateGroupStage,
            IDelete<GroupStage> ucDeleteGroupStage,
            IReadFilterNationalTeams<NationalTeam> ucNationalTeamFilter,
            IReadFilterMatches<Match> ucMatchFilter            
            )
        {
            _ucReadGroupStage = ucReadGroupStage;
            _ucReadNationalTeam = ucReadNationalTeam;
            _ucAssign = ucAssign;
            _ucCreateGroupStage = ucCreateGroupStage;
            _ucUpdateGroupStage = ucUpdateGroupStage;
            _ucDeleteGroupStage = ucDeleteGroupStage;
            _ucNationalTeamFilter = ucNationalTeamFilter;
            _ucMatchFilter = ucMatchFilter;
        }

        public IActionResult GetAll()
        {
            return Ok(GroupStageMapper.FromGroupsStage(_ucReadGroupStage.ReadAll()));
        }
        
        [HttpPost]
        public IActionResult Create(GroupStageDto gsDto)
        {
            try
            {
                if(gsDto == null)
                {
                    return BadRequest("Server did not receive any data.");
                }

                GroupStage group = GroupStageMapper.ToGroupStage(gsDto);
                _ucCreateGroupStage.Create(group);

                return Ok(gsDto);

            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpPut]
        public IActionResult Edit(GroupStageDto gsDto)
        {
            if(gsDto == null)
            {
                return BadRequest("Server did not receive any data.");
            }
            try
            {
                GroupStage group = _ucReadGroupStage.FindById(gsDto.Id);
                GroupStage gs = GroupStageMapper.ToGroupStage(gsDto);
                gs.NationalTeams = group.NationalTeams;

                _ucUpdateGroupStage.Update(gs);

                return Ok(GroupStageMapper.FromGroupStage(gs));
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ucDeleteGroupStage.Delete(new GroupStage() { Id = id });
                return Ok("Success.");
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpPut]
        [Route("group/{groupID}/nationalteam/{nationalTeamID}")]
        public IActionResult Assign(int groupID, int nationalTeamID)
        {
            try
            {
                GroupStage group = _ucReadGroupStage.FindById(groupID);
                NationalTeam national = _ucReadNationalTeam.FindById(nationalTeamID);
                _ucAssign.AssignNationalTeam(group, national);

                return Ok("Success.");
            }
            catch(DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("byGroup/{groupName}")]
        public IActionResult GetTableByGroupName(string groupName)
        {
            IEnumerable<NationalTeam> nts = _ucNationalTeamFilter.NationalTeamsByGroup(groupName);
            IEnumerable<Match> matches = _ucMatchFilter.ReadMatchesByGroup(groupName);


            var resultHome = from nt in nts
                         join m in matches
                         on nt.Id equals m.HomeId
                         select new
                         {
                             country = nt.Country.Name.Value,
                             pts = m.MatchResult == null ? 0 : m.MatchResult.PointsHome.Value ,
                             goalsScored = m.MatchResult == null ? 0 : m.MatchResult.GoalsH.Value,
                             goalsAgainst = m.MatchResult == null ? 0 : m.MatchResult.GoalsA.Value,
                             yellowCards = m.MatchResult == null ? 0 : m.MatchResult.YellowCardsH.Value,
                             redCards = m.MatchResult == null ? 0 : m.MatchResult.RedCardsH.Value,
                             directRedCards = m.MatchResult == null ? 0 : m.MatchResult.DirectRedCardsH.Value
                         };

            var resultHomeGroup = from nteams in resultHome
                          group nteams by nteams.country into nationalteams
                          select new
                          {
                              country = nationalteams.Key,
                              pts = nationalteams.Sum(x => x.pts),
                              goalsScored = nationalteams.Sum(x => x.goalsScored),
                              goalsAgainst = nationalteams.Sum(x => x.goalsAgainst),
                              yellowCards = nationalteams.Sum(x => x.yellowCards),
                              redCards = nationalteams.Sum(x=> x.redCards),
                              directRedCards = nationalteams.Sum(x=> x.directRedCards)
                          };

            var resultAway = from ntAway in nts
                                  join mAway in matches
                                  on ntAway.Id equals mAway.AwayId
                                  select new
                                  {
                                      country = ntAway.Country.Name.Value,
                                      pts = mAway.MatchResult == null ? 0 : mAway.MatchResult.PointsAway.Value,
                                      goalsScored = mAway.MatchResult == null ? 0 : mAway.MatchResult.GoalsA.Value,
                                      goalsAgainst = mAway.MatchResult == null ? 0 : mAway.MatchResult.GoalsH.Value,
                                      yellowCards = mAway.MatchResult == null ? 0 : mAway.MatchResult.YellowCardsA.Value,
                                      redCards = mAway.MatchResult == null ? 0 : mAway.MatchResult.RedCardsA.Value,
                                      directRedCards = mAway.MatchResult == null ? 0 : mAway.MatchResult.DirectRedCardsA.Value
                                  };
            var resultAwayGroup = from nteamsAway in resultAway
                                  group nteamsAway by nteamsAway.country into nationalteamsAway
                                  select new
                                  {
                                      country = nationalteamsAway.Key,
                                      pts = nationalteamsAway.Sum(x => x.pts),
                                      goalsScored = nationalteamsAway.Sum(x => x.goalsScored),
                                      goalsAgainst = nationalteamsAway.Sum(x => x.goalsAgainst),
                                      yellowCards = nationalteamsAway.Sum(x => x.yellowCards),
                                      redCards = nationalteamsAway.Sum(x => x.redCards),
                                      directRedCards = nationalteamsAway.Sum(x => x.directRedCards)
                                  };

            var resultFinal = (from home in resultHomeGroup
                               select new
                               {
                                   home.country,
                                   home.pts,
                                   home.goalsScored,
                                   home.goalsAgainst,
                                   home.yellowCards,
                                   home.redCards,
                                   home.directRedCards
                               }).Union(from away in resultAwayGroup
                                        select new
                                        {
                                            away.country,
                                            away.pts,
                                            away.goalsScored,
                                            away.goalsAgainst,
                                            away.yellowCards,
                                            away.redCards,
                                            away.directRedCards
                                        }

                                );

            var resultDto = from ntFinal in resultFinal
                            group ntFinal by ntFinal.country into natFinal
                            select new
                            {
                                country = natFinal.Key,
                                pts = natFinal.Sum(x => x.pts),
                                goalsScored = natFinal.Sum(x => x.goalsScored),
                                goalsAgainst = natFinal.Sum(x => x.goalsAgainst),
                                yellowCards = natFinal.Sum(x => x.yellowCards),
                                redCards = natFinal.Sum(x => x.redCards),
                                directRedCards = natFinal.Sum(x => x.directRedCards)
                            };
            var resultadoOrdenado = resultDto.OrderByDescending(x => x.pts).ThenByDescending(x => x.goalsScored);


            if (resultadoOrdenado.Count() == 0)
            {
                return BadRequest("No data yet.");
            }

            return Ok(resultadoOrdenado);
        }

    }
}
