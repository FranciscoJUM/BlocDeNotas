using AppCore.IServices;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            button6.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            txtTulo.Visible = false;
            txtTexto.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = false;
            label2.Visible = false;
            comboBox2.Visible = false;
            

            button5.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            txtTexto.Visible = true;
            txtTulo.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            treeView1.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = true;
            button6.Visible=true;
            label4.Visible=true;
            label5.Visible=true;
            label2.Visible=true;
            comboBox2.Visible=true; 
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
                    Id = 1,
                    Titulo = txtTulo.Text,
                    Texto = txtTexto.Text,
                };
                activoServices.Add(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();

                treeView1.Nodes.Add(txtTulo.Text);


            }
        }



        private void limpiar()
        {
            txtTulo.Text = "";
            txtTexto.Text = "";
        }

        private bool verificar()
        {
            if (txtTulo.Text == "" || txtTexto.Text == "")
            {

                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTexto.Visible = false;
            txtTulo.Visible = false;
            dataGridView1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            treeView1.Visible = true;
            button4.Visible = true;
            comboBox1.Visible = false;
            button6.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label2.Visible = false;
            comboBox2.Visible = false;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form2 depreciacion = new Form2(activoServices.Read()[e.RowIndex]);
                depreciacion.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            treeView1.Visible = false;
            button4.Visible = false;

            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
            dataGridView1.Visible = false;
            button5.Visible = false;
           
            button4.Visible = true;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0) 
            {
              txtTexto.ForeColor = Color.Red;
              txtTulo.ForeColor = Color.Red;
            }
             
            if(comboBox1.SelectedIndex == 1)
            {
                   
                txtTexto.ForeColor = Color.White; 
                txtTulo.ForeColor = Color.White;
                }
                
             if (comboBox1.SelectedIndex == 2)
                       
             {
                 txtTexto.ForeColor = Color.Blue;
                 txtTulo.ForeColor = Color.Blue;
                 }

            if (comboBox1.SelectedIndex == 3)
            {
                txtTexto.ForeColor = Color.Black;
                txtTulo.ForeColor = Color.Black;
            }
                
                                  
               
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FontDialog myFontDialog = new FontDialog();
            if (myFontDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the control's font.
                txtTexto.Font = myFontDialog.Font;
                txtTulo.Font= myFontDialog.Font;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0) 
            {

                txtTexto.BackColor = Color.Red;
                txtTulo.BackColor = Color.Red;
            }
            if (comboBox2.SelectedIndex == 1)
            {

                txtTexto.BackColor = Color.White;
                txtTulo.BackColor = Color.White;
            }
            if(comboBox2.SelectedIndex == 2) 
            {
                txtTexto.BackColor = Color.Blue;
                txtTulo.BackColor = Color.Blue;
            }
            if(comboBox2.SelectedIndex == 3)
            {
                txtTexto.BackColor = Color.Black;
                txtTulo.BackColor = Color.Black;
            }
        }
    }
}

