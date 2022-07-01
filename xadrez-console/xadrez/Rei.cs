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

    }
    

}
