using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Mago : Personagem
    {
        public Mago(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 90,
            vidaAtual: 90,
            classe: "Mago",
            inteligencia: 95,
            velocidade: 40,
            forca: 25,
            defesa: 30,
            nomeSkill: "Bola de Fogo",
            descSkill: "Lança uma bola de fogo mágica.",
            danoBaseSkill: 80)
        { }
    }
}
