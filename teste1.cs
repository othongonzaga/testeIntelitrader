//Teste - Menor distância de dois arrays
//Como solicitado, o compilador online para executar os códigos é: https://www.onlinegdb.com/online_csharp_compiler

using System;

class Program
{
    static void Main()
    {
        int[] array1 = { -1, 5, 10, 15, 20, 25, 31, 35, 40, 45 };
        int[] array2 = { 26, 6, 12, 18, 24, 30, 36, 42, 48, 54 };

        int menorDistancia = EncontrarMenorDistancia(array1, array2);

        Console.WriteLine($"A menor distância é: {menorDistancia}");
    }

    static int EncontrarMenorDistancia(int[] arr1, int[] arr2)
    {
        int menorDistancia = int.MaxValue;

        foreach (int num1 in arr1)
        {
            foreach (int num2 in arr2)
            {
                int distanciaAtual = Math.Abs(num1 - num2);
                if (distanciaAtual < menorDistancia)
                {
                    menorDistancia = distanciaAtual;
                }
            }
        }

        return menorDistancia;
    }
}
