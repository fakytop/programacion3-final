using LogicaNegocio.Entidades;
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
            NationalTeam nt = _db.NationalTeams.Find(obj.Country.Id);
            if(nt != null)
            {
                throw new Exception("Ya existe una selección para ese país.");
            }
            try
            {
                obj.Validate();
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Algo pasó");
            }
            }

        public IEnumerable<NationalTeam> All()
        {
            try
            {
                return _db.NationalTeams
                    .Include(c => c.Country)
                    .OrderBy(nt => nt.Name.Value)
                    .ThenBy(nt => nt.Country.Name.Value);
            }
            catch(Exception e)
            {
                throw new Exception($"Error en FindAll: {e.Message}");
            }
        }

        public void Delete(int id)
        {
            NationalTeam nt = FindById(id);
            if(nt == null)
            {
                throw new Exception("No se encontró una selección con ese Id");
            }
            try
            {
                _db.NationalTeams.Remove(nt);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("NO");
            }
        }

        public void Update(NationalTeam obj)
        {
            NationalTeam nt = _db.NationalTeams.Find(obj.Id);
            if(nt == null)
            {
                throw new Exception("No existe NT.");
            }

            try
            {
                obj.Validate();
                nt.Update(obj);
                _db.NationalTeams.Update(nt);
                _db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception($"Error: {e.Message}");
            }
        }

        public NationalTeam FindById(int id)
        {
            NationalTeam nt = _db.NationalTeams
                .FirstOrDefault(nt => nt.Id == id);

            if(nt == null)
            {
                throw new Exception("No se encontró una selección nacional con ese ID");
            }
            return nt;
        }

    }
}
