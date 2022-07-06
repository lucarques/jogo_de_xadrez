using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.WriteLine("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.executaMovimento(origem, destino);
                }
                Tela.ImprimirTabuleiro(partida.Tabuleiro);

            }
            catch (TabuleiroException exception)
            {
                Console.WriteLine(exception.Message);
            }


            Console.ReadLine();
        }
    }
}
