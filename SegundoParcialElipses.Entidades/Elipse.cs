namespace SegundoParcialElipses.Entidades
{
    public class Elipse
    {
        public int SemiEjeMayor { get; set; }
        public int SemiEjeMenor { get; set; }
        public Borde TipoBorde { get; set; }
        public ColorElipse ColorElipse { get; set; }
        public Elipse()
        {
            
        }
        public Elipse(int ejeMayor, int ejeMenor, Borde tipoBorde, ColorElipse color)
        {
            if (ejeMayor <= 0 || ejeMenor <= 0)
            {
                throw new ArgumentException("Los ejes deben ser mayores que cero.");
            }

            SemiEjeMayor = ejeMayor;
            SemiEjeMenor = ejeMenor;
            TipoBorde = tipoBorde;
            ColorElipse = color;
        }
        public double CalcularArea()
        {
            return Math.PI * SemiEjeMayor * SemiEjeMenor;
        }

        public double CalcularPerimetro()
        {
            double a = SemiEjeMayor;
            double b = SemiEjeMenor;
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }
        public override string ToString()
        {
            return $"Elipse [Eje Mayor: {SemiEjeMayor}, Eje Menor: {SemiEjeMenor}, Borde: {TipoBorde}, Color: {ColorElipse}]";
        }
    }

}
