/*
 * Escribe un programa que imprima los 50 primeros números de la sucesión
 * de Fibonacci empezando en 0.
 * - La serie Fibonacci se compone por una sucesión de números en
 *   la que el siguiente siempre es la suma de los dos anteriores.
 *   0, 1, 1, 2, 3, 5, 8, 13...
 */
 double last = 1;
 double second = 0;

Console.Write($"{second},{last}");
 for (int i = 0; i < 50; i++)
 {
    double next = second + last;
    Console.Write($",{next}");

    second = last;
    last = next;
 }