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
                Console.WriteLine("Seleccione que quiere hacer: \n 1. Agregar animal \n 2. Eliminar animal \n 3. Agregar cuidador \n 4. Eliminar cuidador \n 5. Asignar animal a un cuidador \n 6. Mostrar animales \n 7. Mostrar cuidadores       Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        zoo.agregarAnimal(new Mamifero("Juan", "Leon", "Carne"));
                        zoo.agregarAnimal(new Ave("Pedro", "Aguila", "Niños"));
                        zoo.agregarAnimal(new Pez("Jorge", "Dorado", "Gusanos"));
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
                        Console.Write("Ingrese el nombre del animal que quiere eliminar: ");
                        zoo.eliminarAnimal(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Ingrese el nombre del cuidador: ");
                        zoo.agregarCuidador(new Cuidador(Console.ReadLine()));
                        break;
                    case 4:
                        Console.Write("Ingrese el nombre del cuidador: ");
                        zoo.eliminarCuidador(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Ingrese el nombre del cuidador al que quiere asignar un animal: ");
                        nombre = Console.ReadLine();
                        cuidador = new Cuidador(nombre);
                        Console.Write("Ingrese el nombre del animal: ");
                        nombre = Console.ReadLine();
                        animal = new Animal(nombre, "x", "x");
                        zoo.asignarCuidadorAnimal(cuidador, animal);
                        break;
                    case 6:
                        zoo.mostrarAnimales();
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
            } else
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
                            cuidador.AnimalesACargo(animal);
                            existeA++;
                        }
                    }
                    if (existeC != 1)
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
                Console.WriteLine("{0,-15} {1,-15} {2,-15}","Nombre","Especie","Comida");
                foreach (Animal animal in listaAnimales)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-15}",animal.Nombre,animal.Especie,animal.Comida);
                }
            }
        }
    }

    class Animal : IAnimal
    {
        private string nombre { get; }
        private string especie { get; }
        private string comida { get; set; }

        public Animal(string nombre, string especie, string comida)
        {
            this.nombre = nombre;
            this.especie = especie;
            this.comida = comida;
        }

        public string Nombre { get { return nombre; } }
        public string Especie { get { return especie; } }
        public string Comida { get { return comida; } set { comida = value; } }

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
        private string nombre;
        private string tipo;
        private string tipoCarnivoro;

        public PlantaCarnivora(string nombre, string tipo, string tipoCarnivoro)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.tipoCarnivoro = tipoCarnivoro;
        }

        public string Nombre { get { return nombre; } }

        public string Tipo { get { return tipo; } }

        public string TipoCarnivoro { get { return tipoCarnivoro; } }

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
        private string nombre;
        private List<IAnimal> animalesACargo;

        public Cuidador(string nombre)
        {
            this.nombre = nombre;
            this.animalesACargo = new List<IAnimal>();
        }

        public void AnimalesACargo(Animal animal)
        {
            animalesACargo.Add(animal);
        }

        public string Nombre { get { return nombre; } }

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