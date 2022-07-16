using LibCerveceria;
using System;
using System.Windows.Forms;

namespace Ejercicio4
{
    public partial class Form1 : Form
    {
        private Cerveceria cerveceria;

        public Form1()
        {
            InitializeComponent();
            cerveceria = new Cerveceria();
            cerveceria.CervezaVendida += CerveceriaCervezaVendida;
            cerveceria.CervezaInsuficiente += CerveceriaCervezaInsuficiente;
            cerveceria.BarrilCreado += CerveceriaBarrilCreado;
            cerveceria.BarrilError += CerveceriaBarrilError;
        }

        private void CerveceriaBarrilError(string message)
        {
            MessageBox.Show(message);
        }

        private void CerveceriaBarrilCreado(Barril barril)
        {
            listBox3.Items.Add(barril);
        }

        private void CerveceriaCervezaInsuficiente(Barril barril)
        {
            MessageBox.Show("Este barril ya no tiene cerveza");
        }

        private void CerveceriaCervezaVendida(Venta venta)
        {
            MessageBox.Show("Cerveza vendida. Precio: $" + venta.Importe);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Barril barril = listBox3.SelectedItem as Barril;
            Vaso vaso = listBox2.SelectedItem as Vaso;
            if (barril == null)
            {
                MessageBox.Show("Elegí el barril de cerveza");
                return;
            }
            if (vaso == null)
            {
                MessageBox.Show("Elegí el vaso");
                return;
            }
            cerveceria.VenderCerveza(barril, vaso);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Ingresa la cantidad y la capacidad del barril");
                return;
            }
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecciona la cerveza");
                return;
            }
            float capacidad = float.Parse(textBox1.Text);
            float cantidadInicial = float.Parse(textBox2.Text);
            Cerveza cerveza = listBox1.SelectedItem as Cerveza;
            cerveceria.CrearBarril(cerveza, capacidad, cantidadInicial);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cerveceria.Cervezas.ForEach(c => listBox1.Items.Add(c));
            cerveceria.Vasos.ForEach(v => listBox2.Items.Add(v));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La recaudacion total es de $" + cerveceria.ObtenerRecaudacionTotal());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemYCantidad<Barril> item = cerveceria.ObtenerElBarrilQueMasSirvio();
            MessageBox.Show("El barril que mas sirvió fue " + item.Item + " con un total de " + item.Cantidad + " lts");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ItemYCantidad<Barril> item = cerveceria.ObtenerElBarrilQueMenosSirvio();
            MessageBox.Show("El barril que menos sirvió fue " + item.Item + " con un total de " + item.Cantidad + " lts");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ItemYCantidad<Barril> item = cerveceria.ObtenerElBarrilQueMasRecaudo();
            MessageBox.Show("El barril que mas recaudó fue " + item.Item + " con un total de $" + item.Cantidad);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cerveza c = cerveceria.ObtenerCervezaMasVendida();
            MessageBox.Show("La cerveza mas vendida fue " + c.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cerveza c = cerveceria.ObtenerCervezaConMasGanancia();
            MessageBox.Show("La cerveza con mas ganancia es " + c.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cerveza c = cerveceria.ObtenerCervezaConMasLitrosVendidos();
            MessageBox.Show("La cerveza con mas litros vendidos es " + c.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Cerveza c = cerveceria.ObtenerCervezaConMenosLitrosVendidos();
            MessageBox.Show("La cerveza con menos litros vendidos es " + c.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Vaso v = cerveceria.ObtenerVasoMasSolicitado();
            MessageBox.Show("El vaso mas solicitado es " + v.ToString());
        }
    }
}
