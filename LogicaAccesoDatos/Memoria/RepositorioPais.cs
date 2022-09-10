using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPais : IRepositorioPais
    {
        private static List<Pais> paises = new List<Pais>();
        private static int ultId = 1;

        public void Add(Pais obj)
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

        public IEnumerable<Pais> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
