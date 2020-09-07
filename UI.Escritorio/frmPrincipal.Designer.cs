namespace UI.Escritorio
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.panelSubMenuReportes = new System.Windows.Forms.Panel();
            this.btnReportePagos = new System.Windows.Forms.Button();
            this.btnReporteCompras = new System.Windows.Forms.Button();
            this.btnReporteVentas = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.panelSubMenuEmpleados = new System.Windows.Forms.Panel();
            this.btnConsultarEmpleados = new System.Windows.Forms.Button();
            this.btnActualizarEmpleado = new System.Windows.Forms.Button();
            this.btnRegistrarEmpleado = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.panelSubMenuTerceros = new System.Windows.Forms.Panel();
            this.btnConsultarTerceros = new System.Windows.Forms.Button();
            this.btnActualizarTercero = new System.Windows.Forms.Button();
            this.btnRegistrarTercero = new System.Windows.Forms.Button();
            this.btnTerceros = new System.Windows.Forms.Button();
            this.panelSubMenuFacturacion = new System.Windows.Forms.Panel();
            this.btnConsultarFactura = new System.Windows.Forms.Button();
            this.btnActualizarFactura = new System.Windows.Forms.Button();
            this.btnRegistrarFactura = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.panelSubMenuProductos = new System.Windows.Forms.Panel();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnActualizarProducto = new System.Windows.Forms.Button();
            this.btnRegistrarProducto = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFormHijo = new System.Windows.Forms.Panel();
            this.panelMenuLateral.SuspendLayout();
            this.panelSubMenuReportes.SuspendLayout();
            this.panelSubMenuEmpleados.SuspendLayout();
            this.panelSubMenuTerceros.SuspendLayout();
            this.panelSubMenuFacturacion.SuspendLayout();
            this.panelSubMenuProductos.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.AutoScroll = true;
            this.panelMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelMenuLateral.Controls.Add(this.panelSubMenuReportes);
            this.panelMenuLateral.Controls.Add(this.btnReportes);
            this.panelMenuLateral.Controls.Add(this.btnPagos);
            this.panelMenuLateral.Controls.Add(this.panelSubMenuEmpleados);
            this.panelMenuLateral.Controls.Add(this.btnEmpleados);
            this.panelMenuLateral.Controls.Add(this.panelSubMenuTerceros);
            this.panelMenuLateral.Controls.Add(this.btnTerceros);
            this.panelMenuLateral.Controls.Add(this.panelSubMenuFacturacion);
            this.panelMenuLateral.Controls.Add(this.btnFacturacion);
            this.panelMenuLateral.Controls.Add(this.panelSubMenuProductos);
            this.panelMenuLateral.Controls.Add(this.btnProductos);
            this.panelMenuLateral.Controls.Add(this.panelLogo);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(250, 561);
            this.panelMenuLateral.TabIndex = 0;
            // 
            // panelSubMenuReportes
            // 
            this.panelSubMenuReportes.Controls.Add(this.btnReportePagos);
            this.panelSubMenuReportes.Controls.Add(this.btnReporteCompras);
            this.panelSubMenuReportes.Controls.Add(this.btnReporteVentas);
            this.panelSubMenuReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuReportes.Location = new System.Drawing.Point(0, 863);
            this.panelSubMenuReportes.Name = "panelSubMenuReportes";
            this.panelSubMenuReportes.Size = new System.Drawing.Size(233, 120);
            this.panelSubMenuReportes.TabIndex = 2;
            this.panelSubMenuReportes.Visible = false;
            // 
            // btnReportePagos
            // 
            this.btnReportePagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportePagos.FlatAppearance.BorderSize = 0;
            this.btnReportePagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportePagos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReportePagos.ForeColor = System.Drawing.Color.White;
            this.btnReportePagos.Location = new System.Drawing.Point(0, 80);
            this.btnReportePagos.Name = "btnReportePagos";
            this.btnReportePagos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReportePagos.Size = new System.Drawing.Size(233, 40);
            this.btnReportePagos.TabIndex = 0;
            this.btnReportePagos.Text = "Reporte Pagos";
            this.btnReportePagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportePagos.UseVisualStyleBackColor = true;
            this.btnReportePagos.Click += new System.EventHandler(this.btnReportePagos_Click);
            // 
            // btnReporteCompras
            // 
            this.btnReporteCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteCompras.FlatAppearance.BorderSize = 0;
            this.btnReporteCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteCompras.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReporteCompras.ForeColor = System.Drawing.Color.White;
            this.btnReporteCompras.Location = new System.Drawing.Point(0, 40);
            this.btnReporteCompras.Name = "btnReporteCompras";
            this.btnReporteCompras.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReporteCompras.Size = new System.Drawing.Size(233, 40);
            this.btnReporteCompras.TabIndex = 0;
            this.btnReporteCompras.Text = "Reporte Compras";
            this.btnReporteCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteCompras.UseVisualStyleBackColor = true;
            this.btnReporteCompras.Click += new System.EventHandler(this.btnReporteCompras_Click);
            // 
            // btnReporteVentas
            // 
            this.btnReporteVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteVentas.FlatAppearance.BorderSize = 0;
            this.btnReporteVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteVentas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReporteVentas.ForeColor = System.Drawing.Color.White;
            this.btnReporteVentas.Location = new System.Drawing.Point(0, 0);
            this.btnReporteVentas.Name = "btnReporteVentas";
            this.btnReporteVentas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReporteVentas.Size = new System.Drawing.Size(233, 40);
            this.btnReporteVentas.TabIndex = 0;
            this.btnReporteVentas.Text = "Reporte Ventas";
            this.btnReporteVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteVentas.UseVisualStyleBackColor = true;
            this.btnReporteVentas.Click += new System.EventHandler(this.btnReporteVentas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(0, 818);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(233, 45);
            this.btnReportes.TabIndex = 1;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPagos.FlatAppearance.BorderSize = 0;
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPagos.ForeColor = System.Drawing.Color.White;
            this.btnPagos.Location = new System.Drawing.Point(0, 773);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPagos.Size = new System.Drawing.Size(233, 45);
            this.btnPagos.TabIndex = 1;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // panelSubMenuEmpleados
            // 
            this.panelSubMenuEmpleados.Controls.Add(this.btnConsultarEmpleados);
            this.panelSubMenuEmpleados.Controls.Add(this.btnActualizarEmpleado);
            this.panelSubMenuEmpleados.Controls.Add(this.btnRegistrarEmpleado);
            this.panelSubMenuEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuEmpleados.Location = new System.Drawing.Point(0, 653);
            this.panelSubMenuEmpleados.Name = "panelSubMenuEmpleados";
            this.panelSubMenuEmpleados.Size = new System.Drawing.Size(233, 120);
            this.panelSubMenuEmpleados.TabIndex = 2;
            this.panelSubMenuEmpleados.Visible = false;
            // 
            // btnConsultarEmpleados
            // 
            this.btnConsultarEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultarEmpleados.FlatAppearance.BorderSize = 0;
            this.btnConsultarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarEmpleados.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultarEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnConsultarEmpleados.Location = new System.Drawing.Point(0, 80);
            this.btnConsultarEmpleados.Name = "btnConsultarEmpleados";
            this.btnConsultarEmpleados.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnConsultarEmpleados.Size = new System.Drawing.Size(233, 40);
            this.btnConsultarEmpleados.TabIndex = 0;
            this.btnConsultarEmpleados.Text = "Consultar Empleados";
            this.btnConsultarEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarEmpleados.UseVisualStyleBackColor = true;
            this.btnConsultarEmpleados.Click += new System.EventHandler(this.btnConsultarEmpleados_Click);
            // 
            // btnActualizarEmpleado
            // 
            this.btnActualizarEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnActualizarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnActualizarEmpleado.Location = new System.Drawing.Point(0, 40);
            this.btnActualizarEmpleado.Name = "btnActualizarEmpleado";
            this.btnActualizarEmpleado.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnActualizarEmpleado.Size = new System.Drawing.Size(233, 40);
            this.btnActualizarEmpleado.TabIndex = 0;
            this.btnActualizarEmpleado.Text = "Actualizar Empleado";
            this.btnActualizarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarEmpleado.UseVisualStyleBackColor = true;
            this.btnActualizarEmpleado.Click += new System.EventHandler(this.btnActualizarEmpleado_Click);
            // 
            // btnRegistrarEmpleado
            // 
            this.btnRegistrarEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistrarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnRegistrarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegistrarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarEmpleado.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrarEmpleado.Name = "btnRegistrarEmpleado";
            this.btnRegistrarEmpleado.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRegistrarEmpleado.Size = new System.Drawing.Size(233, 40);
            this.btnRegistrarEmpleado.TabIndex = 0;
            this.btnRegistrarEmpleado.Text = "Registrar Empleado";
            this.btnRegistrarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarEmpleado.UseVisualStyleBackColor = true;
            this.btnRegistrarEmpleado.Click += new System.EventHandler(this.btnRegistrarEmpleado_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnEmpleados.Location = new System.Drawing.Point(0, 608);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEmpleados.Size = new System.Drawing.Size(233, 45);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // panelSubMenuTerceros
            // 
            this.panelSubMenuTerceros.Controls.Add(this.btnConsultarTerceros);
            this.panelSubMenuTerceros.Controls.Add(this.btnActualizarTercero);
            this.panelSubMenuTerceros.Controls.Add(this.btnRegistrarTercero);
            this.panelSubMenuTerceros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuTerceros.Location = new System.Drawing.Point(0, 488);
            this.panelSubMenuTerceros.Name = "panelSubMenuTerceros";
            this.panelSubMenuTerceros.Size = new System.Drawing.Size(233, 120);
            this.panelSubMenuTerceros.TabIndex = 2;
            this.panelSubMenuTerceros.Visible = false;
            // 
            // btnConsultarTerceros
            // 
            this.btnConsultarTerceros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultarTerceros.FlatAppearance.BorderSize = 0;
            this.btnConsultarTerceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarTerceros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultarTerceros.ForeColor = System.Drawing.Color.White;
            this.btnConsultarTerceros.Location = new System.Drawing.Point(0, 80);
            this.btnConsultarTerceros.Name = "btnConsultarTerceros";
            this.btnConsultarTerceros.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnConsultarTerceros.Size = new System.Drawing.Size(233, 40);
            this.btnConsultarTerceros.TabIndex = 0;
            this.btnConsultarTerceros.Text = "Consultar Terceros";
            this.btnConsultarTerceros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarTerceros.UseVisualStyleBackColor = true;
            this.btnConsultarTerceros.Click += new System.EventHandler(this.btnConsultarTerceros_Click);
            // 
            // btnActualizarTercero
            // 
            this.btnActualizarTercero.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarTercero.FlatAppearance.BorderSize = 0;
            this.btnActualizarTercero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTercero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizarTercero.ForeColor = System.Drawing.Color.White;
            this.btnActualizarTercero.Location = new System.Drawing.Point(0, 40);
            this.btnActualizarTercero.Name = "btnActualizarTercero";
            this.btnActualizarTercero.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnActualizarTercero.Size = new System.Drawing.Size(233, 40);
            this.btnActualizarTercero.TabIndex = 0;
            this.btnActualizarTercero.Text = "Actualizar Tercero";
            this.btnActualizarTercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarTercero.UseVisualStyleBackColor = true;
            this.btnActualizarTercero.Click += new System.EventHandler(this.btnActualizarTercero_Click);
            // 
            // btnRegistrarTercero
            // 
            this.btnRegistrarTercero.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistrarTercero.FlatAppearance.BorderSize = 0;
            this.btnRegistrarTercero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarTercero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegistrarTercero.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarTercero.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrarTercero.Name = "btnRegistrarTercero";
            this.btnRegistrarTercero.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRegistrarTercero.Size = new System.Drawing.Size(233, 40);
            this.btnRegistrarTercero.TabIndex = 0;
            this.btnRegistrarTercero.Text = "Registrar Tercero";
            this.btnRegistrarTercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarTercero.UseVisualStyleBackColor = true;
            this.btnRegistrarTercero.Click += new System.EventHandler(this.btnRegistrarTercero_Click);
            // 
            // btnTerceros
            // 
            this.btnTerceros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTerceros.FlatAppearance.BorderSize = 0;
            this.btnTerceros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerceros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTerceros.ForeColor = System.Drawing.Color.White;
            this.btnTerceros.Location = new System.Drawing.Point(0, 443);
            this.btnTerceros.Name = "btnTerceros";
            this.btnTerceros.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTerceros.Size = new System.Drawing.Size(233, 45);
            this.btnTerceros.TabIndex = 1;
            this.btnTerceros.Text = "Terceros";
            this.btnTerceros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerceros.UseVisualStyleBackColor = true;
            this.btnTerceros.Click += new System.EventHandler(this.btnTerceros_Click);
            // 
            // panelSubMenuFacturacion
            // 
            this.panelSubMenuFacturacion.Controls.Add(this.btnConsultarFactura);
            this.panelSubMenuFacturacion.Controls.Add(this.btnActualizarFactura);
            this.panelSubMenuFacturacion.Controls.Add(this.btnRegistrarFactura);
            this.panelSubMenuFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuFacturacion.Location = new System.Drawing.Point(0, 323);
            this.panelSubMenuFacturacion.Name = "panelSubMenuFacturacion";
            this.panelSubMenuFacturacion.Size = new System.Drawing.Size(233, 120);
            this.panelSubMenuFacturacion.TabIndex = 2;
            this.panelSubMenuFacturacion.Visible = false;
            // 
            // btnConsultarFactura
            // 
            this.btnConsultarFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultarFactura.FlatAppearance.BorderSize = 0;
            this.btnConsultarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultarFactura.ForeColor = System.Drawing.Color.White;
            this.btnConsultarFactura.Location = new System.Drawing.Point(0, 80);
            this.btnConsultarFactura.Name = "btnConsultarFactura";
            this.btnConsultarFactura.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnConsultarFactura.Size = new System.Drawing.Size(233, 40);
            this.btnConsultarFactura.TabIndex = 0;
            this.btnConsultarFactura.Text = "Consultar Facturas";
            this.btnConsultarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarFactura.UseVisualStyleBackColor = true;
            this.btnConsultarFactura.Click += new System.EventHandler(this.btnConsultarFactura_Click);
            // 
            // btnActualizarFactura
            // 
            this.btnActualizarFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarFactura.FlatAppearance.BorderSize = 0;
            this.btnActualizarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizarFactura.ForeColor = System.Drawing.Color.White;
            this.btnActualizarFactura.Location = new System.Drawing.Point(0, 40);
            this.btnActualizarFactura.Name = "btnActualizarFactura";
            this.btnActualizarFactura.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnActualizarFactura.Size = new System.Drawing.Size(233, 40);
            this.btnActualizarFactura.TabIndex = 0;
            this.btnActualizarFactura.Text = "Actualizar Factura";
            this.btnActualizarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarFactura.UseVisualStyleBackColor = true;
            this.btnActualizarFactura.Click += new System.EventHandler(this.btnActualizarFactura_Click);
            // 
            // btnRegistrarFactura
            // 
            this.btnRegistrarFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistrarFactura.FlatAppearance.BorderSize = 0;
            this.btnRegistrarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegistrarFactura.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarFactura.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrarFactura.Name = "btnRegistrarFactura";
            this.btnRegistrarFactura.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRegistrarFactura.Size = new System.Drawing.Size(233, 40);
            this.btnRegistrarFactura.TabIndex = 0;
            this.btnRegistrarFactura.Text = "Registrar Factura";
            this.btnRegistrarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarFactura.UseVisualStyleBackColor = true;
            this.btnRegistrarFactura.Click += new System.EventHandler(this.btnRegistrarFactura_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnFacturacion.Location = new System.Drawing.Point(0, 278);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFacturacion.Size = new System.Drawing.Size(233, 45);
            this.btnFacturacion.TabIndex = 1;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // panelSubMenuProductos
            // 
            this.panelSubMenuProductos.Controls.Add(this.btnInventario);
            this.panelSubMenuProductos.Controls.Add(this.btnActualizarProducto);
            this.panelSubMenuProductos.Controls.Add(this.btnRegistrarProducto);
            this.panelSubMenuProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuProductos.Location = new System.Drawing.Point(0, 158);
            this.panelSubMenuProductos.Name = "panelSubMenuProductos";
            this.panelSubMenuProductos.Size = new System.Drawing.Size(233, 120);
            this.panelSubMenuProductos.TabIndex = 2;
            this.panelSubMenuProductos.Visible = false;
            // 
            // btnInventario
            // 
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(0, 80);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnInventario.Size = new System.Drawing.Size(233, 40);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnActualizarProducto
            // 
            this.btnActualizarProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarProducto.FlatAppearance.BorderSize = 0;
            this.btnActualizarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizarProducto.ForeColor = System.Drawing.Color.White;
            this.btnActualizarProducto.Location = new System.Drawing.Point(0, 40);
            this.btnActualizarProducto.Name = "btnActualizarProducto";
            this.btnActualizarProducto.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnActualizarProducto.Size = new System.Drawing.Size(233, 40);
            this.btnActualizarProducto.TabIndex = 0;
            this.btnActualizarProducto.Text = "Actualizar Producto";
            this.btnActualizarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarProducto.UseVisualStyleBackColor = true;
            this.btnActualizarProducto.Click += new System.EventHandler(this.btnActualizarProducto_Click);
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistrarProducto.FlatAppearance.BorderSize = 0;
            this.btnRegistrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegistrarProducto.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProducto.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRegistrarProducto.Size = new System.Drawing.Size(233, 40);
            this.btnRegistrarProducto.TabIndex = 0;
            this.btnRegistrarProducto.Text = "Registrar Producto";
            this.btnRegistrarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarProducto.UseVisualStyleBackColor = true;
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(0, 113);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(233, 45);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 113);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelFormHijo
            // 
            this.panelFormHijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelFormHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormHijo.Location = new System.Drawing.Point(250, 0);
            this.panelFormHijo.Name = "panelFormHijo";
            this.panelFormHijo.Size = new System.Drawing.Size(684, 561);
            this.panelFormHijo.TabIndex = 1;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.panelFormHijo);
            this.Controls.Add(this.panelMenuLateral);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximumSize = new System.Drawing.Size(1300, 950);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.panelMenuLateral.ResumeLayout(false);
            this.panelSubMenuReportes.ResumeLayout(false);
            this.panelSubMenuEmpleados.ResumeLayout(false);
            this.panelSubMenuTerceros.ResumeLayout(false);
            this.panelSubMenuFacturacion.ResumeLayout(false);
            this.panelSubMenuProductos.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Panel panelSubMenuProductos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnActualizarProducto;
        private System.Windows.Forms.Button btnRegistrarProducto;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelSubMenuEmpleados;
        private System.Windows.Forms.Button btnConsultarEmpleados;
        private System.Windows.Forms.Button btnActualizarEmpleado;
        private System.Windows.Forms.Button btnRegistrarEmpleado;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Panel panelSubMenuTerceros;
        private System.Windows.Forms.Button btnConsultarTerceros;
        private System.Windows.Forms.Button btnActualizarTercero;
        private System.Windows.Forms.Button btnRegistrarTercero;
        private System.Windows.Forms.Button btnTerceros;
        private System.Windows.Forms.Panel panelSubMenuFacturacion;
        private System.Windows.Forms.Button btnConsultarFactura;
        private System.Windows.Forms.Button btnActualizarFactura;
        private System.Windows.Forms.Button btnRegistrarFactura;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Panel panelSubMenuReportes;
        private System.Windows.Forms.Button btnReportePagos;
        private System.Windows.Forms.Button btnReporteCompras;
        private System.Windows.Forms.Button btnReporteVentas;
        private System.Windows.Forms.Panel panelFormHijo;
    }
}