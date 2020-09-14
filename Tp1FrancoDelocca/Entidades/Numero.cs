using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }
        
       /// <summary>
       /// valida si la cadena pasada es un numero
       /// </summary>
       /// <param name="strNumero"></param>
       /// <returns>la cadena parseada a double o 0</returns>
        public double ValidarNumero(string strNumero)
        {

            if (double.TryParse(strNumero, out double parser))
            {
                return parser;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// valida si la cadena pasada es solo un numero binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true si es binario false si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            for (int x = binario.Length - 1, y = 0; x >= 0; x--, y++)
            {
                if (binario[x].Equals("0") || binario[x].Equals("1"))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// transforma un numero decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>si es mayor a 0 retorna la cadena transformada si no "valor invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            if (numero > 0)
            {
                string cadena = "";

                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                }
                return cadena;
            }
            else
            {
                return "Valor Inválido";
            }
        }

        /// <summary>
        /// transforma una cadena de numeros a una cadena binaria
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>si el numero es mayor a 0 retorna la cadena y si no valor invalido</returns>
        public static string DecimalBinario(string numero)
        {
            int newNumero; 
            int.TryParse(numero, out newNumero);
            if (newNumero > 0)
            {
                string cadena = "";

                while (newNumero > 0)
                {
                    if (newNumero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    newNumero = (int)(newNumero / 2);
                }
                return cadena;
            }
            else
            {
                return "Valor Inválido";
            }
        }

        /// <summary>
        /// transforma una cadena binaria en decimal
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>retorna una cadena de numeros</returns>
        public static string BinarioDecimal(string numero)
        {
            StringBuilder dec = new StringBuilder();

            if (EsBinario(numero))
            {
                double decAux = 0;
                for (int x = numero.Length - 1, y = 0; x >= 0; x--, y++)
                {
                    if (numero[x].Equals('0') || numero[x].Equals('1'))
                    {
                        decAux += (int.Parse(numero[x].ToString()) * Math.Pow(2, y));
                    }
                    else
                    {
                        return "Valor Inválido";

                    }
                }
                string nuevoDecAux = decAux.ToString();
                dec.Append(nuevoDecAux);
                return dec.ToString();
            }
            else
            {
                return "Valor Inválido";
            }

        }

        #region Operadores

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
            
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        #endregion

    }
}
