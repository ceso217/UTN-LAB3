using System;
using System.Text.RegularExpressions;

namespace ZOO
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string nombre;
            string especie;
            string comida;
            Zoologico zoo = new Zoologico();
            Cuidador cuidador;
            Animal animal;

            do
            {
                Console.WriteLine("Seleccione que quiere hacer: \n 1. Agregar animal \n 2. Agregar cuidador \n 3. Eliminar animal \n 4. Eliminar cuidador \n 5. Asignar animal a un cuidador \n 6. Mostrar cuidadores y animales \n 7.        Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        zoo.agregarAnimal(new Mamifero("Juan", "Leon", "Carne"));
                        zoo.agregarAnimal(new Mamifero("Snape", "Serpiente", "Conejos"));
                        zoo.agregarAnimal(new Ave("Pedro", "Aguila", "Niños"));
                        zoo.agregarAnimal(new Pez("Jorge", "Dorado", "Gusanos"));
                        zoo.agregarAnimal(new Pez("Nemo", "Pez Payaso", "Lombrizes"));
                        /*Console.Write("Ingrese el nombre del animal: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Seleccione el grupo del animal: \n 1. Mamifero \n 2. Ave \n 3. Pez");
                        opcion = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la especie: ");
                        especie = Console.ReadLine();
                        Console.Write("Ingrese lo que come el animal: ");
                        comida = Console.ReadLine();
                        switch (opcion)
                        {
                            case 1:
                                zoo.agregarAnimal(new Mamifero(nombre, especie, comida));
                                break;
                            case 2:
                                zoo.agregarAnimal(new Ave(nombre, especie, comida));
                                break;
                            case 3:
                                zoo.agregarAnimal(new Pez(nombre, especie, comida));
                                break;
                            default:
                                Console.WriteLine("Elección inválida.");
                                break;
                        }*/
                        break;
                    case 2:
                        //Console.Write("Ingrese el nombre del cuidador: ");
                        zoo.agregarCuidador(new Cuidador("Lucas"));
                        zoo.agregarCuidador(new Cuidador("Cristian"));
                        zoo.agregarCuidador(new Cuidador("Carmelo"));
                        
                        break;
                    case 3:
                        Console.Write("Ingrese el nombre del animal que quiere eliminar: ");
                        zoo.eliminarAnimal(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Ingrese el nombre del cuidador: ");
                        zoo.eliminarCuidador(Console.ReadLine());
                        break;
                    case 5:
                        zoo.asignarCuidadorAnimal(new Cuidador("Lucas"), new Animal("Juan"));
                        zoo.asignarCuidadorAnimal(new Cuidador("Lucas"), new Animal("Pedro"));
                        zoo.asignarCuidadorAnimal(new Cuidador("Lucas"), new Animal("Jorge"));
                        zoo.asignarCuidadorAnimal(new Cuidador("Cristian"), new Animal("Snape"));
                        /*Console.Write("Ingrese el nombre del cuidador al que quiere asignar un animal: ");
                        nombre = Console.ReadLine();
                        cuidador = new Cuidador(nombre);
                        Console.Write("Ingrese el nombre del animal: ");
                        nombre = Console.ReadLine();
                        animal = new Animal(nombre, "x", "x");
                        zoo.asignarCuidadorAnimal(cuidador, animal);*/
                        break;
                    case 6:
                        zoo.mostrarCuidadoresYAnimales();
                        break;
                    case 7:
                        break;
                    case 8:
                        
                        break;
                }
            } while (opcion != 9);
        }
    }

    class Zoologico
    {
        private List<IAnimal> listaAnimales;
        private List<Cuidador> listaCuidadores;

        public Zoologico()
        {
            this.listaAnimales = new List<IAnimal>();
            this.listaCuidadores = new List<Cuidador>();
        }

        public void agregarAnimal(Animal animal)
        {
            listaAnimales.Add(animal);
        }

        public void eliminarAnimal(string nombre)
        {
            int indice = -1;
            foreach (Animal animal in listaAnimales)
            {
                if (animal.Nombre == nombre)
                {
                    indice = listaAnimales.IndexOf(animal);
                }
            }
            if (indice == -1)
            {
                Console.WriteLine("No existe ningún animal con ese nombre");
            }
            else
            {
                listaAnimales.Remove(listaAnimales[indice]);
                Console.WriteLine("Se eliminó el animal exitosamente!");
            }
        }

        public void agregarCuidador(Cuidador cuidador)
        {
            listaCuidadores.Add(cuidador);
        }

        public void eliminarCuidador(string nombre)
        {
            int existe = 0;
            foreach (Cuidador cuidador in listaCuidadores)
            {
                if (cuidador.Nombre == nombre)
                {
                    listaCuidadores.Remove(cuidador);
                    existe++;
                }
            }
            if (existe != 1)
            {
                Console.WriteLine("No existe ningún cuidador con ese nombre");
            }
        }

        public void asignarCuidadorAnimal(Cuidador nombreCuidador, Animal nombreAnimal)
        {
            int existeC = 0;
            int existeA = 0;

            foreach (Cuidador cuidador in listaCuidadores)
            {
                if (cuidador.Nombre == nombreCuidador.Nombre)
                {
                    existeC++;
                    foreach (Animal animal in listaAnimales)
                    {
                        if (animal.Nombre == nombreAnimal.Nombre)
                        {
                            cuidador.AnimalesACargo.Add(animal);
                            animal.Asignado = true;
                            existeA++;
                        }
                    }
                    if (existeA != 1)
                    {
                        Console.WriteLine("El animal ingresado no existe");
                    }
                }
            }
            if (existeC != 1)
            {
                Console.WriteLine("El cuidador ingresado no existe");
            }
        }

        public void mostrarAnimales()
        {
            if (listaAnimales.Count == 0)
            {
                Console.WriteLine("La lista de animales está vacía");
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Nombre", "Especie", "Comida");
                foreach (Animal animal in listaAnimales)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-15}", animal.Nombre, animal.Especie, animal.Comida);
                }
            }
        }
        public void mostrarCuidadores()
        {
            if (listaCuidadores.Count == 0)
            {
                Console.WriteLine("La lista de cuidadores está vacía");
            }
            else
            {
                Console.WriteLine("{0,-15} ", "Nombre");
                foreach (Cuidador cuidador in listaCuidadores)
                {
                    Console.WriteLine("{0,-15}", cuidador.Nombre);
                }
            }
        }

        public void mostrarCuidadoresYAnimales()
        {
            // cuidadores con animales asignados
            int animalesAsignados = 0;
            int cuidadoresAsignados = 0;
            foreach (Animal animal in listaAnimales)
            {
                if (animal.Asignado == true)
                {
                    animalesAsignados++;
                }
            }
            Console.WriteLine(listaAnimales.Count);
            if (animalesAsignados != 0)
            {
                Console.WriteLine("Los cuidadores con sus animales asignados son los siguientes: ");
                Console.WriteLine("{0,-15} {1,-15}", "Cuidador", "Animales a cargo");

                foreach (Cuidador cuidador in listaCuidadores)
                {
                    if (cuidador.AnimalesACargo.Count != 0)
                    {
                        Console.Write("{0,-15}", cuidador.Nombre);
                        foreach (Animal animal in cuidador.AnimalesACargo)
                        {
                            if (animal != cuidador.AnimalesACargo[cuidador.AnimalesACargo.Count - 1])
                            {
                                Console.Write($" {animal.Nombre} ({animal.Especie}) //");
                            }
                            else
                            {
                                Console.Write($" {animal.Nombre} ({animal.Especie})");
                            }
                        }
                        Console.WriteLine("");
                    }
                }
            }
            // cuidadores sin animales asignados
            foreach(Cuidador cuidador in listaCuidadores)
            {
                if(cuidador.AnimalesACargo.Count != 0)
                {
                    cuidadoresAsignados++;
                }
            }
            if (cuidadoresAsignados != listaCuidadores.Count)
            {
                Console.WriteLine("Los cuidadores sin animales asignados son:");
                foreach (Cuidador cuidador in listaCuidadores)
                {
                    if (cuidador.AnimalesACargo.Count == 0)
                    {
                        Console.WriteLine("{0,-15}", cuidador.Nombre);
                    }
                }
            }
            // animales sin asignar
            if (animalesAsignados != listaAnimales.Count)
            {
                Console.WriteLine("Los animales sin asignar son:");
                foreach (Animal animal in listaAnimales)
                {
                    if (animal.Asignado == false)
                    {
                        Console.WriteLine($"{animal.Nombre} ({animal.Especie})");
                    }
                }
            }
        }
    }

    class Animal : IAnimal
    {
        public string Nombre { get; }
        public string Especie { get; }
        public string Comida { get; set; }
        public bool Asignado { get; set; }

        public Animal(string nombre, string especie, string comida)
        {
            this.Nombre = nombre;
            this.Especie = especie;
            this.Comida = comida;
            this.Asignado = false;
        }

        public Animal(string nombre)
        {
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Especie: {Especie}, Comida: {Comida}";
        }

        public void comer()
        {
            Console.WriteLine("El " + Nombre + " comió " + Comida);
        }

        public void mostarDatos()
        {
            Console.WriteLine(Nombre + "\t" + Especie + "\t" + Comida);
        }
    }

    class Mamifero : Animal
    {
        public Mamifero(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void amamantar()
        {
            Console.WriteLine("El " + this.Nombre + " amamanta");
        }
    }

    class Ave : Animal
    {
        public Ave(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void volar()
        {
            Console.WriteLine("El " + this.Nombre + " vuela");
        }
    }

    class Pez : Animal
    {
        public Pez(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void nadar()
        {
            Console.WriteLine("El " + this.Nombre + "nada");
        }
    }

    class PlantaCarnivora : IAnimal
    {
        public string Nombre { get; }
        public string Tipo { get; }
        public string TipoCarnivoro { get; }

        public PlantaCarnivora(string nombre, string tipo, string tipoCarnivoro)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.TipoCarnivoro = tipoCarnivoro;
        }

        public void comer()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 5))
            {
                case 1:
                    Console.WriteLine("El " + this.Nombre + " comió una mosca ");
                    break;
                case 2:
                    Console.WriteLine("El " + this.Nombre + " comió una hormiga ");
                    break;
                case 3:
                    Console.WriteLine("El " + this.Nombre + " comió una araña ");
                    break;
                case 4:
                    Console.WriteLine("El " + this.Nombre + " comió una hormiga ");
                    break;
            }
        }
    }

    class Cuidador
    {
        public string Nombre { get; }
        public List<IAnimal> AnimalesACargo { get; }

        public Cuidador(string nombre)
        {
            this.Nombre = nombre;
            this.AnimalesACargo = new List<IAnimal>();
        }

        public void agregarAnimalACargo(Animal animal)
        {
            AnimalesACargo.Add(animal);
        }

        public void alimentar(List<IAnimal> animales)
        {
            foreach (Animal animal in animales)
            {
                animal.comer();
            }
        }
    }

    interface IAnimal
    {
        public void comer();
    }
}