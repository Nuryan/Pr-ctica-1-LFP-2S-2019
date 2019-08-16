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

        private string[] palabrasReservadas = {"Planificador", "Año", "Mes", "Dia","Descripcion","Imagen"};
        private string[] simbolos = {"{", "}",":",";" ,"\""};

        public Token(int idToken, int fila, int columna, string lexema, int tipo )
        {
            this.idToken = idToken;
            this.fila = fila;
            this.columna = columna;
            this.lexema = lexema;
            this.tipo = tipo;

            setToken(lexema);
        }

        private void setToken(string lexema)
        {
            this.token = "Cadena";
            double num;
            int i;

            for (i = 0; i<simbolos.Length; i++)
            {
                if (lexema.Equals(simbolos[i]))
                {
                    this.token = "Simbolo "+simbolos[i];
                }
            }

            for (i = 0; i<palabrasReservadas.Length; i++)
            {
                if (lexema.Equals(palabrasReservadas[i]))
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