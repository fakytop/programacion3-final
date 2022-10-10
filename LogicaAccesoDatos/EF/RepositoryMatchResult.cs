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
                throw new DomainException("Match result already registered.");
            }

            try
            {
                obj.Validate();
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
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
                throw new Exception("Something went wrong, please try again later.");
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
