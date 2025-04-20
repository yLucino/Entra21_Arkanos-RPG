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
        public void Menu()
        {
            // OBS: MESMA LÓGICA QUE Batalha.TurnoCompra().cs {do while()}
            // Implementar lógica para fazer com que cada jogador possa acadar e usar itens
            // Começar com: equipe 0 jogador 0 ->
            //              equipe 0 jogador 1 ->
            //              equipe 1 jogador 0 ->
            //              equipe 1 jogador 1 ->
            //              * FINALIZAR TURNO *

            string[] opcoes = { "Atacar", "Itens", "Passar vez" };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();

                // ====== Exibições =======
                ExibirNomeEquipe(0);
                ExibirPersonagens(0);

                Console.SetCursorPosition(0, Console.WindowHeight / 2);
                Console.WriteLine(new string('-', Console.WindowWidth));

                ExibirNomeEquipe(1);
                ExibirPersonagens(1);

                // ====== Menu Opções =======
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;

                int posYInicio = alturaConsole - opcoes.Length - 2;

                for (int i = 0; i < opcoes.Length; i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i + 2;

                    Console.SetCursorPosition(posX, posY);

                    if (opcoes[i] == "Passar vez")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(textoOpcao);
                        Console.ResetColor();
                    }
                    else if (i == indiceSelecionado)
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

            if (indiceSelecionado == 0) Console.WriteLine("ATAQUE");
            else if (indiceSelecionado == 1) Console.WriteLine("ITENS");
            else Console.WriteLine("PASSAR VEZ");
            // Fazer funções para cada if/else if/else
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
                // Nome + Classe
                Console.SetCursorPosition(posX, posY);
                
                if (jogador.Personagem.Classe == "Elétrico ⚡") Console.ForegroundColor = ConsoleColor.Yellow;
                else if (jogador.Personagem.Classe == "Água 💧") Console.ForegroundColor = ConsoleColor.Cyan;
                else if (jogador.Personagem.Classe == "Fantasma \U0001f7e3") Console.ForegroundColor = ConsoleColor.DarkMagenta;
                else if (jogador.Personagem.Classe == "Fogo 🔥") Console.ForegroundColor = ConsoleColor.Red;
                else if (jogador.Personagem.Classe == "Planta 🍃") Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine($"{jogador.Personagem.Nome} - {jogador.Personagem.Classe}");

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
    }
}
