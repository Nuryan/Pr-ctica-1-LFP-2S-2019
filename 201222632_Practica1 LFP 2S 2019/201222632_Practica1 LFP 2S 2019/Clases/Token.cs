using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201222632_Practica1_LFP_2S_2019.Clases
{
    class Token
    {
        private int idToken;
        private string lexema;
        private string token;
        private int fila;
        private int columna;
        private int tipo;

        private int identi;

        private int tipoToken;

        private string[] palabrasReservadas = {"planificador", "año", "mes", "día","descripción","imagen","dia","descripcion"};
        private string[] simbolos = {"{", "}",":",";" ,"\""};
        
        public Token(int idToken, int fila, int columna, string lexema, int tipo )
        {
            this.idToken = idToken;
            this.fila = fila;
            this.columna = columna;
            this.lexema = lexema;
            this.tipo = tipo;
                
            setToken(lexema);
            setIdenti(lexema);
        }
        

        private void setToken(string lexema)
        {
            this.token = "Cadena";
            double num;
            int i;

            for (i = 0; i<simbolos.Length; i++)
            {
                if ((lexema.ToLower()).Equals(simbolos[i]))
                {
                    this.token = "Simbolo "+simbolos[i];
                }
            }

            for (i = 0; i<palabrasReservadas.Length; i++)
            {
                if ((lexema.ToLower()).Equals(palabrasReservadas[i]))
                {
                    this.token = "Palabra Reservada " + palabrasReservadas[i];
                    break;
                }
            }

            if (Double.TryParse(lexema, out num))
            {
                this.token = "Número";
            }
        }

        private void setIdenti(String lexema)
        {
            double num;
            if (Double.TryParse(lexema, out num))
            {
                this.identi= 12;
            }

            if ((lexema.ToLower()).Equals("planificador"))
            {
                this.identi = 0;
            }

            if ((lexema.ToLower()).Equals(":"))
            {
                this.identi = 1;
            }

            if ((lexema.ToLower()).Equals("\""))
            {
                this.identi = 2;
            }

            if (getToken().Equals("Cadena"))
            {
                this.identi = 3;
            }

            if ((lexema.ToLower()).Equals(";"))
            {
                this.identi = 4;
            }

            if ((lexema.ToLower()).Equals("}"))
            {
                this.identi = 5;
            }

            if ((lexema.ToLower()).Equals("{"))
            {
                this.identi = 6;
            }

            if ((lexema.ToLower()).Equals("año"))
            {
                this.identi = 7;
            }

            if ((lexema.ToLower()).Equals("mes"))
            {
                this.identi = 8;
            }

            if ((lexema.ToLower()).Equals("día"))
            {
                this.identi = 9;
            }

            if ((lexema.ToLower()).Equals("descripción"))
            {
                this.identi = 10;
            }

            if ((lexema.ToLower()).Equals("imagen"))
            {
                this.identi = 11;
            }

            #region dia y descripcion, ambos sin tilde

            if ((lexema.ToLower()).Equals("dia"))
            {
                this.identi = 9;
            }

            if ((lexema.ToLower()).Equals("descripcion"))
            {
                this.identi = 10;
            }
            #endregion
        }

        public int getTipoToken()
        {
            return this.tipoToken;
        }

        public void setTipoToken(int tipoToken)
        {
            this.tipoToken = tipoToken;
        }

        public int getIdenti()
        {
            return identi;
        }

        public void setIdToken(int idToken)
        {
            this.idToken = idToken;
        }

        public int getIdToken()
        {
            return this.idToken;
        }

        public void setLexema(string lexema)
        {
            this.lexema = lexema;
        }

        public string getLexema()
        {
            return this.lexema;
        }

        public string getToken()
        {
            return this.token;
        }

        public void setFila(int fila)
        {
            this.fila = fila;
        }

        public int getFila()
        {
            return this.fila;
        }

        public void setColumna(int columna)
        {
            this.columna = columna;
        }

        public int getColumna()
        {
            return this.columna;
        }

        public void setTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public int getTipo()
        {
            return this.tipo;
        }

       
    }
}