using System;

namespace ResultadoEnquete
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] votos = new int[6]; // Vetor para armazenar os votos de cada sistema operacional
            string[] sistemas = { "Windows Server", "Unix", "Linux", "Netware", "Mac OS", "Outro" };

            Console.WriteLine("Qual o melhor Sistema Operacional para uso em servidores?");
            Console.WriteLine("Informe o voto (de 1 a 6) ou digite 0 para encerrar a enquete:");

            int voto;
            do
            {
                voto = Convert.ToInt32(Console.ReadLine());

                // Verifica se o voto é válido e diferente de 0 (que encerra a enquete)
                if (voto >= 1 && voto <= 6)
                {
                    votos[voto - 1]++; // Incrementa o voto para o sistema correspondente no vetor
                }
                else if (voto != 0)
                {
                    Console.WriteLine("Voto inválido! Informe um número de 1 a 6 ou 0 para encerrar a enquete.");
                }
            } while (voto != 0);

            Console.WriteLine("\nSistema Operacional   Votos   %");
            Console.WriteLine("-------------------   -----   ---");

            int totalVotos = 0;
            for (int i = 0; i < sistemas.Length; i++)
            {
                totalVotos += votos[i];
            }

            double percentual;
            int maisVotado = 0;
            int maiorVoto = 0;

            for (int i = 0; i < sistemas.Length; i++)
            {
                percentual = (votos[i] / (double)totalVotos) * 100;
                Console.WriteLine($"{sistemas[i],-20} {votos[i],-7} {percentual:F}%");

                if (votos[i] > maiorVoto)
                {
                    maisVotado = i;
                    maiorVoto = votos[i];
                }
            }

            Console.WriteLine("-------------------   -----   ---");
            Console.WriteLine($"Total                 {totalVotos,-7}");

            Console.WriteLine($"\nO Sistema Operacional mais votado foi o {sistemas[maisVotado]}, com {maiorVoto} votos, correspondendo a {((double)maiorVoto / totalVotos) * 100:F}% dos votos.");
        }
    }
}
