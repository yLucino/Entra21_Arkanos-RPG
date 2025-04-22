using JogoRPG.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Menu_TelaInicial
    {
        public void Menu(Menu_ModoJogo selecionar)
        {

            string[] opcoes = { "Jogar", "Ver Itens", "Ver Pokémons", "Ver Elementos", "Sair " };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                string titulo = "8888888b.   .d88888b.  888    d8P  8888888888 888b     d888  .d88888b.  888b    888 \r\n888   Y88b d88P\" \"Y88b 888   d8P   888        8888b   d8888 d88P\" \"Y88b 8888b   888 \r\n888    888 888     888 888  d8P    888        88888b.d88888 888     888 88888b  888 \r\n888   d88P 888     888 888d88K     8888888    888Y88888P888 888     888 888Y88b 888 \r\n8888888P\"  888     888 8888888b    888        888 Y888P 888 888     888 888 Y88b888 \r\n888        888     888 888  Y88b   888        888  Y8P  888 888     888 888  Y88888 \r\n888        Y88b. .d88P 888   Y88b  888        888   \"   888 Y88b. .d88P 888   Y8888 \r\n888         \"Y88888P\"  888    Y88b 8888888888 888       888  \"Y88888P\"  888    Y888 \r\n                                                                                    \r\n                                                                                    \r\n                                                                                    ";

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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(espacosEsquerdaTitulo, Console.CursorTop);
                    Console.WriteLine(linha);
                }
                Console.ResetColor();

                string instrucao = "Use as setas ↑ ↓ para navegar e Enter para selecionar:\n\n";
                int espacosEsquerdaInstrucao = (larguraConsole - instrucao.Length) / 2;
                Console.SetCursorPosition(espacosEsquerdaInstrucao, Console.CursorTop + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(instrucao + "\n");
                Console.ResetColor();

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
                        int qtdJogadores = selecionar.Menu();
                        
                        if (qtdJogadores != 0)
                        {
                            Menu_EquipesEJogadores equipesEJogadores = new Menu_EquipesEJogadores();
                            equipesEJogadores.Menu(qtdJogadores);
                        }
                    }
                    else if (indiceSelecionado == 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\r\n / ___|    __ _  (_)  _ __     __| |   ___              \r\n \\___ \\   / _` | | | | '_ \\   / _` |  / _ \\             \r\n  ___) | | (_| | | | | | | | | (_| | | (_) |  _   _   _ \r\n |____/   \\__,_| |_| |_| |_|  \\__,_|  \\___/  (_) (_) (_)\n\n\n\n\n\n\n\n\n");
                        Console.ResetColor();

                        break;
                    } 
                    else if (indiceSelecionado == 3)
                    {
                        Menu_Elementos elementos = new Menu_Elementos();
                        elementos.Preview();
                    }
                    else if (indiceSelecionado == 2)
                    {
                        Menu_Personagens personagens = new Menu_Personagens();
                        personagens.Preview();
                    }
                    else if (indiceSelecionado == 1)
                    {
                        Menu_Itens itens = new Menu_Itens();
                        itens.Preview();
                    }
                }

            } while (tecla != ConsoleKey.Escape);
        }
    }
}
