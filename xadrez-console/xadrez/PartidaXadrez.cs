using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();

        }

        public void executaMovimento (Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(peca, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }
        
        public void validaPosicaoOrigem(Posicao posicao)
        {
            if(Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida. [Pressione 'ENTER' para continuar!]");
            }
            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem não é sua! [Pressione 'ENTER' para continuar!]");

            }
            if (!Tabuleiro.Peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida! [Pressione 'ENTER' para continuar!]");
            }
        }
        public void  validarPosicaoDestino (Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! [Pressione 'ENTER' para continuar!]");
            }
        }




        private void mudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca peca in Capturadas)
            {
                if (peca.Cor == cor)
                {
                    auxiliar.Add(peca);
                }
            }
            return auxiliar;
        }


        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    auxiliar.Add(peca);
                }
            }
            auxiliar.ExceptWith(pecasCapturadas(cor));
            return auxiliar;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));

        }

    }
}
