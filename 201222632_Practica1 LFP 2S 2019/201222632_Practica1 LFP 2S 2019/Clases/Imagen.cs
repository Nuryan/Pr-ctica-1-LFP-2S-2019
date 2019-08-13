using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201222632_Practica1_LFP_2S_2019.Clases
{
    class Imagen
    {
        private int idActividad;
        private String ruta;

        public Imagen(int idActividad, String ruta)
        {
            this.IdActividad = idActividad;
            this.Ruta = ruta;
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

        public string Ruta
        {
            get
            {
                return ruta;
            }

            set
            {
                ruta = value;
            }
        }
    }
}
