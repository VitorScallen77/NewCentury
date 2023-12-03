using System;

namespace JogoAdivinhacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 101); // Número aleatório entre 1 e 100

            int tentativas = 0;
            bool acertou = false;

            Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
            Console.WriteLine("Tente adivinhar o número inteiro entre 1 e 100.");

            while (!acertou)
            {
                Console.WriteLine("Digite o seu palpite:");
                int palpite = Convert.ToInt32(Console.ReadLine());
                tentativas++;

                if (palpite < numeroAleatorio)
                {
                    Console.WriteLine("Tente um número maior.");
                }
                else if (palpite > numeroAleatorio)
                {
                    Console.WriteLine("Tente um número menor.");
                }
                else
                {
                    acertou = true;
                    Console.WriteLine($"Parabéns! Você acertou o número {numeroAleatorio} em {tentativas} tentativa(s)!");
                }
            }
        }
    }
}
