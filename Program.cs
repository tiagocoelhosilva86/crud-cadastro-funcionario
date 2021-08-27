using System;
using App.Cadastro.Classes;

namespace App.Cadastro
{
    class Program
    {
        static FuncionarioRepositorio repositorio = new FuncionarioRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFuncionario();
                        break;
                    case "2":
                        InserirFuncionario();
                        break;
                    case "3":
                        AtualizarFuncionario();
                        break;
                    case "4":
                        ExcluirFuncionario();
                        break;
                    case "5":
                        VisualizarFuncionario();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado Por Realizar Seu Cadastro.");
            Console.ReadLine();
        }

        private static void ExcluirFuncionario()
        {
            Console.Write("Digite o id do Funcionario: ");
            int Funcionario = int.Parse(Console.ReadLine());

            repositorio.Exclui(Funcionario);
        }

        private static void VisualizarFuncionario()
        {
            Console.WriteLine("Digite o id do Funcionario: ");
            int indiceFuncionario = int.Parse(Console.ReadLine());

            var Funcionario = repositorio.RetornaPorId(indiceFuncionario);

            Console.WriteLine(Funcionario);
        }
		
        private static void InserirFuncionario()
        {
            Console.WriteLine("Inserir novo Funcionario");


            Console.Write("Digite o nome do Funcionario: ");
            String entradaNome = Console.ReadLine();

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EGenero), i));
            }
            Console.Write("Digite o Genero, conforme as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite a Idade do Funcionario: ");
            int entradaIdade = int.Parse(Console.ReadLine());

            Funcionarios novoFuncionario = new Funcionarios(id: repositorio.proximoid(),
                                                            sexo: (EGenero)entradaGenero,
                                                            nome: entradaNome,
                                                            idade: entradaIdade);

            repositorio.Insere(novoFuncionario);

        }

        private static void AtualizarFuncionario()
        {
            Console.Write("Digite o id do Funcionario: ");
            int funcionarioId = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Funcionario: ");
            String entradaNome = Console.ReadLine();

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EGenero), i));
            }
            Console.Write("Digite o Genero, conforme as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite a Idade do Funcionario: ");
            int entradaIdade = int.Parse(Console.ReadLine());

            Funcionarios atualizaFuncionario = new Funcionarios(id: funcionarioId,
                                        sexo: (EGenero)entradaGenero,
                                       nome: entradaNome,
                                      idade: entradaIdade);

            repositorio.Atualiza(funcionarioId, atualizaFuncionario);
        }
        private static void ListarFuncionario()
        {
            Console.WriteLine("Listar Funcionario");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Funcionario cadastrado.");
                return;
            }

            foreach (var Funcionario in lista)
            {
                var excluido = Funcionario.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", Funcionario.retornaId(), Funcionario.retornaNome(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem Vindo ao Seu Cadastro !!! ");
            Console.WriteLine(" Informe a opção escolha: ");

            Console.WriteLine(" 1- Listar Funcionarios ");
            Console.WriteLine(" 2- Inserir novo Funcionario ");
            Console.WriteLine(" 3- Atualizar Funcionario ");
            Console.WriteLine(" 4- Excluir Funcionario ");
            Console.WriteLine(" 5- Visualizar Funcionario ");
            Console.WriteLine(" C- Limpar Tela ");
            Console.WriteLine(" X-Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}


