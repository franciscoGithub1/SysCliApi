using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using ZKSoftwareAPI;

namespace RelojServer
{
    public partial class RelojServer : Form
    {
        public RelojServer()
        {
            InitializeComponent();
            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            conectserver();
        }
        private void conectserver()
        {
            TcpListener server = null;
            ZKSoftware dispositivo = new ZKSoftware(Modelo.X628C);
            var IpReloj = System.Configuration.ConfigurationSettings.AppSettings["IpReloj"];
            dispositivo.DispositivoConectar(IpReloj, 0, true);
            try
            {
                //ZKSoftware dispositivo = new ZKSoftware(Modelo.X628C);
                //dispositivo.DispositivoConectar("192.168.0.201", 0, true);
                //dispositivo.DispositivoObtenerRegistrosAsistencias();
                //dispositivo.UsuarioBuscarTodos(true);
                // Set the TcpListener on port 13000.
                var PuertoRelojServer = System.Configuration.ConfigurationSettings.AppSettings["PuertoRelojServer"];
                Int32 port = int.Parse(PuertoRelojServer);
                var IpAppRelojServer = System.Configuration.ConfigurationSettings.AppSettings["IpAppRelojServer"];
                IPAddress localAddr = IPAddress.Parse(IpAppRelojServer);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;
                int inicide = 0;
                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        dispositivo.DispositivoObtenerRegistrosAsistencias();

                        //dispositivo.DispositivoObtenerRegistrosOperativos();
                        List<UsuarioMarcaje> usuarioMarcajes = new List<UsuarioMarcaje>();
                        usuarioMarcajes = dispositivo.ListaMarcajes;
                        int valors = dispositivo.ListaMarcajes.Count;
                        if (inicide != valors)
                        {
                            for (int start = valors; start == valors; start++)
                            {
                                inicide = valors;
                                int NumeroCredencial = usuarioMarcajes[start - 1].NumeroCredencial;
                                getCoenxion(NumeroCredencial);
                            }
                        }


                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public void getCoenxion(int codigo)
        {
            try
            {
                // Construimos un objeto SqlConnection para conectarnos
                // a la base Prueba de la instancia local de SQL Server.
                //
                using (SqlConnection cnn = new SqlConnection(
                    "Data Source=10.0.0.102,1433;" +
                    "Initial Catalog=ProyFidens;" +
                    "User id=ncsa;" +
                    "Password=ncsa;"))
                {
                    // Creamos el comando
                    //
                    SqlCommand cmd = new SqlCommand();
                    // Configuramos el comando
                    //
                    cmd.Connection = cnn;
                    cmd.CommandText = "SYS_ADM_OBTENER_COD_ACC_BY_COD_RELOJ_CONTROL";

                    // Indicamos que se trata de un procedimiento almacenado
                    //
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_RELOJ", codigo);
                    // Abrimos la conexión
                    //
                    cnn.Open();
                    // Ejecutamos el comando
                    //
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show(
                    //    "Se ha ejecutado satisfactoriamente el procedimiento almacenado.");
                }
            }
            catch (Exception ex)
            {
                // Se ha producido una excepción
                //
                MessageBox.Show(ex.Message);
            }
        }
    }
}
