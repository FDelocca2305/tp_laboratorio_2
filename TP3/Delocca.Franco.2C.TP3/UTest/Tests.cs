using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using ClasesAbstractas;

namespace UTest
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Verifica si dos universitarios son iguales
        /// </summary>
        [TestMethod]
        public void VerUniversitariosIguales()
        {
            //Arrange
            bool respuesta;
            Profesor profesor = new Profesor(1, "Franco", "Delocca", "43463124", ClasesAbstractas.Persona.ENacionalidad.Argentino);
            Alumno alumno = new Alumno(1, "Franco", "Delocca", "43463124", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            //Act
            respuesta = profesor == alumno;

            //Assert
            Assert.IsFalse(respuesta);
        }

        /// <summary>
        /// Verifica si dos universitarios nulos son iguales
        /// </summary>
        [TestMethod]
        public void VerUniversitariosIgualesNulos()
        {
            //Arrange
            Profesor profesor = null;
            Alumno alumno = null;
            bool respuesta;

            //Act
            respuesta = profesor == alumno;

            //Assert
            Assert.IsFalse(respuesta);
        }

        /// <summary>
        /// Generar al menos dos métodos de test unitario distintos que validen que se lancen correctamente excepciones producidas por nuestro código.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void VerDNIStringInvalido()
        {
            //Arrange
            Profesor profesor;

            //Act   
            profesor = new Profesor(1, "Laura", "Garcia", "287462862", ClasesAbstractas.Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Generar al menos dos métodos de test unitario distintos que validen que se lancen correctamente excepciones producidas por nuestro código.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerDNIStringExtranjeroInvalido()
        {
            //Arrange
            Profesor profesor = new Profesor();

            //Act
            profesor.Nacionalidad = ClasesAbstractas.Persona.ENacionalidad.Extranjero;
            profesor.StringToDNI = "43463124";
        }

        /// <summary>
        /// Generar al menos uno que valide se haya instanciado un atributo del tipo colección en alguna de las clases dadas.
        /// </summary>
        [TestMethod]
        public void VerInstanciaJornada()
        {
            //Arrange
            Jornada jornada;

            //Act
            jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor(1, "Pepito", "Pepe", "8000", ClasesAbstractas.Persona.ENacionalidad.Argentino));

            //Assert
            Assert.IsNotNull(jornada.Alumnos);
        }


    }
}
