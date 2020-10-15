/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int TrapecioIsosceles = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portugues = 3;

        #endregion

        private readonly decimal _ladoa;
        private readonly decimal _ladob;
        private readonly decimal _ladoc;
        private readonly decimal _altura;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ladoa, decimal ladob, decimal ladoc, decimal altura)
        {
            Tipo = tipo;
            _ladoa = ladoa;
            _ladob = ladob;
            _ladoc = ladoc;
            _altura = altura;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else if (idioma == Portugues)
                    sb.Append("<h1>Lista vazia de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else if (idioma == Portugues)
                    sb.Append("<h1>Relatório de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;
                var numeroRectangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecios = 0m;
                var areaRectangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecios = 0m;
                var perimetroRectangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro(); 
                    }
                    if (formas[i].Tipo == TrapecioIsosceles)
                    {
                        numeroTrapecios++;
                        areaTrapecios += formas[i].CalcularArea();
                        perimetroTrapecios += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Rectangulo)
                    {
                        numeroRectangulos++;
                        areaRectangulos += formas[i].CalcularArea();
                        perimetroRectangulos += formas[i].CalcularPerimetro();
                    }
                }
                
                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                sb.Append(ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, TrapecioIsosceles, idioma));
                sb.Append(ObtenerLinea(numeroRectangulos, areaRectangulos, perimetroRectangulos, Rectangulo, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + numeroRectangulos + " " + (idioma == Castellano ? "formas" : idioma == Portugues ? "formas" : "shapes") + " ");
                sb.Append((idioma == Castellano ? "Perimetro " : idioma == Portugues ? "Perímetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecios + perimetroRectangulos).ToString("#.##").Replace('.', ',') + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTrapecios + areaRectangulos).ToString("#.##").Replace('.', ','));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return  $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area.ToString("#.##").Replace('.', ',')} | Perimetro {perimetro.ToString("#.##").Replace('.', ',')} <br/>";
                
                else if (idioma == Portugues)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area.ToString("#.##").Replace('.',',')} | Perímetro {perimetro.ToString("#.##").Replace('.', ',')} <br/>";
                else
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area.ToString("#.##").Replace('.', ',')} | Perimeter {perimetro.ToString("#.##").Replace('.', ',')} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else if (idioma == Portugues) return cantidad == 1 ? "Quadrado" : "Quadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else if (idioma == Portugues) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else if (idioma == Portugues) return cantidad == 1 ? "Triângulo" : "Triângulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
                case TrapecioIsosceles:
                    if (idioma == Castellano) return cantidad == 1 ? "Trapecio" : "Trapecios";
                    else if (idioma == Portugues) return cantidad == 1 ? "Trapézio" : "Trapézios";
                    else return cantidad == 1 ? "Trapeze" : "Trapezoids";
                case Rectangulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                    else if (idioma == Portugues) return cantidad == 1 ? "Retângulo" : "Retângulos";
                    else return cantidad == 1 ? "Rectangle" : "Rectangles";
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _ladoa * _ladoa;
                case Circulo: return (decimal)Math.PI * (_ladoa / 2) * (_ladoa / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _ladoa * _ladoa;
                case TrapecioIsosceles: return _altura * ((_ladoa + _ladob) / 2);
                case Rectangulo: return _ladoa * _ladob;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _ladoa * 4;
                case Circulo: return (decimal)Math.PI * _ladoa;
                case TrianguloEquilatero: return _ladoa * 3;
                case TrapecioIsosceles: return _ladoa + _ladob + (2 * _ladoc);
                case Rectangulo: return (_ladoa * 2) + (_ladob * 2);
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
