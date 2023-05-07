
//criando arrays diretamente da classe
// Double[] amostra = new Double[5];
Array amostra = Array.CreateInstance(typeof(double), 5); // todos os arrays herdam disso, aqui só criamos diretamente
                                //  tipo do array - tamanho
amostra.SetValue(2.5, 0); // na minha posicao 0 do meu array seu valor será de 2.5
amostra.SetValue(1.0, 1);
amostra.SetValue(7.9, 2);
amostra.SetValue(6.9, 3);
amostra.SetValue(5.9, 4);

// Console.WriteLine(amostra.Length);  posicoes
//[2.5][1.0][7.9][6.9][5.9]
//metodo para calcular a mediana

testaMediana(amostra);

void testaMediana(Array array){
    if(array ==null || (array.Length ==0)){
        Console.WriteLine("O array esta nulo ou é igual a 0, não há como calcular mediana");
    }
    
    //fazendo uma cópia do array - pois a classe array permite usar o método sort
    double[] numerosOrdenados = (double []) array.Clone();
    Array.Sort(numerosOrdenados);
    //[1.0][2.5][5.9][6.9][7.9]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho%2 != 0)? numerosOrdenados[meio]: (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"A mediana com base na amostra seria {mediana}");
}


void testaArray(){
     int[] idades = new int[5];
      idades[0] = 30;
      idades[1] = 20;
     idades[2] = 15;
      idades[3] = 90;
      idades[4] = 26;

      Console.WriteLine($"O tamanho do array é {idades.Length}");

     int contador = 0;
      for(int i = 0; i <idades.Length; i++){
       int idade = idades[i];
        Console.WriteLine($"índice [{i}] é = {idades[i]}");
        contador += idades[i];   
     }
     double media = contador/idades.Length;
     Console.WriteLine($"A média das idades é: {media} " );


 }

// testaBuscaPalavras();

 void testaBuscaPalavras(){
    string [] arrayDePalavras = new string[5];

    for(int i = 0; i< arrayDePalavras.Length; i++){
        Console.Write($"Digite {i + 1} primeira palava: ");
        arrayDePalavras[i] = Console.ReadLine();

    }
    Console.Write("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach(string palavra in arrayDePalavras){
        if(palavra.Equals(busca)){
            Console.WriteLine($"Palavra {busca} encontrada ");
            return; //esse return serve para sair fora do lopping assim que detectar a Palavra
        }
        else{
           Console.WriteLine("Palavra não encontrada");
           return;
         }
    }
}