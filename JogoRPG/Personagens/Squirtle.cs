﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Squirtle : Personagem
    {
        public Squirtle(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 110,
            vidaAtual: 110,
            classe: "Água 💧",
            fotoSimples: @"
             ___
            (•_•)_ 
           <(_ _)╯",
            fotoComplexa: "               _,........__\r\n            ,-'            \"`-.\r\n          ,'                   `-.\r\n        ,'                        \\\r\n      ,'                           .\r\n      .'\\               ,\"\".       `\r\n     ._.'|             / |  `       \\\r\n     |   |            `-.'  ||       `.\r\n     |   |            '-._,'||       | \\\r\n     .`.,'             `..,'.'       , |`-.\r\n     l                       .'`.  _/  |   `.\r\n     `-.._'-   ,          _ _'   -\" \\  .     `\r\n`.\"\"\"\"\"'-.`-...,---------','         `. `....__.\r\n.'        `\"-..___      __,'\\          \\  \\     \\\r\n\\_ .          |   `\"\"\"\"'    `.           . \\     \\\r\n  `.          |              `.          |  .     L\r\n    `.        |`--...________.'.        j   |     |\r\n      `._    .'      |          `.     .|   ,     |\r\n         `--,\\       .            `7\"\"' |  ,      |\r\n            ` `      `            /     |  |      |    _,-'\"\"\"`-.\r\n             \\ `.     .          /      |  '      |  ,'          `.\r\n              \\  v.__  .        '       .   \\    /| /              \\\r\n               \\/    `\"\"\\\"\"\"\"\"\"\"`.       \\   \\  /.''                |\r\n                `        .        `._ ___,j.  `/ .-       ,---.     |\r\n                ,`-.      \\         .\"     `.  |/        j     `    |\r\n               /    `.     \\       /         \\ /         |     /    j\r\n              |       `-.   7-.._ .          |\"          '         /\r\n              |          `./_    `|          |            .     _,'\r\n              `.           / `----|          |-............`---'\r\n                \\          \\      |          |\r\n               ,'           )     `.         |\r\n                7____,,..--'      /          |\r\n                                  `---.__,--.'",
            forca: 25,
            defesa: 80,
            nomeSkill: "Jato d’Água",
            descSkill: "Dispara um jato de água forte no inimigo.",
            danoBaseSkill: 55,
            maxPPSkill: 3,
            atualPPSkill: 3,
            status: "Acordado")
        { }
    }
}

