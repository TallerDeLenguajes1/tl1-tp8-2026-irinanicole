# TP 8: Colecciones y Arreglos

Bourdette, Irina Nicole

## EJERCICIO 1

### Clase: RANDOM()

```c#
using System; // Es necesario incluir esta directiva

// 1. Crear una única instancia (debe crearse solo una vez)
Random rnd = new Random();

// 2. Generar un número entero (ejemplo: entre 0 y 99)
int numero = rnd.Next(100); 

// 3. Generar un número entero en un rango específico (ejemplo: entre 1 y 10)
int dado = rnd.Next(1, 11); // El límite superior es exclusivo

// 4. Generar un número decimal entre 0.0 y 1.0
double decimalAleatorio = rnd.NextDouble();
```