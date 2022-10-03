using LogicaNegocio.Entidades;
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
            group.Validate();
            _db.Add(group);
            _db.SaveChanges();
        }

        public IEnumerable<GroupStage> All()
        {
            try
            {
                //Duda
                return _db.GroupsStage
                    .Include(c => c.Group)
                    .OrderBy(gs => gs.Group.Value)
                    .ThenBy(gs => gs.Group.Value);
            }
            catch (Exception e)
            {
                throw new Exception($"Error en FindAll: {e.Message}");
            }
        }

        public void Delete(int id)
        {
            GroupStage group = FindById(id);
            if (group == null)
            {
                throw new Exception($"No existe el grupo con id {id}.");
            }
            try
            {
                _db.GroupsStage.Remove(group);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en Remove {e.Message}");
            }
        }

        private GroupStage FindById(int id)
        {
            // single 
            GroupStage unGroup = _db.GroupsStage
                // .Include(a => a.Pais)
                .FirstOrDefault(a => a.Id == id);
            if (unGroup == null)
            {
                throw new Exception("No se encontró " + id);
            }
            return unGroup;
        }

        public void Update(GroupStage obj)
        {
            GroupStage gs = _db.GroupsStage.Find(obj.Id);
            if (gs == null)
            {
                throw new Exception("No existe el Grupo.");
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

                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
