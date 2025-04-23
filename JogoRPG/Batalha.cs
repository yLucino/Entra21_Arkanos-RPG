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

        public void Start(int qtdPlayers)
        {

            int turno = 1;

            animacoes.CutsceneVS(Listas.Instancia.Equipes[0].Nome, Listas.Instancia.Equipes[1].Nome);

            Partida(true, turno, qtdPlayers);
        }

        static void Partida(bool statusPlayersLife, int turno, int qtdPlayers)
        {
            while (statusPlayersLife)
            {
                animacoes.CutsceneComecoTurno(turno);

                if (turno == 1 || turno == 5) TurnoCompra();
                else batalha.Menu(qtdPlayers);

                Listas.Instancia.Equipes[0].Coins += 750;
                Listas.Instancia.Equipes[1].Coins += 750;

                animacoes.CutsceneFimTurno(turno);
                turno++;

                statusPlayersLife = VerificadorVidaEquipe(qtdPlayers);
            }

            FimPartida();
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

        static void FimPartida()
        {
            Console.WriteLine("FIM DA PARTIDA");
            Console.ReadKey();
        }
    
        static void ResumoTurno()
        {

        }

        static bool VerificadorVidaEquipe(int qtdPlayers)
        {
            bool statusPlayersLife;

            if (qtdPlayers == 4)
            {
                int vidaTotalEquipeRED = Listas.Instancia.Equipes[0].Jogadores[0].Personagem.VidaAtual + Listas.Instancia.Equipes[0].Jogadores[1].Personagem.VidaAtual;
                int vidaTotalEquipeGREEN = Listas.Instancia.Equipes[1].Jogadores[0].Personagem.VidaAtual + Listas.Instancia.Equipes[1].Jogadores[1].Personagem.VidaAtual;

                if (vidaTotalEquipeRED <= 0 || vidaTotalEquipeGREEN <= 0) statusPlayersLife = false;
                else statusPlayersLife = true;
            }
            else
            {
                int vidaTotalEquipeRED = Listas.Instancia.Equipes[0].Jogadores[0].Personagem.VidaAtual;
                int vidaTotalEquipeGREEN = Listas.Instancia.Equipes[1].Jogadores[0].Personagem.VidaAtual;

                if (vidaTotalEquipeRED <= 0 || vidaTotalEquipeGREEN <= 0) statusPlayersLife = false;
                else statusPlayersLife = true;
            }

            return statusPlayersLife;
        }
    }
}
