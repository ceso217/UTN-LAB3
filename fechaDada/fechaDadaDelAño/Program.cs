using System;
using DiaDeLaSemana;

class Program
{
    static void Main(string[] args)
    {
        string[] meses = new string[12];
        Console.WriteLine("Ingrese que día de la semana cayó el primer día de cada uno de los meses del año");
        Console.Write("Enero: ");
        meses[0] = Console.ReadLine();
        Console.Write("Febrero: ");
        meses[1] = Console.ReadLine();
        Console.Write("Marzo: ");
        meses[2] = Console.ReadLine();
        Console.Write("Abril: ");
        meses[3] = Console.ReadLine();
        Console.Write("Mayo: ");
        meses[4] = Console.ReadLine();
        Console.Write("Junio: ");
        meses[5] = Console.ReadLine();
        Console.Write("Julio: ");
        meses[6] = Console.ReadLine();
        Console.Write("Agosto: ");
        meses[7] = Console.ReadLine();
        Console.Write("Septiembre: ");
        meses[8] = Console.ReadLine();
        Console.Write("Octubre: ");
        meses[9] = Console.ReadLine();
        Console.Write("Noviembre: ");
        meses[10] = Console.ReadLine();
        Console.Write("Diciembre: ");
        meses[11] = Console.ReadLine();

        Console.Write("Ingrese el número del mes del que desea saber el día de la semana: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Ahora el día del mes: ");
        int day = int.Parse(Console.ReadLine());

        //Console.WriteLine(meses[month-1]);
        DiaSemana.diaCorrespondiente(meses[month - 1], day);

        Console.WriteLine("Ingrese ahora el número del mes del que quiere saber que fechas van a caer los fines de semana");
        month = int.Parse(Console.ReadLine());

        Program.finDeSemana(meses[month - 1], month);
    }

    public static void finDeSemana(string day, int month)
    {
        int diasDelMes;
        int nroDia = DiaSemana.nroDiaSemana(day);

        Console.WriteLine("El número es " + nroDia);

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            diasDelMes = 31;
        }
        else if (month == 2)
        {
            diasDelMes = 28;
        }
        else
        {
            diasDelMes = 30;
        }

        //intentando no repetir el codigo de abajo

        nroDia = 7 - nroDia;

        Console.Write("Los días que van a caer fin de semana van a ser ");
        while (nroDia < diasDelMes)
        {
            if (nroDia == 0)
            {
                Console.Write((nroDia+1)+" ");
                nroDia = nroDia + 7;
            }
            else
            {
                Console.Write(nroDia + " " + (nroDia + 1) + " ");
                nroDia = nroDia + 7;
            }
        }
        if (nroDia == diasDelMes)
        {
            Console.Write(nroDia);
        }

        //LO LOGRE FINALMENCHI
    }
}
