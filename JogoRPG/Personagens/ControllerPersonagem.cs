﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoRPG.Personagens;

namespace JogoRPG
{

    public class ControllerPersonagem
    {
        Assassino assassino = new Assassino("Kael", "Um matador silencioso, rápido como um sussurro na escuridão.");
        Arqueiro arqueiro = new Arqueiro("Elyndor", "Arqueiro élfico, mestre da furtividade e da mira perfeita.");
        Curandeiro curandeiro = new Curandeiro("Seraphina", "Uma curandeira mística com poder divino de cura.");
        Guerreiro guerreiro = new Guerreiro("Thorgar", "Guerreiro robusto, nascido para o campo de batalha.");
        Mago mago = new Mago("Malrik", "Um conjurador ancestral com poder sobre o fogo e o tempo.");
        Tank tank = new Tank("Brom", "Um colosso inabalável, protetor da linha de frente.");

    }
}
