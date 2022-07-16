using System.Collections.Generic;
using System.Linq;

namespace LibCerveceria
{
    public class Cerveceria
    {
        public event DelCervezaInsuficiente CervezaInsuficiente;
        public event DelCervezaVendida CervezaVendida;
        public event DelBarrilCreado BarrilCreado;
        public event DelErrorBarril BarrilError;

        private List<Cerveza> cervezas;
        private List<Vaso> vasos;

        private List<Barril> barriles;

        private List<Venta> ventas;

        public Cerveceria() 
        {
            this.cervezas = new CreadorDeCervezas().CrearCervezas();
            this.vasos = new CreadorDeVasos().CrearVasos();
            this.barriles = new List<Barril>();
            this.ventas = new List<Venta>();
        }

        public List<Cerveza> Cervezas
        {
            get { return cervezas; }
        }

        public List<Barril> Barriles
        {
            get { return barriles; }
        }

        public List<Vaso> Vasos 
        { 
            get { return vasos; }
        }

        public void CrearBarril(Cerveza cerveza, float capacidad, float cantidadInicial)
        {
            if (cantidadInicial > capacidad)
            {
                BarrilError("La cantidad inicial no puede ser mayor que la capacidad");
                return;
            }
            Barril nuevoBarril = new Barril(cerveza, capacidad, cantidadInicial);
            barriles.Add(nuevoBarril);
            BarrilCreado(nuevoBarril);
        }

        public void VenderCerveza(Barril barril, Vaso vaso)
        {
            bool resultado = barril.ServirCerveza(vaso);
            if (resultado) 
            {
                float importe = barril.Cerveza.CalcularPrecio(vaso);
                Venta venta = new Venta(barril, vaso, importe);
                ventas.Add(venta);
                CervezaVendida(venta);
            } else
            {
                CervezaInsuficiente(barril);
            }
        }

        public float ObtenerRecaudacionTotal()
        {
            return ventas.Sum(v => v.Importe);
        }

        public ItemYCantidad<Barril> ObtenerElBarrilQueMasSirvio()
        {
            Barril barrilQueMasSirvio = null;
            float cantidadServidadMax = 0f;

            foreach (Barril b in barriles)
            {
                var cantServida = (from v in ventas
                                   where v.Barril.Equals(b)
                                   select v.Vaso.CapacidadEnLts).Sum();
                if (cantServida >= cantidadServidadMax || barrilQueMasSirvio == null)
                {
                    barrilQueMasSirvio = b;
                    cantidadServidadMax = cantServida;
                }
            }

            return new ItemYCantidad<Barril>(barrilQueMasSirvio, cantidadServidadMax);
        }

        public ItemYCantidad<Barril> ObtenerElBarrilQueMenosSirvio()
        {
            Barril barrilQueMenosSirvio = null;
            float cantidadServidadMin = 0f;

            foreach (Barril b in barriles)
            {
                var cantServida = (from v in ventas
                                   where v.Barril.Equals(b)
                                   select v.Vaso.CapacidadEnLts).Sum();
                if (cantServida <= cantidadServidadMin || barrilQueMenosSirvio == null)
                {
                    barrilQueMenosSirvio = b;
                    cantidadServidadMin = cantServida;
                }
            }

            return new ItemYCantidad<Barril>(barrilQueMenosSirvio, cantidadServidadMin);
        }

        public ItemYCantidad<Barril> ObtenerElBarrilQueMasRecaudo()
        {
            Barril barrilQueMasRecaudo = null;
            float recaudacionMax = 0f;

            foreach (Barril b in barriles)
            {
                var rec = (from v in ventas
                                   where v.Barril.Equals(b)
                                   select v.Importe).Sum();
                if (rec >= recaudacionMax || barrilQueMasRecaudo == null)
                {
                    barrilQueMasRecaudo = b;
                    recaudacionMax = rec;
                }
            }

            return new ItemYCantidad<Barril>(barrilQueMasRecaudo, recaudacionMax);
        }

        public Cerveza ObtenerCervezaMasVendida()
        {
            Cerveza cerveza = null;
            int cantVentasMax = 0;

            foreach (Cerveza c in cervezas)
            {
                var cant = (from v in ventas
                            where v.Barril.Cerveza.Equals(c)
                            select v).Count();
                if (cerveza == null || cantVentasMax <= cant)
                {
                    cerveza = c;
                    cantVentasMax = cant;
                }
            }

            return cerveza;
        }

        public Cerveza ObtenerCervezaConMasGanancia()
        {
            Cerveza cerveza = null;
            float recMax = 0;

            foreach (Cerveza c in cervezas)
            {
                var rec = (from v in ventas
                            where v.Barril.Cerveza.Equals(c)
                            select v.Importe).Sum();
                if (cerveza == null || recMax <= rec)
                {
                    cerveza = c;
                    recMax = rec;
                }
            }

            return cerveza;
        }

        public Cerveza ObtenerCervezaConMasLitrosVendidos()
        {
            Cerveza cerveza = null;
            float ltsVendidosMax = 0;

            foreach (Cerveza c in cervezas)
            {
                var sumLts = (from v in ventas
                           where v.Barril.Cerveza.Equals(c)
                           select v.Vaso.CapacidadEnLts).Sum();
                if (cerveza == null || ltsVendidosMax <= sumLts)
                {
                    cerveza = c;
                    ltsVendidosMax = sumLts;
                }
            }

            return cerveza;
        }

        public Cerveza ObtenerCervezaConMenosLitrosVendidos()
        {
            Cerveza cerveza = null;
            float ltsVendidosMin = 0;

            foreach (Cerveza c in cervezas)
            {
                var sumLts = (from v in ventas
                              where v.Barril.Cerveza.Equals(c)
                              select v.Vaso.CapacidadEnLts).Sum();
                if (cerveza == null || ltsVendidosMin >= sumLts)
                {
                    cerveza = c;
                    ltsVendidosMin = sumLts;
                }
            }

            return cerveza;
        }

        public Vaso ObtenerVasoMasSolicitado()
        {
            Vaso vasoMax = null;
            int cantVentas = 0;

            foreach(Vaso v in vasos)
            {
                var cant = (from venta in ventas
                            where venta.Vaso.Equals(v)
                            select venta).Count();
                if (vasoMax == null || cantVentas <= cant)
                {
                    vasoMax = v;
                    cantVentas = cant;
                }
            }

            return vasoMax;
        }
    }
}