using ApiApp.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Mapper
{
    public class CountryMapper
    {
        public static Country ToCountry(CountryDto cDto)
        {
            if(cDto == null)
            {
                return null;
            }
            return new Country
            {
                Id = cDto.Id,
                Name = new NameValue(cDto.Name),
                IsoAlfa3 = new ISOAlfa3Value(cDto.IsoAlfa3),
                GDP = new PositiveFloatValue(cDto.GDP),
                Population = new PositiveIntegerValue(cDto.Population),
                Image = cDto.Image,
                Region = new RegionValue(cDto.Region)
            };
        }

        public static CountryDto FromCountry(Country c)
        {
            if(c == null)
            {
                return null;
            }

            return new CountryDto
            {
                Id = c.Id,
                Name = c.Name.Value,
                IsoAlfa3 = c.IsoAlfa3.Value,
                GDP = c.GDP.Value,
                Population = c.Population.Value,
                Image = c.Image,
                Region = c.Region.Value
            };
        }

        public static IEnumerable<CountryDto> FromCountries(IEnumerable<Country> cies)
        {
            if(cies == null)
            {
                return null;
            }
            return cies.Select(c => FromCountry(c));
        }
    }
}
