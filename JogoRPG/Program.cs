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
            Listas listas = new Listas();
            Controller controller = new Controller();
            TelaInicial telaInicial = new TelaInicial();
            SelecaoModoJogo selecaopersonagem = new SelecaoModoJogo();
            SelecaoModoJogo selecaoJogadores = new SelecaoModoJogo();

            //Fazer o cadastro dos personagens assim que iniciar o jogo
            controller.CadastrarPersonagens();

            //Chamar o Menu da tela inicial
            telaInicial.Menu(selecaoJogadores);
            
            Console.ReadKey();
        }
    }
}
