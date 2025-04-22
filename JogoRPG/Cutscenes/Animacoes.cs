using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Animacoes
    {
        public void CutsceneVS(string nomeEquipeRed, string nomeEquipeGreen)
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

        public void CutsceneComecoTurno(int turno)
        {
            string texto = (turno == 1 || turno == 5)
                ? $"TURNO 0{turno} - Fase de Compra"
                : $"TURNO 0{turno} - Fase de Combate";

            int larguraConsole = Console.WindowWidth;
            int posX = (larguraConsole - texto.Length) / 2;
            int posY = Console.WindowHeight / 2;

            Console.Clear();
            Console.SetCursorPosition(posX, posY);

            foreach (char letra in texto)
            {
                Console.Write(letra);
                Thread.Sleep(80);
            }

            Thread.Sleep(1500);

            if (turno == 1 || turno == 5)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string obs = "* Cada equipe pode comprar apenas um EQUIPAMENTO por fase de Compra *";
                Console.SetCursorPosition((larguraConsole - obs.Length) / 2, posY);
                Console.WriteLine(obs);
                Thread.Sleep(1500);
            }
        }
    
        public void CutsceneFimTurno(int turno)
        {
            Console.Clear();

            string text = $"TURNO 0{turno} FINALIZADO";
            string subText = $"Aperte para passar para o turno 0{turno + 1}";

            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int posXText = (larguraConsole - text.Length) / 2;
            int posXsubText = (larguraConsole - subText.Length) / 2;
            Console.SetCursorPosition(posXText, (alturaConsole / 2) - 1);
            
            foreach (char letra in text)
            {
                Console.Write(letra);
                Thread.Sleep(80);
            }

            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(posXsubText, alturaConsole / 2);
            Console.WriteLine(subText);
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
