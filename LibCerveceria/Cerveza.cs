namespace LibCerveceria
{
    public class Cerveza
    {
        private string nombre;
        private float precioPorLitro;

        public Cerveza(string nombre, float precioPorLitro)
        {
            this.nombre = nombre;
            this.precioPorLitro = precioPorLitro;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public float PrecioPorLitro
        {
            get { return precioPorLitro; }
        }

        public float CalcularPrecio(Vaso vaso)
        {
            return precioPorLitro * vaso.CapacidadEnLts;
        }

        public override string ToString()
        {
            return nombre + " " + "$" + precioPorLitro;
        }
    }
}