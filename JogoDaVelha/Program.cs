using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogadorAtual = 1; // Começa com jogador 1
        static int jogadas = 0;

        static void Main(string[] args)
        {
            bool jogando = true;
            while (jogando)
            {
                DesenharTabuleiro();
                Console.WriteLine($"Jogador {jogadorAtual}, digite a posição que deseja marcar: ");
                int posicao = int.Parse(Console.ReadLine()) - 1;

                if (posicao >= 0 && posicao < 9 && tabuleiro[posicao] != 'X' && tabuleiro[posicao] != 'O')
                {
                    tabuleiro[posicao] = jogadorAtual == 1 ? 'X' : 'O';
                    jogadas++;
                    if (VerificarVitoria())
                    {
                        DesenharTabuleiro();
                        Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                        jogando = false;
                    }
                    else if (jogadas == 9)
                    {
                        DesenharTabuleiro();
                        Console.WriteLine("Empate!");
                        jogando = false;
                    }
                    else
                    {
                        jogadorAtual = jogadorAtual == 1 ? 2 : 1;
                    }
                }
                else
                {
                    Console.WriteLine("Posição inválida. Tente novamente.");
                }
            }
        }

        static void DesenharTabuleiro()
        {
            Console.Clear();
            Console.WriteLine(" " + tabuleiro[0] + " | " + tabuleiro[1] + " | " + tabuleiro[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + tabuleiro[3] + " | " + tabuleiro[4] + " | " + tabuleiro[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + tabuleiro[6] + " | " + tabuleiro[7] + " | " + tabuleiro[8]);
        }

        static bool VerificarVitoria()
        {
            // Verifica linhas, colunas e diagonais
            if ((tabuleiro[0] == tabuleiro[1] && tabuleiro[1] == tabuleiro[2]) ||
                (tabuleiro[3] == tabuleiro[4] && tabuleiro[4] == tabuleiro[5]) ||
                (tabuleiro[6] == tabuleiro[7] && tabuleiro[7] == tabuleiro[8]) ||
                (tabuleiro[0] == tabuleiro[3] && tabuleiro[3] == tabuleiro[6]) ||
                (tabuleiro[1] == tabuleiro[4] && tabuleiro[4] == tabuleiro[7]) ||
                (tabuleiro[2] == tabuleiro[5] && tabuleiro[5] == tabuleiro[8]) ||
                (tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8]) ||
                (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6]))
            {
                return true;
            }
            return false;
        }
    }
}