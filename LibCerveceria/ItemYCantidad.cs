namespace LibCerveceria
{
    public class ItemYCantidad<T>
    {
        private T item;
        private float cantidad;

        public ItemYCantidad(T item, float cantidad)
        {
            this.item = item;
            this.cantidad = cantidad;
        }
        
        public T Item
        {
            get { return item; }
        }

        public float Cantidad
        {
            get { return cantidad; }
        }
    }
}
