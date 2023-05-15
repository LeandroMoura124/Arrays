
using Arrays.bytebank.Exception;
using bytebank.Modelos.Conta;


namespace Arrays.byteBankAtendimento
{
    public class ByteBankAtendimento
    {
         #region Trabalhando com objeto em ContaCorrente uma List
       private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
            new ContaCorrente(95, "123456-X"){Saldo = 100, Titular = new Cliente {Cpf = "111111", Nome = "Leandro", Profissao = "dev" }},
            new ContaCorrente(95, "457894-X"){Saldo = 100, Titular = new Cliente {Cpf = "556145", Nome = "Fernando" }},
            new ContaCorrente(92, "213243-X"){Saldo = 200, Titular = new Cliente {Cpf = "222222", Nome = "Maria" }},
            new ContaCorrente(75, "988776-X"){Saldo = 60, Titular = new Cliente {Cpf = "333333", Nome = "João" }},
        };
        // _listaDeContas[0].Titular._nome ="Leandro";
        // _listaDeContas[0].Titular.Cpf ="49931503858";
        // _listaDeContas[0].Titular.Profissao ="Dev";

        public void AtendimentoCliente()
        {   
            try
            {
                char opcao = '0';
                while (opcao != '6'){
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");
                //tratando a excecao caso o usuariodigite um numero inválido
                try
                {
                    opcao = Console.ReadLine()[0];

                }
                catch (System.Exception excecao)
                {
                    
                    throw new ByteBankExceptionsException(excecao.Message);
                }
                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    case '6':
                        EncerrarAplicacao();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
            }
        
            catch (ByteBankExceptionsException excecao)
            {
                
                System.Console.WriteLine($"{excecao.Message}");
            } 
        }

        private void EncerrarAplicacao()
        {
            System.Console.WriteLine("Encerrando a aplicação");
            Console.ReadKey();
        }

        private void CadastrarConta()
        
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");
            // Console.Write("Número da conta: ");
            // string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            System.Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Infome nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Infome CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Infome Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            // _listaDeContas.Add("Olá mundo"); //AGORA n funciona, pois definimos nosso arrya list do tipo ContaCorrente
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }
    
       private void ListarContas()
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===     LISTA DE CONTAS     ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                if (_listaDeContas.Count <= 0)
                {
                    Console.WriteLine("... Não há contas cadastradas! ...");
                    Console.ReadKey();
                    return;
                }
                foreach (ContaCorrente item in _listaDeContas)
                {
                    // Console.WriteLine("===  Dados da Conta  ===");
                    // Console.WriteLine("Número da Conta : " + item.Conta);
                    // System.Console.WriteLine("Número da agência: " + item.Numero_agencia);
                    // Console.WriteLine("Salda da Conta : " + item.Saldo);
                    // Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                    // Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
                    // Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                    System.Console.WriteLine(item.ToString());
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.ReadKey();
                }

            }

       private void RemoverContas()
        {
         Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    REMOVER CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            System.Console.WriteLine("Informe o número da conta: ");
            string numeroConta = Console.ReadLine();

            ContaCorrente conta = null;

            foreach (ContaCorrente item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                System.Console.WriteLine("Conta removida com sucesso!!!");
            }
            else{
                System.Console.WriteLine("Conta não encontrada para a remoção!");
            }
            Console.ReadKey(); //ReadKey - espera o usuario digitar algo para continuar o processamento do programa
            
        }

       private void OrdenarContas()

      

        {
            //Para que a gente posssamos usar o metodo sort para listar contas
            //for preciso implementar a interface IcomprableTO - onde o msm possibilita criar um método especificando quais atributos serao comparados e assim ordenados
            //no caso, usamos o numero_agencia como forma de comparar a lista e ordenalas
            _listaDeContas.Sort();
            System.Console.WriteLine("Lista de contas ordenadas");
        }

       private void PesquisarContas(){
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   Pesquisar Contas    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            System.Console.WriteLine("Deseja pesquisar conta por (1) número da conta, (2) CPF do titular, (3) número da agência? : ");
            
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        System.Console.WriteLine("Informe o número da conta: ");
                        string _numeroDaConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroDaConta);
                        System.Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }

                case 2:
                    {
                        System.Console.WriteLine("Informe o CPF do titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        System.Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        System.Console.WriteLine("Informe o Nº da agência: ");
                        int _nmAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = consultaPorAgencia(_nmAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }


                default:
                System.Console.WriteLine("Opção não implementada!");
                break;
            }
        }

        //Nesses dois metodos ConsultaPorCPF e ConsultaPorNumeroConta
        //iremos usar o percorrimento de um array, se encontrar retorna
        //vamos destrinchar e fixar essa base de percorrer array pq é essencial
       private ContaCorrente ConsultaPorCPFTitular(string? cpf)
        {
            // ContaCorrente conta=null;
            // for (int i = 0; i < _listaDeContas.Count; i++)
            // {
            //     if( _listaDeContas[i].Titular.Cpf.Equals(cpf)){
            //         conta = _listaDeContas[i];
                    
            //     }
            // }
            // return conta;

            // sintetizando 9 linhas em uma só!

            // return _listaDeContas.Where(conta => conta.Titular.Cpf==cpf).FirstOrDefault();

            //por consulta LINQ from where select
            return(from conta in _listaDeContas
                    where conta.Titular.Cpf.Equals(cpf)
                    select conta).First();

        }

       private ContaCorrente ConsultaPorNumeroConta(string? numeroDaConta)
        {
            // ContaCorrente conta = null;
            // for (int i = 0; i < _listaDeContas.Count; i++)
            // {
            //     if(_listaDeContas[i].Conta.Equals(numeroDaConta)){
            //         conta = _listaDeContas[i];
            //     }
            // }
            // return conta;
            
            // sintetizando 9 linhas em uma só!
            // return _listaDeContas.Where(conta => conta.Conta.Equals(numeroDaConta)).FirstOrDefault();

            //por consulta LINQ from where select
           return(from conta in _listaDeContas
                where conta.Conta.Equals(numeroDaConta)
                select conta).First();
        }
       private List<ContaCorrente> consultaPorAgencia(int nmAgencia)
        {
            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia.Equals(nmAgencia)
                select conta).ToList();
            return consulta;
        }

        
      private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if(contasPorAgencia == null){
                System.Console.WriteLine("A consulta não retornou dados");
            }
            else{
                foreach (var item in contasPorAgencia)
                {
                    System.Console.WriteLine(item.ToString() + "\n");
                }
            }
        }

    #endregion
    }
}