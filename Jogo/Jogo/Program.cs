using System;
using System.Collections.Generic;

enum Resultado { SUCCESS, WRONG }

class Jogada
{
    public int COD_JOGADOR { get; set; }
    public int NUM_TENTATIVA { get; set; }
    public DateTime DATA_HORA { get; set; }
    public Resultado RESULTADO { get; set; }
}

class Historico
{
    public List<Jogada> ListaJogadas { get; set; }

    public Historico()
    {
        ListaJogadas = new List<Jogada>();
    }

    public void AdicionarJogada(Jogada jogada)
    {
        ListaJogadas.Add(jogada);
    }

    public void MostrarHistorico()
    {
        foreach (var jogada in ListaJogadas)
        {
            Console.WriteLine($"Jogador: {jogada.COD_JOGADOR} - Tentativa: {jogada.NUM_TENTATIVA} - Data/Hora: {jogada.DATA_HORA} - Resultado: {jogada.RESULTADO}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1, 101);

        int tentativas = 0;
        bool acertou = false;
        Historico historico = new Historico();
        int vitorias = 0;
        int derrotas = 0;

        Dictionary<string, int> dificuldades = new Dictionary<string, int>()
        {
            { "Fácil", 10 },
            { "Médio", 7 },
            { "Difícil", 5 }
        };

        Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
        Console.WriteLine("Escolha a dificuldade:");
        foreach (var dificuldade in dificuldades)
        {
            Console.WriteLine($"{dificuldade.Key} - Total de tentativas: {dificuldade.Value}");
        }

        string escolhaDificuldade = Console.ReadLine();
        int totalTentativas = 0;

        if (dificuldades.ContainsKey(escolhaDificuldade))
        {
            totalTentativas = dificuldades[escolhaDificuldade];
        }
        else
        {
            Console.WriteLine("Dificuldade inválida!");
            return;
        }

        while (!acertou && tentativas < totalTentativas)
        {
            Console.WriteLine("Digite o seu palpite:");
            int palpite = Convert.ToInt32(Console.ReadLine());
            tentativas++;

            Jogada novaJogada = new Jogada()
            {
                COD_JOGADOR = 1, // Código do jogador (pode ser atribuído de forma dinâmica)
                NUM_TENTATIVA = tentativas,
                DATA_HORA = DateTime.Now
            };

            if (palpite < numeroAleatorio)
            {
                Console.WriteLine("Tente um número maior.");
                novaJogada.RESULTADO = Resultado.WRONG;
            }
            else if (palpite > numeroAleatorio)
            {
                Console.WriteLine("Tente um número menor.");
                novaJogada.RESULTADO = Resultado.WRONG;
            }
            else
            {
                acertou = true;
                Console.WriteLine($"Parabéns! Você acertou o número {numeroAleatorio} em {tentativas} tentativa(s)!");
                novaJogada.RESULTADO = Resultado.SUCCESS;
                vitorias++;
            }

            historico.AdicionarJogada(novaJogada);
        }

        if (!acertou)
        {
            derrotas++;
            Console.WriteLine($"Suas tentativas acabaram! O número era: {numeroAleatorio}");
        }

        Console.WriteLine("\n======= Histórico de Tentativas =======");
        historico.MostrarHistorico();

        double percentualVitorias = (double)vitorias / (vitorias + derrotas) * 100;
        Console.WriteLine($"\nTotal de vitórias: {vitorias}");
        Console.WriteLine($"Total de derrotas: {derrotas}");
        Console.WriteLine($"Porcentagem de vitória: {percentualVitorias:F}%");

        string rank = "S";
        if (percentualVitorias < 20)
            rank = "E";
        else if (percentualVitorias < 40)
            rank = "D";
        else if (percentualVitorias < 60)
            rank = "C";
        else if (percentualVitorias < 80)
            rank = "B";
        else if (percentualVitorias < 100)
            rank = "A";

        Console.WriteLine($"Classificação: {rank}");
    }
}
