using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static Random rn = new Random();
        static void Main(string[] args)
        {
            int n = rn.Next(6, 16);
            int m = rn.Next(6, 16);
            char[,] matriz = new char[n, m];
            matriz = llenarmatricaracteres(matriz);
            Console.Write("INGRESAR UNA PALABRA O UNA FRASE: ");
            string frase = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Palabra convertida en Minuscula");
            pal(frase);
            Console.WriteLine();
            Console.WriteLine("Matriz generada:");
            ImprimirMatriz(matriz);
            Console.WriteLine();
            buscarenmatriz(matriz, frase, matriz);
        }
        static char[,] llenarmatricaracteres(char[,] matrizllena)
        {
            for (int i = 0; i < matrizllena.GetLength(0); i++)
            {
                for (int j = 0; j < matrizllena.GetLength(1); j++)
                {

                    if (matrizllena[i, j] < 'a' || matrizllena[i, j] > 'z')
                    {
                        matrizllena[i, j] = (char)rn.Next(97, 123);
                    }
                }

            }
            return matrizllena;
        }
        static void ImprimirMatriz(char[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("|" + matriz[i, j] + "|");
                    Console.ResetColor();

                }
                Console.WriteLine();
            }
        }
        static string pal(string plbra)
        {
            string minus = plbra.ToLower();
            Console.WriteLine(minus);
            return minus;
        }
        static void buscarenmatriz(char[,] matriz, string palabrrr, char[,] mazpo)
        {
            string[] palabras = palabrrr.ToLower().Split(' ');
            bool palabraEncontrada = false;

            foreach (string palabra in palabras)
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (j + palabra.Length <= matriz.GetLength(1))
                        {
                            bool horizontal = true;
                            for (int k = 0; k < palabra.Length; k++)
                            {
                                if (matriz[i, j + k] != palabra[k])
                                {
                                    horizontal = false;
                                    break;
                                }
                            }
                            if (horizontal)
                            {
                                palabraEncontrada = true;
                                Console.WriteLine("la palabra |{0}| se encuentra en la matriz de forma horizontal en la posicion.", palabra);
                                for (int k = 0; k < palabra.Length; k++)
                                {
                                    Console.WriteLine("({0},{1})", i, j + k);
                                }
                            }
                        }
                        if (i + palabra.Length <= matriz.GetLength(0))
                        {
                            bool vertical = true;
                            for (int k = 0; k < palabra.Length; k++)
                            {
                                if (matriz[i + k, j] != palabra[k])
                                {
                                    vertical = false;
                                    break;
                                }
                            }
                            if (vertical)
                            {
                                palabraEncontrada = true;
                                Console.WriteLine("la palabra |{0}| se encuentra en la matriz de forma vertical en la posicion.", palabra);
                                for (int k = 0; k < palabra.Length; k++)
                                {
                                    Console.WriteLine("({0},{1})", i + k, j);
                                }
                            }
                        }
                    }
                    if (palabraEncontrada) break;
                }
            }
            if (palabraEncontrada == false)
            {
                Console.WriteLine("La palabra |{0}| no se encuentra en la matriz.", palabrrr);
            }
            if (palabraEncontrada)
            {
                int originalX = Console.CursorLeft;
                int originalY = Console.CursorTop;
                Console.WriteLine("Matriz con posiciones");
                for (int k = 0; k < mazpo.GetLength(0); k++)
                {
                    for (int l = 0; l < mazpo.GetLength(1); l++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("|" + "{0}x{1} {2}|", k, l, mazpo[k, l]);
                        Console.ResetColor();

                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(originalX, originalY);
                Console.ReadLine();
            }
        }
    }
}
