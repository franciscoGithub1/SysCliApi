using System;
using System.Collections.Generic;
using System.Text;

namespace SysCli.App.Entidades
{
    public class Atencion
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        #region relaciones
        public Paciente Paciente { get; set; }
        public Propietario Propietario { get; set; }
        public MedioPago MedioPago { get; set; }
        public TipoPrevicion TipoPrevicion { get; set; }

        #endregion
    }
}
