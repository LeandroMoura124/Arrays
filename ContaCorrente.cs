namespace bytebank.Modelos.Conta
{



    public class ContaCorrente:IComparable<ContaCorrente> //ICOMPARER Define a forma de como comparar dois objetos.
    //A implementação da interface IComparable, obriga a classe a codificar o método CompareTo 
    //para que definir a ordenação ou classificação de objetos quando em uma lista.
    {     
       
        public Cliente Titular{get;set;}
        public string Nome_Agencia{ get; set; }

        private int _numero_agencia;
        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if(value <= 0)
                {

                }
                else
                {
                    _numero_agencia = value;
                }
            }
        
        }

        private string _conta;
        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if(value == null)
                {
                    return;
                }
                else
                {
                    _conta = value;
                }
            }
        }

        private double saldo;
        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    saldo = value;
                }
            }
        }

        public bool Sacar(double valor)
        {
            if(saldo < valor)
            {
                return false;
            }
            if(valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            saldo = saldo + valor;
        }

        public bool Transferir(double valor,ContaCorrente destino)
        {
            if(saldo < valor)
            {
                return false;
            }
            if(valor <0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo = destino.saldo + valor;
                return true;
            }
        }
           
        
        public int CompareTo(ContaCorrente? outro){
            if (outro == null)
            {
                return 1;
            }
            else{
                return this.Numero_agencia.CompareTo(outro._numero_agencia);
            }
        }

        //Constructor
        public ContaCorrente(int numero_agencia,string numeroDaConta)
        {
            Numero_agencia = numero_agencia;
            Conta = numeroDaConta;
            Titular = new Cliente();
            TotalDeContasCriadas += 1;

        }

        public static int TotalDeContasCriadas { get; set; }

        //public override bool Equals(object? conta)
        //{
        //    ContaCorrente outroConta = conta as ContaCorrente;

        //    if (outroConta == null)
        //    {
        //        return false;
        //    }

        //    return Numero_agencia == outroConta.Numero_agencia && 
        //        Conta.Equals(outroConta.Conta);
        //}



        //Redefinindo o metodo ToString
        //é preciso para retornar os dados do metodo pesquisar conta no nosso programa

        public override string ToString()
        {
            return $"======= DADOS DA CONTA ========== \n" +
                   $"======= Número da conta: {this.Conta} \n" +
                   $"======= Número da conta: {this.Numero_agencia} \n" +
                   $"======= Saldo da conta: {this.Saldo} \n" +
                   $"======= Titular da conta: {this.Titular.Nome} \n" +
                   $"======= CPF do titular: {this.Titular.Cpf} \n" + 
                   $"======= Profissão do titular: {this.Titular.Profissao}";

        }
    }
}