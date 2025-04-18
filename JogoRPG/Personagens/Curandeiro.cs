using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Curandeiro : Personagem
    {
        public Curandeiro(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 100,
            vidaAtual: 100,
            classe: "Curandeiro",
            foto: "                                            --@@@@@@        \r\n                                          @@          @@    \r\n              @@@@@@@@@@@@@@            @@  @@@@mm@@@@  @@  \r\n            @@mmmmmmmmmmmmmm@@        @@  @@  @@--@@  @@  @@\r\n            mmmmmmmmmmmmmmmm##        ..@@    @@--@@    @@@@\r\n          @@mmmmmm@@@@mmmmmmmm..    mm  ########--########  \r\n          ##mmmm##  ##mmmmmmmmmm    MM  ##--------------##  \r\n          @@mmmm      ##mmmmmm::        ##    ##--##    ##..\r\n          MMMMMM        ##MMMM::      ##  ##  ##--##  ##  ##\r\n        mmMMMMMM  --  --  ##MM@@      mm..  ####--####  mm  \r\n        ##MMMMMM          ##MM##        ##MM  ..MM    ##@@  \r\n      ##MMMMMMMMMM        ##MM##            ##########      \r\n    MMMMMMMMMMMM##      ####MMMM##            ##--##        \r\n    ##MMMMMMMMMM##::########MMMM##            ##--##        \r\n    ##MMMMMMMM##        MM####MM##            ##  ##        \r\n    ##MMMMMM##--@@##    ##----####            ##  ##        \r\n    ##MMMM##--------@@##  ##::::mm            ##  ##        \r\n        ##------------::  ##::::::##          ##  ##        \r\n        ::::::::--::::::######++++##          ##  ##        \r\n      ##::::::::::::::##      ##MM##      ####              \r\n      ::::::::::::::##        ..##  ##@@::  ##              \r\n    ##::::::::::::::##          --    ##  @@--##  ##        \r\n    ##::::::::::::++          @@          ##--##--##        \r\n    ::::::::::::::##        ####          ##--##--##        \r\n  ##++++++++++++++##        ######        ##--##  ##        \r\n  ##++++++++++++++++        ######@@      ##--##  ##        \r\n  ##++++++++++++++          ########      ##--##  ##        \r\n  MM++++++++++++##          ##########    ::--##  ##        \r\n  ++++++++++++++##::      ##############    ####  ##        \r\n  ++++++++++++++##  ######    ############    ##  ##        \r\n##++++++++++++++##              ########::##  ##  ##        \r\n##++++++++++++++##              ########    ####  ##        \r\n##++++++++++++++##                ######      ##  ##        ",
            inteligencia: 90,
            velocidade: 40,
            forca: 20,
            defesa: 50,
            nomeSkill: "Benção Vital",
            descSkill: "Cura um aliado com energia divina.",
            danoBaseSkill: -50) // negativo pois é cura
        { }
    }
}
