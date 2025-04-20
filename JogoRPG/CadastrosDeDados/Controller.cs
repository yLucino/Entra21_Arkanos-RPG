using JogoRPG.Jogadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    public class Controller
    {
        public void CadastrarPersonagens()
        {
            Bulbasaur bulbasaur = new Bulbasaur("Bulbasaur", "Um Pokémon de grama e veneno, conhecido por suas habilidades em batalha e seu vínculo com a natureza.");
            Charmander charmander = new Charmander("Charmander", "Com sua chama na cauda sempre acesa, Charmander é um lutador feroz e determinado.");
            Chikorita chikorita = new Chikorita("Chikorita", "Chikorita é um Pokémon carinhoso e leal, com habilidades de cura e proteção para seus amigos.");
            Gastly gastly = new Gastly("Gastly", "Gastly é um Pokémon do tipo fantasma, misterioso e astuto, capaz de enganar seus inimigos com sua névoa venenosa.");
            Pikachu pikachu = new Pikachu("Pikachu", "Pikachu é o Pokémon elétrico mais famoso, conhecido por sua velocidade e ataques elétricos devastadores.");
            Squirtle squirtle = new Squirtle("Squirtle", "Squirtle é um Pokémon de água, destemido e rápido, sempre pronto para proteger seus aliados com seus poderosos jatos d'água.");

            Listas.Instancia.Personagens.Add(gastly);
            Listas.Instancia.Personagens.Add(charmander);
            Listas.Instancia.Personagens.Add(pikachu);
            Listas.Instancia.Personagens.Add(bulbasaur);
            Listas.Instancia.Personagens.Add(squirtle);
            Listas.Instancia.Personagens.Add(chikorita);
        }

        public void CadastrarItens()
        {
            Item potion = new Item("Poção", "Recupera uma pequena quantidade de HP.", 3000);
            Item ether = new Item("Éter", "Restaura o PP de uma habilidade.", 4000);
            Item revive = new Item("Reviver", "Revive um aliado com metade do HP.", 6000);
            Item paralyzeHeal = new Item("Cura Total", "Remove paralisia, queimaduras ou qualquer status negativo.", 2500);

            Listas.Instancia.Itens.Add(potion);
            Listas.Instancia.Itens.Add(ether);
            Listas.Instancia.Itens.Add(revive);
            Listas.Instancia.Itens.Add(paralyzeHeal);
        }
    }
}

