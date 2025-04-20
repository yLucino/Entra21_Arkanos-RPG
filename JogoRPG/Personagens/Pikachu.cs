using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPG
{
    internal class Pikachu : Personagem
    {
        public Pikachu(string nome, string descricao) : base(
            nome,
            descricao,
            vidaMax: 100,
            vidaAtual: 100,
            classe: "Elétrico ⚡",
            fotoSimples: @"
            (\__/)
            (•ㅅ•) 
            /つ つ",
            fotoComplexa: "\\:.             .:/\r\n        \\``._________.''/ \r\n         \\             / \r\n .--.--, / .':.   .':. \\\r\n/__:  /  | '::' . '::' |\r\n   / /   |`.   ._.   .'|\r\n  / /    |.'         '.|\r\n /___-_-,|.\\  \\   /  /.|\r\n      // |''\\.;   ;,/ '|\r\n      `==|:=         =:|\r\n         `.          .'\r\n           :-._____.-:\r\n          `''       `''",
            inteligencia: 50,
            velocidade: 80,
            forca: 55,
            defesa: 40,
            nomeSkill: "Choque do Trovão",
            descSkill: "Dano elétrico com chance de paralisar o inimigo.",
            danoBaseSkill: 60)
        { }
    }
}
