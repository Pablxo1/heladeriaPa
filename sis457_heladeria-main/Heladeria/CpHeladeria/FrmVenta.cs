using CadHeladeria;
using ClnHeladeria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CpHeladeria.Util;

namespace CpHeladeria
{
    public partial class FrmVenta : Form
    {
        private Label montoTotal; // Declarar el control 'montoTotal'
        private Label montoPago;  // Declarar el control 'montoPago'
        private Label montoCambio; // Declarar el control 'montoCambio'
        private CheckBox checkestado;
        private bool esNuevo = false;
        public FrmVenta()
        {
            InitializeComponent();
            montoTotal = new Label(); // Inicializar el control 'montoTotal'
            montoPago = new Label(); // Inicializar el control 'montoPago'
            montoCambio = new Label(); // Inicializar el control 'montoCambio'

            montoTotal.Text = "0.00"; // Inicializar el texto del control
            montoPago.Text = "0.00"; // Inicializar el monto pago
            montoCambio.Text = "0.00"; // Inicializar el monto cambio

            Controls.Add(montoTotal); // Agregar el control al formulario
            Controls.Add(montoPago); // Agregar el control al formulario
        }

        private void listar()
        {
            var lista = VentaCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            foreach (DataGridViewColumn col in dgvLista.Columns)
            {
                Console.WriteLine($"Nombre de columna: {col.Name}");
            }


            // Revisión segura
            if (dgvLista.Columns.Contains("id")) dgvLista.Columns["id"].Visible = false;
            if (dgvLista.Columns.Contains("estado")) dgvLista.Columns["estado"].Visible = false;
            if (dgvLista.Columns.Contains("idUsuario")) dgvLista.Columns["idUsuario"].HeaderText = "ID Usuario";
            if (dgvLista.Columns.Contains("idCliente")) dgvLista.Columns["idCliente"].HeaderText = "ID Cliente";
            if (dgvLista.Columns.Contains("tipoPago")) dgvLista.Columns["tipoPago"].HeaderText = "Tipo de Pago";
            if (dgvLista.Columns.Contains("montoPago")) dgvLista.Columns["montoPago"].HeaderText = "Monto Pago";
            if (dgvLista.Columns.Contains("montoCambio")) dgvLista.Columns["montoCambio"].HeaderText = "Monto Cambio";
            if (dgvLista.Columns.Contains("montoTotal")) dgvLista.Columns["montoTotal"].HeaderText = "Monto Total";
            if (dgvLista.Columns.Contains("usuarioRegistro")) dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            if (dgvLista.Columns.Contains("fechaRegistro")) dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0 && dgvLista.Columns.Contains("tipoPago"))
                dgvLista.CurrentCell = dgvLista.Rows[0].Cells["tipoPago"];
        }

        private void CargarCliente()
        {
            using (var context = new HeladeriaEntities())
            {
                var cliente = context.Cliente.ToList();
                cbxCliente.DataSource = cliente;
                cbxCliente.DisplayMember = "nombre"; // Ajusta según el nombre del campo en Cliente
                cbxCliente.ValueMember = "id";
                cbxCliente.SelectedIndex = -1; // Para que no seleccione nada por defecto
            }
        }

        private void CargarProducto()
        {
            using (var context = new HeladeriaEntities())
            {
                var producto = context.Producto.ToList();
                cbxProducto.DataSource = producto;
                cbxProducto.DisplayMember = "nombre"; // Ajusta según el nombre del campo en Producto
                cbxProducto.ValueMember = "id";
                cbxProducto.SelectedIndex = -1; // Para que no seleccione nada por defecto
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            CargarCliente(); // Cambiar de 'CargarClientes' a 'CargarCliente'
            CargarProducto(); // Cambiar de 'CargarProductos' a 'CargarProducto'
            montoTotal.Text = "0.00"; // Inicializar el monto total
            montoPago.Text = "0.00"; // Inicializar el monto pago
            montoCambio.Text = "0.00"; // Inicializar el monto cambio
            Size = new Size(1022, 384);
            listar();
        }

        private void limpiar()
        {
            cbxCliente.SelectedIndex = -1;
            cbxTipoPago.SelectedIndex = -1;
            txtTotal.AcceptsReturn = false; // Asegurarse de que el campo de texto no acepte saltos de línea
            txtTotal.Text = "0.00"; // Reiniciar el monto total
            txtPago.Text = "0.00"; // Reiniciar el monto pago
            txtCambio.Text = "0.00"; // Reiniciar el monto cambio
        }

        private void CargarVenta()
        {
            List<Venta> ventas = VentaCln.GetAll();
            List<Producto> productos = new List<Producto>();
            dgvLista.Rows.Clear();
            foreach (var venta in ventas)
            {
                dgvLista.Rows.Add(
                    venta.id,
                    venta.idCliente,
                    venta.tipoPago,
                    venta.montoPago,
                    venta.montoCambio,
                    venta.montoTotal,
                    venta.estado == 1 ? "Activo" : "Inactivo"
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1022, 384);
            limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(1022, 510);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            Size = new Size(1022, 510);

            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var venta = VentaCln.obtenerUno(id);
            cbxCliente.SelectedValue = venta.idCliente;
            cbxTipoPago.SelectedItem = venta.tipoPago;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void LimpiarFormulario()
        {
            cbxCliente.SelectedIndex = -1;
            cbxTipoPago.SelectedIndex = -1;
            txtTotal.Text = "0.00";
            txtPago.Text = "0.00";
            txtCambio.Text = "0.00";
            checkestado.Checked = false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta // Inicializar la variable 'venta'
                {
                    idCliente = Convert.ToInt32(cbxCliente.SelectedValue), // Asignar el valor seleccionado del ComboBox
                    tipoPago = cbxTipoPago.Text,
                    montoTotal = decimal.Parse(txtTotal.Text),
                    montoPago = decimal.Parse(txtPago.Text), // Corregir el método de conversión
                    montoCambio = decimal.Parse(txtCambio.Text), // Corregir el método de conversión
                    usuarioRegistro = "usuario_actual",
                    fechaRegistro = DateTime.Now,
                    estado = checkestado.Checked ? (short)1 : (short)0
                };

                VentaCln.insertar(venta); // Cambiar 'Insert' por 'insertar'
                MessageBox.Show("Venta guardada correctamente", "Guardar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            if (MessageBox.Show("¿Está seguro de eliminar esta venta?", "::: Heladería - Confirmación :::",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                VentaCln.eliminar(id, Sesion.Usuario);
                listar();
                MessageBox.Show("Venta eliminada correctamente", "::: Heladería - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private List<VentaDetalle> detalles = new List<VentaDetalle>(); // Declarar e inicializar la lista 'detalles'


        private void CalcularTotal()
        {
            decimal total = detalles.Sum(d => d.precioUnitario); // Corregir el nombre de la propiedad
            montoTotal.Text = total.ToString("0.00");

            if (decimal.TryParse(txtPago.Text, out decimal pago))
            {
                montoCambio.Text = (pago - total).ToString("0.00");
            }
            else
            {
                montoCambio.Text = "0.00";
            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLista.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int ventaId = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["id"].Value);
                Venta venta = VentaCln.obtenerUno(ventaId);

                if (venta != null)
                {
                    cbxCliente.Text = venta.Cliente.nombre; // Ajustar según la propiedad 'nombre' del cliente
                    cbxTipoPago.Text = venta.tipoPago;
                    txtPago.Text = venta.montoPago.ToString("0.00");
                    txtCambio.Text = venta.montoCambio.ToString("0.00");
                    txtTotal.Text = venta.montoTotal.ToString("0.00");
                    checkestado.Checked = venta.estado == 1;
                }
            }
        }
    }
}
