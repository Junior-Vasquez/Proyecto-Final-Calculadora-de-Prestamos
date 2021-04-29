using System;

namespace Calculadora_Prestamos
{
    public class Prestamos
    {
        public double Monto;
        public double Pagos;
        public double Saldo;
        public double AbCapital;
        public double Intereses;
        public double IntAnual;
        public int CuotAs;


        public void Valores()
            
        {
            
            Console.WriteLine("Monto: " + Monto);
            Console.WriteLine("Cuotas: " + CuotAs);
            Console.WriteLine("IntereAnual: " + IntAnual);
            Console.WriteLine("Pago: " + Pagos);
        }
        public void Montos()
        {
            Console.WriteLine("\n                         CALCULADORA DE PRESTAMOS                   ");

            Console.WriteLine("\nDigite el Monto del Prestamo:");
            Monto = Convert.ToDouble(Console.ReadLine());
        }
        public double ReturnMonto()
        {
            return Monto;
        }
        public void Cuotas()
        {
            Console.WriteLine("\nDigite las Cuotas en Meses:");
            CuotAs = int.Parse(Console.ReadLine());
        }

        public int ReturnCuotas()
        {
            return CuotAs;
        }

        public void Interes()
        {
            Console.WriteLine("\nDigite el % de Interes Anual:");
            IntAnual = Convert.ToDouble(Console.ReadLine());
            IntAnual = IntAnual / 100;
            IntAnual = Math.Pow((1 + IntAnual), 0.0833333333) - 1;

        }

        public double ReturnInt()
        {
            return IntAnual;
        }

        public void CalculoPago()
        {

            Pagos = Math.Pow((1 + IntAnual), -(CuotAs));
            Pagos = 1 - Pagos;
            Pagos = IntAnual / Pagos;
            Pagos = Monto * Pagos;
            Pagos = Math.Round(Pagos, 2);
        }

        public double ReturnPago()
        {
            return Pagos;
        }
        public void CalculoIntereses()
        {

            Intereses = Monto * IntAnual;
            Intereses = Math.Round(Intereses, 2);

        }
        public double ReturnIntereses()
        {
            return Intereses;
        }
        public void CalculoAbCapital()
        {

            AbCapital = Pagos - Intereses;
            AbCapital = Math.Round(AbCapital, 2);
        }
        public double ReturnAbCapital()
        {
            return AbCapital;
        }
        public void CalculoSaldo()
        {

            Saldo = Monto - AbCapital;
            Saldo = Math.Round(Saldo, 2); 

        }
        public double ReturnSaldo()
        {
            return Saldo;
        }
        public void NuevosValores(double NuevoSaldo, double NuevoInt, double NuevoAbCapital)
        {
            Monto = NuevoSaldo;
            Intereses = NuevoInt;
            AbCapital = NuevoAbCapital;

        }
    }

    class program
    {

        public static void Main(string[] args)
        {
            Prestamos Prestamo = new Prestamos();

            Prestamo.Montos();
            Prestamo.Cuotas();
            Prestamo.Interes();

            Prestamo.CalculoPago();
            Prestamo.CalculoSaldo();
            Prestamo.CalculoAbCapital();
            Prestamo.CalculoIntereses();

            Console.WriteLine("\nValor de la Cuota Mensual:");
            Console.WriteLine(Prestamo.ReturnPago());

            int i;
            i = 1;
         
            Console.WriteLine(" \n  Pagos    /   Cuotas     /   Intereses     /     Capital   /   Balance     \n");
         
            while (i <= Prestamo.ReturnCuotas())
            {

                Console.WriteLine("    " + i + "         {0}          {2}              {1}        {3}", Prestamo.ReturnPago(), Prestamo.ReturnAbCapital(), Prestamo.ReturnIntereses(), Prestamo.ReturnSaldo());
                i++;
                
                Prestamo.CalculoAbCapital();
                Prestamo.CalculoSaldo();
                Prestamo.CalculoIntereses();
                Prestamo.NuevosValores(Prestamo.ReturnSaldo(), Prestamo.ReturnIntereses(), Prestamo.ReturnAbCapital());
            }

            Console.ReadKey();

        }
    }
}