using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Guerreiro : Personagem
    {
        public Guerreiro(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 150,
            vidaAtual: 150,
            classe: "Guerreiro",
            inteligencia: 30,
            velocidade: 50,
            forca: 80,
            defesa: 60,
            nomeSkill: "Golpe Devastador",
            descSkill: "Um golpe poderoso com a espada.",
            danoBaseSkill: 65)
        { }
    }
}
