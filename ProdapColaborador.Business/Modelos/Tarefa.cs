using System;
using System.Collections.Generic;
using System.Text;

namespace ProdapColaborador.Business.Modelos
{
    public class Tarefa : EntitadeBase
    {
        public string Descricao { get; set; }

        public int IdUsuarioResponsavel { get; set; }
    }
}
