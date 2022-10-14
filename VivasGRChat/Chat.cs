using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VivasGRChat
{
    public class Chat
    {
        private List<Socket> clientes = new List<Socket>();
        BasesDatos bd = new BasesDatos();
        Usuario user = new Usuario();
        Usuario usermensaje = new Usuario();

        public Object llave = new object();

        public static bool usuarioRegistrado = false;
        bool correcto = true;
        string nombre, contrasenha;

        public Chat()
        {

        }

        public void InicioChat()
        {
            bool puertoCorrecto = false;
            usuarioRegistrado = false;
            correcto = true;


            int puerto = 15001;

            while (!puertoCorrecto)
                try
                {
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), puerto);
                    puertoCorrecto = true;

                    Socket socketConexion = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketConexion.Bind(endpoint);
                    socketConexion.Listen(2);
                    Console.WriteLine("Servidor en marcha");

                    while (correcto)
                    {

                        Socket socketCliente = socketConexion.Accept();
                        Thread hilos = new Thread(HiloCliente);

                        using (NetworkStream ns = new NetworkStream(socketCliente))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            nombre = sr.ReadLine();
                            contrasenha = sr.ReadLine();
                            if (bd.ComprobarUsuarioRegistrado(nombre, contrasenha))
                            {
                                hilos.Start(socketCliente);
                            }
                        }

                        
                        


                    }

                }
                catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                {
                    if (puerto < IPEndPoint.MaxPort)
                    {
                        puerto++;
                    }
                    else
                    {
                        puerto = 10000;
                    }
                }
                catch (Exception)
                {

                }
        }



        public void HiloCliente(object Socket)
        {
            Socket socketCliente = (Socket)Socket;
            string mensaje;
            bool cerrarChat = false;
            IPEndPoint info = (IPEndPoint)socketCliente.RemoteEndPoint;
            clientes.Add(socketCliente);

            using (NetworkStream ns = new NetworkStream(socketCliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                user.NickUser = sr.ReadLine();
                user.Contrasenha = sr.ReadLine();
                sw.WriteLine("Bienvenido a VivasGram {0}! \nConexion al puerto:{1}", user.NickUser, info.Port);
                lock (llave)
                {
                    sw.WriteLine("Personas conectadas en el momento de tu conexión:{0} ", clientes.Count);
                }
                sw.Flush();

                while (!cerrarChat)
                {
                    try
                    {
                        mensaje = sr.ReadLine();
                        if (mensaje != null)
                        {
                            Console.WriteLine("Entra ");
                            EnvioMensaje(mensaje, info, user.NickUser);
                        }

                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Se ha desconectado " + info.Port);
                        socketCliente.Close();
                        lock (llave)
                        {
                            clientes.Remove(socketCliente);
                        }
                        cerrarChat = true;

                    }


                }

            }
        }

        public void EnvioMensaje(string m, IPEndPoint ie, string nombre)
        {
            IPEndPoint info;

            lock (llave)
            {
                for (int i = clientes.Count; i > 0; i--)
                {

                    {
                        info = (IPEndPoint)clientes[i - 1].RemoteEndPoint;
                        usermensaje.stream = new NetworkStream(clientes[i - 1]);
                        usermensaje.streamwriter = new StreamWriter(usermensaje.stream);
                        try
                        {
                            usermensaje.streamwriter.WriteLine(user.NickUser + " : " + m);
                            usermensaje.streamwriter.Flush();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("" + e.Message);
                        }
                    }

                }
            }
        }

    }
}
