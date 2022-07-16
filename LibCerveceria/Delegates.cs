namespace LibCerveceria
{
    public delegate void DelCervezaVendida(Venta venta);
    public delegate void DelCervezaInsuficiente(Barril barril);

    public delegate void DelBarrilCreado(Barril barril);
    public delegate void DelErrorBarril(string message);
}