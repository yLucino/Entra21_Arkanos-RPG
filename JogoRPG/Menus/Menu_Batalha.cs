using JogoRPG.FeedbackGUI;
using JogoRPG.Jogadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Menu_Batalha
    {
        static Regras regras = new Regras();
        static Feedback feedback = new Feedback();

        public void Menu(int qtdPlayers)
        {
            string[] opcoes = { " Atacar", "Itens: 0", " PASSAR VEZ" };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            List<(int equipe, int jogador)> ordemTurnos = new List<(int equipe, int jogador)>();

            if (qtdPlayers == 4) ordemTurnos = new List<(int equipe, int jogador)> { (0, 0), (0, 1), (1, 0), (1, 1) };
            else if (qtdPlayers == 2) ordemTurnos = new List<(int equipe, int jogador)> { (0, 0), (1, 0) };

            int turnoAtual = 0;

            regras.GerenciadorStatusPokemon();

            do
            {
                Console.Clear();

                // ==== EXIBIÇÃO ====
                ExibirNomeEquipe(0);
                ExibirPersonagens(0);
                feedback.ExibirCaixaDeFeedback();

                Console.SetCursorPosition(0, Console.WindowHeight / 2);
                Console.WriteLine(new string('-', Console.WindowWidth));

                ExibirNomeEquipe(1);
                ExibirPersonagens(1);

                // ==== MENU OPÇÕES ====
                var (currentEquip, currentPlayer) = ordemTurnos[turnoAtual];
                opcoes[1] = $"Itens: {Listas.Instancia.Equipes[currentEquip].Itens.Count()}";

                string titulo = $" Vez de: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Nome} | {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome}";

                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;
                int posYInicio = alturaConsole - opcoes.Length - 2;

                Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio + 1);

                if (Listas.Instancia.Equipes[currentEquip].Id == "RED") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(titulo);
                Console.ResetColor();

                for (int i = 0; i < opcoes.Length; i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (opcoes[i] == " PASSAR VEZ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else if (i == 1 && Listas.Instancia.Equipes[currentEquip].Itens.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
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
                else if (tecla == ConsoleKey.Enter)
                {
                    if (indiceSelecionado == 2)
                    {
                        feedback.ResumoDeAcaoBatalha($"{Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome} passou sua vez.");
                        turnoAtual++;
                    }
                    else if (indiceSelecionado == 0)
                    {
                        if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaAtual >= 1)
                        {
                            RetornoAtaque retorno = MenuAtaque(currentEquip, currentPlayer);
                            feedback.ResumoDeAcaoBatalha($"{retorno.CurrentPokemon.Nome} atacou o(a) {retorno.PokemonInimigo.Nome} com {retorno.NomeAtaque}. {retorno.Status} e causou {retorno.Dano} de dano a(o) {retorno.PokemonInimigo.Nome}{(retorno.Status == "Ataque falhou" ? $", por que está {retorno.CurrentPokemon.Status}." : ".")}");
                        }

                        turnoAtual++;
                    }
                    else if (indiceSelecionado == 1 && Listas.Instancia.Equipes[currentEquip].Itens.Count() > 0)
                    {
                        RetornoUsoItem retorno = MenuItem(currentEquip, currentPlayer);
                        feedback.ResumoDeAcaoBatalha($"{retorno.CurrentPokemon.Nome} {(retorno.ItemUsado ? "usou" : "tentou usar")} o item {retorno.Item.Nome}. {(retorno.ItemUsado ? "E" : "Mas")} {retorno.Efeito}");
                        turnoAtual++;
                    }

                    Console.ReadKey();
                }

            } while (turnoAtual < ordemTurnos.Count);
        }

        static string BarraHP(int atual, int max)
        {
            int totalBlocos = 20;
            int blocosCheios = (int)((double)atual / max * totalBlocos);
            return new string('■', blocosCheios) + new string(' ', totalBlocos - blocosCheios);
        }

        static void ExibirNomeEquipe(int index)
        {
            string textEquip = $"--- EQUIPE {Listas.Instancia.Equipes[index].Id} - {Listas.Instancia.Equipes[index].Nome} ---";

            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int posXtextEquip = (larguraConsole - textEquip.Length) / 2;

            if (index == 0) Console.SetCursorPosition(posXtextEquip, 1);
            else if (index == 1) Console.SetCursorPosition(posXtextEquip, (alturaConsole / 2) + 2);

            if (Listas.Instancia.Equipes[index].Id == "RED") Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(textEquip);
            Console.ResetColor();
        }

        static void ExibirPersonagens(int index)
        {
            int posX = index == 0 ? 4 : Console.WindowWidth - 40;
            int posY = index == 0 ? 3 : Console.WindowHeight - (Listas.Instancia.Equipes[index].Jogadores.Count * 8) - 3;

            foreach (var jogador in Listas.Instancia.Equipes[index].Jogadores)
            {
                Console.SetCursorPosition(posX, posY);
                
                if (jogador.Personagem.Classe == "Elétrico ⚡") Console.ForegroundColor = ConsoleColor.Yellow;
                else if (jogador.Personagem.Classe == "Água 💧") Console.ForegroundColor = ConsoleColor.Cyan;
                else if (jogador.Personagem.Classe == "Fantasma \U0001f7e3") Console.ForegroundColor = ConsoleColor.DarkMagenta;
                else if (jogador.Personagem.Classe == "Fogo 🔥") Console.ForegroundColor = ConsoleColor.Red;
                else if (jogador.Personagem.Classe == "Planta 🍃") Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine($"{jogador.Personagem.Nome} - {jogador.Personagem.Classe} - {jogador.Personagem.Status}");

                double porcentagem = (double)jogador.Personagem.VidaAtual / jogador.Personagem.VidaMaxima;
                Console.ForegroundColor =
                    porcentagem >= 0.7 ? ConsoleColor.Green :
                    porcentagem >= 0.3 ? ConsoleColor.DarkYellow :
                    ConsoleColor.Red;

                Console.SetCursorPosition(posX, ++posY);
                Console.WriteLine($"HP: [{BarraHP(jogador.Personagem.VidaAtual, jogador.Personagem.VidaMaxima)}] {jogador.Personagem.VidaAtual}/{jogador.Personagem.VidaMaxima}");

                Console.ResetColor();
                string[] linhasFoto = jogador.Personagem.FotoSimples.Split('\n');

                if (jogador.Personagem.Classe == "Elétrico ⚡") Console.ForegroundColor = ConsoleColor.Yellow;
                else if (jogador.Personagem.Classe == "Água 💧") Console.ForegroundColor = ConsoleColor.Cyan;
                else if (jogador.Personagem.Classe == "Fantasma \U0001f7e3") Console.ForegroundColor = ConsoleColor.DarkMagenta;
                else if (jogador.Personagem.Classe == "Fogo 🔥") Console.ForegroundColor = ConsoleColor.Red;
                else if (jogador.Personagem.Classe == "Planta 🍃") Console.ForegroundColor = ConsoleColor.DarkGreen;

                foreach (string linha in linhasFoto)
                {
                    Console.SetCursorPosition(posX, ++posY);
                    Console.WriteLine(linha);
                }

                posY += 1;
            }

            Console.ResetColor();
        }

        static RetornoAtaque MenuAtaque(int currentEquip, int currentPlayer)
        {
            string[] opcoes = { $"Ataque Básico | DANO: ⚪ {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Forca} | PP: ∞",
                                $"{Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.NomeSkill} | DANO: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Classe.Split(' ')[1]} {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.DanoDaseSkill} | PP: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill}/{Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.MaxPPSkill}"};
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            bool loop = true;

            do
            {
                string titulo = $"SELECIONE O ATAQUE DO(A) {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome}";
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;
                int posYInicio = alturaConsole - opcoes.Length - 3;

                Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio + 1);
                Console.WriteLine(titulo);

                for (int i = 0; i < opcoes.Length; i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (i == 1  && Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(textoOpcao);
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow)
                {
                    indiceSelecionado = (indiceSelecionado - 1 + opcoes.Length) % opcoes.Length;
                }
                else if (tecla == ConsoleKey.DownArrow)
                {
                    indiceSelecionado = (indiceSelecionado + 1) % opcoes.Length;
                } else if (tecla == ConsoleKey.Enter)
                {
                    if (indiceSelecionado == 1 && Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill > 0) loop = false;
                    else if (indiceSelecionado == 0) loop = false;
                }

            } while (loop);

            int indexEnemyEquip = 0;

            if (currentEquip == 0) indexEnemyEquip = 1;
            else if (currentEquip == 1) indexEnemyEquip = 0;
            
            int indexEnemyPlayer = SelecionarInimigo(indexEnemyEquip);

            if (indiceSelecionado == 0)
            {
                (int totalDano, string status) = regras.Ataque(currentEquip, currentPlayer, indexEnemyEquip, indexEnemyPlayer, "Basic");
                return new RetornoAtaque(Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem, Listas.Instancia.Equipes[indexEnemyEquip].Jogadores[indexEnemyPlayer].Personagem, "Ataque Básico", totalDano, status);
            }
            else
            {
                (int totalDano, string status) = regras.Ataque(currentEquip, currentPlayer, indexEnemyEquip, indexEnemyPlayer, "Skill");
                return new RetornoAtaque(Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem, Listas.Instancia.Equipes[indexEnemyEquip].Jogadores[indexEnemyPlayer].Personagem, Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.NomeSkill, totalDano, status);
            }

        }

        static RetornoUsoItem MenuItem(int currentEquip, int currentPlayer)
        {
            List<string> opcoes = new List<string>();
            foreach (var item in Listas.Instancia.Equipes[currentEquip].Itens)
            {
                opcoes.Add($"{item.Nome}   ");
            }

            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                string titulo = "SELECIONE UM ITEM PARA USAR";
                string background = "                                                ";
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;

                int removeRow = 4;

                if (opcoes.Count() == 2) removeRow = 3;

                int posYInicio = alturaConsole - opcoes.Count() - removeRow;

                Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio + 1);
                Console.WriteLine(titulo);
                Console.SetCursorPosition((larguraConsole - background.Length) / 2, posYInicio + 3);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(background);
                Console.ResetColor();

                for (int i = 0; i < opcoes.Count(); i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $">  {opcoes[i]}" : $"   {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(textoOpcao);
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

            Item itemSelecionado = Listas.Instancia.Itens.Find(Item => Item.Nome == opcoes[indiceSelecionado].Split(' ')[0]);

            int indexJogador = SelecionarJogadorEPokemon(currentEquip, itemSelecionado);

            (string efeitoDoItem, bool itemUsado) = regras.UsarItem(currentEquip, indexJogador, itemSelecionado);

            return new RetornoUsoItem(Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem, itemSelecionado, efeitoDoItem, itemUsado);
        }

        static int SelecionarInimigo(int indexEnemyEquip)
        {
            List<string> opcoes = new List<string>();

            foreach (var jogador in Listas.Instancia.Equipes[indexEnemyEquip].Jogadores)
            {
                if (jogador.Personagem.VidaAtual >= 1) opcoes.Add($"{jogador.Personagem.Nome} {jogador.Personagem.Classe} Defesa: {jogador.Personagem.Defesa}%");
            }

            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                string titulo = "SELECIONE UM POKÉMON INIMIGO PARA ATACAR";
                string background = "                                                ";
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;
                int removeRow = 4;

                if (opcoes.Count() == 2) removeRow = 3;
                if (opcoes.Count() == 0) removeRow = 4;

                int posYInicio = alturaConsole - opcoes.Count() - removeRow;

                Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio + 1);
                Console.WriteLine(titulo);
                Console.SetCursorPosition((larguraConsole - background.Length) / 2, posYInicio + 3);
                Console.WriteLine(background);

                if (opcoes.Count() == 0)
                {
                    Console.SetCursorPosition((larguraConsole - background.Length) / 2, posYInicio + 4);
                    Console.WriteLine(background);
                }
                
                Console.ResetColor();

                for (int i = 0; i < opcoes.Count(); i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(textoOpcao);
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

            return indiceSelecionado;
        }
    
        static int SelecionarJogadorEPokemon(int indexEquip, Item item)
        {
            List<string> opcoes = new List<string>();

            foreach (var jogador in Listas.Instancia.Equipes[indexEquip].Jogadores)
            {
                opcoes.Add($"Jogador: {jogador.Nome} | Pokémon: {jogador.Personagem.Nome} | Vida: {jogador.Personagem.VidaAtual}/{jogador.Personagem.VidaMaxima} | PP Skill: {jogador.Personagem.AtualPPSkill}/{jogador.Personagem.MaxPPSkill} | Status: {jogador.Personagem.Status}");
            }

            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                string titulo = $"SELECIONE UM POKÉMON PARA USAR O ITEM: {item.Nome}";
                string background = "                                                ";
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;
                int posYInicio = alturaConsole - opcoes.Count() - 4;
                Console.SetCursorPosition((larguraConsole - background.Length) / 2, posYInicio + 3);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(background);
                Console.ResetColor();

                Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio + 1);
                Console.WriteLine(titulo);

                for (int i = 0; i < opcoes.Count(); i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (i == indiceSelecionado)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(textoOpcao);
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

            return indiceSelecionado;
        }
    }
}
