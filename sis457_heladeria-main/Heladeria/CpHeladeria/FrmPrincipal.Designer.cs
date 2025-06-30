namespace CpHeladeria
{
    partial class FrmPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnSabores = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblGestionVentas = new System.Windows.Forms.Label();
            this.lblGestionCompras = new System.Windows.Forms.Label();
            this.btnArqueoCaja = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblAdminSis = new System.Windows.Forms.Label();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnEmpleadosUser = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblCompras = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.lblReportesGral = new System.Windows.Forms.Label();
            this.btnComprasProductos = new System.Windows.Forms.Button();
            this.btnComprasProveedor = new System.Windows.Forms.Button();
            this.btnComprasFechas = new System.Windows.Forms.Button();
            this.btnVentasProductos = new System.Windows.Forms.Button();
            this.btnVentasFechas = new System.Windows.Forms.Button();
            this.btnEmplea = new System.Windows.Forms.Button();
            this.btnProv = new System.Windows.Forms.Button();
            this.btnClie = new System.Windows.Forms.Button();
            this.btnStovkProductos = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lblAcercaSistema = new System.Windows.Forms.Label();
            this.btnAcerca = new System.Windows.Forms.Button();
            this.btnManualUsuario = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitulo.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(288, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(382, 31);
            this.lblTitulo.TabIndex = 22;
            this.lblTitulo.Text = "HELADERIA ICE FRUIT";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(2, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 136);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.lblAdmin);
            this.tabPage1.Controls.Add(this.btnProductos);
            this.tabPage1.Controls.Add(this.btnClientes);
            this.tabPage1.Controls.Add(this.btnSabores);
            this.tabPage1.Controls.Add(this.btnProveedores);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(999, 107);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Catálogos";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(106, 78);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(140, 13);
            this.lblAdmin.TabIndex = 25;
            this.lblAdmin.Text = "Administración de Catálogos";
            // 
            // btnProductos
            // 
            this.btnProductos.Image = global::CpHeladeria.Properties.Resources.icecream4_122441;
            this.btnProductos.Location = new System.Drawing.Point(6, 6);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(93, 58);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Image = global::CpHeladeria.Properties.Resources.employee__icon_icons_com_76984;
            this.btnClientes.Location = new System.Drawing.Point(105, 3);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(68, 61);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnSabores
            // 
            this.btnSabores.Image = global::CpHeladeria.Properties.Resources.fruits_96835;
            this.btnSabores.Location = new System.Drawing.Point(284, 2);
            this.btnSabores.Name = "btnSabores";
            this.btnSabores.Size = new System.Drawing.Size(75, 62);
            this.btnSabores.TabIndex = 24;
            this.btnSabores.Text = "Sabores";
            this.btnSabores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSabores.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Image = global::CpHeladeria.Properties.Resources.iconfinder_factory_3992944_112593;
            this.btnProveedores.Location = new System.Drawing.Point(192, 2);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(75, 62);
            this.btnProveedores.TabIndex = 23;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProveedores.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.lblGestionVentas);
            this.tabPage2.Controls.Add(this.lblGestionCompras);
            this.tabPage2.Controls.Add(this.btnArqueoCaja);
            this.tabPage2.Controls.Add(this.btnVentas);
            this.tabPage2.Controls.Add(this.btnCompras);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(920, 107);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compras/Ventas";
            // 
            // lblGestionVentas
            // 
            this.lblGestionVentas.AutoSize = true;
            this.lblGestionVentas.Location = new System.Drawing.Point(183, 82);
            this.lblGestionVentas.Name = "lblGestionVentas";
            this.lblGestionVentas.Size = new System.Drawing.Size(94, 13);
            this.lblGestionVentas.TabIndex = 29;
            this.lblGestionVentas.Text = "Gestión de Ventas";
            // 
            // lblGestionCompras
            // 
            this.lblGestionCompras.AutoSize = true;
            this.lblGestionCompras.Location = new System.Drawing.Point(20, 82);
            this.lblGestionCompras.Name = "lblGestionCompras";
            this.lblGestionCompras.Size = new System.Drawing.Size(102, 13);
            this.lblGestionCompras.TabIndex = 26;
            this.lblGestionCompras.Text = "Gestión de Compras";
            // 
            // btnArqueoCaja
            // 
            this.btnArqueoCaja.Image = global::CpHeladeria.Properties.Resources.blueboxwipfolder_azul_caja_wip_12411;
            this.btnArqueoCaja.Location = new System.Drawing.Point(223, 17);
            this.btnArqueoCaja.Name = "btnArqueoCaja";
            this.btnArqueoCaja.Size = new System.Drawing.Size(97, 62);
            this.btnArqueoCaja.TabIndex = 28;
            this.btnArqueoCaja.Text = "Arqueo de Caja";
            this.btnArqueoCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArqueoCaja.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            this.btnVentas.Image = global::CpHeladeria.Properties.Resources.Sales_by_payment_method_25410;
            this.btnVentas.Location = new System.Drawing.Point(142, 17);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(75, 62);
            this.btnVentas.TabIndex = 27;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Image = global::CpHeladeria.Properties.Resources.Shopping_icon_30277;
            this.btnCompras.Location = new System.Drawing.Point(33, 17);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(75, 62);
            this.btnCompras.TabIndex = 24;
            this.btnCompras.Text = "Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompras.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage3.Controls.Add(this.lblAdminSis);
            this.tabPage3.Controls.Add(this.btnPermisos);
            this.tabPage3.Controls.Add(this.btnRoles);
            this.tabPage3.Controls.Add(this.btnEmpleadosUser);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(920, 107);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Administración";
            // 
            // lblAdminSis
            // 
            this.lblAdminSis.AutoSize = true;
            this.lblAdminSis.Location = new System.Drawing.Point(152, 85);
            this.lblAdminSis.Name = "lblAdminSis";
            this.lblAdminSis.Size = new System.Drawing.Size(132, 13);
            this.lblAdminSis.TabIndex = 29;
            this.lblAdminSis.Text = "Administración del Sistema";
            // 
            // btnPermisos
            // 
            this.btnPermisos.Image = global::CpHeladeria.Properties.Resources.lock_private_key_19662;
            this.btnPermisos.Location = new System.Drawing.Point(236, 6);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(75, 62);
            this.btnPermisos.TabIndex = 28;
            this.btnPermisos.Text = "Permisos";
            this.btnPermisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPermisos.UseVisualStyleBackColor = true;
            // 
            // btnRoles
            // 
            this.btnRoles.Image = global::CpHeladeria.Properties.Resources.iconview_6283;
            this.btnRoles.Location = new System.Drawing.Point(155, 6);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(75, 62);
            this.btnRoles.TabIndex = 27;
            this.btnRoles.Text = "Roles";
            this.btnRoles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRoles.UseVisualStyleBackColor = true;
            // 
            // btnEmpleadosUser
            // 
            this.btnEmpleadosUser.Image = global::CpHeladeria.Properties.Resources.rotation_102346;
            this.btnEmpleadosUser.Location = new System.Drawing.Point(6, 6);
            this.btnEmpleadosUser.Name = "btnEmpleadosUser";
            this.btnEmpleadosUser.Size = new System.Drawing.Size(126, 82);
            this.btnEmpleadosUser.TabIndex = 26;
            this.btnEmpleadosUser.Text = "Empleados y Usuarios";
            this.btnEmpleadosUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpleadosUser.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage4.Controls.Add(this.lblCompras);
            this.tabPage4.Controls.Add(this.lblVentas);
            this.tabPage4.Controls.Add(this.lblReportesGral);
            this.tabPage4.Controls.Add(this.btnComprasProductos);
            this.tabPage4.Controls.Add(this.btnComprasProveedor);
            this.tabPage4.Controls.Add(this.btnComprasFechas);
            this.tabPage4.Controls.Add(this.btnVentasProductos);
            this.tabPage4.Controls.Add(this.btnVentasFechas);
            this.tabPage4.Controls.Add(this.btnEmplea);
            this.tabPage4.Controls.Add(this.btnProv);
            this.tabPage4.Controls.Add(this.btnClie);
            this.tabPage4.Controls.Add(this.btnStovkProductos);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(920, 107);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reportes";
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Location = new System.Drawing.Point(682, 88);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(48, 13);
            this.lblCompras.TabIndex = 40;
            this.lblCompras.Text = "Compras";
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Location = new System.Drawing.Point(426, 87);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(40, 13);
            this.lblVentas.TabIndex = 36;
            this.lblVentas.Text = "Ventas";
            // 
            // lblReportesGral
            // 
            this.lblReportesGral.AutoSize = true;
            this.lblReportesGral.Location = new System.Drawing.Point(140, 87);
            this.lblReportesGral.Name = "lblReportesGral";
            this.lblReportesGral.Size = new System.Drawing.Size(101, 13);
            this.lblReportesGral.TabIndex = 33;
            this.lblReportesGral.Text = "Reportes Generales";
            // 
            // btnComprasProductos
            // 
            this.btnComprasProductos.Image = global::CpHeladeria.Properties.Resources.shoppingcart_77968;
            this.btnComprasProductos.Location = new System.Drawing.Point(762, 6);
            this.btnComprasProductos.Name = "btnComprasProductos";
            this.btnComprasProductos.Size = new System.Drawing.Size(75, 78);
            this.btnComprasProductos.TabIndex = 39;
            this.btnComprasProductos.Text = "Compras por Productos";
            this.btnComprasProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComprasProductos.UseVisualStyleBackColor = true;
            // 
            // btnComprasProveedor
            // 
            this.btnComprasProveedor.Image = global::CpHeladeria.Properties.Resources.shopping_icon_194144;
            this.btnComprasProveedor.Location = new System.Drawing.Point(662, 6);
            this.btnComprasProveedor.Name = "btnComprasProveedor";
            this.btnComprasProveedor.Size = new System.Drawing.Size(94, 78);
            this.btnComprasProveedor.TabIndex = 38;
            this.btnComprasProveedor.Text = "Compras por Proveedor";
            this.btnComprasProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComprasProveedor.UseVisualStyleBackColor = true;
            // 
            // btnComprasFechas
            // 
            this.btnComprasFechas.Image = global::CpHeladeria.Properties.Resources.date_512x512_35979;
            this.btnComprasFechas.Location = new System.Drawing.Point(552, 6);
            this.btnComprasFechas.Name = "btnComprasFechas";
            this.btnComprasFechas.Size = new System.Drawing.Size(106, 78);
            this.btnComprasFechas.TabIndex = 37;
            this.btnComprasFechas.Text = "Compras por Rango de Fechas";
            this.btnComprasFechas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComprasFechas.UseVisualStyleBackColor = true;
            // 
            // btnVentasProductos
            // 
            this.btnVentasProductos.Image = global::CpHeladeria.Properties.Resources._ice_cream_89753;
            this.btnVentasProductos.Location = new System.Drawing.Point(451, 6);
            this.btnVentasProductos.Name = "btnVentasProductos";
            this.btnVentasProductos.Size = new System.Drawing.Size(75, 78);
            this.btnVentasProductos.TabIndex = 35;
            this.btnVentasProductos.Text = "Ventas por Productos";
            this.btnVentasProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentasProductos.UseVisualStyleBackColor = true;
            // 
            // btnVentasFechas
            // 
            this.btnVentasFechas.Image = global::CpHeladeria.Properties.Resources.clock_timer_time_calendar_date_schedule_hourglass_stopwatch_deadline_icon_231905;
            this.btnVentasFechas.Location = new System.Drawing.Point(348, 6);
            this.btnVentasFechas.Name = "btnVentasFechas";
            this.btnVentasFechas.Size = new System.Drawing.Size(98, 78);
            this.btnVentasFechas.TabIndex = 34;
            this.btnVentasFechas.Text = "Ventas en Rango de Fechas";
            this.btnVentasFechas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentasFechas.UseVisualStyleBackColor = true;
            // 
            // btnEmplea
            // 
            this.btnEmplea.Image = global::CpHeladeria.Properties.Resources._1488492642_people07_81742;
            this.btnEmplea.Location = new System.Drawing.Point(247, 22);
            this.btnEmplea.Name = "btnEmplea";
            this.btnEmplea.Size = new System.Drawing.Size(75, 62);
            this.btnEmplea.TabIndex = 32;
            this.btnEmplea.Text = "Empleados";
            this.btnEmplea.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmplea.UseVisualStyleBackColor = true;
            // 
            // btnProv
            // 
            this.btnProv.Image = global::CpHeladeria.Properties.Resources.factory_115122;
            this.btnProv.Location = new System.Drawing.Point(166, 22);
            this.btnProv.Name = "btnProv";
            this.btnProv.Size = new System.Drawing.Size(75, 62);
            this.btnProv.TabIndex = 31;
            this.btnProv.Text = "Proveedores";
            this.btnProv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProv.UseVisualStyleBackColor = true;
            // 
            // btnClie
            // 
            this.btnClie.Image = global::CpHeladeria.Properties.Resources.founder_icon_icons_com_76996;
            this.btnClie.Location = new System.Drawing.Point(87, 22);
            this.btnClie.Name = "btnClie";
            this.btnClie.Size = new System.Drawing.Size(75, 62);
            this.btnClie.TabIndex = 30;
            this.btnClie.Text = "Clientes";
            this.btnClie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClie.UseVisualStyleBackColor = true;
            // 
            // btnStovkProductos
            // 
            this.btnStovkProductos.Image = global::CpHeladeria.Properties.Resources._3890929_chart_growth_invest_market_stock_111188;
            this.btnStovkProductos.Location = new System.Drawing.Point(6, 6);
            this.btnStovkProductos.Name = "btnStovkProductos";
            this.btnStovkProductos.Size = new System.Drawing.Size(75, 82);
            this.btnStovkProductos.TabIndex = 29;
            this.btnStovkProductos.Text = "Stock de Productos";
            this.btnStovkProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStovkProductos.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage5.Controls.Add(this.lblAcercaSistema);
            this.tabPage5.Controls.Add(this.btnAcerca);
            this.tabPage5.Controls.Add(this.btnManualUsuario);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(920, 107);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Ayuda";
            // 
            // lblAcercaSistema
            // 
            this.lblAcercaSistema.AutoSize = true;
            this.lblAcercaSistema.Location = new System.Drawing.Point(90, 85);
            this.lblAcercaSistema.Name = "lblAcercaSistema";
            this.lblAcercaSistema.Size = new System.Drawing.Size(98, 13);
            this.lblAcercaSistema.TabIndex = 37;
            this.lblAcercaSistema.Text = "Acerca del Sistema";
            // 
            // btnAcerca
            // 
            this.btnAcerca.Image = global::CpHeladeria.Properties.Resources.communication_information_aid_disclaimer_customer_service_about_guide_help_info_icon_210836;
            this.btnAcerca.Location = new System.Drawing.Point(127, 20);
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Size = new System.Drawing.Size(75, 62);
            this.btnAcerca.TabIndex = 34;
            this.btnAcerca.Text = "Acerca de";
            this.btnAcerca.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAcerca.UseVisualStyleBackColor = true;
            // 
            // btnManualUsuario
            // 
            this.btnManualUsuario.Image = global::CpHeladeria.Properties.Resources.User_Manual_80_icon_icons_com_57245;
            this.btnManualUsuario.Location = new System.Drawing.Point(20, 6);
            this.btnManualUsuario.Name = "btnManualUsuario";
            this.btnManualUsuario.Size = new System.Drawing.Size(101, 76);
            this.btnManualUsuario.TabIndex = 33;
            this.btnManualUsuario.Text = "Manual de Usuario";
            this.btnManualUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManualUsuario.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CpHeladeria.Properties.Resources._20250606_0436_image;
            this.ClientSize = new System.Drawing.Size(944, 454);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnSabores;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnEmpleadosUser;
        private System.Windows.Forms.Button btnPermisos;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Label lblGestionCompras;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Label lblGestionVentas;
        private System.Windows.Forms.Button btnArqueoCaja;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblReportesGral;
        private System.Windows.Forms.Button btnEmplea;
        private System.Windows.Forms.Button btnProv;
        private System.Windows.Forms.Button btnClie;
        private System.Windows.Forms.Button btnStovkProductos;
        private System.Windows.Forms.Button btnComprasFechas;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Button btnVentasProductos;
        private System.Windows.Forms.Button btnVentasFechas;
        private System.Windows.Forms.Button btnComprasProductos;
        private System.Windows.Forms.Button btnComprasProveedor;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lblAcercaSistema;
        private System.Windows.Forms.Button btnAcerca;
        private System.Windows.Forms.Button btnManualUsuario;
        private System.Windows.Forms.Label lblAdminSis;
    }
}