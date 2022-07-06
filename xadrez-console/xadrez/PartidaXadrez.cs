using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();

        }

        public void executaMovimento (Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(peca, destino);
        }
        private void colocarPecas()
        {
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.colocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.colocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());

        }

    }
}
