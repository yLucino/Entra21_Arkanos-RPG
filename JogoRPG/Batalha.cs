using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Batalha
    {
        // Batalha 1v1 ou 2v2 em turnos
        // 1º e 5º turno para compra de itens
        // restante dos turno destinado para mecanicas de: Combate e Defesa com uso das Skills
        public void Start(int qtdPlayers)
        {
            // A batalha é um loop entre turno de Combate e turno de Compra(1º e 5º)
            int turno = 0;
            int vezEquipe = 0;

            CutsceneVS(Listas.Instancia.Equipes[0].Nome, Listas.Instancia.Equipes[1].Nome);

            Partida();
        }

        static void CutsceneVS(string nomeEquipeRed, string nomeEquipeGreen)
        {
            Console.Clear();

            string linha1 = $"EQUIPE RED: {nomeEquipeRed.ToUpper()}";
            string linha2 = "       VS       ";
            string linha3 = $"EQUIPE GREEN: {nomeEquipeGreen.ToUpper()}";
            string linha4 = "";
            string linha5 = "";
            string linha6 = "";
            string linha7 = $"Carregando .........";

            string[] linhas = { linha1, linha2, linha3, linha4, linha5, linha6, linha7 };

            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int linhaInicial = alturaConsole / 2 - (linhas.Length / 2);

            for (int i = 0; i < linhas.Length; i++)
            {
                string linha = linhas[i];
                int posX = (larguraConsole - linha.Length) / 2;
                int posY = linhaInicial + i;

                Console.SetCursorPosition(posX < 0 ? 0 : posX, posY);

                if (linha.Contains("RED")) Console.ForegroundColor = ConsoleColor.Red;
                else if (linha.Contains("GREEN")) Console.ForegroundColor = ConsoleColor.Green;
                else if (linha.Contains("Carregando")) Console.ForegroundColor = ConsoleColor.DarkGray;
                else Console.ForegroundColor = ConsoleColor.White;

                foreach (char c in linha)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            Thread.Sleep(3000);
        }

        static void Partida()
        {

        }

        static void MenuBatalha()
        {

        }

        static void TurnoCompra()
        {

        }

        static void TurnoCombate()
        {

        }

        static void FimPartida()
        {

        }
    
    }
}
