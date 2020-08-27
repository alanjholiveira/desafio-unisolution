using Desafio.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface ITanqueServiceApplication
    {
        void Add(TanqueDTO obj);

        TanqueDTO GetById(int id);

        IEnumerable<TanqueDTO> GetAll();

        void Update(TanqueDTO obj);

        void Remove(TanqueDTO obj);

        void Dispose();

    }
}
