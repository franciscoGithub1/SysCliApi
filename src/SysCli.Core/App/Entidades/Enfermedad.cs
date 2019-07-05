using System;
using System.Collections.Generic;
using System.Text;

namespace SysCli.App.Entidades
{
    public class Enfermedad
    {
        public string Nombre { get; set; }
        public string Origen { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        #region relaciones
        public PacienteEnfermedad PacienteEnfermedad { get; set; }
        public Patologia Patologia { get; set; }
        public Tratamiento Tratamiento { get; set; }
        #endregion
    }
}
