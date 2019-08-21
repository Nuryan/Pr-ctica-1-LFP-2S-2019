using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201222632_Practica1_LFP_2S_2019.Clases
{
    class Actividad
    {
        private int idActividad;
        private int año;
        private int mes;
        private int dia;
        private String descripcion, padre;

        private ArrayList tokens;

        public Actividad(int idActividad, int año, int mes, int dia, String descripcion, String padre)
        {
            this.idActividad = idActividad;
            this.año = año;
            this.mes = mes;
            this.dia = dia;
            this.descripcion = descripcion;
            this.padre = padre;
        }
        
        public Actividad(ArrayList tokens)
        {
            this.tokens = tokens;
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int Dia
        {
            get
            {
                return dia;
            }

            set
            {
                dia = value;
            }
        }

        public int Mes
        {
            get
            {
                return mes;
            }

            set
            {
                mes = value;
            }
        }

        public int Año
        {
            get
            {
                return año;
            }

            set
            {
                año = value;
            }
        }

        public int IdActividad
        {
            get
            {
                return idActividad;
            }

            set
            {
                idActividad = value;
            }
        }

        public string Padre
        {
            get
            {
                return padre;
            }

            set
            {
                padre = value;
            }
        }
    }
}
