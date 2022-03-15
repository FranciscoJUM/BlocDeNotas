using AppCore.IServices;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDeNotas
{
    public partial class Form1 : Form
    {
        INotaService activoServices;
        public Form1(INotaService ActivoServices)
        {
            this.activoServices = ActivoServices;
            InitializeComponent();
        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activoServices.Read();

            txtTulo.Visible = false;    
            txtTexto.Visible = false; 
            button2.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            txtTexto.Visible = true;
            txtTulo.Visible=true;
            button2.Visible=true;
            button3.Visible=true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {

                Nota activo = new Nota()
                {
                 Id =1,
                 Titulo = txtTulo.Text,
                 Texto = txtTexto.Text,
                };
                activoServices.Add(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();

            }
        }



        private void limpiar()
        {
            txtTulo.Text ="";
            txtTexto.Text = "";
        }

        private bool verificar()
        {
            if (txtTulo.Text == "" || txtTexto.Text== "")
            {

                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTexto.Visible=false;
            txtTulo.Visible=false;
            dataGridView1.Visible = false;
            button2.Visible=false;
            button3.Visible=false;
           

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
            {
                Form2 depreciacion = new Form2(activoServices.Read()[e.RowIndex]);
                depreciacion.ShowDialog();
            }
        }
    }
}
