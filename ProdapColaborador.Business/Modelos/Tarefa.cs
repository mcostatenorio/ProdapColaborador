using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdapColaborador.Business.Modelos
{
    public class Tarefa : EntitadeBase
    {
        /// <summary>
        /// Descrição da tarefa
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Status da tarefa
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Id do usuário responsável pela tarefa
        /// </summary>
        public int IdUsuarioResponsavel { get; set; }

        [ForeignKey("IdUsuarioResponsavel")]
        public virtual Usuario Usuario { get; set; }
    }
}
