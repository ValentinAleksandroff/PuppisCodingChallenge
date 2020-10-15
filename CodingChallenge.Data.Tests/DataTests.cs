using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0, 0) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3, 0, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 3, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m, 0, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 3, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m, 0, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        //Pruebas extra
        [TestCase]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 3));
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 3, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrapecioIsosceles, 4, 5, 3, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Rectangulo, 5, 2, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m, 0, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>1 Circle | Area 7,07 | Perimeter 9,42 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Trapeze | Area 13,5 | Perimeter 15 <br/>1 Rectangle | Area 10 | Perimeter 14 <br/>TOTAL:<br/>8 shapes Perimeter 118,02 Area 109,21",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnPortugues()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 7, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 2, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrapecioIsosceles, 12, 28, 10, 6),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 6, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 13m, 0, 0, 0),
                new FormaGeometrica(FormaGeometrica.Rectangulo, 4, 2, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m, 0, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Portugues);

            Assert.AreEqual(
                "<h1>Relatório de Formas</h1>2 Quadrados | Area 85 | Perímetro 52 <br/>1 Círculo | Area 3,14 | Perímetro 6,28 <br/>3 Triângulos | Area 115,89 | Perímetro 78,6 <br/>1 Trapézio | Area 120 | Perímetro 60 <br/>1 Retângulo | Area 8 | Perímetro 12 <br/>TOTAL:<br/>8 formas Perímetro 208,88 Area 332,03",
                resumen);
        }
    }
}
