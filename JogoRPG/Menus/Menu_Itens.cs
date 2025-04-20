using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Menu_Itens
    {
        public void Preview()
        {
            int index = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                string titulo = $"PREVIEW ITEM 0{index + 1}";
                string nome = $"Nome: {Listas.Instancia.Itens[index].Nome}";
                string descricao = $"Descrição: {Listas.Instancia.Itens[index].Descricao}";
                string valor = $"Valor: {Listas.Instancia.Itens[index].Valor}";

                List<string> linhas = new List<string>
                {
                    titulo,
                    "",
                    "----- Informações -----",
                    nome,
                    descricao,
                    "",
                    "----- Custo -----",
                    valor
                };

                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;

                int linhaInicial = (alturaConsole / 2) - (linhas.Count / 2 + 3);

                for (int i = 0; i < linhas.Count; i++)
                {
                    string linha = linhas[i];
                    int posX = (larguraConsole - linha.Length) / 2;
                    Console.SetCursorPosition(posX < 0 ? 0 : posX, linhaInicial + i);

                    if (linha == titulo) Console.ForegroundColor = ConsoleColor.Red;
                    else if (linha == "----- Informações -----") Console.ForegroundColor = ConsoleColor.Blue;
                    else if (linha == "----- Custo -----") Console.ForegroundColor = ConsoleColor.DarkYellow;
                    else Console.ResetColor();

                    Console.WriteLine(linha);
                }
                Console.ResetColor();

                string voltarTexto = "Enter para Voltar";
                string setasText = "Use ← → para Navegar";
                int posYVoltar = linhaInicial + linhas.Count + 2;
                int posXVoltar = (larguraConsole - voltarTexto.Length) / 2;
                int posXSetas = (larguraConsole - setasText.Length) / 2;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(posXSetas, posYVoltar);
                Console.WriteLine(setasText);

                Console.SetCursorPosition(posXVoltar, posYVoltar + 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(voltarTexto);

                Console.ResetColor();

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.LeftArrow)
                {
                    index = (index - 1 + Listas.Instancia.Itens.Count) % Listas.Instancia.Itens.Count;
                }
                else if (tecla == ConsoleKey.RightArrow)
                {
                    index = (index + 1) % Listas.Instancia.Itens.Count;
                }

            } while (tecla != ConsoleKey.Enter);

        }
    }
}
