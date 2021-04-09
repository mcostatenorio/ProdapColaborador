using System;
using System.Collections.Generic;
using System.Text;

namespace ProdapColaborador.Business.Modelos
{
    public class Usuario : EntitadeBase
    {
        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Coleção de tarefas
        /// </summary>
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
