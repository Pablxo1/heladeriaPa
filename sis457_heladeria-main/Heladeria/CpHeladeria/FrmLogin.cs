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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            //txtUsuario.Text = Util.Encrypt("rs123");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool validar()
        {
            bool esValido = true;
            erpUsuario.SetError(txtUsuario, "");
            erpClave.SetError(txtClave, "");

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El usuario es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                erpClave.SetError(txtClave, "La clave es obligatoria");
                esValido = false;
            }
            return esValido;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var usuario = UsuarioCln.validar(txtUsuario.Text, Util.Encrypt(txtClave.Text));
                if (usuario != null)
                {
                    //Util.usuario = usuario;
                    //txtClave.Clear();
                    //txtUsuario.Focus();
                    //txtUsuario.SelectAll();
                    //new FrmPrincipal().ShowDialog();
                    bool autenticado = true; // aquí confirmas que el usuario es válido
                    if (autenticado) // si las credenciales son correctas
                    {
                        Sesion.Usuario = txtUsuario.Text.Trim(); // Guarda el usuario que inició sesion
                        Util.usuario = usuario;
                        txtClave.Clear();
                        txtUsuario.Focus();
                        txtUsuario.SelectAll();
                        FrmPrincipal frm = new FrmPrincipal();
                        frm.ShowDialog(); // Espera a que el formulario principal se cierre
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecto", "::: Minerva - Mensaje :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) btnIngresar.PerformClick();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                txtClave.Focus();
            }
        }
    }
}
