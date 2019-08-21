using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201222632_Practica1_LFP_2S_2019.Clases
{
    class Pestaña
    {
        //public ArrayList pestañas = new ArrayList();
        public ArrayList textos = new ArrayList();
        private int numPestañas = 0;
        private TabControl tabControlGeneral;

        public Pestaña(TabControl controlPestaña)
        {
            this.tabControlGeneral = controlPestaña;
        }

        public void nuevaPestaña()
        {
            TabPage pagina = new TabPage();
            RichTextBox texto = new RichTextBox();

            tabControlGeneral.Controls.Add(pagina);

            pagina.SuspendLayout();
            pagina.Controls.Add(texto);
            pagina.Location = new System.Drawing.Point(4,22);
            pagina.Name = "Pestaña" + numPestañas;
            pagina.Padding = new System.Windows.Forms.Padding(3);
            pagina.Size = new System.Drawing.Size(508, 664);
            pagina.TabIndex = numPestañas;
            pagina.Text = "Pestaña "+ numPestañas;
            pagina.UseVisualStyleBackColor = true;

            texto.Dock = System.Windows.Forms.DockStyle.Fill;
            texto.Location = new System.Drawing.Point(3, 3);
            texto.Name = "texto" + numPestañas;
            texto.Size = new System.Drawing.Size(502, 658);
            texto.TabIndex = numPestañas;
            texto.Text = "";
            
            texto.MouseDown += new System.Windows.Forms.MouseEventHandler(clickDerecho);

            pagina.Focus();
            pagina.ResumeLayout(false);
            //MessageBox.Show("1");
            texto.Show();

            tabControlGeneral.SelectedTab = pagina;

            textos.Add(texto);

            numPestañas++;
                                    
        }

        public void cargarArchivo()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "archivos de lenguajes(*.ly)|*.ly";
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                int i;
                for (i = 0; i < textos.Count; i++)
                {
                    if (((RichTextBox)textos[i]).TabIndex == tabControlGeneral.SelectedTab.TabIndex)
                    {
                         ((RichTextBox)textos[i]).Text = fileContent;
                    }
                }
            }
        }

        public ArrayList getTextos()
        {
            return textos;
        }

        private void clickDerecho(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                ToolStripMenuItem pestañaNueva = new ToolStripMenuItem("Nueva Pestaña");
                ToolStripMenuItem cerrarPestaña = new ToolStripMenuItem("Cerrar Pestaña");
                ToolStripMenuItem guardarPestaña = new ToolStripMenuItem("Guardar Pestaña");

                pestañaNueva.Name = "Nueva Pestaña";
                cerrarPestaña.Name = "Cerrar Pestaña";
                guardarPestaña.Name = "Guardar";

                menu.Items.Add(pestañaNueva);
                menu.Items.Add(cerrarPestaña);
                menu.Items.Add(guardarPestaña);

                pestañaNueva.Click += new EventHandler(nuevaPestaña);
                cerrarPestaña.Click += new EventHandler(removerPestaña);

                RichTextBox snd = (RichTextBox)sender;

                int x = snd.Location.X;
                int y = snd.Location.Y;

                menu.Show(snd, new System.Drawing.Point(x, y));
            }
        }

        private void removerPestaña(object sender, EventArgs e)
        {
            tabControlGeneral.TabPages.Remove(tabControlGeneral.SelectedTab);
        }

        public void nuevaPestaña(object sender, EventArgs e)
        {
            nuevaPestaña();
        }
    }
}
