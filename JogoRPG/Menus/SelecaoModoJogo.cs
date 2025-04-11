using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class SelecaoModoJogo
    {
        public int Menu()
        {
            string[] opcoes = { "Modo 1v1", "Modo 2v2", "Voltar" };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                string titulo = "SELECIONE O MODO DE JOGO";
                int larguraConsole = Console.WindowWidth;
                int posXtitulo = (larguraConsole - titulo.Length) / 2;
                int alturaConsole = Console.WindowHeight;
                Console.SetCursorPosition(posXtitulo, ((alturaConsole / 2) - 3));
                Console.WriteLine(titulo);

                int posYInicio = alturaConsole / 2 - opcoes.Length;

                for (int i = 0; i < opcoes.Length; i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(textoOpcao);
                    }
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow)
                {
                    indiceSelecionado = (indiceSelecionado - 1 + opcoes.Length) % opcoes.Length;
                }
                else if (tecla == ConsoleKey.DownArrow)
                {
                    indiceSelecionado = (indiceSelecionado + 1) % opcoes.Length;
                }

            } while (tecla != ConsoleKey.Enter);


            if (indiceSelecionado == 0) return 2;
            else if (indiceSelecionado == 1) return 4;
            else return 0;
        }
    }
}
