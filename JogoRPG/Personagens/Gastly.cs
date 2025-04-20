using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Gastly : Personagem
    {
        public Gastly(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 85,
            vidaAtual: 85,
            classe: "Fantasma 🟣",
            fotoSimples: @"
                (    )
              _( o__o )_
               \      /
                \____/",
            fotoComplexa: "                             _\r\n                          .\"' `..._\r\n                         '         `.\r\n                       .'      ___..'\r\n                 _   .\"       '   .__,-.,\"\", ,----.\r\n      ,.-\"\"''-..\" :  :        `--'        ' :      :\r\n    .'            :_,'                    `._`\"--. ;\r\n    :              _,.--'\"'\"\"`--._           `.  `\"\r\n   j             ,'               `-.      ,._.'  ,\"\".\r\n   :           ,'                   ,-.   .   __  `..'\r\n   `--.    .'.'                   ,'   `. :_,\"  `.\r\n ,.   ;   .   \\                 ,'      |         `.\r\n' :  :    |    `.             ,'        |\\         `.  _\r\n `.   ._  |      \\         _.'          | .      ___ `\" :\r\n        : '     . \\      ,'  .          ' |     :   `...'\r\n       ,'  \\       `.   .             ,'  |     '  __\r\n      .    `.       |    \\          .'    '    .  (  `.\r\n    .'      \\`.___,'      `-.____.-'     '     :   `-.'\r\n     .   ,\". \\ ..___              _     /      :    .\r\n     :   . :  \\|/\\  `\"'--------+\"|,'  ,'       `-..' :\r\n      `-\" .'   `: `\"-.._______,.\\|  .'               '\r\n          `--. _ `._             _,'        ,\"\"-.__,'\r\n              \" :   `\"--.....--\"'     __   .\r\n              ,-'                 ,.-\"  `-'\r\n             :   ,..             .    ,\"\".\r\n            .'   .  :   __..._   `\"-. :   :\r\n            `.._  : ' ,'      `\"--..' `--\"\r\n                `-' `\" ",
            inteligencia: 70,
            velocidade: 75,
            forca: 45,
            defesa: 35,
            nomeSkill: "Língua Sombria",
            descSkill: "Ataque que pode deixar o inimigo assustado.",
            danoBaseSkill: 65)
        { }
    }
}

