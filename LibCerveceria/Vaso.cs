namespace LibCerveceria
{
    public class Vaso
    {
        private string nombre;
        private float capacidadEnLts;

        public string Nombre
        {
            get { return nombre; }
        }

        public float CapacidadEnLts
        {
            get { return capacidadEnLts; }
        }

        public Vaso(string nombre, float capacidadEnLts)
        {
            this.nombre = nombre;
            this.capacidadEnLts = capacidadEnLts;
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}