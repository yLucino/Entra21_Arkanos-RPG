using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Regras
    {
        static Feedback feedback = new Feedback();
        static Chikorita chikorita;

        public (int, string) Ataque(int currentEquip, int currentPlayer, int enemyEquip, int enemyPlayer, string tipoAtaque)
        {
            string classeCurrentPlayer = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Classe;
            string statusCurrentPlayer = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Status;
            string classeEnemyPlayer = Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Classe;
            int defesaEnemyPlayer = Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Defesa;

            double modificador = 1;
            int totalDanoAtaque = 0;
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

            if (statusCurrentPlayer == "Paralisado" || statusCurrentPlayer == "Aterrorizado")
            {
                status = "Ataque falhou";
            }
            else
            {
                totalDanoAtaque = (int)(dano * ((defesaEnemyPlayer / 100f)) * modificador);

                if ((Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual - totalDanoAtaque) <= 0)
                {
                    Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual = 0;
                    Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Desmaiado";


                    if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome == "Chikorita")
                    {
                        feedback.ResumoDeAcaoBatalha(SkillChikorita(currentEquip, currentPlayer));
                        Console.ReadKey();
                    }
                }
                else
                {
                    Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.VidaAtual -= totalDanoAtaque;
                 
                    if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome == "Chikorita")
                    {
                        feedback.ResumoDeAcaoBatalha(SkillChikorita(currentEquip, currentPlayer));
                        Console.ReadKey();
                    }

                    if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome == "Bulbasaur")
                    {
                        Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Envenenado";
                    }

                    if (GenerateRandomNumber() == 1)
                    {
                        if (classeCurrentPlayer == "Fogo 🔥") Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Queimando";
                        else if (classeCurrentPlayer == "Elétrico ⚡") Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Paralisado";
                        else if (classeCurrentPlayer == "Fantasma \U0001f7e3") Listas.Instancia.Equipes[enemyEquip].Jogadores[enemyPlayer].Personagem.Status = "Aterrorizado";
                    }
                }
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

        public int GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 9);
            return randomNumber;
        }

        public void GerenciadorStatusPokemon()
        {
            int indexEquipEnemy = 0;

            for (int indexEquip = 0; indexEquip < 2; indexEquip++)
            {
                if (indexEquip == 0) indexEquipEnemy = 1;
                else if (indexEquip == 1) indexEquipEnemy = 0;

                for (int i = 0; i < Listas.Instancia.Equipes[indexEquip].Jogadores.Count(); i++)
                {
                    if (Listas.Instancia.Equipes[indexEquip].Jogadores[i].Personagem.Status == "Queimando")
                    {
                        feedback.ResumoDeAcaoBatalha(AplicadorDeEfeito(indexEquip, i, "Dano", 10, "Queimando"));
                        
                        Console.ReadKey();
                    }
                    else if (Listas.Instancia.Equipes[indexEquip].Jogadores[i].Personagem.Status == "Envenenado")
                    {
                        feedback.ResumoDeAcaoBatalha(AplicadorDeEfeito(indexEquip, i, "Dano", 15, "Envenenado"));
                        
                        Console.ReadKey();

                        for (int j = 0; j < Listas.Instancia.Equipes[indexEquip].Jogadores.Count(); j++)
                        {
                            if (Listas.Instancia.Equipes[indexEquipEnemy].Jogadores[j].Personagem.Nome == "Bulbasaur")
                            {
                                feedback.ResumoDeAcaoBatalha(AplicadorDeEfeito(indexEquipEnemy, j, "Cura", 10, $"Drenando a vida do(a) {Listas.Instancia.Equipes[indexEquip].Jogadores[i].Personagem.Nome}")); // Cura o inimigo que tiver um Bulbasaur
                                
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
        }

        static string AplicadorDeEfeito(int indexEquip, int indexPlayer, string tipoAcao, int pontos, string causa)
        {
            var personagem = Listas.Instancia.Equipes[indexEquip].Jogadores[indexPlayer].Personagem;
            string mensagem = "";

            if (tipoAcao == "Cura")
            {
                personagem.VidaAtual = Math.Min(personagem.VidaAtual + pontos, personagem.VidaMaxima);
                mensagem = $"{personagem.Nome} está {causa} e curou {pontos}HP.";
            }
            else if (tipoAcao == "Dano")
            {
                personagem.VidaAtual = Math.Max(personagem.VidaAtual - pontos, 0);
                mensagem = $"{personagem.Nome} está {causa} e tomou {pontos} de dano.";
            }

            return mensagem;
        }

        static string SkillChikorita(int currentEquip, int currentPlayer)
        {
            string mensagem = "";

            if (Listas.Instancia.Equipes[currentEquip].Jogadores.Count() == 2)
            {
                int indexDupla = 0;

                if (currentPlayer == 0) indexDupla = 1;
                else if (currentPlayer == 1) indexDupla = 0;

                var dupla = Listas.Instancia.Equipes[currentEquip].Jogadores[indexDupla];

                if (dupla.Personagem.VidaAtual + 10 >= dupla.Personagem.VidaMaxima && dupla.Personagem.Status != "Desmaiado")
                {
                    dupla.Personagem.VidaAtual = dupla.Personagem.VidaMaxima;
                    mensagem = $"{dupla.Personagem.Nome} curou 10HP com a Skill de sua dupla: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.NomeSkill}";
                }
                else if (dupla.Personagem.Status != "Desmaiado")
                {
                    dupla.Personagem.VidaAtual += 10;
                    mensagem = $"{dupla.Personagem.Nome} curou 10HP com a Skill de sua dupla: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.NomeSkill}";
                }

            }
            else
            {
                if (Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaAtual + 10 >= Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaMaxima) Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaAtual = Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaMaxima;
                else Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.VidaAtual += 10;

                mensagem = $"{Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.Nome} curou 10HP com a Skill: {Listas.Instancia.Equipes[currentEquip].Jogadores[currentPlayer].Personagem.NomeSkill}";
            }

            return mensagem;
        }
    }
}
