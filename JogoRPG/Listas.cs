using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Jogadores;

namespace JogoRPG
{
    public class Listas
    {
        private static Listas _instancia;
        public static Listas Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Listas();
                return _instancia;
            }
        }

        public List<Personagem> Personagens { get; set; }
        public List<Equipe> Equipes { get; set; }
        public List<Item> Itens { get; set; }

        public Listas()
        {
            Personagens = new List<Personagem>();
            Equipes = new List<Equipe>();
            Itens = new List<Item>();
        }
    }
}
