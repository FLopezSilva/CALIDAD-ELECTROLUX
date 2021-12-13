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
    public partial class FormCondicionEnsayoIndi : Form
    {
        public FormCondicionEnsayoIndi()
        {
            //trae el dato tipo de gas 
            InitializeComponent();
            Fillcombo();
            cmbGasReferencia.Text = "Seleccionar";

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (cmbGasReferencia.Text == "" || txtPresiongas.Text == "" || txtCalorifico.Text == "" || numericHumedad.Value == 0 || numericTemperatura.Value == 0)
            {
                MessageBox.Show("Ingrese los datos correspondientes");
                cmbGasReferencia.Focus();
            }
            else
            {


                try
                {
                    string connetionString = null;
                    connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                    SqlConnection conn = new SqlConnection(connetionString);
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO condicion_ensayo(presion_gas,poder_calorifico,humed_relativa,temp_ambiente,cod_cocina,id_gas) VALUES(@miau2, @miau3,@miau4,@miau5,@miau6,@miau7)";

                    comm.Parameters.AddWithValue("@miau2", txtPresiongas.Text);
                    comm.Parameters.AddWithValue("@miau3", txtCalorifico.Text);
                    comm.Parameters.AddWithValue("@miau4", numericHumedad.Value);
                    comm.Parameters.AddWithValue("@miau5", numericTemperatura.Value);
                    comm.Parameters.AddWithValue("@miau6", txtCodCocina.Text);
                    comm.Parameters.AddWithValue("@miau7", cmbGasReferencia.SelectedValue);

                    comm.ExecuteNonQuery();
                    conn.Close();

                    var w = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(3))
                           .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                    MessageBox.Show("Condicion de ensayo registrada satisfactoriamente");



                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }


            }


        }
        public void Fillcombo()
        {

            DataTable dt = new DataTable();
            string constring = "Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$";
            using (SqlConnection cnn = new SqlConnection(constring))
            {
                cnn.Open();

                //selecciona el tipo de gas de la BD
                string query = "select * from tipo_gas";
                SqlCommand cmd = new SqlCommand(query, cnn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            //
            cmbGasReferencia.ValueMember = "id_gas";
            cmbGasReferencia.DisplayMember = "nombre_gas";
            cmbGasReferencia.DataSource = dt;

            cmbGasReferencia.SelectedIndex = 0;
            this.cmbGasReferencia.DropDownStyle = ComboBoxStyle.DropDownList;



        }

        private void txtPresiongas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtCalorifico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        public bool terminar = false;

        private void btnTerminar_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (cmbGasReferencia.Text == "" || txtPresiongas.Text == "" || txtCalorifico.Text == "" || numericHumedad.Value == 0 || numericTemperatura.Value == 0)
            {
                MessageBox.Show("Ingrese los datos correspondientes");
                cmbGasReferencia.Focus();
            }
            else
            {


                try
                {

                    string query = "select COUNT(*) from condicion_ensayo where cod_cocina = @id;";

                    SqlCommand cmd2 = new SqlCommand(query, con);
                    cmd2.Parameters.AddWithValue("@id", txtCodCocina.Text);

                    int cant = Convert.ToInt32(cmd2.ExecuteScalar());


                    if (cant == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "INSERT INTO condicion_ensayo(presion_gas,poder_calorifico,humed_relativa,temp_ambiente,cod_cocina,id_gas) VALUES(@miau2, @miau3,@miau4,@miau5,@miau6,@miau7)";

                        comm.Parameters.AddWithValue("@miau2", txtPresiongas.Text);
                        comm.Parameters.AddWithValue("@miau3", txtCalorifico.Text);
                        comm.Parameters.AddWithValue("@miau4", numericHumedad.Value);
                        comm.Parameters.AddWithValue("@miau5", numericTemperatura.Value);
                        comm.Parameters.AddWithValue("@miau6", txtCodCocina.Text);
                        comm.Parameters.AddWithValue("@miau7", cmbGasReferencia.SelectedValue);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Condicion de ensayo registrada satisfactoriamente");

                        FormPruebaIndi asd = new FormPruebaIndi();

                        this.Close();

                        asd.btnManuales.Enabled = true;
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
                            comm.CommandText = "update condicion_ensayo set presion_gas = @miau2,poder_calorifico = @miau3,humed_relativa = @miau4,temp_ambiente = @miau5,cod_cocina = @miau6,id_gas = @miau7 where cod_Cocina = @miau6";

                            comm.Parameters.AddWithValue("@miau2", Convert.ToSingle(txtPresiongas.Text));
                            comm.Parameters.AddWithValue("@miau3", txtCalorifico.Text);
                            comm.Parameters.AddWithValue("@miau4", numericHumedad.Value);
                            comm.Parameters.AddWithValue("@miau5", numericTemperatura.Value);
                            comm.Parameters.AddWithValue("@miau6", txtCodCocina.Text);
                            comm.Parameters.AddWithValue("@miau7", cmbGasReferencia.SelectedValue);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Condicion de ensayo actualizada satisfactoriamente");

                            FormPruebaIndi asd = new FormPruebaIndi();

                            this.Close();

                            asd.btnManuales.Enabled = true;
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

        private void txtCalorifico_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCalorifico_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtPresiongas_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)
|| e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
        }

        private void FormCondicionEnsayoIndi_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
