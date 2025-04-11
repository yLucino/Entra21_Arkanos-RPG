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
        static List<Personagem> lista_personagens = new List<Personagem>();
        
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            TelaInicial telaInicial = new TelaInicial();
            SelecaoModoJogo selecaopersonagem = new SelecaoModoJogo();
            SelecaoModoJogo selecaoJogadores = new SelecaoModoJogo();

            //Fazer o cadastro dos personagens assim que iniciar o jogo
            controller.CadastrarPersonagens(lista_personagens);

            //Chamar o Menu da tela inicial
            telaInicial.Menu(selecaoJogadores);

            Console.ReadKey();
        }
    }
}
