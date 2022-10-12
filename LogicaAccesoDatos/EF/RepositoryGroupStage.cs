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
    public class RepositoryGroupStage : IRepositoryGroupStage
    {

        private ObligatorioContext _db;
        public RepositoryGroupStage(ObligatorioContext db)
        {
            _db = db;
        }

        
        public void Add(GroupStage group)
        {
            IEnumerable<GroupStage> gs = All();
            if(gs.Count() >= 8)
            {
                throw new DomainException("There already 8 groups registered.");
            }
            _db.Add(group);
            group.Validate();
            _db.SaveChanges();
        }

        public IEnumerable<GroupStage> All()
        {
            try
            {
                return _db.GroupsStage
                    .Include(gs => gs.NationalTeams)
                    .ThenInclude(c => c.Country)
                    .OrderBy(gs => gs.Group.Value)
                    .ThenBy(gs => gs.Group.Value);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }
        public void Delete(int id)
        {
            GroupStage gs = FindById(id);

            IEnumerable<NationalTeam> nts = from nt in _db.NationalTeams
                                            where nt.GroupStage.Id == gs.Id
                                            select nt;
            if(nts.Count() > 0)
            {
                throw new DomainException("Can't be deleted, has asociated National Teams.");
            }

            if (gs == null)
            {
                throw new Exception($"Group stage does not exist.");
            }
            try
            {
                _db.GroupsStage.Remove(gs);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }

        public GroupStage FindById(int id)
        {
            GroupStage group = _db.GroupsStage
                .Include (group => group.NationalTeams)
                .FirstOrDefault(group => group.Id == id);
            if (group == null)
            {
                throw new Exception("Group stage does not exist.");
            }
            return group;
        }

        public void Update(GroupStage obj)
        {
            GroupStage gs = FindById(obj.Id);
            if (gs == null)
            {
                throw new Exception("Group stage does not exist.");
            }

            try
            {
                obj.Validate();
                gs.Update(obj);
                _db.GroupsStage.Update(gs);
                _db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong, please try again later.");
            }
        }
    }
}
