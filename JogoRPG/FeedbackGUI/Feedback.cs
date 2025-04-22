using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Feedback
    {
        static string bordaCima = "================== RESUMO AÇÕES ==================";
        static int larguraConsole = Console.WindowWidth;
        static int alturaConsole = Console.WindowHeight;
        static int larguraBox = bordaCima.Length;
        static int alturaBox = 5;
        static int posX = 2;
        static int posY = alturaConsole - alturaBox - 2;
        static string bordaBaixo = new string('=', larguraBox);
        static string mensagemEmpyt = "                                                ";
        
        public void ExibirCaixaDeFeedback()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(bordaCima.PadRight(larguraBox));

            Console.SetCursorPosition(posX, posY + 1);
            Console.WriteLine("|" + new string(' ', larguraBox - 2) + "|");

            string textoCentralizado = mensagemEmpyt.PadRight((larguraBox - 2 + mensagemEmpyt.Length) / 2).PadLeft(larguraBox - 2);
            Console.SetCursorPosition(posX, posY + 2);
            Console.WriteLine("|" + textoCentralizado + "|");

            Console.SetCursorPosition(posX, posY + 3);
            Console.WriteLine("|" + new string(' ', larguraBox - 2) + "|");

            Console.SetCursorPosition(posX, posY + 4);
            Console.WriteLine(bordaBaixo);

            Console.ResetColor();
        }

        public void ResumoDeAcaoBatalha(string mensagem)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(posX, posY - 1);
            Console.WriteLine(bordaCima.PadRight(larguraBox));

            int larguraTexto = larguraBox - 2;

            if (mensagem.Length < mensagemEmpyt.Length)
            {
                mensagem = mensagem.PadRight(mensagemEmpyt.Length);
            }

            List<string> linhas = new List<string>();
            for (int i = 0; i < mensagem.Length; i += larguraTexto)
            {
                string linha = mensagem.Substring(i, Math.Min(larguraTexto, mensagem.Length - i));
                linhas.Add(linha);
            }

            while (linhas.Count < 3) linhas.Add("");

            for (int i = 0; i < 3; i++)
            {
                string linhaTexto = linhas[i];
                string linhaCentralizada = linhaTexto.PadRight((larguraTexto + linhaTexto.Length) / 2).PadLeft(larguraTexto);
                Console.SetCursorPosition(posX, posY + i);
                Console.WriteLine("|" + linhaCentralizada + "|");
            }

            Console.SetCursorPosition(posX, posY + 3);
            Console.WriteLine(bordaBaixo);

            Console.ResetColor();
        }
    }
}
