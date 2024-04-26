using System;

namespace DiaDeLaSemana
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el primer día del mes:");

            string firstDay = Console.ReadLine();

            Console.WriteLine("Ingrese el número del día que quiere saber que cae:");

            int day = 0;

            while (day < 1 || 31 < day)
            {
                day = int.Parse(Console.ReadLine());

                if (day < 1 || 31 < day)
                {
                    Console.WriteLine("Ingrese un día válido:");
                }
            }

            DiaSemana.diaCorrespondiente(firstDay, day);
        }

    }

    public class DiaSemana
    {
        public static void diaCorrespondiente(string firstDay, int day)
        {
            switch (nroDiaSemana(firstDay, day))
            {
                case 1:
                    Console.WriteLine("Lunes");
                    break;
                case 2:
                    Console.WriteLine("Martes");
                    break;
                case 3:
                    Console.WriteLine("Miércoles");
                    break;
                case 4:
                    Console.WriteLine("Jueves");
                    break;
                case 5:
                    Console.WriteLine("Viernes");
                    break;
                case 6:
                    Console.WriteLine("Sábado");
                    break;
                case 7:
                    Console.WriteLine("Domingo");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static int nroDiaSemana(string firstDay, int day = 1)
        {
            if (firstDay == "Lunes" || firstDay == "lunes")
            {
                day = day;
            }
            else if (firstDay == "Martes" || firstDay == "martes")
            {
                day = day + 1;
            }
            else if (firstDay == "Miércoles" || firstDay == "Miercoles" || firstDay == "miércoles" || firstDay == "miercoles")
            {
                day = day + 2;
            }
            else if (firstDay == "Jueves" || firstDay == "jueves")
            {
                day = day + 3;
            }
            else if (firstDay == "Viernes" || firstDay == "viernes")
            {
                day = day + 4;
            }
            else if (firstDay == "Sábado" || firstDay == "Sabado" || firstDay == "sábado" || firstDay == "sabado")
            {
                day = day + 5;
            }
            else if (firstDay == "Domingo" || firstDay == "domingo")
            {
                day = day + 6;
            }

            while (day > 7)
            {
                day = day - 7;
            }

            return day;
        }
    }
}
