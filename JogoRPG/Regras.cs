using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Regras
    {
       public (int, string) Ataque(int currentEquip, int currentPlayer, int enemyEquip, int enemyPlayer, string tipoAtaque)
       {
            string classeCurrentPlayer = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Classe;
            string classeEnemyPlayer = Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Classe;

            double modificador = 1;
            string status = "Ataque Neutro";

            if (tipoAtaque == "Skill")
            {
                if (classeCurrentPlayer == "Fogo 🔥" && classeEnemyPlayer == "Planta 🍃")
                {
                    status = "Ataque Super eficaz";
                    modificador = 2;
                }
                else if (classeCurrentPlayer == "Fogo 🔥" && classeEnemyPlayer == "Água 💧")
                {
                    status = "Ataque Ineficaz";
                    modificador = 0.3;
                }
                else if (classeCurrentPlayer == "Água 💧" && classeEnemyPlayer == "Fogo 🔥")
                {
                    status = "Ataque Super eficaz";
                    modificador = 2;
                }
                else if (classeCurrentPlayer == "Água 💧" && classeEnemyPlayer == "Planta 🍃")
                {
                    status = "Ataque Pouco eficaz";
                    modificador = 0.6;
                }
                else if (classeCurrentPlayer == "Elétrico ⚡" && classeEnemyPlayer == "Água 💧")
                {
                    status = "Ataque Super eficaz";
                    modificador = 2;
                }
                else if (classeCurrentPlayer == "Planta 🍃" && classeEnemyPlayer == "Água 💧")
                {
                    status = "Ataque Super eficaz";
                    modificador = 2;
                }
                else if (classeCurrentPlayer == "Fantasma \U0001f7e3" && classeEnemyPlayer == "Fogo 🔥")
                {
                    status = "Ataque Ineficaz";
                    modificador = 0.3;
                }
            }

            int dano = 0;

            if (tipoAtaque == "Basic")
            {
                dano = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Forca;
            }
            else if (tipoAtaque == "Skill")
            {
                if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill <= 0) Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill = 0;
                else Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill--;

                dano = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.DanoDaseSkill;
            }

            int defesa = Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Defesa;

            int totalDanoAtaque = (int)(dano * ((defesa / 100f)) * modificador);

            if ((Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual - totalDanoAtaque) <= 0)
            {
                Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual = 0;
                Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Desmaiado";
            }
            else 
            {
                Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual -= totalDanoAtaque;
            }

            return (totalDanoAtaque, status);
       }

       public (string, bool) UsarItem(int indexEquip, int indexPlayer, Item item)
       {
            string efeitoDoItem = "";
            bool itemUsado = false;

            if (item.Nome == "Poção")
            {
                if (Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual > 0 && Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual < Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima)
                {
                    if ((Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual + 40) > Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima)
                    {
                        int cura = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima - Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual;
                        Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima;
                        efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} curou {cura}HP com o item: Poção.";
                    }
                    else
                    {
                        Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual += 40;
                        efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} curou 40HP com o item: Poção.";
                    }

                    itemUsado = true;
                }
                else
                {
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} está {(Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual <= 0 ? "desmaiado" : "com a vida cheia")} e não pode usar o item: Poção.";
                }
            }
            else if (item.Nome == "Éter")
            {
                if (Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.AtualPPSkill < Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.MaxPPSkill)
                {
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.AtualPPSkill = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.MaxPPSkill;
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} restaurou o PP de sua Skill com o item: Éter.";

                    itemUsado = true;
                }
                else
                {
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} está com o PP da skill cheia e não pode usar o item: Éter.";
                }
            }
            else if (item.Nome == "Reviver")
            {
                if (Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status != "Acordado")
                {
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima / 2;
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status = "Acordado";
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} reviveu com o item: Reviver.";

                    itemUsado = true;
                }
                else
                {
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} está acordado e não pode usar o item: Reviver.";
                }
            }
            else if (item.Nome == "HealStatus")
            {
                if (Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status != "Acordado" && Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status != "Desmaiado")
                {
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status = "Acordado";
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} restaurou todos seus Status com o item: Status Total.";

                    itemUsado = true;
                }
                else
                {
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} não foi afetado com nenhum efeito negativo. (PAR, FEAR ou  BURN)";
                }
            }

            if (itemUsado) Listas.Instancia.Equipes[indexEquip].Itens.Remove(item);

            return (efeitoDoItem, itemUsado);
       }
    }
}
