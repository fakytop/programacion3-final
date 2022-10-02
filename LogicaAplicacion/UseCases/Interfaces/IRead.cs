using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IRead<T>
    {
        public IEnumerable<T> ReadAll();
        public T FindById(int id);
    }
}
