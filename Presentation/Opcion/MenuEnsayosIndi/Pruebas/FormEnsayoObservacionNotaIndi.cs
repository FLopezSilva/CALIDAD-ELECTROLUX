using Presentation.Opcion.MenuEnsayos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Opcion.MenuEnsayosIndi.Pruebas
{
    public partial class FormEnsayoObservacionNotaIndi : Form
    {
        public FormEnsayoObservacionNotaIndi()
        {
            InitializeComponent();
        }

        public static string asd7 = "";
        public static int asd8 = 0;

        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (pictureBox1.Image == null || pictureBox2.Image == null || pictureBox3.Image == null)
            {
                MessageBox.Show("Ingrese las imagenes de la cocina");
            }
            else
            {
                try
                {
                    string query1 = "select COUNT(*) from INFORME_PRUEBA where n_planilla = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd7);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (cant1 == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();

                        comm.CommandText = "INSERT INTO informe_prueba(n_planilla,fecha_docum,observacion,nota,foto_1,foto_2,foto_3,rut_usuario) VALUES(@i1,@i2,@i3,@i4,@i5,@i6,@i7,@i8)";

                        /*Image imagen = pictureBox1.Image;*/



                        comm.Parameters.AddWithValue("@i1", asd7); //valor que debe cambiarse por un dato que sea autoincrementable
                        comm.Parameters.AddWithValue("@i2", DateTime.Now);
                        comm.Parameters.AddWithValue("@i3", richTextBox2.Text);
                        comm.Parameters.AddWithValue("@i4", richTextBox1.Text);
                        comm.Parameters.AddWithValue("@i5", System.Data.SqlDbType.Image);
                        comm.Parameters.AddWithValue("@i6", System.Data.SqlDbType.Image);
                        comm.Parameters.AddWithValue("@i7", System.Data.SqlDbType.Image);
                        comm.Parameters.AddWithValue("@i8", txtrut.Text);



                        //comm.Parameters.AddWithValue("@idrol", rutt);

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        System.IO.MemoryStream mt = new System.IO.MemoryStream();
                        System.IO.MemoryStream mu = new System.IO.MemoryStream();

                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pictureBox2.Image.Save(mt, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pictureBox3.Image.Save(mu, System.Drawing.Imaging.ImageFormat.Jpeg);

                        comm.Parameters["@i5"].Value = ms.GetBuffer();
                        comm.Parameters["@i6"].Value = mt.GetBuffer();
                        comm.Parameters["@i7"].Value = mu.GetBuffer();

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Observaciones, notas y fotos ingresados satisfactoriamente");

                        FormPrueba asd = new FormPrueba();

                        this.Close();

                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string connetionString = null;
                            connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                            SqlConnection conn = new SqlConnection(connetionString);
                            conn.Open();
                            SqlCommand comm = conn.CreateCommand();

                            comm.CommandText = "UPDATE informe_prueba SET n_planilla = @i1 ,fecha_docum = @i2 ,observacion = @i3 ,nota = @i4 ,foto_1 = @i5 ,foto_2 = @i6 ,foto_3 = @i7 ,rut_usuario = @i8 where n_planilla = @i1";

                            /*Image imagen = pictureBox1.Image;*/



                            comm.Parameters.AddWithValue("@i1", asd7); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@i2", DateTime.Now);
                            comm.Parameters.AddWithValue("@i3", richTextBox2.Text);
                            comm.Parameters.AddWithValue("@i4", richTextBox1.Text);
                            comm.Parameters.AddWithValue("@i5", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i6", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i7", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i8", txtrut.Text);



                            //comm.Parameters.AddWithValue("@idrol", rutt);

                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            System.IO.MemoryStream mt = new System.IO.MemoryStream();
                            System.IO.MemoryStream mu = new System.IO.MemoryStream();

                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pictureBox2.Image.Save(mt, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pictureBox3.Image.Save(mu, System.Drawing.Imaging.ImageFormat.Jpeg);

                            comm.Parameters["@i5"].Value = ms.GetBuffer();
                            comm.Parameters["@i6"].Value = mt.GetBuffer();
                            comm.Parameters["@i7"].Value = mu.GetBuffer();

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Datos Observaciones, notas y fotos actualizados satisfactoriamente");

                            FormPrueba asd = new FormPrueba();

                            this.Close();

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }

            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // pictureBox1.Image = Obt();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void txtrut_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonFoto3_Click(object sender, EventArgs e)
        {
            //llevar las fotos a la BD (la tercera foto)

            String imagen3 = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    imagen3 = dialog.FileName;

                    pictureBox3.ImageLocation = imagen3;

                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "");
            }
        }

        private void buttonFoto2_Click(object sender, EventArgs e)
        {
            //llevar las fotos a la BD (la segunda foto)

            String imagen2 = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    imagen2 = dialog.FileName;

                    pictureBox2.ImageLocation = imagen2;

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "");
            }
        }

        private void buttonFoto1_Click(object sender, EventArgs e)
        {
            //llevar las fotos a la BD (la primera foto)

            String imagen1 = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    imagen1 = dialog.FileName;

                    pictureBox1.ImageLocation = imagen1;

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormEnsayoObservacionNotaIndi_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
