using System;
using System.Text.RegularExpressions;

namespace ZOO
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string nombreA;
            string nombreC;
            string especie;
            string comida;
            string tipo;
            string tipoCarnivoro;
            Zoologico zoo = new Zoologico();

            do
            {
                Console.WriteLine("Seleccione que quiere hacer: \n 1. Agregar animal \n 2. Agregar planta carnívora \n 3. Agregar cuidador \n 4. Eliminar animal o planta carnívora \n 5. Eliminar cuidador \n 6. Asignar animal a un cuidador \n 7. Mostrar cuidadores, animales y plantas carnívoras \n 8. Alimentar animales y plantas carnívoras\n 9. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        /*zoo.agregarAnimal(new Mamifero("Juan", "Leon", "Carne"));
                        zoo.agregarAnimal(new Mamifero("Snape", "Serpiente", "Conejos"));
                        zoo.agregarAnimal(new Ave("Pedro", "Aguila", "Niños"));
                        zoo.agregarAnimal(new Pez("Jorge", "Dorado", "Gusanos"));
                        zoo.agregarAnimal(new Pez("Nemo", "Pez Payaso", "Lombrizes"));*/
                        Console.Write("Ingrese el nombre del animal: ");
                        nombreA = Console.ReadLine();
                        Console.WriteLine("Seleccione el grupo del animal: \n 1. Mamifero \n 2. Ave \n 3. Pez");
                        opcion = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la especie: ");
                        especie = Console.ReadLine();
                        Console.Write("Ingrese lo que come el animal: ");
                        comida = Console.ReadLine();
                        switch (opcion)
                        {
                            case 1:
                                zoo.agregarAnimal(new Mamifero(nombreA, especie, comida));
                                break;
                            case 2:
                                zoo.agregarAnimal(new Ave(nombreA, especie, comida));
                                break;
                            case 3:
                                zoo.agregarAnimal(new Pez(nombreA, especie, comida));
                                break;
                            default:
                                Console.WriteLine("Elección inválida.");
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("Ingrese el nombre de la planta carnívora: ");
                        nombreA = Console.ReadLine();
                        Console.Write("Ingrese el tipo: ");
                        tipo = Console.ReadLine();
                        Console.Write("Ingrese el tipo de trampa: ");
                        tipoCarnivoro = Console.ReadLine();
                        zoo.agregarPlanta(new PlantaCarnivora(nombreA, tipo, tipoCarnivoro));
                        /*zoo.agregarPlanta(new PlantaCarnivora("Nepenthes", "Trepadora", "Trampa líquida"));
                        zoo.agregarPlanta(new PlantaCarnivora("Drosera", "Herbácea", "Trampa pegajosa"));*/
                        break;
                    case 3:
                        Console.Write("Ingrese el nombre del cuidador: ");
                        nombreC = Console.ReadLine();
                        zoo.agregarCuidador(new Cuidador(nombreC));
                        /*zoo.agregarCuidador(new Cuidador("Lucas"));
                        zoo.agregarCuidador(new Cuidador("Cristian"));
                        zoo.agregarCuidador(new Cuidador("Carmelo"));
                        zoo.agregarCuidador(new Cuidador("Daiana"));*/
                        break;
                    case 4:
                        Console.Write("Ingrese el nombre del animal o planta carnívora que quiere eliminar: ");
                        zoo.eliminarAnimal(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Ingrese el nombre del cuidador: ");
                        zoo.eliminarCuidador(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Ingrese el nombre del cuidador al que quiere asignar un animal: ");
                        nombreC = Console.ReadLine();
                        Console.Write("Ingrese el nombre del animal: ");
                        nombreA = Console.ReadLine();
                        zoo.asignarCuidadorAnimal(nombreC, nombreA);
                        /*zoo.asignarCuidadorAnimal("Lucas", "Juan");
                        zoo.asignarCuidadorAnimal("Lucas", "Pedro");
                        zoo.asignarCuidadorAnimal("Lucas", "Jorge");
                        zoo.asignarCuidadorAnimal("Cristian", "Snape");
                        zoo.asignarCuidadorAnimal("Daiana", "Nepenthes");*/
                        break;
                    case 7:
                        zoo.mostrarCuidadoresYAnimales();
                        break;
                    case 8:
                        zoo.alimentarAnimales();
                        break;
                    case 9:
                        Console.WriteLine("Gracias por usar nuestro programa!");
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

        public void agregarAnimal(SerVivo animal)
        {
            listaAnimales.Add(animal);
        }

        public void agregarPlanta(PlantaCarnivora plantaCarnivora)
        {
            listaAnimales.Add(plantaCarnivora);
        }

        // después de hacer este método creo que soy dios
        public void eliminarAnimal(string nombre)
        {
            int indiceAnimales = -1;
            int indiceCuidador = -1;
            int indiceAnimalACargo = -1;

            foreach (SerVivo animal in listaAnimales)
            {
                if (animal.Nombre == nombre)
                {
                    // si existe el animal guarda el indice de la posición en la que se encuentra
                    indiceAnimales = listaAnimales.IndexOf(animal);
                    if (animal.Asignado)
                    {
                        foreach(Cuidador cuidador in listaCuidadores)
                        {
                            foreach(SerVivo serVivo in cuidador.AnimalesACargo)
                            {
                                if (serVivo.Nombre == nombre)
                                {
                                    // si el animal fue asignado a un cuidador guarda el indice del cuidador y el indice del animal en la lista de animales a cargo del cuidador
                                    indiceCuidador = listaCuidadores.IndexOf(cuidador);
                                    indiceAnimalACargo = cuidador.AnimalesACargo.IndexOf(animal);
                                }
                            }
                        }
                    }
                }
            }
            // si no existe el animal tira un mensaje de error, y si existe lo elimina de la lista de animales del zoo
            if (indiceAnimales == -1)
            {
                Console.WriteLine("No existe ningún animal con ese nombre");
            }
            else
            {
                // si el indice es distindo al por defecto, en este caso -1, significa que el animal había sido asignado a un cuidador
                // por ende procede a eliminar al animal de la lista de animales a cargo del cuidador haciendo uso de los indices tomados anteriormente
                if(indiceCuidador != -1)
                {
                    listaCuidadores[indiceCuidador].AnimalesACargo.Remove(listaCuidadores[indiceCuidador].AnimalesACargo[indiceAnimalACargo]);
                }
                listaAnimales.Remove(listaAnimales[indiceAnimales]);
                Console.WriteLine("Se eliminó el animal exitosamente!");
            }
        }

        public void agregarCuidador(Cuidador cuidador)
        {
            listaCuidadores.Add(cuidador);
        }

        public void eliminarCuidador(string nombre)
        {
            int indice = -1;
            foreach (Cuidador cuidador in listaCuidadores)
            {
                if (cuidador.Nombre == nombre)
                {
                    indice = listaCuidadores.IndexOf(cuidador);
                }
            }
            if (indice == -1)
            {
                Console.WriteLine("No existe ningún cuidador con ese nombre");
            }
            else
            {
                listaCuidadores.Remove(listaCuidadores[indice]);
                Console.WriteLine("Se eliminó al cuidador exitosamente!");
            }
        }

        public void asignarCuidadorAnimal(string nombreCuidador, string nombreAnimal)
        {
            int existeC = 0;
            int existeA = 0;

            foreach (Cuidador cuidador in listaCuidadores)
            {
                if (cuidador.Nombre == nombreCuidador)
                {
                    existeC++;
                    foreach (SerVivo animal in listaAnimales)
                    {
                        if (animal.Nombre == nombreAnimal)
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

        public void mostrarCuidadoresYAnimales()
        {
            // cuidadores con animales asignados
            int animalesAsignados = 0;
            int cuidadoresAsignados = 0;
            if (listaAnimales.Count == 0 && listaCuidadores.Count == 0)
            {
                Console.WriteLine("No hay cuidadores, animales ni plantas carnívoras en el zoo");
            }
            else
            {
                foreach (SerVivo animal in listaAnimales)
                {
                    if (animal.Asignado == true)
                    {
                        animalesAsignados++;
                    }
                }
                if (animalesAsignados != 0)
                {
                    Console.WriteLine("Los cuidadores con sus animales asignados son los siguientes: \n");
                    Console.WriteLine("{0,-15} {1,-15}", "Cuidador", "Animales a cargo");

                    foreach (Cuidador cuidador in listaCuidadores)
                    {
                        if (cuidador.AnimalesACargo.Count != 0)
                        {
                            Console.Write("{0,-15}", cuidador.Nombre);
                            foreach (SerVivo animal in cuidador.AnimalesACargo)
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
                foreach (Cuidador cuidador in listaCuidadores)
                {
                    if (cuidador.AnimalesACargo.Count != 0)
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
                    bool sonAnimales = false;
                    bool sonPlantas = false;
                    // revisa si los seres vivos que faltan asignar son animales
                    foreach (SerVivo serVivo in listaAnimales)
                    {
                        if (serVivo is not PlantaCarnivora && !serVivo.Asignado)
                        {
                            if (!serVivo.Asignado)
                            {
                                sonAnimales = true;
                            }
                        }
                    }
                    // si son animales, los imprime
                    if (sonAnimales)
                    {
                        Console.WriteLine("Los animales sin asignar son:");
                        foreach (SerVivo serVivo in listaAnimales)
                        {
                            if (serVivo is not PlantaCarnivora && !serVivo.Asignado)
                            {
                                Console.WriteLine($"{serVivo.Nombre} ({serVivo.Especie})");
                            }
                        }
                    }
                    // revisa si los seres vivos que faltan asignar son plantas carnívoras
                    foreach (SerVivo serVivo in listaAnimales)
                    {
                        if (serVivo is PlantaCarnivora && !serVivo.Asignado)
                        {
                            if (!serVivo.Asignado)
                            {
                                sonPlantas = true;
                            }
                        }
                    }
                    // si son plantas, las imprime
                    if (sonPlantas)
                    {
                        Console.WriteLine("Las plantas carnívoras sin asignar son:");
                        foreach (SerVivo serVivo in listaAnimales)
                        {
                            if (serVivo is PlantaCarnivora && !serVivo.Asignado)
                            {
                                Console.WriteLine($"{serVivo.Nombre} ({serVivo.Especie})");
                            }
                        }
                    }
                }
            }
        }

        public void alimentarAnimales()
        {
            bool existeC = false;
            bool existeA = false;
            foreach (Cuidador cuidador in listaCuidadores)
            {
                existeC = true;
                if (cuidador.AnimalesACargo.Count == 0)
                {
                    Console.WriteLine($"{cuidador.Nombre} no tiene animales a cargo para alimentar");
                }
                else
                {
                    Console.WriteLine($"{cuidador.Nombre} alimenta a sus animales:");
                }
                foreach (SerVivo animal in cuidador.AnimalesACargo)
                {
                    Console.Write("    ");
                    animal.comer();
                    existeA = true;
                }
            }
            if (existeC == false)
            {
                Console.WriteLine("No hay ningún cuidador");
            }
        }
    }

    class SerVivo : IAnimal
    {
        public string Nombre { get; }
        public string Especie { get; set; }
        public string Comida { get; set; }
        public bool Asignado { get; set; }
        public bool Alimentado { get; set; }

        public SerVivo(string nombre, string especie, string comida)
        {
            this.Nombre = nombre;
            this.Especie = especie;
            this.Comida = comida;
            this.Asignado = false;
            this.Alimentado = false;
        }

        public SerVivo(string nombre)
        {
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Especie: {Especie}, Comida: {Comida}";
        }

        public virtual void comer()
        {
            if (Alimentado == false)
            {
                Console.WriteLine($"{Nombre} el {Especie} comió {Comida}");
                Alimentado = true;
            }
            else
            {
                Console.WriteLine($"{Nombre} el {Especie} ya comió");
            }
        }

        public void mostarDatos()
        {
            Console.WriteLine(Nombre + "\t" + Especie + "\t" + Comida);
        }
    }

    class Mamifero : SerVivo
    {
        public Mamifero(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void amamantar()
        {
            Console.WriteLine("El " + this.Nombre + " amamanta");
        }
    }

    class Ave : SerVivo
    {
        public Ave(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void volar()
        {
            Console.WriteLine("El " + this.Nombre + " vuela");
        }
    }

    class Pez : SerVivo
    {
        public Pez(string nombre, string especie, string comida) : base(nombre, especie, comida)
        {
        }

        public void nadar()
        {
            Console.WriteLine("El " + this.Nombre + "nada");
        }
    }

    class PlantaCarnivora : SerVivo, IAnimal
    {
        public string Tipo { get; }
        public string TipoCarnivoro { get; }

        public PlantaCarnivora(string nombre, string tipo, string tipoCarnivoro) : base(nombre)
        {
            this.Especie = "Planta Carnívora";
            this.Tipo = tipo;
            this.TipoCarnivoro = tipoCarnivoro;
        }

        public override void comer()
        {
            Random rnd = new Random();
            if (!this.Alimentado)
            {
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        Console.WriteLine($"{this.Nombre} la planta carnívora comió una mosca ");
                        break;
                    case 2:
                        Console.WriteLine($"{this.Nombre} la planta carnívora comió una hormiga ");
                        break;
                    case 3:
                        Console.WriteLine($"{this.Nombre} la planta carnívora comió una araña ");
                        break;
                    case 4:
                        Console.WriteLine($"{this.Nombre} la planta carnívora comió una hormiga ");
                        break;
                }
                Alimentado = true;
            }
            else
            {
                Console.WriteLine($"{this.Nombre} la planta carnívora ya comió");
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

        public void agregarAnimalACargo(SerVivo animal)
        {
            AnimalesACargo.Add(animal);
        }

        public void alimentar(List<IAnimal> animales)
        {
            foreach (SerVivo animal in animales)
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