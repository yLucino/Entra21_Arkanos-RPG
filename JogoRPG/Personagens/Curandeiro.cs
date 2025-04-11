using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Curandeiro : Personagem
    {
        public Curandeiro(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 100,
            vidaAtual: 100,
            classe: "Curandeiro",
            inteligencia: 90,
            velocidade: 40,
            forca: 20,
            defesa: 50,
            nomeSkill: "Benção Vital",
            descSkill: "Cura um aliado com energia divina.",
            danoBaseSkill: -50) // negativo pois é cura
        { }
    }
}
