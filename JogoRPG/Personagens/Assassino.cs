using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Assassino : Personagem
    {
        public Assassino(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 80,
            vidaAtual: 80,
            classe: "Assassino",
            inteligencia: 40,
            velocidade: 90,
            forca: 60,
            defesa: 30,
            nomeSkill: "Golpe Sombrio",
            descSkill: "Um ataque crítico vindo das sombras.",
            danoBaseSkill: 70)
        { }
    }
}
