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
            string status = "";

            if (classeCurrentPlayer == "Fogo 🔥" && classeEnemyPlayer == "Planta 🍃")
            {
                status = "Super eficaz";
                modificador = 2;
            }
            else if (classeCurrentPlayer == "Fogo 🔥" && classeEnemyPlayer == "Água 💧")
            {
                status = "Ineficaz";
                modificador = 0.3;
            }
            else if (classeCurrentPlayer == "Água 💧" && classeEnemyPlayer == "Fogo 🔥")
            {
                status = "Super eficaz";
                modificador = 2;
            }
            else if (classeCurrentPlayer == "Água 💧" && classeEnemyPlayer == "Planta 🍃")
            {
                status = "Pouco eficaz";
                modificador = 0.6;
            }
            else if (classeCurrentPlayer == "Elétrico ⚡" && classeEnemyPlayer == "Água 💧")
            {
                status = "Super eficaz";
                modificador = 2;
            }
            else if (classeCurrentPlayer == "Planta 🍃" && classeEnemyPlayer == "Água 💧")
            {
                status = "Super eficaz";
                modificador = 2;
            }
            else if (classeCurrentPlayer == "Fantasma \U0001f7e3" && classeEnemyPlayer == "Fogo 🔥")
            {
                status = "Ineficaz";
                modificador = 0.3;
            }

            int dano = 0;

            if (tipoAtaque == "Basic")
            {
                dano = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Forca;
            }
            else if (tipoAtaque == "Skill")
            {
                Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.AtualPPSkill--;
                dano = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.DanoDaseSkill;
            }

            int defesa = Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Defesa;

            int totalDanoAtaque = (int)(dano * ((defesa / 100f)) * modificador);

            if ((Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual - totalDanoAtaque) < 0)
            {
                Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual = 0;
            }
            else 
            {
                Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual -= totalDanoAtaque;
            }

            return (totalDanoAtaque, status);
       }

       public string UsarItem(int indexEquip, int indexPlayer, Item item)
       {
            string efeitoDoItem = "";

            if (item.Nome == "Poção")
            {
                if ((Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual + 40) > Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima)
                {
                    int cura = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima - Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual;
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima;
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} curou {cura}HP com o item: Poção";
                }
                else
                {
                    Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual += 40;
                    efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} curou 40HP com o item: Poção";
                }
            }
            else if (item.Nome == "Éter")
            {
                Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.AtualPPSkill = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.MaxPPSkill;
                efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} restaurou o PP de sua Skill com o item: Éter";
            }
            else if (item.Nome == "Reviver")
            {
                Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaAtual = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.VidaMaxima / 2;
                Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status = "Acordado";
                efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} reviveu com o item: Reviver";
            }
            else if (item.Nome == "Cura Total")
            {
                Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Status = "Acordado";
                efeitoDoItem = $"{Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem.Nome} restaurou todos seus Status com o item: Status Total";
            }

            Listas.Instancia.Equipes[indexEquip].Itens.Remove(item);

            return efeitoDoItem;
       }
    }
}
