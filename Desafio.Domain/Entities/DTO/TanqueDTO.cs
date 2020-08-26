using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities.DTO
{
    public class TanqueDTO
    {
        public int? Id { get; set; }

        public string Descricao { get; set; }

        public string Quantidade { get; set; }

        public int TipoProduto { get; set; }
    }
}
