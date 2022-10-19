
namespace ClienteGrafico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.listMensajes = new System.Windows.Forms.ListBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(41, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(41, 123);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(81, 17);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Contraseña";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(41, 183);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(50, 17);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Puerto";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(199, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(149, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(199, 123);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(149, 22);
            this.txtPass.TabIndex = 4;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(199, 183);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(149, 22);
            this.txtPort.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(44, 312);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(95, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(199, 312);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(96, 23);
            this.btnConectar.TabIndex = 7;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(348, 312);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // listMensajes
            // 
            this.listMensajes.FormattingEnabled = true;
            this.listMensajes.ItemHeight = 16;
            this.listMensajes.Location = new System.Drawing.Point(27, 31);
            this.listMensajes.Name = "listMensajes";
            this.listMensajes.Size = new System.Drawing.Size(439, 356);
            this.listMensajes.TabIndex = 9;
            this.listMensajes.Visible = false;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(27, 410);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(335, 22);
            this.txtMensaje.TabIndex = 10;
            this.txtMensaje.Visible = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(391, 406);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Visible = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(27, 390);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(0, 17);
            this.lblAviso.TabIndex = 12;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.listMensajes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vivasgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ListBox listMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblAviso;
    }
}

