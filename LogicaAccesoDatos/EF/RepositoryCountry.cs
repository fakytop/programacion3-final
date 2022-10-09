using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
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
            Country country = _db.Countries.FirstOrDefault(country => country.Id == id);
            _db.Countries.Remove(country);
            _db.SaveChanges();

        }

        public void Update(Country country)
        {
            Country old = _db.Countries.Find(country.Id);

            if (old == null)
            {
                throw new Exception("Didn't find any Country to update.");
            }
            try
            {
                country.validate();
                old.Update(country);
                _db.Countries.Update(old);
                _db.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}");
            }

        }

        public Country FindById(int id)
        {
            Country country = _db.Countries
                .FirstOrDefault(country => country.Id == id);
        
            if(country == null)
            {
                throw new DomainException("Country doesn't exists.");
            }

            return country;
        }
    }
}
