using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Guerreiro : Personagem
    {
        public Guerreiro(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 150,
            vidaAtual: 150,
            classe: "Guerreiro",
            foto: "                                                            \r\n                                                            \r\n                                                            \r\n                          ########                  MM      \r\n                      ####        mm          ..##    ##--  \r\n                    MM    MM      ##      ##mm    ##++##    \r\n                    ##      ##::  mm  ##      ##::::##      \r\n                    ######    ::  ##::  mm##::::##          \r\n                    ####    @@    ::##MM::::##              \r\n          @@MM      ##      ..mm##::::::##                  \r\n        ##  ##  ..####    ##::MM  ####                      \r\n              @@::::::@@@@##    ..  ##::                    \r\n        ####  ##::##++::::        mm##  ::####mm            \r\n    ##          ::::##MM##      @@::            ##          \r\n  ..  ##    ##--####  ##  ####    MM            ##          \r\n    --@@##++MM--MM    ##--    ..##::##      ##::            \r\n    ..::####  @@@@::::  ::::::::::  ::--  --::              \r\n      ##MM::####  ####              ::::##MM##  MM          \r\n      ::::  ..    ::##  ####        ##  ::MM::++            \r\n        ::    ####::####    ##      ++  ::##  MM####        \r\n        ##::  ####::##          ##MM    mm##::    ##        \r\n        --::  ####::##                ::######    ####      \r\n          ##::####::##    mm      ##  @@######mm##          \r\n          ##::MMMM@@######..::####################    mm    \r\n          MMmm::++########  --################::::++::      \r\n              ########              ##::######    ##mm      \r\n            ########      ######      mm::####..  ##::      \r\n          ::########      ######@@      ::####::  @@++      \r\n          ##########MMMM@@########MMMMMM@@@@##@@MM@@##      \r\n                                                            \r\n                                                            ",
            inteligencia: 30,
            velocidade: 50,
            forca: 80,
            defesa: 60,
            nomeSkill: "Golpe Devastador",
            descSkill: "Um golpe poderoso com a espada.",
            danoBaseSkill: 65)
        { }
    }
}
