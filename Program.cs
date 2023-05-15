using Arrays;
using Arrays.bytebank.Exception;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
        #region Exemplos Arrays em C#W
        // //TestaArrayInt();
        // //TestaBuscarPalavra();

        // void TestaArrayInt()
        // {
        //     int[] idades = new int[5];
        //     idades[0] = 30;
        //     idades[1] = 40;
        //     idades[2] = 17;
        //     idades[3] = 21;
        //     idades[4] = 18;

        //     Console.WriteLine($"Tamanho do Array {idades.Length}");

        //     int acumulador = 0;
        //     for (int i = 0; i < idades.Length; i++)
        //     {
        //         int idade = idades[i];
        //         Console.WriteLine($"índice [{i}] = {idade}");
        //         acumulador += idade;
        //     }

        //     int media = acumulador / idades.Length;
        //     Console.WriteLine($"Média de idades = {media}");
        // }

        // void TestaBuscarPalavra()
        // {
        //     string[] arrayDePalavras = new string[5];

        //     for (int i = 0; i < arrayDePalavras.Length; i++)
        //     {
        //         Console.Write($"Digite {i + 1}ª Palavra: ");
        //         arrayDePalavras[i] = Console.ReadLine();
        //     }

        //     Console.Write("Digite palavara a ser encontrada: ");
        //     var busca = Console.ReadLine();

        //     foreach (string palavra in arrayDePalavras)
        //     {
        //         if (palavra.Equals(busca))
        //         {
        //             Console.WriteLine($"Palavra encontrada = {busca}.");
        //             break;
        //         }
        //     }

        // }

        //[5,9][1,8][7,1][10][6,9]
        //Array amostra = Array.CreateInstance(typeof(double), 5);
        Array amostra = new double[5];
        amostra.SetValue(5.9, 0);
        amostra.SetValue(1.8, 1);
        amostra.SetValue(7.1, 2);
        amostra.SetValue(10, 3);
        amostra.SetValue(6.9, 4);

        ///TestaMediana(amostra);

        void TestaMediana(Array array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array para cálculo da  mediana está vazio ou nulo.");
            }

            //Mediana
            double[] numerosOrdenados = (double[])array.Clone();

            Array.Sort(numerosOrdenados);
            //[1,8][5,9][6,9][7,1][10]

            int tamanho = numerosOrdenados.Length;
            int meio = tamanho / 2;
            double mediana = tamanho % 2 != 0 ? numerosOrdenados[meio] : (numerosOrdenados[meio] +
                numerosOrdenados[meio - 1]) / 2;

            Console.WriteLine($"Com base na amostra a mediana = {mediana}.");
        }

        void TestaArrayDeContasCorrentes()
        {

            ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
            listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
            listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
            listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
            listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
            listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
            listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
            var contaDoAndre = new ContaCorrente(963, "123456-X");
            listaDeContas.Adicionar(contaDoAndre);
            //listaDeContas.ExibeLista();
            //Console.WriteLine("============");
            //listaDeContas.Remover(contaDoAndre);
            //listaDeContas.ExibeLista();

            for (int i = 0; i < listaDeContas.Tamanho; i++)
            {
                ContaCorrente conta = listaDeContas[i];
                Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
            }

        }
        #endregion
        //TestaArrayDeContasCorrentes();
       
        
        #region Trabalhando com objeto em ContaCorrente uma List
        List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
            new ContaCorrente(95, "123456-X"){Saldo = 100, Titular = new Cliente {Cpf = "111111", Nome = "Leandro", Profissao = "dev" }},
            new ContaCorrente(95, "457894-X"){Saldo = 100, Titular = new Cliente {Cpf = "556145", Nome = "Fernando" }},
            new ContaCorrente(92, "213243-X"){Saldo = 200, Titular = new Cliente {Cpf = "222222", Nome = "Maria" }},
            new ContaCorrente(75, "988776-X"){Saldo = 60, Titular = new Cliente {Cpf = "333333", Nome = "João" }},
        };
        // _listaDeContas[0].Titular._nome ="Leandro";
        // _listaDeContas[0].Titular.Cpf ="49931503858";
        // _listaDeContas[0].Titular.Profissao ="Dev";

       AtendimentoCliente();
        void AtendimentoCliente()
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

        

        void CadastrarConta()
        
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");
            Console.Write("Número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

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
    
        void ListarContas()
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

        void RemoverContas()
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

        void OrdenarContas()

      

        {
            //Para que a gente posssamos usar o metodo sort para listar contas
            //for preciso implementar a interface IcomprableTO - onde o msm possibilita criar um método especificando quais atributos serao comparados e assim ordenados
            //no caso, usamos o numero_agencia como forma de comparar a lista e ordenalas
            _listaDeContas.Sort();
            System.Console.WriteLine("Lista de contas ordenadas");
        }

        void PesquisarContas(){
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
        ContaCorrente ConsultaPorCPFTitular(string? cpf)
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

            return _listaDeContas.Where(conta => conta.Titular.Cpf==cpf).FirstOrDefault();

        }

        ContaCorrente ConsultaPorNumeroConta(string? numeroDaConta)
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
            return _listaDeContas.Where(conta => conta.Conta.Equals(numeroDaConta)).FirstOrDefault();
        }
        List<ContaCorrente> consultaPorAgencia(int nmAgencia)
        {
            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia.Equals(nmAgencia)
                select conta).ToList();
            return consulta;
        }

        
       void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
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
        //Generics ---
        //Permite trabalhar com classes, metodos, sem definir explicitamente o seu tipo
        // isto é, em um método, posso retornar string ou int ao mesmo tempo
        #region Trabalhando com a classe Gnerics
        Generic<String> teste1 = new Generic<String>();
        teste1.mensagemTeste("Exibindo String");

        Generic<int> teste2 = new Generic<int>();
        teste2.mensagemTeste(556);

        //Como dito, essa é a colecao da classe Generic<>, permitiu exibir string e dps int
        //Em suma, esse recurso possibilita que a gente reaproveite o código

        Pessoa andre = new Pessoa() { Idade = 18, Nome = "André" };
        Generic<Pessoa> objGenerico3 = new Generic<Pessoa>();
        objGenerico3.ExibirDados(andre);
         #endregion
    

        #region Trabalhando com metodos da collection list - AddRange, GetRange, Reverse
        /*Trabalhando com metodos da collection List*/
        List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>(){
            new ContaCorrente(954, "45432545-A"){Saldo = 100},
            new ContaCorrente(925, "65884878-B"){Saldo = 200},
            new ContaCorrente(754, "45454475-C"){Saldo = 60}
        };

        List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>(){
            new ContaCorrente(195, "45474545-D"){Saldo = 100},
            new ContaCorrente(492, "65684878-E"){Saldo = 200},
            new ContaCorrente(375, "45447545-F"){Saldo = 60}
        };

        //AddRange - Pega o valor de uma lista, e adiciona o valor de outra
        _listaDeContas2.AddRange(_listaDeContas3); // agora lista 2 terá 6 elementos

        //Reverse - inverte os dados da lista
        _listaDeContas2.Reverse();

        //percorrendo a lista2 para ver os valores
        for (int i = 0; i < _listaDeContas2.Count; i++)
        {
            System.Console.WriteLine($"Indice[{i}] = Conta[{_listaDeContas2[i].Numero_agencia + " " +_listaDeContas2[i].Conta}]");
        }

        System.Console.WriteLine("\n\n");

        //Extraindo dados de uma Lista - GetRange
        var range = _listaDeContas3.GetRange(0, 1); //pega o elemento da lista do indice 0 até o 1- ou seja, 
        //pega a primeira conta
        for (int i = 0; i < range.Count; i++)
        {
           System.Console.WriteLine($"Indice[{i}] = Conta[{range[i].Numero_agencia + " " + range[i].Conta}]");
        }

        System.Console.WriteLine("\n\n");

        _listaDeContas3.Clear(); //Limpa a lista
        //pega a primeira conta
        for (int i = 0; i < _listaDeContas3.Count; i++)
        {
           System.Console.WriteLine($"Indice[{i}] = Conta[{range[i].Numero_agencia + " " + range[i].Conta}]");
        }
    #endregion






        #region  Trabalhando Exercicios 

        List<string> nomesDosEscolhidos = new List<string>()
        {
            "Bruce Wayne",
            "Carlos Vilagran",
            "Richard Grayson",
            "Bob Kane",
            "Will Farrel",
            "Lois Lane",
            "General Welling",
            "Perla Letícia",
            "Uxas",
            "Diana Prince",
            "Elisabeth Romanova",
            "Anakin Wayne"
        };

        bool VerificaNomes(List<string> nomesDosEscolhidos,string escolhido)
        {
            return nomesDosEscolhidos.Contains(escolhido);
        }
        VerificaNomes(nomesDosEscolhidos, "Uxas");




        //Collection Stack
        /*esta coleção implementa o conceito de pilha, onde os elementos mais novos são adicionados no topo da pilha,
         e devem ser retirados nesta ordem. Esta classe também possui uma versão genérica. Exemplo de utilização:*/

        Stack<string> minhlaPilhaDeLivros = new Stack<string>();
        minhlaPilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
        minhlaPilhaDeLivros.Push("A Guerra do Velho.");
        minhlaPilhaDeLivros.Push("Protocolo Bluehand");
        minhlaPilhaDeLivros.Push("Crise nas Infinitas Terras.");

        Console.WriteLine(minhlaPilhaDeLivros.Peek());// Retorna o elemento do topo.
        Console.WriteLine(minhlaPilhaDeLivros.Pop()); //Remove o elemento do topo


        //Collection Queue
        /*Queue, esta coleção por sua vez implementa o conceito de fila, onde os elementos mais7
        antigos são os primeiros a serem removidos. Para adicionar um elemento na fila usamos o método Enqueue:*/
        Queue<string> filaAtendimento  = new Queue<string>();
        filaAtendimento.Enqueue("André Silva");
        filaAtendimento.Enqueue("Lou Ferrigno");
        filaAtendimento.Enqueue("Gal Gadot");

        //o método Dequeue para remover um objeto da fila. Exemplo:
        filaAtendimento.Dequeue();//Remove o primeiro elemento da fila.


        //Collection HashSet
        //HashSet, focado em alta performance esta coleção não aceita valores duplicados,
        // para adicionar elementos temos também disponível o método Add:

        HashSet<int> _numeros = new HashSet<int>();
        _numeros.Add(0);
        _numeros.Add(1);
        _numeros.Add(1);
        _numeros.Add(1);

            Console.WriteLine(_numeros.Count);// a saída é 2.
            System.Console.WriteLine(_numeros.Contains(1)); // retorna true
            
            //Para exibirmos o conteúdo podemos percorrer a coleção usando um foreach:
            foreach (var item in _numeros)
            {
                Console.WriteLine(item);
            }
        #endregion
       
        Pessoa p1 = new Pessoa() { Idade = 18, Nome = "André" };
        Generic<Pessoa> objgenerico = new Generic<Pessoa>();
        objgenerico.ExibirDados(p1);

        }


    public class Generic<T>{
        public void mensagemTeste(T t){
            System.Console.WriteLine($"Generics exibe {t}");
        }
           public void ExibirDados(T t)
        {
            Console.WriteLine($"Dado Informado = {t.ToString()}");
            Console.WriteLine($"Tipo = {t.GetType()}");
        }  
    }

}


