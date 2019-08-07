using _201222632_Practica1_LFP_2S_2019.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201222632_Practica1_LFP_2S_2019
{
    public partial class Form1 : Form
    {
        private Pestaña pestañas;
        private Analizador anali; 

        public Form1()
        {
            InitializeComponent();

            pestañas = new Pestaña(tabControl1);
            anali = new Analizador(tabControl1, botonAnalizar, calendario1, arbolVisualizar, infoDetallada);
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pestañas.nuevaPestaña();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
