using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;

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
            throw new NotImplementedException();
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
