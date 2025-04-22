using System;
using System.Text;

namespace JogoRPG
{
    public class Menu_Elementos
    {
        public void Preview()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] elementos = { "Fantasma", "Fogo", "Elétrico", "Planta", "Água" };

            string[,] tabela = {
                { "🟡", "⚪", "🟡", "🟡", "🟡" },
                { "🟡", "⚪", "🟡", "🔴", "🔵" },
                { "🟡", "🟡", "⚪", "🔵", "🔴" },
                { "🟡", "🔵", "🔴", "⚪", "🔴" },
                { "🟡", "🔴", "🔵", "🔵", "⚪" }
            };

            Console.Clear();
            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int totalLinhas = 1                     // Título
                            + 2                     // Cabeçalho + separador
                            + elementos.Length      // Linhas da tabela
                            + 6;                    // Legenda + instrução

            int posYInicial = (alturaConsole - totalLinhas) / 2;

            string titulo = "TABELA DE VANTAGENS ELEMENTAIS";
            int posXtitulo = (larguraConsole - titulo.Length) / 2;
            Console.SetCursorPosition(posXtitulo, posYInicial);
            Console.WriteLine(titulo);

            string cabecalho = "Atacante ↓ / Defensor → |";
            foreach (var elemento in elementos)
                cabecalho += $" {elemento.PadRight(9)} |";

            int posXCabecalho = (larguraConsole - cabecalho.Length) / 2;
            Console.SetCursorPosition(posXCabecalho, posYInicial + 2);
            Console.WriteLine(cabecalho);

            Console.SetCursorPosition(posXCabecalho, posYInicial + 3);
            Console.WriteLine(new string('-', cabecalho.Length));

            for (int i = 0; i < elementos.Length; i++)
            {
                string linha = $"{elementos[i].PadRight(24)}|";
                for (int j = 0; j < elementos.Length; j++)
                    linha += $"     {tabela[i, j]}     |";

                Console.SetCursorPosition(posXCabecalho, posYInicial + 4 + i);
                Console.WriteLine(linha);
            }

            int posYLegenda = posYInicial + 4 + elementos.Length + 1;
            string[] legenda = {
                "Legenda:",
                "🔴 Super eficaz (2x dano)",
                "🔵 Pouco eficaz (0.6x dano)",
                "⚪ Ineficaz (0.3x dano)",
                "🟡 Neutro (1x dano)"
            };

            for (int i = 0; i < legenda.Length; i++)
            {
                int posX = (larguraConsole - legenda[i].Length) / 2;
                Console.SetCursorPosition(posX, posYLegenda + i);
                Console.WriteLine(legenda[i]);
            }

            string textoVoltar = "Pressione ENTER para voltar...";
            int posXVoltar = (larguraConsole - textoVoltar.Length) / 2;
            Console.SetCursorPosition(posXVoltar, posYLegenda + legenda.Length + 1);
            Console.WriteLine(textoVoltar);

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
