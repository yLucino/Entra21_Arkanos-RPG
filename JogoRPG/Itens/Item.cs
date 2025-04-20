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
        public int Valor { get; set; }

        public Item(string nome, string descricao, int valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
