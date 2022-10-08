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
    public class RepositoryMatch : IRepositoryMatch
    {
        public ObligatorioContext _db;

        public RepositoryMatch(ObligatorioContext db)
        {
            _db = db;
        }

        public void Add(Match obj)
        {
            IEnumerable <Match> matches = All();
            
            if(obj.Home.GroupStageId != obj.Away.GroupStageId)
            {
                throw new DomainException("Home and Away must be from the same group.");
            }

            if(obj.Home == obj.Away)
            {
                throw new DomainException("National Team can't play against itself.");
            }
            foreach (var item in matches)
            {
                if((item.Home == obj.Home && item.Away == obj.Away) || (item.Home == obj.Away && item.Away == obj.Home))
                {
                    throw new DomainException("Match already exists.");
                }
                if(item.MatchDate.Value == obj.MatchDate.Value)
                {
                    throw new DomainException("Match date already taken.");
                }
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

        public IEnumerable<Match> All()
        {
            try
            {
                return _db.Match
                    .Include(th => th.Home)
                    .Include(ta => ta.Away)
                    .OrderBy(d => d.MatchDate.Value);
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

        public void Update(Match obj)
        {
            throw new NotImplementedException();
        }
    }
}
