using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// valida si la cadena recibina es uno de los 4 operadores
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>si es un operador valido lo retorna denuevo si no usa el default que es +</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        /// <summary>
        /// opera los dos numeros segun sea el operador
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>retorna el resultado si no 0</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "-": return num1 - num2;
                case "+": return num1 + num2;
                case "/": return num1 / num2;
                case "*": return num1 * num2;
                default: return 0;
            }
        }
    }
}
