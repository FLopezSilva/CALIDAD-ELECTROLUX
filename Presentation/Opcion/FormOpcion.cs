using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Presentation.Helpers;

namespace Presentation.Opcion
{
    public partial class FormOpcion : Form
    {
        private DragControl dragControl;//Permite arrastrar el formulario.       


        public FormOpcion(UserModel userModel)
        {
            InitializeComponent();
            LoadUserData(userModel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            dragControl = new DragControl(panel1, this);



        }



        public void LoadUserData(UserModel userModel)
        {
            //Cargar los datos del usuario conectado en el menú lateral.
            FormEnsayo asd = new FormEnsayo();
            txtrut.Text = userModel.Rut;
        }

        public static string rut = "";


        private void button1_Click(object sender, EventArgs e)
        {
            FormEnsayo mainMenu = new FormEnsayo();
            mainMenu.txtrut.Text = txtrut.Text;
            mainMenu.Show();
            this.Hide();
            FormEnsayo.opcion = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEnsayo mainMenu = new FormEnsayo();
            mainMenu.txtrut.Text = txtrut.Text;
            mainMenu.Show();
            this.Hide();
            FormEnsayo.opcion = 0;

            //Process myProcess = new Process();

            //try
            //{
            //    myProcess.StartInfo.UseShellExecute = false;
            //    // You can start any process, HelloWorld is a do-nothing example.
            //    myProcess.StartInfo.FileName = "C:\\Presentation.exe";
            //    myProcess.StartInfo.CreateNoWindow = true;
            //    myProcess.Start();
            //    // This code assumes the process you are starting will terminate itself.
            //    // Given that is is started without a window so you cannot terminate it
            //    // on the desktop, it must terminate itself or you can do it programmatically
            //    // from this application using the Kill method.
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR");

            //}
        }

        private void FormOpcion_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormEnsayo mainMenu = new FormEnsayo();
            mainMenu.FormClosed += (s, args) => this.Show();
            this.Close();
            FormLogin ads = new FormLogin();
            ads.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿ Está seguro de cerrar la aplicación ? ", "Mensaje", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();//Cierra toda la aplicación finalizando todos los procesos.

            }
            else
            {

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de cerrar sesión ? ", "Mensaje", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                FormLogin ads = new FormLogin();
                ads.Show();
            }
            else
            {

            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
