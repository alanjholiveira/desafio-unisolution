using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Entities
{
    public class Tanque : Base
    {
        public string Descricao { set; get; }
        public string Quantidade { set; get; }
        public int TipoProduto { set; get; }
    }
}
