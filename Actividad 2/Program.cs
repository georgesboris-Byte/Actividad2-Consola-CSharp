using System;
using System.Globalization;
using System.Text;

namespace Actividad_2
{
    // =============================================================
    //  Actividad 2 - Bucles y métodos (funciones)
    //  Algoritmos Computacionales - Prof. Gamalier Reyes del Carmen
    //
    //  Calculadora de áreas geométricas (triángulo, cuadrado y
    //  círculo) y validador de mayoría de edad, usando funciones
    //  que reciben parámetros y retornan un resultado.
    // =============================================================
    internal class Program
    {
        // Edad a partir de la cual una persona es mayor de edad (República Dominicana)
        const int MAYORIA_DE_EDAD = 18;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Actividad 2 - Áreas y edad";

            int opcion;

            do
            {
                MostrarMenu();
                opcion = LeerEntero("  Elige una opción (1-5): ", 1, 5);
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        MostrarTitulo("ÁREA DEL TRIÁNGULO");
                        double baseTriangulo = LeerNumeroPositivo("  Base del triángulo (cm): ");
                        double alturaTriangulo = LeerNumeroPositivo("  Altura del triángulo (cm): ");
                        double areaTriangulo = CalcularAreaTriangulo(baseTriangulo, alturaTriangulo);
                        MostrarResultado("Fórmula: (base × altura) / 2",
                            $"Área del triángulo = {areaTriangulo:N2} cm²");
                        break;

                    case 2:
                        MostrarTitulo("ÁREA DEL CUADRADO");
                        double lado = LeerNumeroPositivo("  Lado del cuadrado (cm): ");
                        double areaCuadrado = CalcularAreaCuadrado(lado);
                        MostrarResultado("Fórmula: lado × lado",
                            $"Área del cuadrado = {areaCuadrado:N2} cm²");
                        break;

                    case 3:
                        MostrarTitulo("ÁREA DEL CÍRCULO");
                        double radio = LeerNumeroPositivo("  Radio del círculo (cm): ");
                        double areaCirculo = CalcularAreaCirculo(radio);
                        MostrarResultado("Fórmula: π × radio²",
                            $"Área del círculo = {areaCirculo:N2} cm²");
                        break;

                    case 4:
                        MostrarTitulo("VALIDAR MAYORÍA DE EDAD");
                        int edad = LeerEntero("  Escribe la edad (0-120): ", 0, 120);
                        string mensaje = ValidarEdad(edad);
                        MostrarResultado($"Mayoría de edad: {MAYORIA_DE_EDAD} años", mensaje);
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("  ¡Gracias por usar el programa! Hasta luego.");
                        Console.ResetColor();
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine();
                    Console.Write("  Presiona ENTER para volver al menú...");
                    Console.ReadLine();
                }

            } while (opcion != 5);
        }

        // =============================================================
        //  FUNCIONES DE CÁLCULO (reciben parámetros y retornan resultado)
        // =============================================================

        /// <summary>Calcula el área de un triángulo: (base × altura) / 2.</summary>
        static double CalcularAreaTriangulo(double baseTriangulo, double altura)
        {
            return (baseTriangulo * altura) / 2;
        }

        /// <summary>Calcula el área de un cuadrado: lado × lado.</summary>
        static double CalcularAreaCuadrado(double lado)
        {
            return lado * lado;
        }

        /// <summary>Calcula el área de un círculo: π × radio².</summary>
        static double CalcularAreaCirculo(double radio)
        {
            return Math.PI * radio * radio;
        }

        /// <summary>Recibe la edad y retorna un mensaje indicando si es mayor o menor de edad.</summary>
        static string ValidarEdad(int edad)
        {
            if (edad >= MAYORIA_DE_EDAD)
            {
                return $"Con {edad} años, la persona es MAYOR de edad.";
            }
            else
            {
                int faltan = MAYORIA_DE_EDAD - edad;
                return $"Con {edad} años, la persona es MENOR de edad (le faltan {faltan} año(s)).";
            }
        }

        // =============================================================
        //  PROCEDIMIENTOS DE PANTALLA Y LECTURA DE DATOS
        // =============================================================

        /// <summary>Muestra el menú principal.</summary>
        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║   CALCULADORA DE ÁREAS Y VALIDAR EDAD    ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("    1. Área del triángulo");
            Console.WriteLine("    2. Área del cuadrado");
            Console.WriteLine("    3. Área del círculo");
            Console.WriteLine("    4. Validar mayoría de edad");
            Console.WriteLine("    5. Salir");
            Console.WriteLine("  ────────────────────────────────────────────");
        }

        /// <summary>Muestra el título de la opción elegida.</summary>
        static void MostrarTitulo(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  === {titulo} ===");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>Muestra el resultado resaltado en verde.</summary>
        static void MostrarResultado(string detalle, string resultado)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {detalle}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✔ {resultado}");
            Console.ResetColor();
        }

        /// <summary>Muestra un mensaje de error en rojo.</summary>
        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✖ {mensaje}");
            Console.ResetColor();
        }

        /// <summary>Pide un número mayor que cero hasta que el usuario lo escriba bien.
        /// Acepta punto o coma como separador decimal.</summary>
        static double LeerNumeroPositivo(string mensaje)
        {
            double numero;
            bool valido;

            do
            {
                Console.Write(mensaje);
                string texto = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
                valido = double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out numero)
                         && numero > 0;

                if (!valido)
                {
                    MostrarError("Valor no válido. Escribe un número mayor que 0 (ej.: 5 o 7.5).");
                }
            } while (!valido);

            return numero;
        }

        /// <summary>Pide un número entero dentro de un rango hasta que el usuario lo escriba bien.</summary>
        static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            int numero;
            bool valido;

            do
            {
                Console.Write(mensaje);
                valido = int.TryParse(Console.ReadLine(), out numero)
                         && numero >= minimo && numero <= maximo;

                if (!valido)
                {
                    MostrarError($"Valor no válido. Escribe un número entero entre {minimo} y {maximo}.");
                }
            } while (!valido);

            return numero;
        }
    }
}
