using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IDelete<T>
    {
        public void Delete(T obj);
    }
}
