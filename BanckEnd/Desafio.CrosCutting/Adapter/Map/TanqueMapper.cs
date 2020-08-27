using Desafio.CrosCutting.Adapter.Interfaces;
using Desafio.Domain.Entities;
using Desafio.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.CrosCutting.Adapter.Map
{
    public class TanqueMapper : ITanqueMapper
    {

        #region properties

        List<TanqueDTO> tanqueDTOs = new List<TanqueDTO>();

        #endregion


        #region methods

        public Tanque MapperToEntity(TanqueDTO tanqueDTO)
        {
            Tanque tanque = new Tanque
            {
                Id = tanqueDTO.Id
                ,
                Descricao = tanqueDTO.Descricao
                ,
                Quantidade = tanqueDTO.Quantidade
                ,
                TipoProduto = tanqueDTO.TipoProduto
            };

            return tanque;

        }


        public IEnumerable<TanqueDTO> MapperListTanques(IEnumerable<Tanque> tanques)
        {
            foreach (var item in tanques)
            {


                TanqueDTO tanqueDTO = new TanqueDTO
                {
                    Id = item.Id
                   ,
                    Descricao = item.Descricao
                   ,
                    Quantidade = item.Quantidade
                   ,
                    TipoProduto = item.TipoProduto
                };



                tanqueDTOs.Add(tanqueDTO);

            }

            return tanqueDTOs;
        }

        public TanqueDTO MapperToDTO(Tanque Tanque)
        {

            TanqueDTO tanqueDTO = new TanqueDTO
            {
                Id = Tanque.Id
                ,
                Descricao = Tanque.Descricao
                ,
                Quantidade = Tanque.Quantidade
                ,
                TipoProduto = Tanque.TipoProduto
            };

            return tanqueDTO;

        }

        #endregion

    }
}
