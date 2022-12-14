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
        
        public Object llave = new object();

        public static bool usuarioRegistrado = false;
        bool correcto = true;
        string nombre, contrasenha, estado;

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
                    puertoCorrecto = true;

                    Socket socketConexion = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), puerto);
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
                            hilos.Start(socketCliente);
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

        //public bool ComprobarPuerto(string puertoCadena)
        //{
        //    bool correcto = false;
        //    int puerto;

        //    if (int.TryParse(puertoCadena, out puerto))
        //    {
        //        correcto = true;
        //    }

        //    return correcto;
        //}

        public void HiloCliente(object Socket)
        {
            Usuario user = new Usuario();
            Socket socketCliente = (Socket)Socket;
            string mensaje;
            bool cerrarChat = false;
            IPEndPoint info = (IPEndPoint)socketCliente.RemoteEndPoint;
            clientes.Add(socketCliente);

            using (NetworkStream ns = new NetworkStream(socketCliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                estado = sr.ReadLine();
                nombre = sr.ReadLine();
                contrasenha = sr.ReadLine();

                user.NickUser = nombre;
                user.Contrasenha = contrasenha;

                if (estado == "conect")
                {
                    if (bd.ComprobarUsuarioRegistrado(nombre, contrasenha))
                    {

                        sw.WriteLine("ok");
                        sw.Flush();

                        sw.WriteLine("Bienvenido a VivasGram {0}! Usuario(s) conectado(s) : {1}", nombre, clientes.Count);
                        sw.Flush();

                        while (!cerrarChat)
                        {
                            try
                            {
                                mensaje = sr.ReadLine();
                                if (mensaje != null)
                                {
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
                    else
                    {
                       sw.WriteLine("deny");
                    }
                }
                else if(estado == "registro")
                {
                    if (!bd.UsuarioYaRegistrado(user.NickUser))
                    {
                        sw.WriteLine("ok");
                        sw.Flush();
                        bd.AnhadirUsuario(user.NickUser, user.Contrasenha);

                        sw.WriteLine("Registrado en Vivasgram {0}! Usuario(s) conectado(s) : {1}", nombre, clientes.Count);
                        sw.Flush();

                        while (!cerrarChat)
                        {
                            try
                            {
                                mensaje = sr.ReadLine();
                                if (mensaje != null)
                                {
                                    //Console.WriteLine("Entra ");
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
                    else
                    {
                        sw.WriteLine("deny");
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

                        using (NetworkStream ns = new NetworkStream(clientes[i - 1]))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            try
                            {
                                sw.WriteLine(nombre + " : " + m);
                                sw.Flush();

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
}
