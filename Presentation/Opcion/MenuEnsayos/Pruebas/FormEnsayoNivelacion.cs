using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Opcion.MenuEnsayos;

namespace Presentation.Opcion.MenuEnsayos.Pruebas
{
    public partial class FormEnsayoNivelacion : Form
    {
        string tiem_inicio = DateTime.Now.ToString("HH:mm:ss");

        public FormEnsayoNivelacion()
        {
            InitializeComponent();
                        
        }

        public static string asd2 = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        //ingreso de nivelación de puerta sin peso 
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        //ingreso de nivelación de puerta con peso
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //cambiar el valor dependiendo de la normativa de nivelación con peso o sin peso 
        //(este valor debe cambiarse por un select que tome el valor correspondiente de las tablas metricas)
        public bool nivelac(){
             

            int sinPeso = Convert.ToInt32(numericNivSPeso.Value);
            int conPeso = Convert.ToInt32(numericNivCPeso.Value);

            if (sinPeso < 0 || conPeso < 0) {

                MessageBox.Show("Error, no puede ingresarse grados y milimetros negativos en la prueba de nivelación");

                return false;
            }

            else {

                if (sinPeso > 5 && conPeso < 15) {

                    return false;

                } else {

                    return true;
                }

            }                              
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (numericNivCPeso.Value == 0 || numericNivSPeso.Value == 0)
            {
                MessageBox.Show("Ingrese los datos correspondientes");
            }
            else
            {
                try
                {
                    string query1 = "select COUNT(*) from ensayo_nivelac where id_nivelac = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd2);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    string query2 = "select COUNT(*) from ensayo_resist where id_resist = @id;";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@id", asd2);
                    int cant2 = Convert.ToInt32(cmd2.ExecuteScalar());

                    string query3 = "select COUNT(*) from ensayo_trabam where id_trab = @id;";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@id", asd2);
                    int cant3 = Convert.ToInt32(cmd3.ExecuteScalar());

                    string query4 = "select COUNT(*) from ENSAYO_BASCUL where id_basc = @id;";
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    cmd4.Parameters.AddWithValue("@id", asd2);
                    int cant4 = Convert.ToInt32(cmd4.ExecuteScalar());

                    if (cant1 == 0 && cant2 == 0 && cant3 == 0 && cant4 == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();

                        comm.CommandText = "INSERT INTO ensayo_nivelac(id_nivelac,niv_puerta_sp,niv_puerta_cp,cumple_nivelam,fecha_nivelac,hora_inicio_n,hora_termino_n) VALUES(@niv7,@niv1, @niv2, @niv3, @niv4, @niv5, @niv6)";

                        comm.Parameters.AddWithValue("@niv7", asd2);
                        comm.Parameters.AddWithValue("@niv1", numericNivSPeso.Value); //valor que debe cambiarse por un dato que sea autoincrementable
                        comm.Parameters.AddWithValue("@niv2", numericNivCPeso.Value);
                        comm.Parameters.AddWithValue("@niv3", nivelac());
                        comm.Parameters.AddWithValue("@niv4", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@niv5", tiem_inicio);
                        comm.Parameters.AddWithValue("@niv6", DateTime.Now.ToString("HH:mm:ss"));

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());


                        conn.Open();

                        comm.CommandText = "INSERT INTO ensayo_resist(id_resist,resist_puerta,cumple_resis,fecha_resis,hora_inicio_res,hora_termino_res) VALUES(@resis1, @resis2, @resis3,@resis4,@resis5,@resis6)";


                        comm.Parameters.AddWithValue("@resis1", asd2);
                        comm.Parameters.AddWithValue("@resis2", numericResistencia.Value);
                        bool resistencia;
                        if (numericResistencia.Value >= 40)
                        {
                            resistencia = true;
                        }
                        else
                        {
                            resistencia = false;
                        }
                        comm.Parameters.AddWithValue("@resis3", resistencia); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@resis4", DateTime.Now);
                        comm.Parameters.AddWithValue("@resis5", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                        comm.Parameters.AddWithValue("@resis6", tiempoResist());

                        comm.ExecuteNonQuery();
                        conn.Close();


                        //ensayo de trabamiento de puerta  
                        conn.Open();
                        comm.CommandText = "INSERT INTO ensayo_trabam(id_trab,cumple_trab,fecha_trab,hora_inicio_tr,hora_termino_tr) VALUES(@trab1,@trab2, @trab3, @trab4, @trab5)";
                        bool trabamiento = true;
                        if (checkBox3.Checked)
                        {
                            trabamiento = true;
                        }
                        else if (checkBox4.Checked)
                        {
                            trabamiento = false;
                        }
                        comm.Parameters.AddWithValue("@trab1", asd2);
                        comm.Parameters.AddWithValue("@trab2", trabamiento); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@trab3", DateTime.Now);
                        comm.Parameters.AddWithValue("@trab4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                        comm.Parameters.AddWithValue("@trab5", tiempoTrab());

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //ensayo de basculamiento
                        conn.Open();
                        comm.CommandText = "INSERT INTO ENSAYO_BASCUL (id_basc,cumple_basc,fecha_bas,hora_inicio_b,hora_termino_b) VALUES(@bas1,@bas2, @bas3, @bas4, @bas5)";

                        comm.Parameters.AddWithValue("@bas1", asd2);

                        bool basculamiento = true;

                        if (checkBox1.Checked)
                        {
                            basculamiento = false;
                        }
                        else if (checkBox2.Checked)
                        {
                            basculamiento = true;
                        }

                        comm.Parameters.AddWithValue("@bas2", basculamiento);
                        comm.Parameters.AddWithValue("@bas3", DateTime.Now);
                        comm.Parameters.AddWithValue("@bas4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                        comm.Parameters.AddWithValue("@bas5", tiempoBascul());

                        comm.ExecuteNonQuery();
                        conn.Close();

                        this.Close();

                        MessageBox.Show("Ensayo de nivelación de puerta registrado satisfactoriamente");

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

                            comm.CommandText = "update ensayo_nivelac set id_nivelac = @niv7 ,niv_puerta_sp = @niv1 ,niv_puerta_cp = @niv2,cumple_nivelam = @niv3 ,fecha_nivelac = @niv4,hora_inicio_n = @niv5,hora_termino_n = @niv6  where id_nivelac = @niv7";

                            comm.Parameters.AddWithValue("@niv7", asd2);
                            comm.Parameters.AddWithValue("@niv1", numericNivSPeso.Value); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@niv2", numericNivCPeso.Value);
                            comm.Parameters.AddWithValue("@niv3", nivelac());
                            comm.Parameters.AddWithValue("@niv4", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@niv5", tiem_inicio);
                            comm.Parameters.AddWithValue("@niv6", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());


                            conn.Open();

                            comm.CommandText = "update ensayo_resist set id_resist = @resis1 ,resist_puerta = @resis2 ,cumple_resis = @resis3 ,fecha_resis = @resis4 ,hora_inicio_res = @resis5 ,hora_termino_res = @resis6  where id_resist = @resis1";


                            comm.Parameters.AddWithValue("@resis1", asd2);
                            comm.Parameters.AddWithValue("@resis2", numericResistencia.Value);
                            bool resistencia;
                            if (numericResistencia.Value >= 40)
                            {
                                resistencia = true;
                            }
                            else
                            {
                                resistencia = false;
                            }
                            comm.Parameters.AddWithValue("@resis3", resistencia); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@resis4", DateTime.Now);
                            comm.Parameters.AddWithValue("@resis5", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@resis6", tiempoResist());

                            comm.ExecuteNonQuery();
                            conn.Close();


                            //ensayo de trabamiento de puerta  
                            conn.Open();
                            comm.CommandText = "update ensayo_trabam set id_trab = @trab1 ,cumple_trab = @trab2 ,fecha_trab = @trab3 ,hora_inicio_tr = @trab4,hora_termino_tr = @trab5  where id_trab = @trab1";
                            bool trabamiento = true;
                            if (checkBox3.Checked)
                            {
                                trabamiento = true;
                            }
                            else if (checkBox4.Checked)
                            {
                                trabamiento = false;
                            }
                            comm.Parameters.AddWithValue("@trab1", asd2);
                            comm.Parameters.AddWithValue("@trab2", trabamiento); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@trab3", DateTime.Now);
                            comm.Parameters.AddWithValue("@trab4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@trab5", tiempoTrab());

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //ensayo de basculamiento
                            conn.Open();
                            comm.CommandText = "update ENSAYO_BASCUL set id_basc = @bas1 ,cumple_basc = @bas2 ,fecha_bas = @bas3 ,hora_inicio_b = @bas4 ,hora_termino_b = @bas5 where id_basc = @bas1";

                            comm.Parameters.AddWithValue("@bas1", asd2);

                            bool basculamiento = true;

                            if (checkBox1.Checked)
                            {
                                basculamiento = false;
                            }
                            else if (checkBox2.Checked)
                            {
                                basculamiento = true;
                            }

                            comm.Parameters.AddWithValue("@bas2", basculamiento);
                            comm.Parameters.AddWithValue("@bas3", DateTime.Now);
                            comm.Parameters.AddWithValue("@bas4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@bas5", tiempoBascul());

                            comm.ExecuteNonQuery();
                            conn.Close();

                            this.Close();

                            MessageBox.Show("Ensayos de nivelación de puerta actualizados satisfactoriamente");



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
        public string tiempoBascul()
        {

            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {

                string terminoBascul = DateTime.Now.ToString("HH:mm:ss");

                return terminoBascul;

            }
            else
            {

                return null;

            }

        }
        public string tiempoTrab()
        {

            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {
                string terminoTrab = DateTime.Now.ToString("HH:mm:ss");

                return terminoTrab;
            }
            else
            {
                return null;
            }

        }

        public string tiempoResist()
        {

            if ((numericResistencia.Value != 0 && numericResistencia.Value > 0))
            {
                string terminoResis = DateTime.Now.ToString("HH:mm:ss");

                return terminoResis;
            }
            else
            {
                return null;
            }

        }


        private void FormEnsayoNivelacion_Load(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox4.Checked = false;
            }
            else
            {

                checkBox4.Checked = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Checked = false;
            }
            else
            {

                checkBox3.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
            else
            {

                checkBox1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else
            {

                checkBox2.Checked = true;
            }
        }

        private void FormEnsayoNivelacion_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }

