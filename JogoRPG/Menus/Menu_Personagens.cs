using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Jogadores;

namespace JogoRPG
{
    public class Menu_Personagens
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

        public void Preview()
        {
            int index = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                string titulo = $"PREVIEW PERSONAGEM 0{index + 1}";
                
                string foto = Listas.Instancia.Personagens[index].FotoComplexa;
                string nome = $"Nome: {Listas.Instancia.Personagens[index].Nome}";
                string classe = $"Classe: {Listas.Instancia.Personagens[index].Classe}";
                string descricao = $"Descrição: {Listas.Instancia.Personagens[index].Descricao}";

                string pontosVid = $"Pontos de Vida: {Listas.Instancia.Personagens[index].VidaMaxima}";
                string pontosInt = $"Pontos de Inteligência: {Listas.Instancia.Personagens[index].Inteligencia}";
                string pontosVel = $"Pontos de Velocidade: {Listas.Instancia.Personagens[index].Velocidade}";
                string pontosFor = $"Pontos de Força: {Listas.Instancia.Personagens[index].Forca}";
                string pontosDef = $"Pontos de Defesa: {Listas.Instancia.Personagens[index].Defesa}";

                string nomeSkill = $"Nome da Skill: {Listas.Instancia.Personagens[index].NomeSkill}";
                string descSkill = $"Descrição da Skill: {Listas.Instancia.Personagens[index].DescricaoSkill}";
                string danoSkill = $"Dano da Skill: {Listas.Instancia.Personagens[index].DanoDaseSkill}";

                List<string> linhas = new List<string>
                {
                    titulo,
                    "",
                    foto,
                    "",
                    "----- Informações -----",
                    nome,
                    classe,
                    descricao,
                    "",
                    "------ Atributos ------",
                    pontosVid,
                    pontosInt,
                    pontosVel,
                    pontosFor,
                    pontosDef,
                    "",
                    "----- Habilidades -----",
                    nomeSkill,
                    descSkill,
                    danoSkill
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
                    else if (linha == "------ Atributos ------") Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (linha == "----- Habilidades -----") Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                    index = (index - 1 + Listas.Instancia.Personagens.Count) % Listas.Instancia.Personagens.Count;
                }
                else if (tecla == ConsoleKey.RightArrow)
                {
                    index = (index + 1) % Listas.Instancia.Personagens.Count;
                }

            } while (tecla != ConsoleKey.Enter);

        }
    }
}
