using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Personagens
{
    internal class Tank : Personagem
    {
        public Tank(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 200,
            vidaAtual: 200,
            classe: "Tank",
            inteligencia: 20,
            velocidade: 30,
            forca: 50,
            defesa: 100,
            nomeSkill: "Provocação",
            descSkill: "Força os inimigos a atacá-lo, reduzindo o dano recebido.",
            danoBaseSkill: 30)
        { }
    }
}
