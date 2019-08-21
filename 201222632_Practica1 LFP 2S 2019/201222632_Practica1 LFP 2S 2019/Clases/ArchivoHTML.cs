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
    class ArchivoHTML
    {
        private ArrayList tokens;
        private String path;
        private String texto;
        public ArchivoHTML(ArrayList tokens)
        {
            this.tokens = tokens;
        }

        public void guardarComo()
        {
            try
            {
                StreamWriter escritor;
                SaveFileDialog guardando = new SaveFileDialog();
                guardando.Filter = "Archivos de Lenguajes(*.html)|*.html";
                guardando.Title = "Guardando...";
                guardando.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                guardando.RestoreDirectory = true;
                guardando.FilterIndex = 1;
                //guardando.CheckFileExists = true;
                //guardando.CheckPathExists = true;
                guardando.OverwritePrompt = true;



                if (guardando.ShowDialog() == DialogResult.OK)
                {
                    generarCodigoHTML();
                    escritor = new StreamWriter(guardando.FileName);
                    escritor.Write(texto);
                    escritor.Close();
                    setPath(guardando.FileName);
                }
            }
            catch (Exception e)
            {

            }
        }

        private void generarCodigoHTML()
        {
            int i, a;
            Token ultimo = (Token)tokens[tokens.Count-1];
            int numFilas = ultimo.getIdToken()+1;
            Token procesando;
            texto = "<html><body><table> \n";
            for (i = -1; i<numFilas; i++)
            {
                texto = texto + "<tr> \n";
                if (i == -1)
                {
                    texto = texto + "<td> Num </td> \n <td> Lexema </td> \n <td> Token </td> \n";
                }
                else
                {
                    procesando = (Token)tokens[i];
                    texto = texto + "<td>"+ procesando.getIdToken()+"</td> \n" 
                                    + "<td>" +procesando.getLexema() +"</td> \n" 
                                    + "<td>" +procesando.getToken() +"</td> \n" ;
                }
                
                texto = texto + "</tr> \n";
            }

            texto = texto + "</table> \n\n\n\n\n Ahora vienen los errores \n\n\n\n\n <table>";
            
            for (i = -1; i<numFilas; i++)
            {
                texto = texto + "<tr> \n";
                if (i == -1)
                {
                    texto = texto + "<td> Num </td> \n <td> Lexema </td> \n <td> Columna </td> \n <td>Fila</td> \n <td>Error</td> \n";
                }
                else
                {
                    procesando = (Token)tokens[i];
                    if (procesando.getTipo() == 1)
                    {
                        texto = texto + "<td>" + procesando.getIdToken() + "</td> \n"
                                    + "<td>" + procesando.getLexema() + "</td> \n"
                                    + "<td>" + procesando.getColumna() + "</td> \n"
                                    + "<td>" + procesando.getFila() + "</td> \n"
                                    + "<td>" + "No se esperaba ese token" + "</td> \n";
                    }
                }

                texto = texto + "</tr> \n";
            }

            texto = texto + "</table></body></html>";
            
        }

        public String getPath()
        {
            return path;
        }

        public void setPath(String path)
        {
            this.path = path;
        }

    }
}
