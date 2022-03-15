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
    public partial class Form2 : Form
    {
        private Nota activo;
        public Form2(Nota Activo)
        {
            this.activo = Activo;
            InitializeComponent();
           

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;





            label4.Text = $"{activo.Id}";
            textBox2.Text = activo.Titulo;
            textBox1.Text = activo.Texto;
           
        }
    }
}
