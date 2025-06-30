using CadHeladeria;
using ClnHeladeria;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["sabor"].HeaderText = "Sabor";
            dgvLista.Columns["proveedor"].HeaderText = "Proveedor";
            dgvLista.Columns["presentacion"].HeaderText = "Presentación";
            dgvLista.Columns["precio"].HeaderText = "Precio";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";
            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(835, 362);
            using (var context = new HeladeriaEntities())
            {
                // Cargar sabores
                var sabores = context.Sabor.ToList();
                cbxSabor.DataSource = sabores;
                cbxSabor.DisplayMember = "nombre"; // Ajusta según el nombre del campo en Sabor
                cbxSabor.ValueMember = "id";
                cbxSabor.SelectedIndex = -1; // Para que no seleccione nada por defecto

                // Cargar proveedores
                var proveedores = context.Proveedor.ToList();
                cbxProveedor.DataSource = proveedores;
                cbxProveedor.DisplayMember = "nombre"; // Ajusta según el nombre del campo en Proveedor
                cbxProveedor.ValueMember = "id";
                cbxProveedor.SelectedIndex = -1;
            }
            listar();
        }

        private void limpiar()
        {
            txtNombre.Clear();
            cbxSabor.SelectedIndex = -1;
            cbxProveedor.SelectedIndex = -1;
            txtPresentacion.Clear();
            nudPrecio.Value = 0;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(835, 362);
            limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(835, 487);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            Size = new Size(835, 487);

            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var producto = ProductoCln.obtenerUno(id);
            txtNombre.Text = producto.nombre;
            cbxSabor.SelectedValue = producto.idsabor; //SelectedValue
            cbxProveedor.SelectedValue = producto.idproveedor; //SelectedValue
            txtPresentacion.Text = producto.presentacion;
            nudPrecio.Value = producto.precio;
            txtNombre.Focus();
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

        private bool validar()
        {
            bool esValido = true;
            erpNombre.SetError(txtNombre, "");
            erpSabor.SetError(cbxSabor, "");
            erpProveedor.SetError(cbxProveedor, "");
            erpPresentacion.SetError(txtPresentacion, "");
            erpPrecio.SetError(nudPrecio, "");

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                erpNombre.SetError(txtNombre, "El campo Nombre es obligatorio.");
                esValido = false;
            }
            if (cbxSabor.SelectedValue == null || Convert.ToInt32(cbxSabor.SelectedValue) <= 0)
            {
                erpSabor.SetError(cbxSabor, "Debe seleccionar un sabor válido.");
                esValido = false;
            }
            if (cbxProveedor.SelectedValue == null || Convert.ToInt32(cbxProveedor.SelectedValue) <= 0)
            {
                erpProveedor.SetError(cbxProveedor, "Debe seleccionar un proveedor válido.");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtPresentacion.Text.Trim()))
            {
                erpPresentacion.SetError(txtPresentacion, "El campo Presentación es obligatorio.");
                esValido = false;
            }
            if (nudPrecio.Value <= 0)
            {
                erpPrecio.SetError(nudPrecio, "El campo Precio debe ser mayor a 0.");
                esValido = false;
            }
            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var producto = new Producto();
                producto.nombre = txtNombre.Text.Trim();
                producto.idsabor = Convert.ToInt32(cbxSabor.SelectedValue);
                producto.idproveedor = Convert.ToInt32(cbxProveedor.SelectedValue);
                producto.presentacion = txtPresentacion.Text.Trim();
                producto.precio = nudPrecio.Value;
                producto.usuarioRegistro = Sesion.Usuario; // Aquí deberías obtener el usuario que inicio sesion
                producto.fechaRegistro = DateTime.Now;

                if (esNuevo)
                {
                    producto.estado = 1;
                    ProductoCln.insertar(producto);
                }
                else
                {
                    int index = dgvLista.CurrentCell.RowIndex;
                    producto.id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                    ProductoCln.actualizar(producto);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente", "::: Heladeria - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            string nombre = dgvLista.Rows[index].Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro que desea dar de baja el producto {nombre}?",
                "::: Heladeria - Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ProductoCln.eliminar(id, Sesion.Usuario);
                listar();
                MessageBox.Show("Producto eliminado correctamente", "::: Heladeria - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
