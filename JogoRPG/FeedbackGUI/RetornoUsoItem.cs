using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.FeedbackGUI
{
    public class RetornoUsoItem
    {
        public Personagem CurrentPokemon { get; set; }
        public Item Item { get; set; }
        public string Efeito { get; set; }
        public bool ItemUsado { get; set; }

        public RetornoUsoItem(Personagem currentPokemon, Item item, string efeito, bool itemUsado)
        {
            this.CurrentPokemon = currentPokemon;
            this.Item = item;
            this.Efeito = efeito;
            this.ItemUsado = itemUsado;
        }
    }
}
