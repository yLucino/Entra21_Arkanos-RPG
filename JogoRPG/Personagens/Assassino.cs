using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Assassino : Personagem
    {
        public Assassino(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 80,
            vidaAtual: 80,
            classe: "Assassino",
            foto: "                                                            \r\n                                                            \r\n                          ########                          \r\n                          ##mmmmmmmm##                      \r\n        ##..              MMmmmmmmmmmmmm                    \r\n      MM++                  ##mmmmmmmmmm##                  \r\n      ##++##                ##@@####mmmm##                  \r\n      ++mmmm##            ..MM####  @@####                  \r\n      ##mmmmmmMM############MMmm##..  --                    \r\n        @@##mmmmmmmmMMMM@@@@@@@@mmmm##                      \r\n              ##@@@@##########mmmmmmmm::        @@MM        \r\n    ..++####@@@@##--  --##++MM##mmmmMM                      \r\n    ##@@@@@@@@##    ##MMmm##++@@##mm::                      \r\n          --      ##mmmmMM##++++MM            ##  ##MM      \r\n                ####MM##mm##mmmmmm##          ##    ##      \r\n              ++##MM##MM##@@mmmmmmmm##      ..@@@@##        \r\n            ####MM##MM##@@mmmmmmmmmm####mm  MMmmMM          \r\n            @@++++##  ##@@mmmmmmmmmm########mmmm##          \r\n            ##mmmmmm    @@@@mmmmmmmm########mmmm++          \r\n            ##mmmmmm    ##@@@@MMMMMM##  ####MM##            \r\n              mmMM@@      ##MM####@@##      ##              \r\n              ######  ##############@@  --MM##########      \r\n          ######    ########mmmmMMMMMM                      \r\n          ######    ########mmMMMMMMMM  @@mm..              \r\n              --  MM  ##@@@@######@@mm..                    \r\n                ##    ##@@MMmmmmmmmmmm##                    \r\n                      @@@@MMMMMMmmmmmm##                    \r\n                                                            ",
            inteligencia: 40,
            velocidade: 90,
            forca: 60,
            defesa: 30,
            nomeSkill: "Golpe Sombrio",
            descSkill: "Um ataque crítico vindo das sombras.",
            danoBaseSkill: 70)
        { }
    }
}
