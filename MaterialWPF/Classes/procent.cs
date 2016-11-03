namespace MaterialWPF
{
    public static class Procent
    {
        public static double intX(double max, double i)
        {

            return (max * i) / 100;
        }
        public static double procentX(double max, double p)
        {
            if ((p * 100) / max >= 100)
            {
                return 100;
            }
            if (((p * 100) / max) <= 0)
            {
                return 0;
            }
            return (p * 100) / max;
        }
    }
}