namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca( Cor cor,Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            Tabuleiro = tabuleiro;
        }

        public void incrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public void decrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j=0; j < Tabuleiro.Colunas; j++)
                {
                    if (matriz [i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel (Posicao posicao)
        {
            return movimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();
       
    }
}
