using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG.Menus
{
    public class MenuPreview
    {
        public void Menu()
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

            string equipeRedTitulo = $"Equipe RED - {Listas.Instancia.Equipes[0].Nome}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((larguraConsole - equipeRedTitulo.Length) / 2, linhaAtual++);
            Console.WriteLine(equipeRedTitulo);
            Console.ResetColor();

            string redCoins = $"Coins da Equipe: {Listas.Instancia.Equipes[0].Coins}";
            Console.SetCursorPosition((larguraConsole - redCoins.Length) / 2, linhaAtual++);
            Console.WriteLine(redCoins);

            string redQtd = $"Quantidade de Players: {Listas.Instancia.Equipes[0].Jogadores.Count()}";
            Console.SetCursorPosition((larguraConsole - redQtd.Length) / 2, linhaAtual++);
            Console.WriteLine(redQtd);

            linhaAtual++;

            for (int i = 0; i < Listas.Instancia.Equipes[0].Jogadores.Count(); i++)
            {
                string nomeJogador = $"Jogador {i + 1}: {Listas.Instancia.Equipes[0].Jogadores[i].Nome} - Personagem: {Listas.Instancia.Equipes[0].Jogadores[i].Personagem.Classe} {Listas.Instancia.Equipes[0].Jogadores[i].Personagem.Nome}";
                Console.SetCursorPosition((larguraConsole - nomeJogador.Length) / 2, linhaAtual++);
                Console.WriteLine(nomeJogador);
            }

            linhaAtual += 2;

            string equipeGreenTitulo = $"Equipe GREEN - {Listas.Instancia.Equipes[1].Nome}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((larguraConsole - equipeGreenTitulo.Length) / 2, linhaAtual++);
            Console.WriteLine(equipeGreenTitulo);
            Console.ResetColor();

            string greenCoins = $"Coins da Equipe: {Listas.Instancia.Equipes[1].Coins}";
            Console.SetCursorPosition((larguraConsole - greenCoins.Length) / 2, linhaAtual++);
            Console.WriteLine(greenCoins);

            string greenQtd = $"Quantidade de Players: {Listas.Instancia.Equipes[1].Jogadores.Count()}";
            Console.SetCursorPosition((larguraConsole - greenQtd.Length) / 2, linhaAtual++);
            Console.WriteLine(greenQtd);

            linhaAtual++;

            for (int i = 0; i < Listas.Instancia.Equipes[1].Jogadores.Count(); i++)
            {
                string nomeJogador = $"Jogador {i + 1}: {Listas.Instancia.Equipes[1].Jogadores[i].Nome} - Personagem: {Listas.Instancia.Equipes[1].Jogadores[i].Personagem.Classe} {Listas.Instancia.Equipes[1].Jogadores[i].Personagem.Nome}";
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
