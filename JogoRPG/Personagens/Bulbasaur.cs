using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Bulbasaur : Personagem
    {
        public Bulbasaur(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 105,
            vidaAtual: 105,
            classe: "Planta 🍃",
            fotoSimples: @"
               /\
              /__\   _ 
             (o__o)_/_\
            /(_  _) _ /",
            fotoComplexa: "             `;,;.;,;.;.'\r\n              ..:;:;::;: \r\n        ..--''' '' ' ' '''--.  \r\n      /' .   .'        '.   .`\\\r\n     | /    /            \\   '.|\r\n     | |   :             :    :|\r\n   .'| |   :             :    :|\r\n ,: /\\ \\.._\\ __..===..__/_../ /`.\r\n|'' |  :.|  `'          `'  |.'  ::.\r\n|   |  ''|    :'';          | ,  `''\\\r\n|.:  \\/  | /'-.`'   ':'.-'\\ |  \\,   |\r\n| '  /  /  | / |...   | \\ |  |  |';'|\r\n \\ _ |:.|  |_\\_|`.'   |_/_|  |.:| _ |\r\n/,.,.|' \\__       . .      __/ '|.,.,\\\r\n     | ':`.`----._____.---'.'   |\r\n      \\   `:\"\"\"-------'\"\"' |   |\r\n       ',-,-',             .'-=,=,",
            inteligencia: 60,
            velocidade: 45,
            forca: 50,
            defesa: 55,
            nomeSkill: "Semente Sanguessuga",
            descSkill: "Planta uma semente no inimigo e recupera vida a cada turno.",
            danoBaseSkill: 50,
            maxPPSkill: 2,
            atualPPSkill: 2,
            status: "Acordado")
        { }
    }
}

