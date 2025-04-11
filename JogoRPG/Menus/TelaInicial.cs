using JogoRPG.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class TelaInicial
    {
        public void Menu(SelecaoModoJogo selecionar)
        {

            string[] opcoes = { "Jogar", "Sair  " };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                string titulo = "\r\n    / \\     _ __  | | __   __ _   _ __     ___    ___              |  _ \\  |  _ \\   / ___|\r\n   / _ \\   | '__| | |/ /  / _` | | '_ \\   / _ \\  / __|    _____    | |_) | | |_) | | |  _ \r\n  / ___ \\  | |    |   <  | (_| | | | | | | (_) | \\__ \\   |_____|   |  _ <  |  __/  | |_| |\r\n /_/   \\_\\ |_|    |_|\\_\\  \\__,_| |_| |_|  \\___/  |___/             |_| \\_\\ |_|      \\____|";

                string[] linhasTitulo = titulo.Split(new[] { "\r\n" }, StringSplitOptions.None);
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;

                int maiorLinhaTitulo = linhasTitulo.Max(l => l.Length);
                int espacosEsquerdaTitulo = (larguraConsole - maiorLinhaTitulo) / 2;

                int alturaTotal = linhasTitulo.Length + 2 + opcoes.Length;
                int linhaInicial = (alturaConsole - alturaTotal) / 2;

                Console.SetCursorPosition(0, linhaInicial);

                foreach (string linha in linhasTitulo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(espacosEsquerdaTitulo, Console.CursorTop);
                    Console.WriteLine(linha);
                }
                Console.ResetColor();

                string instrucao = "Use as setas ↑ ↓ para navegar e Enter para selecionar:\n\n";
                int espacosEsquerdaInstrucao = (larguraConsole - instrucao.Length) / 2;
                Console.SetCursorPosition(espacosEsquerdaInstrucao, Console.CursorTop + 1);
                Console.WriteLine(instrucao + "\n");

                for (int i = 0; i < opcoes.Length; i++)
                {
                    string linhaBotao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int espacosEsquerdaBotao = (larguraConsole - linhaBotao.Length) / 2;

                    if (i == indiceSelecionado)
                    {
                        Console.SetCursorPosition(espacosEsquerdaBotao, Console.CursorTop);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(linhaBotao);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(espacosEsquerdaBotao, Console.CursorTop);
                        Console.WriteLine(linhaBotao);
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
                else if (tecla == ConsoleKey.Enter)
                {
                    if (indiceSelecionado == 0)
                    {
                        // Obtem o retorno da opção selecionada (Modo de jogo | Qtd de players)
                        int qtdJogadores = selecionar.Menu();
                        
                        if (qtdJogadores != 0)
                        {
                            EquipesEJogadores equipesEJogadores = new EquipesEJogadores();

                            // Chama a função para cadastrar Equipes e Jogadores.
                            equipesEJogadores.Menu(qtdJogadores);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\r\n / ___|    __ _  (_)  _ __     __| |   ___              \r\n \\___ \\   / _` | | | | '_ \\   / _` |  / _ \\             \r\n  ___) | | (_| | | | | | | | | (_| | | (_) |  _   _   _ \r\n |____/   \\__,_| |_| |_| |_|  \\__,_|  \\___/  (_) (_) (_)\n\n\n\n\n\n\n\n\n");
                        Console.ResetColor();

                        break;
                    }
                }

            } while (tecla != ConsoleKey.Escape);
        }
    }
}
