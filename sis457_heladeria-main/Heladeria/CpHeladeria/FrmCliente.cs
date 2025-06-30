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
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ClienteCln.listar(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["nit"].HeaderText = "NIT";
            dgvLista.Columns["celular"].HeaderText = "Celular";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";
            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Size = new Size(835, 362);
            listar();
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtNit.Clear();
            txtCelular.Clear();
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
            var cliente = ClienteCln.obtenerUno(id);
            txtNombre.Text = cliente.nombre;
            txtNit.Text = cliente.nit;
            txtCelular.Text = cliente.celular;
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
            if(e.KeyChar == (char)Keys.Enter) listar();
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.SetError(txtNombre, "");
            erpNit.SetError(txtNit, "");
            erpCelular.SetError(txtCelular, "");

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                erpNombre.SetError(txtNombre, "El nombre es obligatorio.");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtNit.Text.Trim()))
            {
                erpNit.SetError(txtNit, "El NIT es obligatorio.");
                esValido = false;
            }
            //if (string.IsNullOrEmpty(txtCelular.Text.Trim()))
            //{
            //    erpCelular.SetError(txtCelular, "El celular es obligatorio.");
            //    esValido = false;
            //}
            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var cliente = new Cliente();
                cliente.nombre = txtNombre.Text.Trim();
                cliente.nit = txtNit.Text.Trim();
                cliente.celular = txtCelular.Text.Trim();
                cliente.usuarioRegistro = Sesion.Usuario;  // Aquí deberías obtener el usuario que inicio sesion
                cliente.fechaRegistro = DateTime.Now;

                if (esNuevo)
                {
                    cliente.estado = 1;
                    ClienteCln.insertar(cliente);
                }
                else
                {
                    int index = dgvLista.CurrentCell.RowIndex;
                    cliente.id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                    ClienteCln.actualizar(cliente);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Cliente guardado correctamente", "::: Heladería - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            string nombre = dgvLista.Rows[index].Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro que desea dar de baja el cliente {nombre}?",
                "::: Heladería - Confirmación :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ClienteCln.eliminar(id, Sesion.Usuario);
                listar();
                MessageBox.Show("Cliente eliminado correctamente", "::: Heladería - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
