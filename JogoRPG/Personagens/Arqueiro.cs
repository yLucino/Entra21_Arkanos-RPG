using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Arqueiro : Personagem
    {
        public Arqueiro(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 100,
            vidaAtual: 100,
            classe: "Arqueiro",
            foto: "                                                            \r\n                                                            \r\n                                                            \r\n                                                            \r\n                  ::##      ##@@####                        \r\n                ##--##            ..##                      \r\n              ##--##                ..##                    \r\n            ##--    --##            ++::####                \r\n            --##    ##                ##  @@##              \r\n          ##--          ####..++####      ####              \r\n          ####    ##  ..                ######++            \r\n          ####    ..  ##    ####    mm  --MM::##            \r\n          ####        ####::####::##mm      ##::            \r\n          ##--  ##    ##::mm::::##::mm    ####              \r\n          ++--  ##    ##::::::::::::      ##                \r\n            --##::      mm::::::::##      --::##            \r\n            ##########    ##::::##    ####MM--              \r\n            ++--mm    ##                  ####              \r\n              ##++                      mm++##              \r\n            ##::::::##              ..##::::++::            \r\n            ##::::::::::##::--##::::::::::::++##            \r\n            MM::::::::##--##@@::::::::::::::++##            \r\n                                                            \r\n                                                            ",
            inteligencia: 50,
            velocidade: 80,
            forca: 55,
            defesa: 40,
            nomeSkill: "Flecha Precisa",
            descSkill: "Dispara uma flecha certeira com chance de crítico.",
            danoBaseSkill: 60)
        { }
    }
}
