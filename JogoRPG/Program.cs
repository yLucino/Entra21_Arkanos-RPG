using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Menus;
using JogoRPG.Personagens;

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

            //Fazer o cadastro dos personagens assim que iniciar o jogo
            controller.CadastrarPersonagens();
            controller.CadastrarItens();

            //Chamar o Menu da tela inicial
            telaInicial.Menu(selecaoJogadores);
            
            Console.ReadKey();
        }
    }
}
