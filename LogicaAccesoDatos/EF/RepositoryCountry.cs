using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaAccesoDatos.EF
{
    public class RepositoryCountry : IRepositoryCountry
    {
        private ObligatorioContext _db;
        public RepositoryCountry (ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Country country)
        {
            country.validate();
            _db.Add(country);
            _db.SaveChanges();
        }

        public IEnumerable<Country> All()
        {
            return _db.Countries;
        }

        public void Delete(int id)
        {
            Country country = _db.Countries.Find(id);
            _db.Countries.Remove(country);
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }

        public Country FindById(int id)
        {
            Country c = _db.Countries
                .FirstOrDefault(c => c.Id == id);
        
            if(c == null)
            {
                throw new Exception("No se encontró país");
            }

            return c;
        }
    }
}
