namespace tabuleiro
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

        public Peca Peca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return Peca(posicao) != null;
        }
        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if(existePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
        public Peca retirarPeca(Posicao posicao)
        {
            if (Peca(posicao) == null)
            {
                return null;
            }
            Peca auxiliar = Peca(posicao);
            auxiliar.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return auxiliar;
            
        }
        
        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
