using JogoRPG.Jogadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Menus
{
    public class Menu_EquipesEJogadores
    {
        public void Menu(int qtdPlayers)
        {
            MenuEquipes();
            MenuJogadores(qtdPlayers);

            int coins = 0;
            if (qtdPlayers == 2) coins = 5000;
            else coins = 10000;

            Listas.Instancia.Equipes[0].Coins = coins;
            Listas.Instancia.Equipes[1].Coins = coins;

            Menu_Personagens selecaoPersonage = new Menu_Personagens();
            Menu_Preview preview = new Menu_Preview();

            selecaoPersonage.Menu(qtdPlayers);

            preview.Menu();
        }

        static void MenuEquipes()
        {
            Console.Clear();
            string titulo = "DEFINIR NOME DAS EQUIPES";
            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int posXtitulo = (larguraConsole - titulo.Length) / 2;
            int posYtitulo = (alturaConsole / 2) - 3;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(posXtitulo, posYtitulo);
            Console.WriteLine(titulo);
            Console.ResetColor();

            string pergunta1 = "Digite o nome da Equipe RED:";
            int posXpergunta1 = (larguraConsole - pergunta1.Length) / 2;
            int posYpergunta1 = posYtitulo + 4;

            Console.SetCursorPosition(posXpergunta1, posYpergunta1);
            Console.WriteLine(pergunta1);

            int posXinput1 = (larguraConsole / 2) - 9;
            int posYinput1 = posYpergunta1 + 1;

            Console.SetCursorPosition(posXinput1, posYinput1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-> ");
            string nomeEquipeRED = Console.ReadLine();
            Console.ResetColor();
            Listas.Instancia.Equipes.Add(new Equipe(nomeEquipeRED, "RED"));

            // ----------

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(posXtitulo, posYtitulo);
            Console.WriteLine(titulo);
            Console.ResetColor();

            string pergunta2 = "Digite o nome da Equipe GREEN:";
            int posXpergunta2 = (larguraConsole - pergunta2.Length) / 2;
            int posYpergunta2 = posYtitulo + 4;

            Console.SetCursorPosition(posXpergunta2, posYpergunta2);
            Console.WriteLine(pergunta2);

            int posXinput2 = (larguraConsole / 2) - 9;
            int posYinput2 = posYpergunta2 + 1;

            Console.SetCursorPosition(posXinput2, posYinput2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("-> ");
            string nomeEquipeGREEN = Console.ReadLine();
            Console.ResetColor();
            Listas.Instancia.Equipes.Add(new Equipe(nomeEquipeGREEN, "GREEN"));

        }
    
        static void MenuJogadores(int qtdPlayers)
        {
            Console.Clear();

            string titulo = "DEFINIR NOME DO(S) JOGADOR(ES)";
            string subTitulo = $"EQUIPE: RED - {Listas.Instancia.Equipes[0].Nome}";
            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int posXtitulo = (larguraConsole - titulo.Length) / 2;
            int posYtitulo = (alturaConsole / 2) - 3;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(posXtitulo, posYtitulo);
            Console.WriteLine(titulo);
            Console.SetCursorPosition(posXtitulo + 5, posYtitulo + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(subTitulo);
            Console.ResetColor();

            for (int i = 0; i < (qtdPlayers / 2); i++)
            {
                string pergunta1 = $"Digite o nome do jogador {i + 1}";
                int posXpergunta1 = (larguraConsole - pergunta1.Length) / 2;
                int posYpergunta1 = posYtitulo + 4 + (i * 3);

                Console.SetCursorPosition(posXpergunta1, posYpergunta1);
                Console.WriteLine(pergunta1);

                int posXinput1 = (larguraConsole / 2) - 9;
                int posYinput1 = posYpergunta1 + 1;

                Console.SetCursorPosition(posXinput1, posYinput1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-> ");
                string nomeJogadorRED = Console.ReadLine();
                Console.ResetColor();

                Listas.Instancia.Equipes[0].Jogadores.Add(new Jogador(nomeJogadorRED, Listas.Instancia.Equipes[0].Id));
            }

            //------------------
            Console.Clear();

            subTitulo = $"EQUIPE: GREEN - {Listas.Instancia.Equipes[1].Nome}";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(posXtitulo, posYtitulo);
            Console.WriteLine(titulo);
            Console.SetCursorPosition(posXtitulo + 5, posYtitulo + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(subTitulo);
            Console.ResetColor();

            for (int i = 0; i < (qtdPlayers / 2); i++)
            {
                string pergunta1 = $"Digite o nome do jogador {i + 1}";
                int posXpergunta1 = (larguraConsole - pergunta1.Length) / 2;
                int posYpergunta1 = posYtitulo + 4 + (i * 3);

                Console.SetCursorPosition(posXpergunta1, posYpergunta1);
                Console.WriteLine(pergunta1);

                int posXinput1 = (larguraConsole / 2) - 9;
                int posYinput1 = posYpergunta1 + 1;

                Console.SetCursorPosition(posXinput1, posYinput1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("-> ");
                string nomeJogadorGREEN = Console.ReadLine();   
                Console.ResetColor();

                Listas.Instancia.Equipes[1].Jogadores.Add(new Jogador(nomeJogadorGREEN, Listas.Instancia.Equipes[1].Id));
            }
        }
    }
}
