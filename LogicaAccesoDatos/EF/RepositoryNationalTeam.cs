using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF
{
    class RepositoryNationalTeam : IRepositoryNationalTeam
    {
        private ObligatorioContext _context;

        public RepositoryNationalTeam(ObligatorioContext pContext)
        {
            _context = pContext;
        }

        public void Add(NationalTeam obj)
        {
            obj.Validate();
            _context.Add(obj);
            _context.SaveChanges(); 
        }

        public IEnumerable<NationalTeam> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NationalTeam obj)
        {
            throw new NotImplementedException();
        }
    }
}
