using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Dictionary<string, List<int>> filmesRegistrados = new Dictionary<string, List<int>>
    {
        { "A Culpa é das Estrelas", new List<int> { 8, 6, 10 } },
        { "UP", new List<int> { 10, 9, 3 } },
        { "A Pequena Sereia", new List<int> { 6, 5, 10 } }
    };


    static void Main()
    {
        ExibirOpcoesDoMenu();
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@"

███████████████████████████████████████████████████████████
█▄─▀█▀─▄█─▄▄─█▄─█─▄█▄─▄█▄─▄▄─█─▄▄▄▄█─▄─▄─█─▄▄─█▄─▄▄▀█▄─█─▄█
██─█▄█─██─██─██▄▀▄███─███─▄█▀█▄▄▄▄─███─███─██─██─▄─▄██▄─▄██
▀▄▄▄▀▄▄▄▀▄▄▄▄▀▀▀▄▀▀▀▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀
");
        Console.WriteLine("Bem-vindo ao MovieStory!");
    }

    static void ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar um filme");
        Console.WriteLine("Digite 2 para mostrar todos os filmes");
        Console.WriteLine("Digite 3 para avaliar um filme");
        Console.WriteLine("Digite 4 para exibir a média de um filme");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                RegistrarFilme();
                break;
            case 2:
                MostrarFilmesRegistrados();
                break;
            case 3:
                AvaliarUmFilme();
                break;
            case 4:
                ExibirMedia();
                break;
            case -1:
                Console.WriteLine("Até logo! :)");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    static void RegistrarFilme()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro de Filmes");
        Console.Write("Digite o nome do filme que deseja registrar: ");
        string nomeDoFilme = Console.ReadLine();
        filmesRegistrados.Add(nomeDoFilme, new List<int>());
        Console.WriteLine($"O filme {nomeDoFilme} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    static void MostrarFilmesRegistrados()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Todos os Filmes Registrados");

        foreach (string filme in filmesRegistrados.Keys)
        {
            Console.WriteLine($"Filme: {filme}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    static void AvaliarUmFilme()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar Filme");
        Console.Write("Digite o nome do filme que deseja avaliar: ");
        string nomeDoFilme = Console.ReadLine();

        if (filmesRegistrados.ContainsKey(nomeDoFilme))
        {
            Console.Write($"Qual nota você dá para o filme {nomeDoFilme}? ");
            int nota = int.Parse(Console.ReadLine());
            filmesRegistrados[nomeDoFilme].Add(nota);
            Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o filme {nomeDoFilme}");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"\nO filme {nomeDoFilme} não foi encontrado!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }

    static void ExibirMedia()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir Média do Filme");
        Console.Write("Digite o nome do filme que deseja exibir a média: ");
        string nomeDoFilme = Console.ReadLine();

        if (filmesRegistrados.ContainsKey(nomeDoFilme))
        {
            List<int> notasDoFilme = filmesRegistrados[nomeDoFilme];
            Console.WriteLine($"\nA média do filme {nomeDoFilme} é {notasDoFilme.Average()}.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"\nO filme {nomeDoFilme} não foi encontrado!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
}
