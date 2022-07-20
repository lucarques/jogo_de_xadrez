using tabuleiro;

namespace xadrez
{
    class Rei: Peca
    {
        public Rei (Tabuleiro tabuleiro, Cor cor): base (cor, tabuleiro)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        private bool podeMover (Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool [,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            //acima

            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.posicaoValida (posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //nordeste
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna +1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //direta
            posicao.definirValores(Posicao.Linha , Posicao.Coluna +1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }
            //sudeste
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna +1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //sul
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //suldoeste
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }

            //noroeste 
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

            }
            return matriz;







        }

    }
    

}
