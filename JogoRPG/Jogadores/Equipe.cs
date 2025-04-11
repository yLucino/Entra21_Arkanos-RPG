using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Jogadores
{
    public class Equipe
    {
        public string Id { get; set; }
        public string Nome {  get; set; }
        public int Coins { get; set; }
        public List<Jogador> Jogadores { get; set; }

        public Equipe(string nome, string id)
        {
            this.Nome = nome;
            this.Id = id;
            Jogadores = new List<Jogador>();
        }
    }
}
