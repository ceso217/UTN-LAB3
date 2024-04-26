namespace CajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            int monto;
            Cajero cajero = new Cajero("25 de Mayo");
            CuentaBancaria cuenta;

            Console.WriteLine("Bienvenido al cajero automatico!");
            Console.WriteLine("¿Qué desea hacer?\n1. Crear cuenta\n2. Salir");
            do
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Ingrese una opcion válida");
                }
            } while (opcion != 1 && opcion != 2);
            if (opcion == 2)
            {
                Console.WriteLine("Gracias por usar nuestro cajero!");
                Environment.Exit(0);
            }

            cuenta = cajero.crearCuenta();

            do
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Depositar");
                Console.WriteLine("2. Retirar");
                Console.WriteLine("3. Mostrar datos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        cajero.deposito(cuenta, cajero.nroCajero);
                        break;
                    case 2:
                        cajero.retiro(cuenta, cajero.nroCajero);
                        break;
                    case 3:
                        cuenta.mostrarDatos();
                        break;
                    case 4:
                        Console.WriteLine("Gracias por utilizar nuestro cajero automático.");
                        break;
                    default:
                        
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            } while (opcion != 4);
        }
    }

    class Cajero
    {
        public string direccion;
        public int nroCajero;
        Random rnd = new Random();
        static int i = 0;


        public Cajero(string direccion)
        {
            this.direccion = direccion;
            this.nroCajero = rnd.Next(3000, 5000);
        }

        public CuentaBancaria crearCuenta()
        {
            string nom;
            string dir;
            int opcion;
            string tipoUs = "a";

            Console.WriteLine("Ingrese su nombre:");
            nom = Console.ReadLine();
            Console.WriteLine("Ingrese su dirección:");
            dir = Console.ReadLine();
            Console.WriteLine("Seleccione el tipo de usuario: \n 1. En actividad laboral\n 2. Jubilado");
            do
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Ingrese una opcion válida");
                }
            } while (opcion != 1 && opcion != 2);

            switch (opcion)
            {
                case 1:
                    tipoUs = "En activdad laboral";
                    break;
                case 2:
                    tipoUs = "Jubilado";
                    break;
            }

            CuentaBancaria cuenta = new CuentaBancaria(new Usuario(nom, dir, tipoUs));
            return cuenta;
        }

        public void deposito(CuentaBancaria cuenta, int nroCajero)
        {
            int monto;
            Console.WriteLine("Ingrese el monto a depositar:");
            monto = int.Parse(Console.ReadLine());
            cuenta.LOperaciones[i] = cuenta.deposito(nroCajero, monto);
            i++;
        }
        public void retiro(CuentaBancaria cuenta, int nroCajero)
        {
            int monto;
            Console.WriteLine("Ingrese el monto a retirar:");
            monto = int.Parse(Console.ReadLine());
            cuenta.LOperaciones[i] = cuenta.retiro(nroCajero, monto);
            i++;
        }
    }

    class CuentaBancaria
    {
        private static int _nroCuenta = 1;

        private int nroCuenta { get; }
        private float saldoActual { get; set; }
        private DateTime fechaApertura { get; }
        Usuario usuario { get; }
        public Operacion[] LOperaciones { get; }

        int mesesAcum;

        public CuentaBancaria(Usuario usuario)
        {
            this.nroCuenta = _nroCuenta++;
            this.saldoActual = 0;
            this.fechaApertura = DateTime.Now;
            this.usuario = usuario;
            this.LOperaciones = new Operacion[50];
        }

        public Operacion deposito(int nroCajero, int monto)
        {
            saldoActual = saldoActual + monto;

            Operacion op = new Operacion(nroCajero, "Deposito", monto);

            return op;
        }
        public Operacion retiro(int nroCajero, int monto)
        {
            Operacion op = null;

            if (usuario.tipoUs == "Jubilado")
            {
                if ((this.saldoActual-monto) < -10000)
                {
                    Console.WriteLine("Los jubilados solo pueden retirar hasta $10000 en concepto de adelanto de sueldo");
                } else
                {
                    saldoActual = saldoActual- monto;
                    op = new Operacion(nroCajero, "Retiro", monto);
                    return op;
                }
            }
            if (usuario.tipoUs == "En activdad laboral")
            {
                if ((this.saldoActual - monto) < -20000)
                {
                    Console.WriteLine("Los usuario en actividad laboral solo pueden retirar hasta $20000 en concepto de adelanto de sueldo");
                }
                else
                {
                    saldoActual = saldoActual - monto;
                    op = new Operacion(nroCajero, "Retiro", monto);
                    return op;
                }
            }
            return op;
        }

        public void preacordado()
        {
            foreach(Operacion operacion in LOperaciones)
            {
                if()
            }
        }

        public void mostrarDatos()
        {
            Console.WriteLine("Número de cuenta: {0}", this.nroCuenta);
            Console.WriteLine("Saldo actual: {0}", this.saldoActual);
            Console.WriteLine("Fecha de apertura: {0}", this.fechaApertura);
            Console.WriteLine("Información del usuario:");
            Console.WriteLine("  ID de usuario: {0}", this.usuario.id);
            Console.WriteLine("  Nombre: {0}", this.usuario.nombre);
            Console.WriteLine("  Dirección: {0}", this.usuario.direccion);
            Console.WriteLine("  Tipo de usuario: {0}", this.usuario.tipoUs);
            mostrarOperaciones();
        }

        public void mostrarOperaciones()
        {
            Console.WriteLine("Operaciones realizadas en la cuenta:");
            foreach (Operacion operacion in LOperaciones)
            {
                if (operacion != null)
                {
                    Console.WriteLine("Fecha: {0}, Tipo: {1}, Monto: {2}, Cajero: {3}",
                        operacion.fecha, operacion.tipoOperacion, operacion.monto, operacion.cajero);
                }
            }
        }
    }

    class Usuario
    {
        private static int _id = 1;

        public int id { get; }
        public string nombre { get; }
        public string direccion { get; }
        public string tipoUs { get; }

        public Usuario(string nombre, string direccion, string tipoUs)
        {
            this.id = _id++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.tipoUs = tipoUs;
        }
    }

    class Operacion
    {
        public DateTime fecha;
        public int cajero;
        public string tipoOperacion;
        public int monto;

        public Operacion(int cajero, string tipoOperacion, int monto)
        {
            this.fecha = DateTime.Now;
            this.cajero = cajero;
            this.tipoOperacion = tipoOperacion;
            this.monto = monto;
        }
    }
}