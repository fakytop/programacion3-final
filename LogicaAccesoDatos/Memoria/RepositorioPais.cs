﻿using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPais : IRepositoryCountry
    {
        private static List<Country> paises = new List<Country>();
        private static int ultId = 1;

        public void Add(Country obj)
        {
            if(paises.Contains(obj))
            {
                throw new DomainException("El país ya está registrado.");
            }
            obj.Validar();
            obj.Id = ultId++;
            paises.Add(obj);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
