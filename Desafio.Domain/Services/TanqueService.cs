using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Services
{
    public class TanqueService : ServiceBase<Tanque>, ITanqueService
    {
        public readonly ITanqueRepository _tanqueRepository;


        public TanqueService(ITanqueRepository tanqueRepository)
           : base(tanqueRepository)
        {
            _tanqueRepository = tanqueRepository;
        }
    }
}
