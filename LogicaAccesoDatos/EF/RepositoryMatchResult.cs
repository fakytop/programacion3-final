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
    public class RepositoryMatchResult : IRepositoryMatchResult
    {
        public ObligatorioContext _db;

        public RepositoryMatchResult(ObligatorioContext db)
        {
            _db = db;
        }

        public void Add(MatchResult obj)
        {
            IEnumerable<MatchResult> mr = All();

            if(mr.Contains(obj))
            {
                throw new DomainException("The match result already exists.");
            }

            try
            {
                obj.Validate();
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Eror: {e.Message}");
            }
        }

        public IEnumerable<MatchResult> All()
        {
            try
            {
                return _db.MatchResult
                    .Include(mr => mr.Match)
                    .OrderBy(d => d.Match.MatchDate.Value);
            }
            catch (Exception e)
            {
                throw new Exception($"Error en FindAll: {e.Message}");
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MatchResult FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MatchResult obj)
        {
            throw new NotImplementedException();
        }
    }
}
