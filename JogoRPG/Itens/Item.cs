using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Item
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int AumentoDano { get; set; }
        public double Proficiencia { get; set; }
        public string Classe { get; set; }
        public double Valor { get; set; }

        public Item(string nome, string descricao, int aumentoDano, double proficiencia, string classe, double valor)
        {
            Nome = nome;
            Descricao = descricao;
            AumentoDano = aumentoDano;
            Proficiencia = proficiencia;
            Classe = classe;
            Valor = valor;
        }
    }
}
