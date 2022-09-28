using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IUpdate<T>
    {
        public void Update(T obj);
    }
}
