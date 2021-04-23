
namespace CapaPresentacion
{
    partial class FrmError
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptarEliminar = new System.Windows.Forms.Button();
            this.lblMensajeEliminar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptarEliminar
            // 
            this.btnAceptarEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(194)))), ((int)(((byte)(133)))));
            this.btnAceptarEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarEliminar.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptarEliminar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnAceptarEliminar.Location = new System.Drawing.Point(33, 251);
            this.btnAceptarEliminar.Name = "btnAceptarEliminar";
            this.btnAceptarEliminar.Size = new System.Drawing.Size(124, 56);
            this.btnAceptarEliminar.TabIndex = 1;
            this.btnAceptarEliminar.Tag = "";
            this.btnAceptarEliminar.Text = "ACEPTAR";
            this.btnAceptarEliminar.UseVisualStyleBackColor = false;
            this.btnAceptarEliminar.Click += new System.EventHandler(this.btnAceptarEliminar_Click);
            // 
            // lblMensajeEliminar
            // 
            this.lblMensajeEliminar.BackColor = System.Drawing.Color.White;
            this.lblMensajeEliminar.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMensajeEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.lblMensajeEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMensajeEliminar.Location = new System.Drawing.Point(8, 197);
            this.lblMensajeEliminar.Name = "lblMensajeEliminar";
            this.lblMensajeEliminar.Size = new System.Drawing.Size(340, 36);
            this.lblMensajeEliminar.TabIndex = 8;
            this.lblMensajeEliminar.Text = "!MENSAJE!";
            this.lblMensajeEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 180);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox1.Location = new System.Drawing.Point(80, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnCancelar.Location = new System.Drawing.Point(189, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 56);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Tag = "";
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 319);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptarEliminar);
            this.Controls.Add(this.lblMensajeEliminar);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInformacion";
            this.Load += new System.EventHandler(this.FrmInformacion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptarEliminar;
        private System.Windows.Forms.Label lblMensajeEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancelar;
    }
}