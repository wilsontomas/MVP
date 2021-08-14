using AplicacionDeContactos.Models;
using AplicacionDeContactos.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionDeContactos
{
    public partial class VentanaEdicion : Form
    {
        public VentanaEdicion()
        {
            InitializeComponent();
        }
        public int id { get; set; }
        private void VentanaEdicion_Load(object sender, EventArgs e)
        {
            MessageBox.Show(id.ToString());
            var contacto = new Contactos();
            contacto.Id = this.id;
            var presenter = new ContactosPresenter(contacto);
            var datos = presenter.VerContactosPorId();
            if(datos != null)
            {
                NombreE.Text = datos.Nombre;
                ApellidoE.Text = datos.Apellido;
                NumeroE.Text = datos.Numero.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 crud = new Form1();
            this.Hide();
            crud.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long numerotxt = 0;
            if (long.TryParse(NumeroE.Text, out numerotxt))
            {
                if (!string.IsNullOrEmpty(NombreE.Text) || !string.IsNullOrEmpty(ApellidoE.Text) || !string.IsNullOrEmpty(NumeroE.Text))
                {
                    var contacto = new Contactos();
                    contacto.Nombre = NombreE.Text;
                    contacto.Apellido = ApellidoE.Text;
                    contacto.Numero = numerotxt;
                    var presenter = new ContactosPresenter(contacto);
                    if (presenter.EditarContacto())
                    {
                        Form1 crud = new Form1();
                        this.Hide();
                        crud.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error al editar");
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un numero de telefono valido (solo numeros)");
            }
        }
    }
}
