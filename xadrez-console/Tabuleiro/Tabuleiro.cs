﻿namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro (int linha, int colunas)
        {
            Linhas = linha;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
    }
}
