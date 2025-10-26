// Criar uma aplicação de console em C# que faça um CRUD completo,parecido
// com o anterior, mas agora com o tema Cadastro de Livros.

using System;
using System.Collections.Generic;

namespace Desafio_Treinamento_CRUD_Livros
{
    class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Genero { get; set; }
    }

    class Program
    {
        static List<Livros> listaLivros = new List<Livros>();

        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("\nSeja Bem-Vindo(a) a Biblioteca Sertão Veredas!");
                Console.WriteLine("======== Menu Principal ========");
                Console.WriteLine("1. Listar Livros");
                Console.WriteLine("2. Adicionar Livro");
                Console.WriteLine("3. Atualizar Livro");
                Console.WriteLine("4. Deletar Livro");
                Console.WriteLine("5. Sair");
                Console.WriteLine("================================");
                Console.WriteLine("\nEscolha a opção desejada, por favor: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Inserir();
                        break;
                    case 3:
                        Atualizar();
                        break;
                    case 4:
                        Deletar();
                        break;
                    case 5:
                        Console.WriteLine("\nObrigado por utilizar o sistema. Até logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void Listar()
        {
            Console.WriteLine("\nLista de Livros Cadastrados:");
            if (listaLivros.Count == 0)
            {
                Console.WriteLine("\nNenhum livro cadastrado.");
            }
            else
            {
                foreach (var livro in listaLivros)
                {
                    int anos_publicado = CalcularAnosDesdePublicacao(livro.AnoPublicacao);
                    Console.WriteLine($"\nID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Ano de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine($"Gênero: {livro.Genero} | Publicado há {anos_publicado} anos.\n");
                }
            }
        }

        static void Inserir()
        {
            Livros novoLivro = new Livros();

            Console.WriteLine("\nDigite o ID do Livro: ");
            novoLivro.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o Título do Livro: ");
            novoLivro.Titulo = Console.ReadLine();

            Console.WriteLine("\nDigite o Autor do Livro: ");
            novoLivro.Autor = Console.ReadLine();

            Console.WriteLine("\nDigite o Ano de Publicação do Livro: ");
            int.TryParse(Console.ReadLine(), out int ano);
            novoLivro.AnoPublicacao = ano;

            Console.WriteLine("\nDigite o Gênero do Livro: ");
            novoLivro.Genero = Console.ReadLine();
            listaLivros.Add(novoLivro);

            Console.WriteLine("\nLivro cadastrado com sucesso!");
        }

        static void Atualizar()
        {
            Console.WriteLine("\nDigite o ID do Livro que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            var livro = listaLivros.Find(l => l.Id == id);

            if (livro != null)
            {
                Console.WriteLine("\nDigite o novo Título do Livro: ");
                livro.Titulo = Console.ReadLine();

                Console.WriteLine("\nInsisra o novo Autor do Livro: ");
                livro.Autor = Console.ReadLine();

                Console.WriteLine("\nInsira o novo Ano de Publicação do Livro: ");
                int.TryParse(Console.ReadLine(), out int ano);
                livro.AnoPublicacao = ano;

                Console.WriteLine("\nDigite o novo Gênero do Livro: ");
                livro.Genero = Console.ReadLine();

                Console.WriteLine("\nLivro atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado.");
            }
        }

        static void Deletar()
        {
            Console.WriteLine("\nDigite o ID do Livro que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            var livro = listaLivros.Find(l => l.Id == id);

            if (livro != null)
            {
                listaLivros.Remove(livro);
                Console.WriteLine("\nLivro deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado.");
            }
        }

        static int CalcularAnosDesdePublicacao(int anoPublicacao)
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - anoPublicacao;
        }
    }
}