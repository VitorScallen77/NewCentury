using System;

namespace CalculoReajusteSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o salário do colaborador: ");
            double salario = Convert.ToDouble(Console.ReadLine());

            double percentual = 0;
            double aumento = 0;

            if (salario <= 280)
            {
                percentual = 0.2; // 20%
            }
            else if (salario > 280 && salario <= 700)
            {
                percentual = 0.15; // 15%
            }
            else if (salario > 700 && salario <= 1500)
            {
                percentual = 0.1; // 10%
            }
            else
            {
                percentual = 0.05; // 5%
            }

            aumento = salario * percentual;
            double novoSalario = salario + aumento;

            Console.WriteLine($"Salário antes do reajuste: R$ {salario}");
            Console.WriteLine($"Percentual de aumento aplicado: {percentual * 100}%");
            Console.WriteLine($"Valor do aumento: R$ {aumento}");
            Console.WriteLine($"Novo salário após o aumento: R$ {novoSalario}");

            Console.ReadLine();
        }
    }
}
