using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Personagem
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VidaMaxima { get; set; }
        public int VidaAtual { get; set; }
        public string Classe { get; set; }


        public int Inteligencia { get; set; }
        public int Velocidade { get; set; }
        public int Forca { get; set; }
        public int Desefa { get; set; }


        public string NomeSkill { get; set; }
        public string DescricaoSkill { get; set; }
        public int DanoDaseSkill { get; set; }



        public Personagem(string nome, string descricao, int vidaMax, int vidaAtual, string classe, int inteligencia, int velocidade, int forca, int defesa, string nomeSkill, string descSkill, int danoBaseSkill)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.VidaMaxima = vidaMax;
            this.VidaAtual = vidaAtual;
            this.Classe = classe;
            this.Inteligencia = inteligencia;
            this.Velocidade = velocidade;
            this.Forca = forca;
            this.Desefa = defesa;
            this.NomeSkill = nomeSkill;
            this.DescricaoSkill = descSkill;
            this.DanoDaseSkill = danoBaseSkill;
        }
    }
}
