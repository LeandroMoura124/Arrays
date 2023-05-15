using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arrays
{
    public class Pessoa{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public override string ToString()
    {
        return $"Nome = {this.Nome} com Idade = {this.Idade}";
    }
    
    }
}