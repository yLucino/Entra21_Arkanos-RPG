using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Jogadores;

namespace JogoRPG
{
    public class SelecaoPersonagem
    {
        public void Menu(int qtdPlayers)
        {
            List<string> opcoes = new List<string>();

            foreach (var personagem in Listas.Instancia.Personagens)
            {
                Console.WriteLine(personagem.Nome);
                opcoes.Add($"{personagem.Classe} - {personagem.Nome}");
            }

            int indiceSelecionado = 0;
            ConsoleKey tecla;

            
            for (int j = 0; j < qtdPlayers / 2; j++)
            {
                do
                {
                    Console.Clear();

                    string titulo = "  SELECIONE O PERSONAGEM";
                    string subTitulo = $"  EQUIPE: {Listas.Instancia.Equipes[0].Id} {Listas.Instancia.Equipes[0].Nome} | JOGADOR: {Listas.Instancia.Equipes[0].Jogadores[j].Nome}";

                    int larguraConsole = Console.WindowWidth;
                    int posXtitulo = (larguraConsole - titulo.Length) / 2;
                    int alturaConsole = Console.WindowHeight;
                    Console.SetCursorPosition(posXtitulo, ((alturaConsole / 2) - 5));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(titulo);
                    
                    int posXSubTitulo = (larguraConsole - subTitulo.Length) / 2;
                    Console.SetCursorPosition(posXSubTitulo, ((alturaConsole / 2) - 4));

                    if (Listas.Instancia.Equipes[0].Id == "RED") Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(subTitulo);
                    Console.ResetColor();

                    int posYInicio = alturaConsole / 2 - opcoes.Count();

                    for (int i = 0; i < opcoes.Count(); i++)
                    {
                        string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                        int posX = (larguraConsole - textoOpcao.Length) / 2;
                        int posY = posYInicio + i + 4;

                        Console.SetCursorPosition(posX, posY);

                        if (i == indiceSelecionado)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
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
                        indiceSelecionado = (indiceSelecionado - 1 + opcoes.Count()) % opcoes.Count();
                    }
                    else if (tecla == ConsoleKey.DownArrow)
                    {
                        indiceSelecionado = (indiceSelecionado + 1) % opcoes.Count();
                    }

                } while (tecla != ConsoleKey.Enter);

                string nomePersonagemSelecionado = opcoes[indiceSelecionado].Split('-')[1].Trim();
                Personagem personagemEscolhido = Listas.Instancia.Personagens.Find(p => p.Nome == nomePersonagemSelecionado);

                Listas.Instancia.Equipes[0].Jogadores[j].Personagem = personagemEscolhido;
            }
            
            for (int j = 0; j < qtdPlayers / 2; j++)
            {
                do
                {
                    Console.Clear();

                    string titulo = "  SELECIONE O PERSONAGEM";
                    string subTitulo = $"  EQUIPE: {Listas.Instancia.Equipes[1].Id} {Listas.Instancia.Equipes[1].Nome} | JOGADOR: {Listas.Instancia.Equipes[1].Jogadores[j].Nome}";

                    int larguraConsole = Console.WindowWidth;
                    int posXtitulo = (larguraConsole - titulo.Length) / 2;
                    int alturaConsole = Console.WindowHeight;
                    Console.SetCursorPosition(posXtitulo, ((alturaConsole / 2) - 5));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(titulo);
                    
                    int posXSubTitulo = (larguraConsole - subTitulo.Length) / 2;
                    Console.SetCursorPosition(posXSubTitulo, ((alturaConsole / 2) - 4));

                    if (Listas.Instancia.Equipes[1].Id == "RED") Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(subTitulo);
                    Console.ResetColor();

                    int posYInicio = alturaConsole / 2 - opcoes.Count();

                    for (int i = 0; i < opcoes.Count(); i++)
                    {
                        string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                        int posX = (larguraConsole - textoOpcao.Length) / 2;
                        int posY = posYInicio + i + 4;

                        Console.SetCursorPosition(posX, posY);

                        if (i == indiceSelecionado)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
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
                        indiceSelecionado = (indiceSelecionado - 1 + opcoes.Count()) % opcoes.Count();
                    }
                    else if (tecla == ConsoleKey.DownArrow)
                    {
                        indiceSelecionado = (indiceSelecionado + 1) % opcoes.Count();
                    }

                } while (tecla != ConsoleKey.Enter);

                string nomePersonagemSelecionado = opcoes[indiceSelecionado].Split('-')[1].Trim();
                Personagem personagemEscolhido = Listas.Instancia.Personagens.Find(p => p.Nome == nomePersonagemSelecionado);

                Listas.Instancia.Equipes[1].Jogadores[j].Personagem = personagemEscolhido;
            }
        }
    }
}
