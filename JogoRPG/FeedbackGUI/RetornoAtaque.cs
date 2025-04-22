using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.FeedbackGUI
{
    public class RetornoAtaque
    {
        public Personagem PokemonInimigo { get; set; }
        public Personagem CurrentPokemon { get; set; }
        public string NomeAtaque { get; set; }
        public int Dano { get; set; }
        public string Status { get; set; }

        public RetornoAtaque(Personagem currentPokemon, Personagem pokemonInimigo, string nomeAtaque, int dano, string status)
        {
            this.CurrentPokemon = currentPokemon;
            this.PokemonInimigo = pokemonInimigo;
            this.NomeAtaque = nomeAtaque;
            this.Dano = dano;
            this.Status = status;
        }
    }
}
