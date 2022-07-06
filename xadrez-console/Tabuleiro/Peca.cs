namespace tabuleiro
{
    class Peca
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
    }
}
