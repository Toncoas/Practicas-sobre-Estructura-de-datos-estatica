// ===========================
// EJERCICIO 1: Barajar y repartir cartas
// ===========================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_estructura_de_datos_estaticas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("EJECUTANDO EJERCICIO 1\n");
            //Ejercicio1.Ejecutar();

            //Console.WriteLine("\nEJECUTANDO EJERCICIO 2\n");
            //Ejercicio2.Ejecutar();

            //Console.WriteLine("\nEJECUTANDO EJERCICIO 3\n");
            //Ejercicio3.Ejecutar();
        }
    }
    class Carta
    {
        public string Palo { get; set; }
        public string Valor { get; set; }

        public override string ToString() => $"{Valor} de {Palo}";
    }

    class Baraja
    {
        private List<Carta> cartas = new List<Carta>();
        private static readonly string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
        private static readonly string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public Baraja()
        {
            foreach (var palo in palos)
                foreach (var valor in valores)
                    cartas.Add(new Carta { Palo = palo, Valor = valor });
        }

        public void Barajar()
        {
            Random rnd = new Random();
            for (int i = 0; i < cartas.Count; i++)
            {
                int j = rnd.Next(i, cartas.Count);
                (cartas[i], cartas[j]) = (cartas[j], cartas[i]);
            }
        }

        public List<Carta> Repartir(int cantidad)
        {
            return cartas.GetRange(0, Math.Min(cantidad, cartas.Count));
        }
    }

    class Ejercicio1
    {
        public static void Ejecutar()
        {
            Baraja baraja = new Baraja();
            baraja.Barajar();
            var cartas = baraja.Repartir(5);
            Console.WriteLine("Cartas repartidas:");
            foreach (var carta in cartas)
                Console.WriteLine(carta);
        }
    }

    // ===========================
    // EJERCICIO 2: CRUD de estudiantes
    // ===========================

    class Estudiante
    {
        public string Matricula, Nombre, Apellido, Telefono, Correo, Carrera, Grado;
    }

    class SistemaEstudiantes
    {
        private List<Estudiante> lista = new List<Estudiante>();

        public void Agregar(Estudiante e) => lista.Add(e);

        public Estudiante Buscar(string matricula) => lista.Find(e => e.Matricula == matricula);

        public bool Eliminar(string matricula)
        {
            var e = Buscar(matricula);
            if (e != null)
            {
                lista.Remove(e);
                return true;
            }
            return false;
        }

        public bool Modificar(string matricula, Estudiante nuevo)
        {
            var e = Buscar(matricula);
            if (e != null)
            {
                e.Nombre = nuevo.Nombre;
                e.Apellido = nuevo.Apellido;
                e.Telefono = nuevo.Telefono;
                e.Correo = nuevo.Correo;
                e.Carrera = nuevo.Carrera;
                e.Grado = nuevo.Grado;
                return true;
            }
            return false;
        }

        public void MostrarTodos()
        {
            foreach (var e in lista)
                Console.WriteLine($"\n{e.Matricula}, {e.Nombre}, {e.Apellido}, {e.Telefono}, {e.Correo}, {e.Carrera}, {e.Grado}");
        }
    }

    class Ejercicio2
    {
        public static void Ejecutar()
        {
            SistemaEstudiantes sistema = new SistemaEstudiantes();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Estudiantes ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Modificar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Mostrar todos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Estudiante nuevo = LeerEstudiante();
                        sistema.Agregar(nuevo);
                        Console.WriteLine("Estudiante agregado correctamente.");
                        break;
                    case "2":
                        Console.Write("Ingrese la matrícula a buscar: ");
                        var encontrado = sistema.Buscar(Console.ReadLine());
                        if (encontrado != null)
                            Console.WriteLine($"Encontrado: {encontrado.Matricula}, {encontrado.Nombre} {encontrado.Apellido}");
                        else
                            Console.WriteLine("No encontrado.");
                        break;
                    case "3":
                        Console.Write("Ingrese matrícula del estudiante a modificar: ");
                        string matMod = Console.ReadLine();
                        Estudiante datosNuevos = LeerEstudiante();
                        if (sistema.Modificar(matMod, datosNuevos))
                            Console.WriteLine("Modificado exitosamente.");
                        else
                            Console.WriteLine("No encontrado.");
                        break;
                    case "4":
                        Console.Write("Ingrese matrícula a eliminar: ");
                        if (sistema.Eliminar(Console.ReadLine()))
                            Console.WriteLine("Eliminado.");
                        else
                            Console.WriteLine("No encontrado.");
                        break;
                    case "5":
                        sistema.MostrarTodos();
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static Estudiante LeerEstudiante()
        {
            Estudiante e = new Estudiante();
            Console.Write("Matrícula: "); e.Matricula = Console.ReadLine();
            Console.Write("Nombre: "); e.Nombre = Console.ReadLine();
            Console.Write("Apellido: "); e.Apellido = Console.ReadLine();
            Console.Write("Teléfono: "); e.Telefono = Console.ReadLine();
            Console.Write("Correo: "); e.Correo = Console.ReadLine();
            Console.Write("Carrera: "); e.Carrera = Console.ReadLine();
            Console.Write("Grado: "); e.Grado = Console.ReadLine();
            return e;
        }
    }

    // ===========================
    // EJERCICIO 3: Matriz y mínimo/máximo
    // ===========================

    class Ejercicio3
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese número de filas: ");
            int filas = int.Parse(Console.ReadLine());
            Console.Write("Ingrese número de columnas: ");
            int columnas = int.Parse(Console.ReadLine());

            int[,] matriz = new int[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write($"Valor para [{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }

            Console.WriteLine("\nMatriz ingresada:");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                    Console.Write(matriz[i, j] + "\t");
                Console.WriteLine();
            }

            int max = matriz[0, 0], min = matriz[0, 0];
            (int fMax, int cMax) = (0, 0);
            (int fMin, int cMin) = (0, 0);

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    if (matriz[i, j] > max) { max = matriz[i, j]; fMax = i; cMax = j; }
                    if (matriz[i, j] < min) { min = matriz[i, j]; fMin = i; cMin = j; }
                }

            Console.WriteLine($"\nValor máximo: {max} en [{fMax},{cMax}]");
            Console.WriteLine($"Valor mínimo: {min} en [{fMin},{cMin}]");
        }
    }


}
