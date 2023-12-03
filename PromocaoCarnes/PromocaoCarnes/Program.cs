using System;

namespace PromocaoCarnes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Promoção de Carnes - Mercado XXXXXXX");
            Console.WriteLine("Escolha o tipo de carne:");
            Console.WriteLine("1 - File Duplo");
            Console.WriteLine("2 - Alcatra");
            Console.WriteLine("3 - Picanha");
            int tipoCarne = Convert.ToInt32(Console.ReadLine());

            string nomeCarne = "";
            double precoPorKg = 0;

            switch (tipoCarne)
            {
                case 1:
                    nomeCarne = "File Duplo";
                    precoPorKg = 4.9;
                    break;
                case 2:
                    nomeCarne = "Alcatra";
                    precoPorKg = 5.9;
                    break;
                case 3:
                    nomeCarne = "Picanha";
                    precoPorKg = 6.9;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    return;
            }

            Console.WriteLine("Digite a quantidade em quilos:");
            double quantidade = Convert.ToDouble(Console.ReadLine());

            double precoTotal = precoPorKg * quantidade;
            string tipoPagamento = "";
            double desconto = 0;
            double valorAPagar = precoTotal;

            Console.WriteLine("A compra será realizada no cartão Tabajara? (S/N)");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                tipoPagamento = "Cartão Tabajara";
                desconto = precoTotal * 0.05;
                valorAPagar = precoTotal - desconto;
            }
            else if (resposta.ToLower() == "n")
            {
                tipoPagamento = "Outro";
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                return;
            }

            Console.WriteLine("\n======= Cupom Fiscal =======");
            Console.WriteLine($"Tipo de carne: {nomeCarne}");
            Console.WriteLine($"Quantidade: {quantidade} Kg");
            Console.WriteLine($"Preço total: R$ {precoTotal:F2}");
            Console.WriteLine($"Tipo de pagamento: {tipoPagamento}");
            Console.WriteLine($"Valor do desconto: R$ {desconto:F2}");
            Console.WriteLine($"Valor a pagar: R$ {valorAPagar:F2}");
        }
    }
}
