using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioResultadoPartido : IRepositorioResultadoPartido
    {
        private static List<ResultadoPartido> resultados = new List<ResultadoPartido>();
        private static int ultId = 1;

        public void Add(ResultadoPartido obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultadoPartido> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ResultadoPartido obj)
        {
            throw new NotImplementedException();
        }
    }
}
