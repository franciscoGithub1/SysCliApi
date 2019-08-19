using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZKSoftwareAPI;
namespace PruebaDeZKSoftwareAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ZKSoftware dispositivo = new ZKSoftware(Modelo.X628C);

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Desconectar")
            {
                button1.Text = "Conectar";
                dispositivo.DispositivoDesconectar();
                return;
            }
            if (!dispositivo.DispositivoConectar("192.168.0.201", 0, true))
            {
                MessageBox.Show(dispositivo.ERROR);
            }
            else
            {
                button1.Text = "Desconectar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Buscar todos los usuarios del dispositivo
            if (dispositivo.UsuarioBuscarTodos(true))
            {
                comboBox1.DataSource = dispositivo.ListaUsuarios;
            }
            else
            {
                MessageBox.Show(dispositivo.ERROR);
            }

            //Consultar total de huellas registradas
            dispositivo.DispositivoConsultar(NumeroDe.HuellasRegistradas);
            lblHuellas.Text = dispositivo.ResultadoConsulta.ToString();
            //Consltar total de marcajes de asistencias
            dispositivo.DispositivoConsultar(NumeroDe.RegistrosDeAsistencias);
            lblAsistencias.Text = dispositivo.ResultadoConsulta.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Deshabilitar")
            {
                button3.Text = "Habilitar";
                dispositivo.DispositivoCambiarEstatus(Estatus.Deshabilitar);
            }
            else
            {
                button3.Text = "Deshabilitar";
                dispositivo.DispositivoCambiarEstatus(Estatus.Habilitar);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dispositivo.DispositivoObtenerRegistrosAsistencias();
            listBox1.DataSource = dispositivo.ListaMarcajes;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dispositivo.DispositivoObtenerRegistrosOperativos();
            listBox2.DataSource = dispositivo.ListaMarcajes;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            
            dispositivo.UsuarioAgregar(10, "Francisco", Permiso.UsuarioNormal, 1, "");
        }
    }
}
