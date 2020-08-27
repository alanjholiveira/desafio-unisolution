using Desafio.Application.Interfaces;
using Desafio.CrosCutting.Adapter.Interfaces;
using Desafio.Domain.Entities.DTO;
using Desafio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class TanqueServiceApplication : ITanqueServiceApplication
    {
        private readonly ITanqueService _tanqueService;
        private readonly ITanqueMapper _tanqueMapper;

        public TanqueServiceApplication(ITanqueService TanqueService, ITanqueMapper TanqueMapper)
        {
            _tanqueService = TanqueService;
            _tanqueMapper = TanqueMapper;
        }


        public void Add(TanqueDTO obj)
        {
            var objTanque = _tanqueMapper.MapperToEntity(obj);
            _tanqueService.Add(objTanque);
        }

        public void Dispose()
        {
            _tanqueService.Dispose();
        }

        public IEnumerable<TanqueDTO> GetAll()
        {
            var objTanques = _tanqueService.GetAll();
            return _tanqueMapper.MapperListTanques(objTanques);
        }

        public TanqueDTO GetById(int id)
        {
            var objTanque = _tanqueService.GetById(id);
            return _tanqueMapper.MapperToDTO(objTanque);
        }

        public void Remove(TanqueDTO obj)
        {
            var objTanque = _tanqueMapper.MapperToEntity(obj);
            _tanqueService.Remove(objTanque);
        }

        public void Update(TanqueDTO obj)
        {
            var objTanque = _tanqueMapper.MapperToEntity(obj);
            _tanqueService.Update(objTanque);
        }
    }
}
