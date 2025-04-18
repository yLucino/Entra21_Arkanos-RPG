using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Jogadores
{
    public class Jogador
    {
        public string Nome { get; set; }
        public string IdEquipe { get; set; }
        public Personagem Personagem { get; set; }


        public Jogador(string nome, string idEquipe)
        {
            this.Nome = nome;
            this.IdEquipe = idEquipe;
            Personagem = null;
        }
    }
}
