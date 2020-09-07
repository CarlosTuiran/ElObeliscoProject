using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI.Escritorio
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void hideSubMenu() 
        {
            if (panelSubMenuProductos.Visible == true) { panelSubMenuProductos.Visible = false; }
            if (panelSubMenuFacturacion.Visible == true) { panelSubMenuFacturacion.Visible = false; }
            if (panelSubMenuTerceros.Visible == true) { panelSubMenuTerceros.Visible = false; }
            if (panelSubMenuEmpleados.Visible == true) { panelSubMenuEmpleados.Visible = false; }
            if (panelSubMenuReportes.Visible == true) { panelSubMenuReportes.Visible = false; }
        }

        private void showSubMenu(Panel subMenu) 
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        #region Producto
        private void btnProductos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuProductos);
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            openFormHijo(new Productos());
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        #endregion

        #region Reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuReportes);
        }
        private void btnReporteCompras_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        private void btnReportePagos_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        #endregion

        #region Terceros
        private void btnTerceros_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuTerceros);
        }
        private void btnConsultarTerceros_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnActualizarTercero_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnRegistrarTercero_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        #endregion

        #region Facturacion
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuFacturacion);
        }
        private void btnConsultarFactura_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnActualizarFactura_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnRegistrarFactura_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        #endregion

        #region Empleados
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuEmpleados);
        }
        private void btnConsultarEmpleados_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }
        #endregion

        private void btnPagos_Click(object sender, EventArgs e)
        {
            //---
            //El codigo
            //---
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openFormHijo(Form FormHijo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(FormHijo);
            panelFormHijo.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFormHijo(new Inicio());
        }
    }
}
