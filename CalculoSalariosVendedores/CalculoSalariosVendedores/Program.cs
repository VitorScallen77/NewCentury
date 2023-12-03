using System;
using System.Collections.Generic;

namespace CalculoSalariosVendedores
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> contadores = new List<int>(10); // Lista para armazenar os contadores das faixas salariais

            // Inicializa os contadores com zero para cada faixa salarial
            for (int i = 0; i < 10; i++)
            {
                contadores.Add(0);
            }

            Console.WriteLine("Digite as vendas brutas dos vendedores (digite -1 para encerrar):");

            double vendaBruta;
            do
            {
                vendaBruta = Convert.ToDouble(Console.ReadLine());

                if (vendaBruta >= 0)
                {
                    double salario = 200 + (0.09 * vendaBruta);

                    // Calcula o índice da lista baseado no salário e atualiza o contador correspondente
                    int indice = (int)((salario - 200) / 100);
                    if (indice >= 0 && indice <= 9)
                    {
                        contadores[indice]++;
                    }
                    else
                    {
                        contadores[9]++; // Contador para $1000 em diante
                    }
                }
            } while (vendaBruta >= 0);

            Console.WriteLine("\nQuantidade de vendedores em cada faixa salarial:");

            // Exibe a contagem de vendedores em cada faixa salarial
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"${200 + i * 100} - ${299 + i * 100}: {contadores[i]} vendedores");
            }
            Console.WriteLine($"$1000 em diante: {contadores[9]} vendedores");
        }
    }
}
