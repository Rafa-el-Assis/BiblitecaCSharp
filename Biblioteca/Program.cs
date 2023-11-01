using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        while (true)
        {
            ExibirOpcoesdoMenu(biblioteca);
        }
    }

    static void ExibirOpcoesdoMenu(Biblioteca biblioteca)
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar um livro");
        Console.WriteLine("Digite 2 para ver todo o acervo da biblioteca");
        Console.WriteLine("Digite 3 para procurar um livro por nome, autor ou numero");
        Console.WriteLine("Digite 4 para alugar um livro");
        Console.WriteLine("Digite 5 para saber quais livros foram alugados");
        Console.WriteLine("Digite -1 para fechar a aplicação");

        while (true)
        {
            Console.WriteLine("\nDigite a opção desejada:");
            string opcaoEscolhida = Console.ReadLine();
            int opcaoEscolhidaNumerica;

            if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarLivros(biblioteca);
                        break;
                    case 2:
                        ListarLivros(biblioteca);
                        break;
                    case 3:
                        MenuBuscaNumeros(biblioteca);
                        break;
                    case 4:
                        ListarLivrosDisponiveis(biblioteca);
                        break;
                    case 5:
                        ListarLivrosAlugados(biblioteca);
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau :)");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Digite um número válido.");
            }
        }
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@"
██████╗░██╗██████╗░██╗░░░░░██╗░█████╗░████████╗███████╗░█████╗░░█████╗░
██╔══██╗██║██╔══██╗██║░░░░░██║██╔══██╗╚══██╔══╝██╔════╝██╔══██╗██╔══██╗
██████╦╝██║██████╦╝██║░░░░░██║██║░░██║░░░██║░░░█████╗░░██║░░╚═╝███████║
██╔══██╗██║██╔══██╗██║░░░░░██║██║░░██║░░░██║░░░██╔══╝░░██║░░██╗██╔══██║
██████╦╝██║██████╦╝███████╗██║╚█████╔╝░░░██║░░░███████╗╚█████╔╝██║░░██║
╚═════╝░╚═╝╚═════╝░╚══════╝╚═╝░╚════╝░░░░╚═╝░░░╚══════╝░╚════╝░╚═╝░░╚═╝

██╗░░░░░██╗██╗░░░██╗██████╗░░█████╗░░██████╗██╗
██║░░░░░██║██║░░░██║██╔══██╗██╔══██╗██╔════╝██║
██║░░░░░██║╚██╗░██╔╝██████╔╝██║░░██║╚█████╗░██║
██║░░░░░██║░╚████╔╝░██╔══██╗██║░░██║░╚═══██╗╚═╝
███████╗██║░░╚██╔╝░░██║░░██║╚█████╔╝██████╔╝██╗
╚══════╝╚═╝░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝");
    }

    static void RegistrarLivros(Biblioteca biblioteca)
    {
        Console.Write("Digite o nome do autor: ");
        string nomeAutor = Console.ReadLine();
        Console.Write("Digite o nome do livro: ");
        string nomeLivro = Console.ReadLine();
        Console.Write("Digite o número do livro: ");
        if (int.TryParse(Console.ReadLine(), out int numeroLivro))
        {
            biblioteca.RegistrarLivro(nomeAutor, nomeLivro, numeroLivro);
            Console.WriteLine("Livro registrado com sucesso!");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesdoMenu(biblioteca);
        }
        else
        {
            Console.WriteLine("Número de livro inválido.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesdoMenu(biblioteca);
        }
    }

    static void ListarLivros(Biblioteca biblioteca)
    {
        List<Livro> todosLivros = biblioteca.ListarTodosLivros();
        if (todosLivros.Count > 0)
        {
            Console.WriteLine("Livros registrados:");
            foreach (var livro in todosLivros)
            {
                Console.WriteLine($"Autor: {livro.NomeAutor}, Livro: {livro.NomeLivro}, Número: {livro.Numero}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro registrado.");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdoMenu(biblioteca);
    }

    static void MenuBuscaNumeros(Biblioteca biblioteca)
    {
        Console.Write("Digite o nome, autor ou número do livro que deseja buscar: ");
        string termoBusca = Console.ReadLine();
        Livro livroEncontrado = null;

        if (int.TryParse(termoBusca, out int numeroBusca))
        {
            livroEncontrado = biblioteca.BuscarLivroPorNumero(numeroBusca);;
        }
        else
        {
            livroEncontrado = biblioteca.BuscarLivroPorNome(termoBusca);
            if (livroEncontrado == null)
            {
                livroEncontrado = biblioteca.BuscarLivroPorAutor(termoBusca);
            }
        }

        if (livroEncontrado != null)
        {
            Console.WriteLine($"Livro encontrado: Autor: {livroEncontrado.NomeAutor}, Livro: {livroEncontrado.NomeLivro}, Número: {livroEncontrado.Numero}");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesdoMenu(biblioteca);
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesdoMenu(biblioteca);
        }
    }
    static void ListarLivrosDisponiveis(Biblioteca biblioteca)
    {
        List<Livro> livrosDisponiveis = biblioteca.ListarLivrosDisponiveis();

        if (livrosDisponiveis.Count > 0)
        {
            Console.WriteLine("Livros disponíveis para alugar:");
            foreach (var livro in livrosDisponiveis)
            {
                Console.WriteLine($"Número: {livro.Numero}, Autor: {livro.NomeAutor}, Livro: {livro.NomeLivro}");
            }

            Console.WriteLine("\nDigite o número do livro que deseja alugar (ou -1 para voltar ao menu principal):");
            if (int.TryParse(Console.ReadLine(), out int numeroLivro))
            {
                if (numeroLivro == -1)
                {
                    Console.Clear();
                    ExibirOpcoesdoMenu(biblioteca);
                }
                else
                {
                    bool sucesso = biblioteca.AlugarLivro(numeroLivro);
                    if (sucesso)
                    {
                        Console.WriteLine("Livro alugado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado ou já alugado.");
                    }

                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesdoMenu(biblioteca);
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro disponível para alugar.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesdoMenu(biblioteca);
        }
    }

    static void ListarLivrosAlugados(Biblioteca biblioteca)
    {
        List<Livro> livrosAlugados = biblioteca.ListarLivrosAlugados();

        if (livrosAlugados.Count > 0)
        {
            Console.WriteLine("Livros alugados:");
            foreach (var livro in livrosAlugados)
            {
                Console.WriteLine($"Número: {livro.Numero}, Autor: {livro.NomeAutor}, Livro: {livro.NomeLivro}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro alugado no momento.");
            Console.WriteLine("Caso queria ver os livros Disponiveis volte no menu principal na opção 2");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdoMenu(biblioteca);
    }

}

public class Livro
{
    public string NomeAutor { get; set; }
    public string NomeLivro { get; set; }
    public int Numero { get; set; }
    public bool Alugado { get; set; }

}

public class Biblioteca
{
    private List<Livro> livros = new List<Livro>();

    public List<Livro> ListarLivrosDisponiveis()
    {
        return livros.Where(l => !l.Alugado).ToList();
    }

    public List<Livro> ListarLivrosAlugados()
    {
        return livros.Where(l => l.Alugado).ToList();
    }

    public bool AlugarLivro(int numero)
    {
        Livro livro = livros.FirstOrDefault(l => l.Numero == numero && !l.Alugado);
        if (livro != null)
        {
            livro.Alugado = true;
            return true;
        }
        return false;
    }

    public void RegistrarLivro(string nomeAutor, string nomeLivro, int numero)
    {
        Livro livro = new Livro
        {
            NomeAutor = nomeAutor,
            NomeLivro = nomeLivro,
            Numero = numero
        };
        livros.Add(livro);
    }

    public Livro BuscarLivroPorNome(string nome)
    {
        return livros.FirstOrDefault(l => l.NomeLivro == nome);
    }

    public Livro BuscarLivroPorAutor(string autor)
    {
        return livros.FirstOrDefault(l => l.NomeAutor == autor);
    }

    public Livro BuscarLivroPorNumero(int numero)
    {
        return livros.FirstOrDefault(l => l.Numero == numero);
    }

    public List<Livro> ListarTodosLivros()
    {
        return livros;
    }
}
