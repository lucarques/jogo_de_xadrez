using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(cor, tabuleiro)
        {

        }
        
        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicaoDestino = new Posicao(0, 0);

            //acima
            posicaoDestino.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.posicaoValida(posicaoDestino) && podeMover(posicaoDestino)) 
            {
                matriz[posicaoDestino.Linha, posicaoDestino.Coluna] = true;
                if (Tabuleiro.Peca(posicaoDestino) != null && Tabuleiro.Peca(posicaoDestino).Cor != Cor)
                {
                    break;
                }
                posicaoDestino.Linha = posicaoDestino.Linha - 1;
            }

            //abaixo
            
            posicaoDestino.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.posicaoValida(posicaoDestino) && podeMover(posicaoDestino))
            {
                matriz[posicaoDestino.Linha, posicaoDestino.Coluna] = true;
                if (Tabuleiro.Peca(posicaoDestino) != null && Tabuleiro.Peca(posicaoDestino).Cor != Cor)
                {
                    break;
                }
                posicaoDestino.Linha = posicaoDestino.Linha + 1;
            }


            //direita
            posicaoDestino.definirValores(Posicao.Linha, Posicao.Coluna +1);
            while (Tabuleiro.posicaoValida(posicaoDestino) && podeMover(posicaoDestino))
            {
                matriz[posicaoDestino.Linha, posicaoDestino.Coluna] = true;
                if (Tabuleiro.Peca(posicaoDestino) != null && Tabuleiro.Peca(posicaoDestino).Cor != Cor)
                {
                    break;
                }
                posicaoDestino.Coluna = posicaoDestino.Coluna + 1;
            }

            //esquerda
            posicaoDestino.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(posicaoDestino) && podeMover(posicaoDestino))
            {
                matriz[posicaoDestino.Linha, posicaoDestino.Coluna] = true;
                if (Tabuleiro.Peca(posicaoDestino) != null && Tabuleiro.Peca(posicaoDestino).Cor != Cor)
                {
                    break;
                }
                posicaoDestino.Coluna = posicaoDestino.Coluna - 1;
            }


            return matriz;


        }


    }
}
