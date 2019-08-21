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
        private int estado, enError, esTerminal;
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

            analizar(analizando);

            encontrarErroresOrdenDeTokens();

            int i;
            Token prueba;
            for (i = 0; i<tokens.Count; i++)
            {
                prueba = (Token)tokens[i];
                if (prueba.getTipo()==0)
                {
                    infoDetalle.Text = infoDetalle.Text + "\n";
                    infoDetalle.Text = infoDetalle.Text + prueba.getLexema() + " columna " + prueba.getColumna() + " fila " + prueba.getFila() + " y se esperaba, su numero de token es " + prueba.getIdToken();
                }
                else
                {
                    infoDetalle.Text = infoDetalle.Text + "\n";
                    infoDetalle.Text = infoDetalle.Text + prueba.getLexema() + " columna " + prueba.getColumna() + " fila " + prueba.getFila() + " y no se esperaba, su numero de token es "+prueba.getIdToken();
                }

            }


            #region 

            ArchivoHTML impresor = new ArchivoHTML(tokens);

            impresor.guardarComo();

            #endregion

            //int i,j;

            //for (i = 0; i<analizando.Length; i++)
            //{
            //    setEstado(analizando[i]);
            //    infoDetalle.Text = infoDetalle.Text + analizando[i]+ "  y su estado es    "+ getEstado()+ " y se han encontrado "+enError+" su estadoT es "+esTerminal+"\n";
            //}
            //analizar(analizando);
            //infoDetalle.Text = infoDetalle.Text + "\n\n\n  "+"con una cantidad de tokens de: "+tokens.Count;
            //infoDetalle.Text = infoDetalle.Text + "\n\n\n  ";
            //infoDetalle.Text = infoDetalle.Text + "\n\n\n  ";

            //Token prueba;
            //for (i = 0; i<tokens.Count; i++)
            //{
            //    prueba = (Token)tokens[i];
            //    infoDetalle.Text = infoDetalle.Text +"Token id: "+ prueba.getIdToken()+" y contiene "+prueba.getLexema()+" y es "+prueba.getToken()+" su idneti es "+prueba.getIdenti()+"\n";
            //}

        }

        private void ordenarActividades()
        {
            String padre = "", descripcion = "";
            int año, mes, dia, aux1, aux2, i, a;

            for (i = 0; i<tokens.Count; i++)
            {

            }

        }
        
        private void encontrarErroresOrdenDeTokens()
        {
            int i, a;
            int identiActual;
            int[] identiEsperada = new int[] { 0};
            Token auxiliar;

            for (i = 0; i<tokens.Count; i++)
            {
                auxiliar = (Token)tokens[i];

                identiActual = auxiliar.getIdenti();

                for (a = 0; a < identiEsperada.Length; a++)
                {
                    if (auxiliar.getIdenti() == identiEsperada[a])
                    {
                        auxiliar.setTipo(0);
                        tokens[i] = auxiliar;
                        break;
                    }
                    auxiliar.setTipo(1);
                    tokens[i] = auxiliar;
                }

                switch (identiActual)
                {
                    case 0:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 1:
                        identiEsperada = new int[] { 2, 12 };
                        break;
                    case 2:
                        identiEsperada = new int[] { 3, 4, 6 };
                        break;
                    case 3:
                        identiEsperada = new int[] { 2 };
                        break;
                    case 4:
                        identiEsperada = new int[] { 5, 10, 11 };
                        break;
                    case 5:
                        identiEsperada = new int[] { 5, 7, 8, 9, 0};
                        break;
                    case 6:
                        identiEsperada = new int[] { 7, 8, 9, 10, 11 };
                        break;
                    case 7:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 8:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 9:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 10:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 11:
                        identiEsperada = new int[] { 1 };
                        break;
                    case 12:
                        identiEsperada = new int[] { 6 };
                        break;
                }
            }

        }

        private void crearListaActividades()
        {

        }

        private void analizar(String analizando)
        {
            int i;
            estado = 0;
            int fila = 0;
            int columna = -1;
            int idToken = 0;
            esTerminal = 0;
            tokens = new ArrayList();

            string concatenando = "";

            for (i = 0; i<analizando.Length; i++)
            {
                columna++;
                #region añade nueva linea
                if ((char)analizando[i] == 10)
                {
                    fila++;
                    columna = 0;
                }
                #endregion
                //32 espacio, 10 nueva linea, 9 tabulacion

                if (estado == 4 || estado == 6)
                {

                }else
                {
                    if ((char)analizando[i] == 9 || (char)analizando[i] == 10 || (char)analizando[i] == 32)
                    {
                        continue;
                    }
                }
                
                if (esTerminal == 1 && concatenando.Length > 0)
                {
                    añadirToken(idToken, fila, columna, enError, concatenando);
                    idToken++;
                    concatenando = "";
                    enError = 0;
                }

                setEstado(analizando[i]);

                if (esTerminal == 1 && concatenando.Length > 0)
                {
                    añadirToken(idToken, fila, columna, enError, concatenando);
                    idToken++;
                    concatenando = "";
                    enError = 0;
                }
                concatenando = concatenando + analizando[i];
            }
            if (esTerminal == 1 && concatenando.Length > 0)
            {
                añadirToken(idToken, fila, columna, enError, concatenando);
                idToken++;
                concatenando = "";
                enError = 0;
            }
        }

        private void añadirToken(int idToken, int fila, int columna, int enError, String concatenando)
        {
            tokens.Add(new Token(idToken, fila, columna, concatenando, enError));
        }

        private void setEstado(char grafo)
        {
            switch (grafo)
            {
                #region abecedario 
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
                    #endregion
                    esTerminal = 0;
                    switch (estado)
                    {
                        case 0:
                            estado = 1;
                            break;
                        case 1:
                        case 9:
                        case 5:
                        case 8:
                            estado = 0;
                            break;
                        case 4:
                            estado = 6;
                            break;
                        case 6:
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                #region numeros
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
                    esTerminal = 0;
                    switch (estado)
                    {
                        case 2:
                            estado = 3;
                            break;
                        case 3:
                            estado = 2;
                            break;
                        case 4:
                            estado = 6;
                            break;
                        case 6:
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                case '{':
                    esTerminal = 1;
                    switch (estado)
                    {
                        case 2:
                        case 3:
                        case 7:
                            estado = 5;
                            break;
                        case 4:
                            esTerminal = 0;
                            estado = 6;
                            break;
                        case 6:
                            esTerminal = 0;
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                case '}':
                    esTerminal = 1;
                    switch (estado)
                    {
                        case 8:
                            estado = 9;
                            break;
                        case 9:
                            estado = 8;
                            break;
                        case 4:
                            esTerminal = 0;
                            estado = 6;
                            break;
                        case 6:
                            esTerminal = 0;
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                case ':':
                    esTerminal = 1;
                    switch (estado)
                    {
                        case 0:
                        case 1:
                            estado = 2;
                            break;
                        case 4:
                            esTerminal = 0;
                            estado = 6;
                            break;
                        case 6:
                            esTerminal = 0;
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                case '"':
                    esTerminal = 1;
                    switch (estado)
                    {
                        case 4:
                        case 6:
                            estado = 7;
                            break;
                        case 2:
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                case ';':
                    esTerminal = 1;
                    switch (estado)
                    {
                        case 7:
                            estado = 8;
                            break;
                        case 4:
                        case 6:
                            estado = 7;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
                    break;
                //32 espacio, 10 nueva linea, 9 tabulacion
                case (char)9:
                case (char)10:
                case (char)32:
                    switch (estado)
                    {

                        case 4:
                            esTerminal = 0;
                            estado = 6;
                            break;
                        case 6:
                            esTerminal = 0;
                            estado = 4;
                            break;
                    }
                    break;
                default:
                    switch (estado)
                    {
                        case 4:
                            esTerminal = 0;
                            estado = 6;
                            break;
                        case 6:
                            esTerminal = 0;
                            estado = 4;
                            break;
                        default:
                            enError = 1;
                            break;
                    }
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