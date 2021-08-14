using AplicacionDeContactos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using AplicacionDeContactos.Presenter;

namespace AplicacionDeContactos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Numero_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var contacto = new Contactos();
            var presenter = new ContactosPresenter(contacto);
            DataGrid.DataSource = presenter.VerContactos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long numerotxt = 0;
            if(long.TryParse(Numero.Text,out numerotxt))
            {
                if(!string.IsNullOrEmpty(Nombre.Text) || !string.IsNullOrEmpty(Apellido.Text) || !string.IsNullOrEmpty(Numero.Text))
                {
                    var contacto = new Contactos();
                    contacto.Nombre = Nombre.Text;
                    contacto.Apellido = Apellido.Text;
                    contacto.Numero = numerotxt;
                    var presenter = new ContactosPresenter(contacto);
                    presenter.AgregarContacto();
                    DataGrid.DataSource = presenter.VerContactos();
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un numero de telefono valido (solo numeros)");
            }
            
           
            
        }
    }
}
