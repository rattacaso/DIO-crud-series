using System;
using cadastro.Classes;

namespace cadastro
{
    class Program
    {
        static SerieRepositorios repositorio = new SerieRepositorios();
        static void Main(string[] args)
        {
            string opcao = MenuOpcoes();

            while(opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();               
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentException();    
                }
                opcao = MenuOpcoes();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista das séries cadastradas...");
            
            
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "**Excluido**" : "");
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série: ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} - {1} ",i, Enum.GetName(typeof(Genero),i));
            }
            Console.ForegroundColor = ConsoleColor.White;   
            Console.Write("Digite o GÊNERO entre as opções acima...");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o TÍTULO da série...");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Informe o ANO da série...");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a DESCRIÇÃO da série...");
            string entraDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entraGenero,
                                        titulo: entraTitulo,
                                        ano: entraAno,
                                        descricao: entraDescricao);

            repositorio.Insere(novaSerie);


        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Informe o ID/Código da série que deseja atualizar... ");
            int indiceSerie =  int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o GÊNERO entre as opções acima ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o TÍTULO da série...");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Informe o ANO da série...");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a DESCRIÇÃO da série...");
            string entraDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entraGenero,
                                        titulo: entraTitulo,
                                        ano: entraAno,
                                        descricao: entraDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);


        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Excluir série - Informe o ID que deseja EXCLUIR...");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Confirma a Exclusão da série? S -> Sim | N - Não");
            string confirmacao = Console.ReadLine().ToUpper();
            if (confirmacao == "S")
            {
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("Item marcado como Excluído!");
            }
            else if (confirmacao == "N")
            {
                Console.Clear();
            } else
            {
             Console.ForegroundColor = ConsoleColor.Yellow;
             Console.WriteLine("Valor Inválido, Informe Apenas (S) para Excluir ou (N) para cancelar.");
            }
            Console.ForegroundColor = ConsoleColor.White;
            

        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Informe o ID da série para obter informações...");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static string MenuOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("***** Exercício da Aula: Criando um cadastro simples - Digital Inovation One *****");
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("");
            
            Console.WriteLine("1 - LISTAR SÉRIES");
            
            Console.WriteLine("2 - INSERIR NOVA SÉRIE");
            
            Console.WriteLine("3 - ATUALIZAR INFORMAÇÕES DE UMA SÉRIE");
           
            Console.WriteLine("4 - EXCLUIR SÉRIE");
            
            Console.WriteLine("5 - VISUALIZAR SÉRIE");
            
            Console.WriteLine("C - LIMPAR TELA");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("X - SAIR");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
