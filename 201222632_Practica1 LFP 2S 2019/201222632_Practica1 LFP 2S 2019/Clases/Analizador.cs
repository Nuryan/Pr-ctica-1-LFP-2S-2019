using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201222632_Practica1_LFP_2S_2019.Clases
{
    class Analizador
    {
        private TabControl tabControlGeneral;
        private Button botonAnali;
        private MonthCalendar calendario;
        private TreeView arbol;
        private RichTextBox infoDetalle;

        private string[] grafosPermitidos = {"a","á", "b", "c", "d", "e", "é", "f", "g", "h", "i", "í", "j", "k", "l", "m", "n", "ñ", "o", "ó",
            "p", "q", "r", "s", "t", "u","ú","ü","v","w","x","y","z","A","Á","B","C","D","E","É","F","G","H","I","Í","J","K","L","M","N","Ñ",
            "O","Ó","P","Q","R","S","T","U","Ú","Ü","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9","{","}", ":", " ", "    ", ""};

        private char[] prueba = {' ', ' ', 'a', 'á'};

        public void imprimirASCII()
        {
            int i;
            for (i = 0; i<grafosPermitidos.Length; i++)
            {
                infoDetalle.Text = infoDetalle.Text + Encoding.ASCII.GetBytes(grafosPermitidos[i]) + "\n";
            }
            
        }

        private int caraterNoPermitido(string caracter)
        {
            int i, devolver = -1;

            for (i = 0; i < grafosPermitidos.Length; i++)
            {
                if (!caracter.Equals(grafosPermitidos[i]))
                {
                    devolver = -1;
                }
            }

            return devolver;
        }

        private void clickBotonAnalizar(object sender, EventArgs e)
        {
            //MessageBox.Show("dfasd");

            imprimirASCII();

            infoDetalle.Text = "";

            int i = 0;
            for (i = 0; i<prueba.Length; i++)
            {
                infoDetalle.Text = infoDetalle.Text + (Int32)prueba[i] + "\n";
            }
        }

        public Analizador(TabControl controlGeneral, Button botonAnali, MonthCalendar calendario, TreeView arbol, RichTextBox infoDetalle)
        {
            this.tabControlGeneral = controlGeneral;
            this.botonAnali = botonAnali;
            this.calendario = calendario;
            this.arbol = arbol;
            this.infoDetalle = infoDetalle;

            botonAnali.Click += new System.EventHandler(clickBotonAnalizar);
        }
    }
}
