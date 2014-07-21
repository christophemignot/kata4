using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.ClassLib
{
    public interface ICalculator
    {
        string NombreA { get; }
        string NombreB { get; }

        void Entrer(string nombre);
        string Add();
    }
}
