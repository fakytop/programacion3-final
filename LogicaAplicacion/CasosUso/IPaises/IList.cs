﻿using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasosUso.IPaises
{
    public interface IList
    {
        public IEnumerable<Country> FindAll();
    }
}
