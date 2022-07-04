using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez posicao = new PosicaoXadrez('a', 1);

            Console.WriteLine(posicao);

            Console.WriteLine(posicao.ToPosicao());
            Console.ReadLine();
        }
    }
}
