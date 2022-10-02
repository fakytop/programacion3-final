using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface ICreate<T>
    {
        public void Create(T obj);
    }
}
