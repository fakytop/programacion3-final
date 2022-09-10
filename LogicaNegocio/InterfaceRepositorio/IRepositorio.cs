using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorio<T>
    {
        public void Add(T obj);
        public IEnumerable<T> FindAll();
        public void Delete(int id);
        public void Update(T obj);
    }
}
