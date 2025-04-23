using JogoRPG.Jogadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Batalha
    {
        static Animacoes animacoes = new Animacoes();
        static Menu_Batalha batalha = new Menu_Batalha();
        static Controller controller = new Controller();

        public void Start(int qtdPlayers)
        {

            int turno = 1;

            animacoes.CutsceneVS(Listas.Instancia.Equipes[0].Nome, Listas.Instancia.Equipes[1].Nome);

            Partida(true, turno, qtdPlayers);
        }

        static void Partida(bool statusPlayersLife, int turno, int qtdPlayers)
        {
            Equipe equipeVencedora = new Equipe();

            while (statusPlayersLife)
            {
                animacoes.CutsceneComecoTurno(turno);

                if (turno == 1 || turno == 5) TurnoCompra();
                else batalha.Menu(qtdPlayers);

                Listas.Instancia.Equipes[0].Coins += 750;
                Listas.Instancia.Equipes[1].Coins += 750;

                animacoes.CutsceneFimTurno(turno);
                turno++;

                (bool status, Equipe equipe) = VerificadorVidaEquipe(qtdPlayers);
                statusPlayersLife = status;
                equipeVencedora = equipe;
            }

            FimPartida(equipeVencedora);
        }

        static void TurnoCompra()
        {
            List<string> opcoes = new List<string>();
            foreach (var item in Listas.Instancia.Itens)
            {
                opcoes.Add($"{item.Nome} | {item.Descricao} | Valor: {item.Valor}");
            }
            opcoes.Add("PASSAR FASE DE COMPRA.");

            int indiceSelecionado = 0;
            ConsoleKey tecla;
            int currentEquip = 0;

            do
            {
                Console.Clear();

                string titulo = "-= CENTRO POKÉMON =-";
                string subTitulo = $"Vez da equipe: {Listas.Instancia.Equipes[currentEquip].Id} - {Listas.Instancia.Equipes[currentEquip].Nome} | Total de Coins: {Listas.Instancia.Equipes[currentEquip].Coins}";
                int larguraConsole = Console.WindowWidth;
                int alturaConsole = Console.WindowHeight;

                int posXtitulo = (larguraConsole - titulo.Length) / 2;
                int posXsubTitulo = (larguraConsole - subTitulo.Length) / 2;

                int linhaMeio = alturaConsole / 2;
                int posYtitulo = linhaMeio - opcoes.Count;
                int posYsubTitulo = posYtitulo - 1;

                Console.SetCursorPosition(posXsubTitulo, posYsubTitulo);
                if (Listas.Instancia.Equipes[currentEquip].Id == "RED") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(subTitulo);
                Console.ResetColor();

                Console.SetCursorPosition(posXtitulo, posYtitulo);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(titulo);
                Console.ResetColor();

                int posYInicio = linhaMeio - (opcoes.Count / 2);

                for (int i = 0; i < opcoes.Count; i++)
                {
                    string textoOpcao = (i == indiceSelecionado) ? $"> {opcoes[i]}" : $"  {opcoes[i]}";
                    int posX = (larguraConsole - textoOpcao.Length) / 2;
                    int posY = posYInicio + i;

                    Console.SetCursorPosition(posX, posY);

                    if (opcoes[i] == "PASSAR FASE DE COMPRA.")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
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
                    indiceSelecionado = (indiceSelecionado - 1 + opcoes.Count) % opcoes.Count;
                }
                else if (tecla == ConsoleKey.DownArrow)
                {
                    indiceSelecionado = (indiceSelecionado + 1) % opcoes.Count;
                }
                else if (tecla == ConsoleKey.Enter)
                {
                    if (opcoes[indiceSelecionado] == "PASSAR FASE DE COMPRA.")
                    {
                        currentEquip++;
                    }
                    else
                    {
                        string nomeItem = opcoes[indiceSelecionado].Split('|')[0].Trim();
                        Item itemSelected = Listas.Instancia.Itens.Find(Item => Item.Nome == nomeItem);

                        if (Listas.Instancia.Equipes[currentEquip].Coins >= itemSelected.Valor)
                        {
                            Listas.Instancia.Equipes[currentEquip].Itens.Add(itemSelected);
                            Listas.Instancia.Equipes[currentEquip].Coins -= itemSelected.Valor;
                            currentEquip++;
                        }
                    }
                }

            } while (currentEquip < Listas.Instancia.Equipes.Count);
        }

        static (bool, Equipe) VerificadorVidaEquipe(int qtdPlayers)
        {
            bool statusPlayersLife;
            Equipe equipeVencedora = new Equipe();

            int vidaTotalEquipeRED;
            int vidaTotalEquipeGREEN;

            if (qtdPlayers == 4)
            {
                vidaTotalEquipeRED = Listas.Instancia.Equipes[0].Jogadores[0].Personagem.VidaAtual + Listas.Instancia.Equipes[0].Jogadores[1].Personagem.VidaAtual;
                vidaTotalEquipeGREEN = Listas.Instancia.Equipes[1].Jogadores[0].Personagem.VidaAtual + Listas.Instancia.Equipes[1].Jogadores[1].Personagem.VidaAtual;

                if (vidaTotalEquipeRED <= 0 || vidaTotalEquipeGREEN <= 0) statusPlayersLife = false;
                else statusPlayersLife = true;
            }
            else
            {
                vidaTotalEquipeRED = Listas.Instancia.Equipes[0].Jogadores[0].Personagem.VidaAtual;
                vidaTotalEquipeGREEN = Listas.Instancia.Equipes[1].Jogadores[0].Personagem.VidaAtual;

                if (vidaTotalEquipeRED <= 0 || vidaTotalEquipeGREEN <= 0) statusPlayersLife = false;
                else statusPlayersLife = true;
            }

            if (vidaTotalEquipeRED <= 0 && vidaTotalEquipeGREEN >= 1) equipeVencedora = Listas.Instancia.Equipes[1];
            else if (vidaTotalEquipeGREEN <= 0 && vidaTotalEquipeRED >= 1) equipeVencedora = Listas.Instancia.Equipes[0];

            return (statusPlayersLife, equipeVencedora);
        }

        static void FimPartida(Equipe equipeVencedora)
        {
            Console.Clear();

            string titulo = "========== FIM DA PARTIDA ==========";
            string equipeVencedoraLabel = "🏆 Equipe Vencedora: ";
            string jogadorLabel = "👤 Jogador {0}: ";
            string pokemonsUsados = "   🔹 Pokémons usados:";
            string pokemonInfo = "     - {0,-15} (Classe: {1})";
            string divisor = "====================================";
            string continuar = "Pressione qualquer tecla para continuar...";

            int larguraConsole = Console.WindowWidth;
            int alturaConsole = Console.WindowHeight;

            int totalLinhas = 5 + (equipeVencedora.Jogadores.Count * 4);
            int posYInicio = (alturaConsole / 2) - (totalLinhas / 2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((larguraConsole - titulo.Length) / 2, posYInicio);
            Console.WriteLine(titulo);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((larguraConsole - (equipeVencedoraLabel.Length + equipeVencedora.Nome.Length)) / 2, posYInicio + 2);
            Console.Write(equipeVencedoraLabel);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(equipeVencedora.Nome);

            for (int i = 0; i < equipeVencedora.Jogadores.Count; i++)
            {
                var jogador = equipeVencedora.Jogadores[i];
                int currentY = posYInicio + 4 + (i * 4);

                Console.ForegroundColor = ConsoleColor.Cyan;
                string jogadorText = string.Format(jogadorLabel, i + 1);
                Console.SetCursorPosition((larguraConsole - (jogadorText.Length + jogador.Nome.Length)) / 2, currentY);
                Console.Write(jogadorText);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(jogador.Nome);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition((larguraConsole - pokemonsUsados.Length) / 2, currentY + 1);
                Console.WriteLine(pokemonsUsados);

                Console.ForegroundColor = ConsoleColor.White;
                string pokemonText = string.Format(pokemonInfo, jogador.Personagem.Nome, jogador.Personagem.Classe);
                Console.SetCursorPosition((larguraConsole - pokemonText.Length) / 2, currentY + 2);
                Console.WriteLine(pokemonText);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((larguraConsole - divisor.Length) / 2, posYInicio + 5 + (equipeVencedora.Jogadores.Count * 4));
            Console.WriteLine(divisor);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((larguraConsole - continuar.Length) / 2, posYInicio + 7 + (equipeVencedora.Jogadores.Count * 4));
            Console.WriteLine(continuar);

            Console.ResetColor();
            Console.ReadKey();

            // Reset de Listas e Registros
            Listas.Instancia.Equipes.Clear();
            Listas.Instancia.Personagens.Clear();

            controller.CadastrarPersonagens();
        }
    }
}
