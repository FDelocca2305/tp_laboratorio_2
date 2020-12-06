using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    //Creo delegado
    public delegate void EntroAlLocal(Cliente cliente);
    public class Cliente : ICliente
    {
        //Creo el evento
        public event EntroAlLocal Entro;

        private int dni;
        private string nombre;
        private List<Cliente> clientes;

        //Este es un array de string de los nombres que pueden tener los clientes
        private string[] nombresPosibles = { "Mateo", "Nicolas", "Fabiana", "Franco", "Sebastian", "Laura", "Joel", "Juan", "Pepe"};

        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public Cliente()
        {
            this.Entro += this.EstaEnLaTienda;
            this.clientes = new List<Cliente>();
        }

        public Cliente(int dni, string nombre)
        {
            this.dni = dni;
            this.nombre = nombre;
        }

        /// <summary>
        /// Me suscribo al evento de Entrara la local y creo los clientes con datos aleatorios
        /// y los paso para que se inserten en la lista de clientes
        /// </summary>
        public void EntrarAlLocal()
        {
            while (true)
            {
                Thread.Sleep(new Random().Next(5000, 10000));

                string nombre = nombresPosibles[new Random().Next(0, 8)];

                if (!object.ReferenceEquals(this.Entro, null))
                {
                    this.Entro.Invoke(new Cliente(new Random().Next(10000000, 99999999), nombre));
                }
            }
            
        }

        /// <summary>
        /// Añado clientes a la lista de clientes
        /// </summary>
        /// <param name="cliente"></param>
        public void EstaEnLaTienda(Cliente cliente)
        {
            this.clientes.Add(cliente);
        }

        /// <summary>
        /// Muestro todos los datos del Cliente
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>
        private static string MostrarDatos(Cliente cli)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Nombre: {cli.Nombre}, DNI:{cli.Dni}");
            //stringBuilder.AppendLine("<------------------------------------------------------>");


            return stringBuilder.ToString();
        }

        /// <summary>
        /// Override del metodo to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
