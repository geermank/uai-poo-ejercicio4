namespace LibCerveceria
{
    public class Barril
    {
        private Cerveza cerveza;
        private float capacidad;
        private float cantidad;

        public Barril(Cerveza cerveza, float capacidad, float cantidad)
        {
            this.cerveza = cerveza;
            this.capacidad = capacidad;
            this.cantidad = cantidad;
        }

        public Cerveza Cerveza
        {
            get { return cerveza; }
        }

        public float Cantidad
        {
            get { return cantidad; }
        }

        public float Capacidad
        {
            get { return capacidad; }
        }   

        public bool ServirCerveza(Vaso vaso)
        {
            if (vaso.CapacidadEnLts > cantidad)
            {
                return false;
            }
            cantidad -= vaso.CapacidadEnLts;
            return true;
        }

        public override string ToString()
        {
            return "Barril con cerveza: " + cerveza.ToString();
        }
    }
}