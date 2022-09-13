using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.InterfaceRepositorio
{
    public interface IRepository<T>
    {
        public void Add(T obj);
        public IEnumerable<T> All();
        public void Delete(int id);
        public void Update(T obj);
    }
}
