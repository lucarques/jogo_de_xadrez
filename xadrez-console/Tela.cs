using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int i=0; i < tabuleiro.Linhas; i++)
            {
                for (int j=0; j< tabuleiro.Colunas; j++)
                {
                    Console.Write(tabuleiro.Peca(i,j) + " ");
                    if (tabuleiro.Peca (i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.Peca(i,j)+ " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
