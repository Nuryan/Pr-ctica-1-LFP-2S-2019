using System;
using System.Collections;
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
        private ArrayList textos;

        private ArrayList tokens;
        private int estado, fila, columna, idToken, enError;
        private string lexema;

        private char[] grafosPermitidos = {'a', 'á', 'b', 'c', 'd', 'e','é', 'f', 'g', 'h', 'i', 'í', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o',
            'ó', 'p', 'q', 'r', 's', 't', 'u', 'ú', 'ü', 'v', 'w', 'x', 'y', 'z', 'A', 'Á', 'B','C','D','E','É','F','G','H','I','Í','J',
            'K','L','M','N','Ñ','O','Ó','P','Q','R','S','T','U','Ú','Ü','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9',':',
            '{','}','"',(char)32, (char)10, (char)9};
        
        //32 espacio, 10 nueva linea, 9 tabulacion

        private int caracterPermitido(char caracter)
        {
            int i;

            for (i = 0; i < grafosPermitidos.Length; i++)
            {
                if (caracter.Equals(grafosPermitidos[i]))
                {
                    return 1;
                }
            }
            return -1;
        }

        private void clickBotonAnalizar(object sender, EventArgs e)
        {
            infoDetalle.Text = "";

            String analizando = getTextoDeEntrada();

            int i,j;

            for (i = 0; i<analizando.Length; i++)
            {
                //infoDetalle.Text = infoDetalle.Text + analizando[i] + "\n";
                if (caracterPermitido(analizando[i])==1)
                {
                    infoDetalle.Text = infoDetalle.Text + "     "+(Int32)analizando[i]+"     se hallo en los caracteres \n";
                }
                else
                {
                    infoDetalle.Text = infoDetalle.Text + "     " + (Int32)analizando[i] + "     no se hallo en los caracteres \n";
                }
            }
            analizar(analizando);
            infoDetalle.Text = infoDetalle.Text + "\n\n\n  "+fila;
        }

        private void analizar(String analizando)
        {
            int i;
            estado = 0;
            fila = 0;
            columna = 0;
            idToken = 0;

            string concatenando = "";

            for (i = 0; i<analizando.Length; i++)
            {
                setEstado(analizando[i]);

                #region añade nueva linea

                if ((char)analizando[i] == 10)
                {
                    fila++;
                    columna = 0;
                }

                #endregion


                switch (getEstado())
                {
                    case 0:
                        if (enError ==1)
                        {
                            enError =
                                0;
                        }
                        break;
                    case 1:
                        break;
                                           
                }

            }
        }

        private void setEstado(char grafo)
        {
            switch (grafo)
            {
                #region Carácteres del estado 0
                case 'a':
                case 'á':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'é':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'í':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'ñ':
                case 'o':
                case 'ó':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'ú':
                case 'ü':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'Á':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'É':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'Í':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'Ñ':
                case 'O':
                case 'Ó':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'Ú':
                case 'Ü':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    #endregion
                    estado = 0;
                    break;
                #region Carácteres del estado 1
                case '{':
                case '}':
                case ':':
                case '"':
                    #endregion
                    estado = 1;
                    break;
                #region Carácteres que mantienen el estado actual
                case (char)9:
                case (char)10:
                case (char)32:
                    #endregion
                    break;
                default:
                    enError = 1;
                    estado = 0;
                    break;
            }
        }

        private int getEstado()
        {
            return this.estado;
        }

        private String getTextoDeEntrada()
        {
            int i;
            for (i = 0; i < textos.Count; i++)
            {
                if (((RichTextBox)textos[i]).TabIndex == tabControlGeneral.SelectedTab.TabIndex)
                {
                   return ((RichTextBox)textos[i]).Text;
                }
            }

            return "error en la lectura del texto de entrada";
        }

        public Analizador(TabControl controlGeneral, Button botonAnali, MonthCalendar calendario, TreeView arbol, RichTextBox infoDetalle,
            ArrayList textos)
        {
            this.tabControlGeneral = controlGeneral;
            this.botonAnali = botonAnali;
            this.calendario = calendario;
            this.arbol = arbol;
            this.infoDetalle = infoDetalle;
            this.textos = textos;
            botonAnali.Click += new System.EventHandler(clickBotonAnalizar);
        }
    }
}
