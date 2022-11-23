using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LogicaAccesoDatos.EF
{
    public class RepositoryNationalTeam : IRepositoryNationalTeam
    {
        private ObligatorioContext _db;

        public RepositoryNationalTeam(ObligatorioContext pContext)
        {
            _db = pContext;
        }

        public void Add(NationalTeam obj)
        {
            IEnumerable<NationalTeam> nts = All();
            foreach (var item in nts)
            {
                if(item.Country.Id == obj.Country.Id)
                {
                    throw new DomainException("National Team already exists.");
                }
            }
            try
            {
                obj.Validate();
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }

        public IEnumerable<NationalTeam> All()
        {
            try
            {
                return _db.NationalTeams
                    .Include(c => c.Country)
                    .Include(g => g.GroupStage)
                    .OrderBy(nt => nt.Country.Name.Value)
                    .ThenBy(nt => nt.Country.Name.Value);
            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }

        public void Delete(int id)
        {
            NationalTeam nt = FindById(id);
            IEnumerable<Match> matches = from n in _db.Match
                                         where n.AwayId == nt.Id || n.HomeId == nt.Id
                                         select n;
            if(matches.Count() > 0)
            {
                throw new DomainException("Can't be deleted, has asociated match games.");
            }
            
            
            if (nt == null)
            {
                throw new DomainException("National Team does not exist.");
            }
            try
            {
                _db.NationalTeams.Remove(nt);
                _db.SaveChanges();
            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }

        public void Update(NationalTeam obj)
        {
            NationalTeam nt = FindById(obj.Id);
            try
            {
                obj.Validate();
                nt.Update(obj);
                _db.NationalTeams.Update(nt);
                _db.SaveChanges();
            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong, please try again later.");
            }
        }

        public NationalTeam FindById(int id)
        {
            try
            {
                NationalTeam nt = _db.NationalTeams
                   .Include(c => c.Country)
                   .FirstOrDefault(nt => nt.Id == id);

                if (nt == null)
                {
                    throw new DomainException("National Team does not exist.");
                }
                return nt;

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }

        }

        public IEnumerable<NationalTeam> NationalTeamsByGroup(string groupName)
        {
            IEnumerable<NationalTeam> nts = _db.NationalTeams
                .Include(nt => nt.GroupStage)
                .Include(nt => nt.Country)
                .Where(nt => nt.GroupStage.Group.Value == groupName)
                .ToList();

            return nts;
        }
    }
}
