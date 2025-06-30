namespace CpHeladeria
{
    partial class FrmPedido
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
            this.components = new System.ComponentModel.Container();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.lblParametro = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.cbxTipoProducto = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtFechaPedido = new System.Windows.Forms.TextBox();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.erpFechaPedido = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpTipoPago = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxLista = new System.Windows.Forms.GroupBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.erpEstado = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPedidos = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.gbxDatos.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpFechaPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipoPago)).BeginInit();
            this.gbxLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CpHeladeria.Properties.Resources.find_search_locate_6312;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(711, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnBuscar.Size = new System.Drawing.Size(98, 40);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(14, 61);
            this.txtParametro.MaxLength = 100;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(680, 20);
            this.txtParametro.TabIndex = 30;
            // 
            // lblParametro
            // 
            this.lblParametro.AutoSize = true;
            this.lblParametro.Location = new System.Drawing.Point(14, 42);
            this.lblParametro.Name = "lblParametro";
            this.lblParametro.Size = new System.Drawing.Size(197, 13);
            this.lblParametro.TabIndex = 29;
            this.lblParametro.Text = "Buscar por Fecha Pedido, Tipo de Pago";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::CpHeladeria.Properties.Resources.file_new_14966;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(179, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNuevo.Size = new System.Drawing.Size(98, 40);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.txtEstado);
            this.gbxDatos.Controls.Add(this.lblEstado);
            this.gbxDatos.Controls.Add(this.lblTipoPago);
            this.gbxDatos.Controls.Add(this.cbxTipoProducto);
            this.gbxDatos.Controls.Add(this.btnCancelar);
            this.gbxDatos.Controls.Add(this.btnGuardar);
            this.gbxDatos.Controls.Add(this.txtFechaPedido);
            this.gbxDatos.Controls.Add(this.lblFechaPedido);
            this.gbxDatos.Location = new System.Drawing.Point(14, 323);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(795, 115);
            this.gbxDatos.TabIndex = 34;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(126, 73);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 19;
            this.lblEstado.Text = "Estado:";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Location = new System.Drawing.Point(95, 44);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(74, 13);
            this.lblTipoPago.TabIndex = 17;
            this.lblTipoPago.Text = "Tipo de Pago:";
            // 
            // cbxTipoProducto
            // 
            this.cbxTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoProducto.FormattingEnabled = true;
            this.cbxTipoProducto.Items.AddRange(new object[] {
            "Efectivo",
            "Pago Qr",
            "Tarjeta"});
            this.cbxTipoProducto.Location = new System.Drawing.Point(177, 44);
            this.cbxTipoProducto.Name = "cbxTipoProducto";
            this.cbxTipoProducto.Size = new System.Drawing.Size(147, 21);
            this.cbxTipoProducto.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::CpHeladeria.Properties.Resources.Cancel_27012;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(672, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancelar.Size = new System.Drawing.Size(111, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::CpHeladeria.Properties.Resources.save_icon_icons_com_53618;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(561, 71);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnGuardar.Size = new System.Drawing.Size(105, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtFechaPedido
            // 
            this.txtFechaPedido.Location = new System.Drawing.Point(177, 14);
            this.txtFechaPedido.MaxLength = 30;
            this.txtFechaPedido.Name = "txtFechaPedido";
            this.txtFechaPedido.Size = new System.Drawing.Size(148, 20);
            this.txtFechaPedido.TabIndex = 2;
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.Location = new System.Drawing.Point(93, 16);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(76, 13);
            this.lblFechaPedido.TabIndex = 2;
            this.lblFechaPedido.Text = "Fecha Pedido:";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::CpHeladeria.Properties.Resources._1486564394_edit_81508;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(283, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEditar.Size = new System.Drawing.Size(98, 40);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnCerrar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnEditar);
            this.pnlAcciones.Controls.Add(this.btnNuevo);
            this.pnlAcciones.Location = new System.Drawing.Point(14, 274);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(795, 47);
            this.pnlAcciones.TabIndex = 33;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::CpHeladeria.Properties.Resources.vcsremoved_103741;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(495, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCerrar.Size = new System.Drawing.Size(96, 40);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::CpHeladeria.Properties.Resources._1486504830_delete_dustbin_empty_recycle_recycling_remove_trash_81361;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(387, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEliminar.Size = new System.Drawing.Size(102, 40);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // erpFechaPedido
            // 
            this.erpFechaPedido.ContainerControl = this;
            // 
            // erpTipoPago
            // 
            this.erpTipoPago.ContainerControl = this;
            // 
            // gbxLista
            // 
            this.gbxLista.Controls.Add(this.dgvLista);
            this.gbxLista.Location = new System.Drawing.Point(14, 89);
            this.gbxLista.Name = "gbxLista";
            this.gbxLista.Size = new System.Drawing.Size(795, 179);
            this.gbxLista.TabIndex = 32;
            this.gbxLista.TabStop = false;
            this.gbxLista.Text = "Lista de Pedidos";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 21);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(783, 150);
            this.dgvLista.TabIndex = 0;
            // 
            // erpEstado
            // 
            this.erpEstado.ContainerControl = this;
            // 
            // lblPedidos
            // 
            this.lblPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidos.Location = new System.Drawing.Point(9, 11);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Size = new System.Drawing.Size(800, 31);
            this.lblPedidos.TabIndex = 28;
            this.lblPedidos.Text = "Pedidos";
            this.lblPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(179, 73);
            this.txtEstado.MaxLength = 30;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(148, 20);
            this.txtEstado.TabIndex = 20;
            // 
            // FrmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(819, 448);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.lblParametro);
            this.Controls.Add(this.gbxDatos);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.gbxLista);
            this.Controls.Add(this.lblPedidos);
            this.Name = "FrmPedido";
            this.Text = "Pedido - Heladeria";
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpFechaPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipoPago)).EndInit();
            this.gbxLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEstado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label lblParametro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.ComboBox cbxTipoProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtFechaPedido;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ErrorProvider erpFechaPedido;
        private System.Windows.Forms.GroupBox gbxLista;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label lblPedidos;
        private System.Windows.Forms.ErrorProvider erpTipoPago;
        private System.Windows.Forms.ErrorProvider erpEstado;
        private System.Windows.Forms.TextBox txtEstado;
    }
}