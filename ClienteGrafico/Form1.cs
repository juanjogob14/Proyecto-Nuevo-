﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VivasGRChat;

namespace ClienteGrafico
{
    public partial class Form1 : Form
    {
        private NetworkStream stream;
        private StreamWriter streamwriter;
        private StreamReader streamreader;




        const string IP_SERVER = "127.0.0.1";
        public Object l = new object();
        public string nombreUsuario, contrasenha;
        public List<string> nombres = new List<string>();
        public bool usuarioRegistrado = false;
        VivasGRChat.BasesDatos bd = new BasesDatos();

        IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 15001);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";

                if (txtNombre.Text.Contains(" ") || txtNombre.Text == "" || txtPass.Text.Contains(" ") || txtPass.Text == "" || txtPort.Text == "")
                {
                    lblAviso.Text = "INTRODUZCA DATOS CORRECTOS";
                }
                else
                {

                    nombreUsuario = this.txtNombre.Text;
                    contrasenha = this.txtPass.Text;

                    server.Connect(ie);

                    stream = new NetworkStream(server);
                    streamwriter = new StreamWriter(stream);
                    streamreader = new StreamReader(stream);

                    streamwriter.WriteLine(nombreUsuario);
                    streamwriter.WriteLine(contrasenha);

                    streamwriter.Flush();

                    Thread hiloListen = new Thread(EsucharConexion);
                    hiloListen.Start();

                    if (streamreader.ReadLine().Equals("ok"))
                    {
                        this.lblNombre.Visible = false;
                        this.lblAviso.Visible = false;
                        this.txtNombre.Visible = false;
                        this.txtPass.Visible = false;
                        this.btnRegistrar.Visible = false;
                        this.lblPass.Visible = false;
                        this.btnCancelar.Visible = false;
                        this.btnConectar.Visible = false;

                        this.listMensajes.Visible = true;
                        this.btnEnviar.Visible = true;
                        this.txtMensaje.Visible = true;

                        this.Text = "VivasGram";

                        this.AcceptButton = this.btnEnviar;
                    }
                    else
                    {
                        lblAviso.Text = "Usuario no registrado";
                    }


                }

            }
            catch (SocketException se)
            {
                Console.WriteLine("Error de conexion {0}", se.ErrorCode);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private delegate void DAddItem(String s);

        private void AddItem(String s)
        {
            listMensajes.Items.Add(s);
        }

        void EsucharConexion()
        {
            while (server.Connected)
            {
                lock (l)
                {
                    if (server.Connected)
                    {
                        try
                        {
                            this.Invoke(new DAddItem(AddItem), streamreader.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Application.Exit();
                        }
                    }
                }

            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "" || txtMensaje.Text[0] == ' ')
            {
                txtMensaje.Text = ("Escribe un mensaje válido");
            }
            else
            {
                streamwriter.WriteLine(txtMensaje.Text);
                streamwriter.Flush();
                txtMensaje.Clear();
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {

                this.listMensajes.Visible = true;
                this.txtMensaje.Visible = true;
                this.btnEnviar.Visible = true;

                this.btnConectar.Visible = false;
                this.btnCancelar.Visible = false;
                this.btnRegistrar.Visible = false;

                this.AcceptButton = btnEnviar;

            }
            catch (Exception)
            {

                Console.WriteLine("Error");
            }


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                // EN caso de que el usuario no este registrado se le registra pulsando aqui 
                lblAviso.Text = "";

                if (bd.UsuarioYaRegistrado(txtNombre.Text))
                {
                    lblAviso.Text = "Este usuario ya está registrado, \n" +
                        "pruebe otro nombre";
                }
                else
                {
                    bd.AnhadirUsuario(txtNombre.Text, txtPass.Text);
                    lblAviso.Text = "El usuario ha sido registrado con éxito! \n" +
                                        "Ya puedes iniciar sesion";
                }

                this.Text = "VivasGram";



            }
            catch (SocketException se)
            {
                Console.WriteLine("Error de conexion {0}", se.ErrorCode);
            }
        }

    }
}
