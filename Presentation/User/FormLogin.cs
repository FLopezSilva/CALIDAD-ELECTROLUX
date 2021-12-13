using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
using Common.Cache;
using Presentation.Opcion;
using System.Data.SqlClient;
using Common;
using Presentation.User;

namespace Presentation
{
    public partial class FormLogin : Form
    {

        private string usernamePlaceholder;//Marca de agua(Placeholder) para el cuadro de texto usuario.
        private string passwordPlaceholder;//Marca de agua(Placeholder) para el cuadro de texto contraseña.
        private Color placeholderColor;//Color del marca de agua(Placeholder).
        private Color textColor;//Color para el texto del cuadro texto.


        public FormLogin()
        {
            InitializeComponent();
            pictureBox2.Visible = false;

            ConexionBD conex = new ConexionBD();
            conex.abrir();
            usernamePlaceholder = txtUser.Text;//Establecer placeholder del cuadro de texto usuario.
            passwordPlaceholder = txtPass.Text;//Establecer placeholder del cuadro de texto contraseña.
            placeholderColor = txtUser.ForeColor;////Establecer color de placeholder.
            textColor = Color.Gainsboro;//Establecer color del cuadro de texto usuario y contraseña.

            label1.Select();


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void SetPlaceholder()
        {//Establecer la marca de agua (Placeholder) al cuadro de texto usuario y contraseña,
            //Siempre en cuando el valor sea nulo o tiene espacios en blanco.
            if (string.IsNullOrWhiteSpace(txtUser.Text))//Usuario
            {
                txtUser.Text = usernamePlaceholder;
                txtUser.ForeColor = placeholderColor;
            }
            if (string.IsNullOrWhiteSpace(txtPass.Text))//Contraseña
            {
                txtPass.Text = passwordPlaceholder;
                txtPass.ForeColor = placeholderColor;
                txtPass.UseSystemPasswordChar = false;//Quitar el enmascaramiento de caracteres.
            }
        }

        private void RemovePlaceHolder(TextBox textBox, string placeholderText)
        {//Quitar la marca de agua (Placeholder) de un cuadro de texto.
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";//Quitar placeholder
                textBox.ForeColor = textColor;//Establecer color normal de texto
                if (textBox == txtPass)//Si el cuadro de texto es contraseña, enmascarar los caracteres.
                    textBox.UseSystemPasswordChar = true;

            }
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void Login()
        {//Iniciar sesión

            //Validar campos
            if (string.IsNullOrWhiteSpace(txtUser.Text) || txtUser.Text == usernamePlaceholder)
            {
                ShowMessage("Ingrese nombre de usuario o correo electrónico");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text == passwordPlaceholder)
            {
                ShowMessage("Ingrese contraseña");
                return;
            }
            //Fin Validar campos

            //Ejecutar el metodo de inicio de sesión del modelo de dominio.
            var userModel = new UserModel().Login(txtUser.Text, txtPass.Text);//Devuelve un objeto UserModel como resultado.
            if (userModel != null)//Si el inicio de sesión fue exitosa.
            {
                /*Nota: Esto es solamente un ejemplo de demostración, ya que si el sistema es demasiado grande, 
                 * se suele mostrar un formulario de menu principal diferente para cada area o cargo.
                 * Puedes eliminar las condicionales y mostrar un formulario único*/

                Form FormOpcion;//Definir el campo para el formulario principal.


                if (ActiveUser.Rol == Rol.Adminsitrador || ActiveUser.Rol == Rol.Operador
                    || ActiveUser.Rol == Rol.Coordinador)
                {
                    //Enviar el modelo de vista del usuario conectado, para mostrar sus datos en el formulario principal. 
                    FormOpcion = new FormOpcion(userModel);
                    AutoClosingMessageBox.Show("Bienvenido " + userModel.Nombre + " " + userModel.Apellido, "Inicio Sesion", 3000);

                }

                else
                {
                    FormOpcion = null;
                    MessageBox.Show("Usted no tiene un cargo asignado, no puede iniciar sesión.", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();//Ocultar el formualario login.
                var welcomeForm = new WelcomeForm(userModel.Nombre + " " + " " + userModel.Apellido);//Mostrar el formulario de bienvenida.
                welcomeForm.ShowDialog();

                FormOpcion.Show();//Mostrar el formulario principal.
            }
            else //Si el inicio de sesión NO fue exitosa, mostrar mensaje.
                ShowMessage("Usuario o contraseña incorrecto");

        }

        private void ShowMessage(string message)
        {
            lbErrorMessage.Text = "    " + message;
            lbErrorMessage.Visible = true;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            RemovePlaceHolder(txtUser, usernamePlaceholder);

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            RemovePlaceHolder(txtPass, passwordPlaceholder);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar la aplicación?", "Mensaje",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();//Cierra toda la aplicación finalizando todos los procesos.

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
      
  
        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                Login();//Invocar el método Iniciar sesión, si preciona enter en el cuadro de texto contraseña.
        }
        int lx, ly;
        int sw, sh;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;

        }


    }
    
}
