using JogoRPG.Jogadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Menus
{
    public class EquipesEJogadores
    {
        static List<Equipe> Equipes = new List<Equipe>();
        static List<Jogador> JogadoresRED = new List<Jogador>();
        static List<Jogador> JogadoresGREEN = new List<Jogador>();

        public void Menu(int qtdPlayers)
        {
            MenuEquipes();
            MenuJogadores(qtdPlayers);

            int coins = 0;
            if (qtdPlayers == 2) coins = 5000;
            else coins = 10000;

            Equipes[0].Jogadores = JogadoresRED;
            Equipes[0].Coins = coins;
            Equipes[1].Jogadores = JogadoresGREEN;
            Equipes[1].Coins = coins;

            PreviewEquipesJogadores();
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
            Equipes.Add(new Equipe(nomeEquipeRED, "RED"));

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
            Equipes.Add(new Equipe(nomeEquipeGREEN, "GREEN"));

        }
    
        static void MenuJogadores(int qtdPlayers)
        {
            Console.Clear();

            string titulo = "DEFINIR NOME DO(S) JOGADOR(ES)";
            string subTitulo = $"EQUIPE: RED - {Equipes[0].Nome}";
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

                JogadoresRED.Add(new Jogador(nomeJogadorRED, Equipes[0].Id));
            }

            //------------------

            Console.Clear();

            subTitulo = $"EQUIPE: GREEN - {Equipes[1].Nome}";

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
                string nomeJogadorRED = Console.ReadLine();
                Console.ResetColor();

                JogadoresGREEN.Add(new Jogador(nomeJogadorRED, Equipes[1].Id));
            }
        }

        static void PreviewEquipesJogadores()
        {
            Console.Clear();

            string titulo = "PREVIEW DAS EQUIPES";
            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int posXtitulo = (larguraConsole - titulo.Length) / 2;
            int posYtitulo = (alturaConsole / 2) - 10;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(posXtitulo, posYtitulo);
            Console.WriteLine(titulo);
            Console.ResetColor();

            int linhaAtual = posYtitulo + 2;

            string equipeRedTitulo = $"Equipe RED - {Equipes[0].Nome}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((larguraConsole - equipeRedTitulo.Length) / 2, linhaAtual++);
            Console.WriteLine(equipeRedTitulo);
            Console.ResetColor();

            string redCoins = $"Coins da Equipe: {Equipes[0].Coins}";
            Console.SetCursorPosition((larguraConsole - redCoins.Length) / 2, linhaAtual++);
            Console.WriteLine(redCoins);

            string redQtd = $"Quantidade de Players: {Equipes[0].Jogadores.Count()}";
            Console.SetCursorPosition((larguraConsole - redQtd.Length) / 2, linhaAtual++);
            Console.WriteLine(redQtd);

            linhaAtual++;

            for (int i = 0; i < Equipes[0].Jogadores.Count(); i++)
            {
                string nomeJogador = $"Jogador {i + 1}: {Equipes[0].Jogadores[i].Nome}";
                Console.SetCursorPosition((larguraConsole - nomeJogador.Length) / 2, linhaAtual++);
                Console.WriteLine(nomeJogador);
            }

            linhaAtual += 2;

            string equipeGreenTitulo = $"Equipe GREEN - {Equipes[1].Nome}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((larguraConsole - equipeGreenTitulo.Length) / 2, linhaAtual++);
            Console.WriteLine(equipeGreenTitulo);
            Console.ResetColor();

            string greenCoins = $"Coins da Equipe: {Equipes[1].Coins}";
            Console.SetCursorPosition((larguraConsole - greenCoins.Length) / 2, linhaAtual++);
            Console.WriteLine(greenCoins);

            string greenQtd = $"Quantidade de Players: {Equipes[1].Jogadores.Count()}";
            Console.SetCursorPosition((larguraConsole - greenQtd.Length) / 2, linhaAtual++);
            Console.WriteLine(greenQtd);

            linhaAtual++;

            for (int i = 0; i < Equipes[1].Jogadores.Count(); i++)
            {
                string nomeJogador = $"Jogador {i + 1}: {Equipes[1].Jogadores[i].Nome}";
                Console.SetCursorPosition((larguraConsole - nomeJogador.Length) / 2, linhaAtual++);
                Console.WriteLine(nomeJogador);
            }

            linhaAtual += 2;
            string msg = "Aperte qualquer tecla para continuar!";
            Console.SetCursorPosition((larguraConsole - msg.Length) / 2, linhaAtual);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(msg);
            Console.ResetColor();

            Console.ReadKey();

        }
    }
}
