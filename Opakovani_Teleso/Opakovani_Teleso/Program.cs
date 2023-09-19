namespace Opakovani_Teleso;

class Program
{
    abstract class Teleso
    {
        public abstract double Povrch();
        public abstract double Objem();

        public double PomerPovrchObjem()
        {
            return Povrch() / Objem();
        }
    }

    class Valec : Teleso
    {
        private double polomerPodstavy;
        public double PolomerPodstavy
        {
            get
            {
                return polomerPodstavy;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }

                polomerPodstavy = value;

            }
        }

        private double vyska;
        public double Vyska
        {
            get
            {
                return vyska;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                vyska = value;
            }
        }

        public override double Povrch()
        {
            return 2 * (Math.PI * polomerPodstavy * polomerPodstavy) + (2 * Math.PI * polomerPodstavy * Vyska);
        }

        public override double Objem()
        {
            return Math.PI * (polomerPodstavy * polomerPodstavy) * Vyska;
        }

        public static string KouleKuValci(double polomerKoule)
        {
            Koule novaKoule = new Koule { Polomer = polomerKoule };
            Valec novyValec = new Valec { vyska = 4d / 3d * polomerKoule, polomerPodstavy = polomerKoule};
            return $"Pomer povrchu ku objemu koule: {novaKoule.PomerPovrchObjem()}\nPomer povrchu ku objemu valec: {novyValec.PomerPovrchObjem()}";
        }
    }

    class Koule : Teleso
    {
        private double polomer;
        public double Polomer
        {
            get
            {
                return polomer;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }

                polomer = value;

            }
        }

        public override double Povrch()
        {
            return 4 * Math.PI * Polomer * Polomer;
        }

        public override double Objem()
        {
            return 4d/3d * Math.PI * Math.Pow(Polomer, 3);
        }

    }

    public static void Main(string[] args)
    {
        Valec mujV = new Valec { PolomerPodstavy = 5, Vyska = 3 };

        Koule mojeK = new Koule { Polomer = 43 };

        Console.WriteLine(Valec.KouleKuValci(3));

        Console.ReadKey();
    }
}