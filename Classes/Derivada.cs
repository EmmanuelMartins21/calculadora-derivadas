using System;
using System.Collections.Generic;

namespace calculadora_derivadas.Classes
{
    internal class Derivada
    {
        string function;
        string functionLine;

        public void Menu()
        {
            function = null;
            Console.WriteLine($"Quantas variaveis há em sua função");
            var qtdvariaveis = Convert.ToInt16(Console.ReadLine());

            try
            {
                if (qtdvariaveis > 0)
                {
                    for (int i = 1; i <= qtdvariaveis; i++)
                    {
                        Console.WriteLine($"Qual o valor da variavel {i}?");
                        var vlr = Console.ReadLine();

                        Console.WriteLine($"Qual o valor do expoente da variavel {i}?");
                        var vlrExpoente = Console.ReadLine();

                        function += $"{vlr}x^{vlrExpoente} ";
                    }
                }
            }
            catch (Exception ex) { }

            Console.WriteLine($"Quantas constantes há em sua função");
            var qtdConstantes = Convert.ToInt16(Console.ReadLine());

            try
            {
                if (qtdConstantes > 0)
                {
                    for (int i = 1; i <= qtdConstantes; i++)
                    {
                        Console.WriteLine($"Qual o valor da constante {i}?");
                        var vlr = Console.ReadLine();
                        function += $"+ ({vlr})";
                    }
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// A derivada de ax^2 + bx + c em relação a x é 2ax + b
        /// Calculadora de derivada de funções quadraticas
        /// </summary>
        /// <returns></returns>
        public string CalculatorDerivative()
        {
            Menu();         

            string[] terms = function.Split(' ');
            foreach (var term in terms)
            {
                if (term.Contains("x"))
                {
                    string[] parts = term.Split(new char[] { 'x', '^' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1)
                    {
                        int coeficiente = int.Parse(parts[0]);
                        functionLine += $"{coeficiente * 2}x + ";
                    }
                    else if (parts.Length == 2)
                    {
                        int coeficiente = int.Parse(parts[0]);
                        int expoente = int.Parse(parts[1]);

                        if (expoente == 0)
                        {
                            functionLine += $"{coeficiente}";
                        }
                        else if (expoente == 1)
                        {
                            functionLine += $"{coeficiente}x";
                        }
                        else
                        {
                            functionLine += $"{coeficiente * expoente}x^{expoente - 1} + ";
                        }
                    }
                }
            }
            functionLine = functionLine.TrimEnd('+', ' ');

            Console.WriteLine($"A função é: {function}");
            Console.WriteLine($"A derivada da função é: {functionLine}");
            return functionLine;
        }
    }
}
