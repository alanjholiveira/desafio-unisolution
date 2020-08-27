using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain.Entities.DTO;

namespace Desafio.CrosCutting.Adapter.Interfaces
{
    public interface ITanqueMapper
    {
        #region Mappers

        Tanque MapperToEntity(TanqueDTO clienteDTO);

        IEnumerable<TanqueDTO> MapperListTanques(IEnumerable<Tanque> tanques);

        TanqueDTO MapperToDTO(Tanque Tanque);

        #endregion
    }
}
