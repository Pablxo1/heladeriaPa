using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpHeladeria
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new FrmCliente().ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            new FrmVenta().ShowDialog();
        }
    }
}
