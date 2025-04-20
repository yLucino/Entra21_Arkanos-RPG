using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Charmander : Personagem
    {
        public Charmander(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 95,
            vidaAtual: 95,
            classe: "Fogo 🔥",
            fotoSimples: @"
             (    )
            ( o__o )
             ( __ )>
              ||||",
            fotoComplexa: "              _.--\"\"`-..\r\n            ,'          `.\r\n          ,'          __  `.\r\n         /|          \" __   \\\r\n        , |           / |.   .\r\n        |,'          !_.'|   |\r\n      ,'             '   |   |\r\n     /              |`--'|   |\r\n    |                `---'   |\r\n     .   ,                   |                       ,\".\r\n      ._     '           _'  |                    , ' \\ `\r\n  `.. `.`-...___,...---\"\"    |       __,.        ,`\"   L,|\r\n  |, `- .`._        _,-,.'   .  __.-'-. /        .   ,    \\\r\n-:..     `. `-..--_.,.<       `\"      / `.        `-/ |   .\r\n  `,         \"\"\"\"'     `.              ,'         |   |  ',,\r\n    `.      '            '            /          '    |'. |/\r\n      `.   |              \\       _,-'           |       ''\r\n        `._'               \\   '\"\\                .      |\r\n           |                '     \\                `._  ,'\r\n           |                 '     \\                 .'|\r\n           |                 .      \\                | |\r\n           |                 |       L              ,' |\r\n           `                 |       |             /   '\r\n            \\                |       |           ,'   /\r\n          ,' \\               |  _.._ ,-..___,..-'    ,'\r\n         /     .             .      `!             ,j'\r\n        /       `.          /        .           .'/\r\n       .          `.       /         |        _.'.'\r\n        `.          7`'---'          |------\"'_.'\r\n       _,.`,_     _'                ,''-----\"'\r\n   _,-_    '       `.     .'      ,\\\r\n   -\" /`.         _,'     | _  _  _.|\r\n    \"\"--'---\"\"\"\"\"'        `' '! |! /\r\n                            `\" \" -' ",
            inteligencia: 55,
            velocidade: 65,
            forca: 60,
            defesa: 35,
            nomeSkill: "Chama Ardente",
            descSkill: "Ataca com fogo intenso e pode causar queimadura.",
            danoBaseSkill: 65)
        { }
    }
}