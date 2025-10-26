// Criar uma aplicação de console em C# que faça um CRUD completo,parecido
// com o anterior, mas agora com o tema Cadastro de Livros.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_Treinamento_CRUD_Livros
{
    class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Genero { get; set; }
        public bool Lido { get; set; }
    }

    class Program
    {
        static List<Livros> listaLivros = new List<Livros>();

        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 8)
            {
                Console.WriteLine("\nSeja Bem-Vindo(a) a Biblioteca Sertão Veredas!");
                Console.WriteLine("======== Menu Principal ========");
                Console.WriteLine("1. Listar todos os Livros");
                Console.WriteLine("2. Adicionar novo Livro");
                Console.WriteLine("3. Atualizar informações de um Livro");
                Console.WriteLine("4. Deletar Livro");
                Console.WriteLine("5. Buscar livros por gênero");
                Console.WriteLine("6. Marcar livro como lido/não lido");
                Console.WriteLine("7. Mostrar estatísticas sobre livros");
                Console.WriteLine("8. Sair");
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
                        BuscaPorGenero();
                        break;
                    case 6:
                        MarcarLidoNaoLido();
                        break;
                    case 7:
                        MostrarEstatisticas();
                        break;
                    case 8:
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
                    int anos_publicado = Math.Max(0, CalcularAnosDesdePublicacao(livro.AnoPublicacao));
                    Console.WriteLine($"\nID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Ano de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine($"Gênero: {livro.Genero} | Publicado há {anos_publicado} anos | Status: {(livro.Lido ? "LIDO" : "NÃO LIDO")}");
                }
            }
        }

        static void Inserir()
        {
            Livros novoLivro = new Livros();

            Console.WriteLine("\nDigite o ID do Livro: ");
            int.TryParse(Console.ReadLine(), out int id);
            novoLivro.Id = id;

            Console.WriteLine("\nDigite o Título do Livro: ");
            novoLivro.Titulo = Console.ReadLine().ToUpper(); // ToUpper() -> Converte o título para maiúsculas

            // Validação do Título
            if (string.IsNullOrWhiteSpace(novoLivro.Titulo))
            {
                Console.WriteLine("Otítulo não pode ficar em branco!");
                return;
            }

            Console.WriteLine("\nDigite o Autor do Livro: ");
            novoLivro.Autor = Console.ReadLine().ToUpper(); // ToUpper() -> Converte o autor para maiúsculas

            Console.WriteLine("\nDigite o Ano de Publicação do Livro: ");
            int.TryParse(Console.ReadLine(), out int ano);
            novoLivro.AnoPublicacao = ano;

            Console.WriteLine("\nDigite o Gênero do Livro: ");
            novoLivro.Genero = Console.ReadLine().ToUpper(); // ToUpper() -> Converte o gênero para maiúsculas

            listaLivros.Add(novoLivro);

            Console.WriteLine("\nLivro cadastrado com sucesso!");
        }

        static void Atualizar()
        {
            Console.WriteLine("\nDigite o ID do Livro que deseja atualizar: ");
            
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                return;
            }

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
            
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                return;
            }

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
       
        static void BuscaPorGenero()
        {
            Console.WriteLine("\nDigite o gênero que deseja buscar: ");
            string generoBusca = Console.ReadLine().ToUpper();

            var livrosEncontrados = listaLivros.FindAll(l => l.Genero.ToUpper().Contains(generoBusca));
            
            if (livrosEncontrados.Count > 0)
            {
                Console.WriteLine($"\nLivros encontrados no gênero '{generoBusca}':");
                foreach (var livro in livrosEncontrados)
                {
                    Console.WriteLine($"\nID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Ano de Publicação: {livro.AnoPublicacao}\n");
                }
            }
            else
            {
                Console.WriteLine($"\nNenhum livro encontrado no gênero '{generoBusca}'.");
            }
        }

        static void MarcarLidoNaoLido()
        {
            Console.Write("\nDigite o título do livro que deseja atualizar: ");
            string tituloBusca = Console.ReadLine().ToUpper();

            var livro = listaLivros.Find(l => l.Titulo.ToUpper() == tituloBusca);

            if (livro == null)
            {
                Console.WriteLine("\nLivro não encontrado!");
                return;
            }

            Console.WriteLine($"\nLivro encontrado: {livro.Titulo} (Status atual: {(livro.Lido ? "LIDO" : "NÃO LIDO")})");
            Console.Write("Deseja marcar como LIDO (S/N)? ");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "S")
            {
                livro.Lido = true;
                Console.WriteLine("Livro marcado como LIDO!");
            }
            else
            {
                livro.Lido = false;
                Console.WriteLine("Livro marcado como NÃO LIDO!");
            }
        }

        static void MostrarEstatisticas()
        {
            int totalLidos = 0;
            int totalNaoLidos = 0;

            foreach (var livro in listaLivros)
            {
                if (livro.Lido)
                    totalLidos++;
                else
                    totalNaoLidos++;
            }

            Console.WriteLine("\n===== ESTATÍSTICAS =====");
            Console.WriteLine($"Total de livros cadastrados: {listaLivros.Count}");
            Console.WriteLine($"Livros lidos: {totalLidos}");
            Console.WriteLine($"Livros não lidos: {totalNaoLidos}");
        }

        static int CalcularAnosDesdePublicacao(int anoPublicacao)
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - anoPublicacao;
        }
    }
}