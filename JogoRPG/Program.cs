using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Menus;

namespace JogoRPG
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Controller controller = new Controller();
            Menu_TelaInicial telaInicial = new Menu_TelaInicial();
            Menu_ModoJogo selecaoJogadores = new Menu_ModoJogo();

            controller.CadastrarPersonagens();
            controller.CadastrarItens();

            telaInicial.Menu(selecaoJogadores);
        }
    }
}
