using System;

namespace ProdapColaborador.Business.Modelos
{
    public abstract class EntitadeBase
    {
        /// <summary>
        /// Construtor
        /// </summary>
        protected EntitadeBase()
        {
            DataCriacao = DateTime.Now;
        }

        /// <summary>
        /// Id do registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data criação do registro
        /// </summary>
        public DateTime DataCriacao { get; set; }
    }
}
