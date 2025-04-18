using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Mago : Personagem
    {
        public Mago(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 90,
            vidaAtual: 90,
            classe: "Mago",
            foto: "                                                            \r\n                                                            \r\n                      ######                  mm++          \r\n                    ##----++              @@mmmmmm          \r\n                  ##--------##          MMmmmmmmmm##        \r\n                @@--##--::##--##        mmmm######mm@@      \r\n              ::--++..    ------##    ##mm@@      @@mm++    \r\n            @@----##        ##----##    mmmm##..  ##mm##    \r\n          ..----####        ####--++    ##mmmm++  ##mm##    \r\n          ##--::####--####  ####----        @@  ++mm##      \r\n          ##----####        ####MMMM            MM@@        \r\n          @@mmMM##          --++####          ##mmMM        \r\n            ####@@      ##    ------##        ##mm          \r\n            ##--##  ##  MM    --------@@      ##mm          \r\n          ##----##  mm  MM  ..----------@@@@########        \r\n          ------@@  @@  ##  ##--------##  ##MM++++  ::      \r\n        ##--------..##    @@::----##@@MM  ##MM      ::      \r\n        MM##----MM..MM##  ##::##MMMM----..  mm      ::      \r\n      ##--------MM@@..##..##MM##--------############        \r\n    ++------------##..##::MM--MM----------######mm::##      \r\n    ##--@@mm----::##..##..@@--::--##----##MM  ##mm##--##    \r\n    ####------####MM##..####--------MM--####  ##mm####++    \r\n    ##------##MM##--MM##..MM--------MM--MM##  ##mm####--##  \r\n    ------####++##----++##MM--------MMMMMM##  ##mm####--@@  \r\n  ##----######----------------------MMMMMM##  ##mm####::--  \r\n  MM--########----------------------##MMMM##  ##mm####MM--::\r\n  ----######------------------MM----##MMMM##  ##mm####MM--MM\r\n  --@@######------------------::----####MM######mm####::--++\r\n  --########::--##----##------##----############mm####--MM  \r\n  ######################################################    \r\n                                                            ",
            inteligencia: 95,
            velocidade: 40,
            forca: 25,
            defesa: 30,
            nomeSkill: "Bola de Fogo",
            descSkill: "Lança uma bola de fogo mágica.",
            danoBaseSkill: 80)
        { }
    }
}
