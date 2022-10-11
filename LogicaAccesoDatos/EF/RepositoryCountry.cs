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
        private ObligatorioContext _repository;
        public RepositoryCountry (ObligatorioContext repository)
        {
            _repository = repository;
        }
        public void Add(Country country)
        {
            country.Validate();
            Country c = _repository.Countries.FirstOrDefault(co => co.Name.Value == country.Name.Value);
            if (c != null)
            {
                throw new DomainException("Country already exists.");
            }
            _repository.Add(country);
            _repository.SaveChanges();
        }

        public IEnumerable<Country> All()
        {
            return _repository.Countries;
        }

        public void Delete(int id)
        {
            Country country = _repository.Countries.FirstOrDefault(country => country.Id == id);
            IEnumerable<NationalTeam> nationalTeams = from n in _repository.NationalTeams
                                                      where n.Country.Id == country.Id
                                                      select n;
            if (nationalTeams.Count () > 0)
            {
                throw new DomainException("Cannot delete country associated to National Team.");
            }
            _repository.Countries.Remove(country);
            _repository.SaveChanges();

        }

        public void Update(Country country)
        {
            Country old = _repository.Countries.Find(country.Id);

            if (old == null)
            {
                throw new Exception("Country does not exist.");
            }
            try
            {
                country.Validate();
                old.Update(country);
                _repository.Countries.Update(old);
                _repository.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }

        }

        public Country FindById(int id)
        {
            Country country = _repository.Countries
                .FirstOrDefault(country => country.Id == id);
        
            if(country == null)
            {
                throw new DomainException("Country does not exist.");
            }

            return country;
        }

        public Country FindByISO (string iso)
        {
            Country country = _repository.Countries
                .FirstOrDefault(c => c.IsoAlfa3.Value == iso);
            if (country == null)
            {
                throw new DomainException("Country does not exist.");
            }
            return country;
        }

        public IEnumerable<Country> FindByRegion (string region)
        {
            IEnumerable<Country> countries = from c in _repository.Countries
                                             where c.Region.Value == region
                                             select c;
            if (countries.Count () == 0)
            {
                throw new DomainException("No countries for the specified region.");
            }
            return countries;
        }
    }
}
