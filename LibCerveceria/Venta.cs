namespace LibCerveceria
{
    public class Venta
    {
        private Barril barril;
        private Vaso vaso;
        private float importe;

        public Venta(Barril barril, Vaso vaso, float importe)
        {
            this.barril = barril;
            this.vaso = vaso;
            this.importe = importe;
        }

        public Barril Barril
        {
            get { return barril; }
        }
        public Vaso Vaso
        {
            get { return vaso; }
        }

        public float Importe
        {
            get { return importe; }
        }
    }
}