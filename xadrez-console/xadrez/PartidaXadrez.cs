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
        public bool Xeque { get; private set; }

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

        public Peca executaMovimento (Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(peca, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if(pecaCapturada != null)
            {
                Tabuleiro.colocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tabuleiro.colocarPeca(p, origem);
            
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

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

        private Cor adversaria (Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        
        private Peca rei (Cor cor)
        {
            foreach(Peca peca in pecasEmJogo(cor))
            {
                if(peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca peca in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = peca.movimentosPossiveis();
                if (matriz[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;

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
