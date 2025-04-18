using JogoRPG.Jogadores;
using JogoRPG.Personagens;
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
            Assassino assassino = new Assassino("Kael", "Um matador silencioso, rápido como um sussurro na escuridão.");
            Arqueiro arqueiro = new Arqueiro("Elyndor", "Arqueiro élfico, mestre da furtividade e da mira perfeita.");
            Curandeiro curandeiro = new Curandeiro("Seraphina", "Uma curandeira mística com poder divino de cura.");
            Guerreiro guerreiro = new Guerreiro("Thorgar", "Guerreiro robusto, nascido para o campo de batalha.");
            Mago mago = new Mago("Malrik", "Um conjurador ancestral com poder sobre o fogo e o tempo.");
            Tank tank = new Tank("Brom", "Um colosso inabalável, protetor da linha de frente.");

            Listas.Instancia.Personagens.Add(tank);
            Listas.Instancia.Personagens.Add(mago);
            Listas.Instancia.Personagens.Add(assassino);
            Listas.Instancia.Personagens.Add(arqueiro);
            Listas.Instancia.Personagens.Add(guerreiro);
            Listas.Instancia.Personagens.Add(curandeiro);
        }


        public void CadastrarItens()
        {
            // Assassino
            Item item1 = new Item("Lâmina da Sombra", "Adaga leve e silenciosa, ideal para ataques furtivos.", 15, 1.1, "Assassino", 5000);
            Item item2 = new Item("Máscara do Sussurro", "Máscara que reduz ruído e aumenta furtividade.", 5, 1.25, "Assassino", 5000);
            Item item3 = new Item("Garras de Nocturne", "Adagas lendárias que tornam o usuário invisível após ataque crítico.", 40, 1.6, "Assassino", 10000);

            // Arqueiro – Elyndor
            Item item4 = new Item("Arco de Galadhorn", "Arco élfico de precisão e longo alcance.", 18, 1.15, "Arqueiro", 5000);
            Item item5 = new Item("Botas Silenciosas de Thalanor", "Botas que eliminam o som dos passos.", 4, 1.3, "Arqueiro", 5000);
            Item item6 = new Item("Olho de Elarion", "Colar mágico que concede visão além do normal.", 28, 1.75, "Arqueiro", 10000);

            // Curandeira – Seraphina
            Item item7 = new Item("Frasco de Luz Branda", "Poção que cura ferimentos leves instantaneamente.", 0, 1.2, "Curandeiro", 5000);
            Item item8 = new Item("Orbe da Serenidade", "Amuleto que acelera magias de cura.", 2, 1.35, "Curandeiro", 5000);
            Item item9 = new Item("Lágrima de Elunaria", "Joia sagrada capaz de reviver um aliado.", 10, 2.0, "Curandeiro", 10000);

            // Guerreiro – Thorgar
            Item item10 = new Item("Machado do Vale Rochoso", "Machado robusto ideal para esmagar armaduras.", 22, 1.1, "Guerreiro", 5000);
            Item item11 = new Item("Braceletes de Ferro Negro", "Aumentam a resistência e absorvem dano físico.", 6, 1.3, "Guerreiro", 5000);
            Item item12 = new Item("Ira de Tormak", "Arma colossal que libera ondas de choque flamejantes.", 45, 1.7, "Guerreiro", 10000);

            // Mago – Malrik
            Item item13 = new Item("Grimório das Chamas Menores", "Livro arcano com feitiços de fogo básicos.", 20, 1.2, "Mago", 5000);
            Item item14 = new Item("Capa do Tempo Trêmulo", "Concede chance de retardar ataques recebidos.", 5, 1.4, "Mago", 5000);
            Item item15 = new Item("Relógio Arcano de Chronos", "Permite reverter tempo e vida em até 6 segundos.", 35, 1.9, "Mago", 10000);

            // Tank – Brom
            Item item16 = new Item("Escudo de Aço Rúnico", "Escudo pesado que reduz dano mágico.", 8, 1.1, "Tank", 5000);
            Item item17 = new Item("Elmo do Guardião Imóvel", "Resistente a efeitos de controle.", 5, 1.25, "Tank", 5000);
            Item item18 = new Item("Coração de Titanos", "Cria barreira que protege aliados próximos.", 20, 2.0, "Tank", 10000);

            Listas.Instancia.Itens.Add(item1);
            Listas.Instancia.Itens.Add(item2);
            Listas.Instancia.Itens.Add(item3);
            
            Listas.Instancia.Itens.Add(item4);
            Listas.Instancia.Itens.Add(item5);
            Listas.Instancia.Itens.Add(item6);

            Listas.Instancia.Itens.Add(item7);
            Listas.Instancia.Itens.Add(item8);
            Listas.Instancia.Itens.Add(item9);
            
            Listas.Instancia.Itens.Add(item10);
            Listas.Instancia.Itens.Add(item11);
            Listas.Instancia.Itens.Add(item12);
            
            Listas.Instancia.Itens.Add(item13);
            Listas.Instancia.Itens.Add(item14);
            Listas.Instancia.Itens.Add(item15);
            
            Listas.Instancia.Itens.Add(item16);
            Listas.Instancia.Itens.Add(item17);
            Listas.Instancia.Itens.Add(item18);
        }
    }
}

