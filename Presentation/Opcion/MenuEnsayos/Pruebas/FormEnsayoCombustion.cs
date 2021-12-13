using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Presentation.Opcion.MenuEnsayos.Pruebas
{
    public partial class FormEnsayoCombustion : Form
    {
        string inicio = DateTime.Now.ToString("HH:mm:ss");
        float z = Convert.ToSingle(0.15);
        float x = Convert.ToSingle(0.1);

        public FormEnsayoCombustion()
        {
            InitializeComponent();
        }

        public static string asd4 = "";
        private void FormEnsayoCombustion_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCo4_TextChanged(object sender, EventArgs e)
        {

        }

        /*-------------------Generación de metodos booleanos -----------------*/


        /*------Metodos de validación individual de combustion----*/
        public bool com1()
        {

            if (textBox1.Text == "0")
            {

                bool resultado = false;


                return resultado;
            }
            else
            {
                float valor1 = Convert.ToSingle(textBox1.Text);

                bool resultado = (valor1 >= x) ? false : true;

                return resultado;
            }

        }

        public bool com2()
        {
            if (textBox17.Text == "0")
            {
                bool resultado = false;

                return resultado;
            }
            else
            {
                float valor2 = Convert.ToSingle(textBox17.Text);

                bool resultado = (valor2 > z) ? false : true;

                return resultado;
            }


        }

        public bool com3()
        {
            if (textBox3.Text == "0")
            {
                bool resultado = false;

                return resultado;
            }
            else
            {
                float valor3 = Convert.ToSingle(textBox3.Text);

                bool resultado = (valor3 > x) ? false : true;

                return resultado;
            }

        }

        public bool com4()
        {
            if (textBox4.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor4 = Convert.ToSingle(textBox4.Text);

                bool resultado = (valor4 > z) ? false : true;

                return resultado;
            }

        }

        public bool com5()
        {
            if (textBox5.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor5 = Convert.ToSingle(textBox5.Text);

                bool resultado = (valor5 > x) ? false : true;

                return resultado;
            }

        }


        public bool com6()
        {
            if (textBox6.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor6 = Convert.ToSingle(textBox6.Text);

                bool resultado = (valor6 > z) ? false : true;

                return resultado;
            }

        }

        public bool com7()
        {
            if (textBox7.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor7 = Convert.ToSingle(textBox7.Text);

                bool resultado = (valor7 > x) ? false : true;

                return resultado;
            }

        }

        public bool com8()
        {
            if (textBox8.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor8 = Convert.ToSingle(textBox8.Text);

                bool resultado = (valor8 > z) ? false : true;

                return resultado;
            }

        }

        public bool com9()
        {
            if (textBox9.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor9 = Convert.ToSingle(textBox9.Text);

                bool resultado = (valor9 >= x) ? false : true;

                return resultado;
            }
        }

        public bool com10()
        {
            if (textBox10.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor10 = Convert.ToSingle(textBox10.Text);

                bool resultado = (valor10 > z) ? false : true;

                return resultado;
            }

        }

        public bool com11()
        {
            if (textBox11.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor11 = Convert.ToSingle(textBox11.Text);

                bool resultado = (valor11 > x) ? false : true;

                return resultado;
            }

        }

        public bool com12()
        {
            if (textBox12.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor12 = Convert.ToSingle(textBox12.Text);

                bool resultado = (valor12 > z) ? false : true;

                return resultado;
            }

        }

        public bool com13()
        {
            if (textBox13.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor13 = Convert.ToSingle(textBox13.Text);

                bool resultado = (valor13 > x) ? false : true;

                return resultado;
            }

        }

        public bool com14()
        {
            if (textBox14.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor14 = Convert.ToSingle(textBox14.Text);

                bool resultado = (valor14 > z) ? false : true;

                return resultado;
            }

        }

        public bool com15()
        {
            if (textBox15.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor15 = Convert.ToSingle(textBox15.Text);

                bool resultado = (valor15 > x) ? false : true;

                return resultado;
            }

        }

        public bool com16()
        {
            if (textBox16.Text == "0")
            {
                bool resultado = false;
                return resultado;
            }
            else
            {
                float valor16 = Convert.ToSingle(textBox16.Text);

                bool resultado = (valor16 > x) ? false : true;

                return resultado;
            }

        }

        /* ------Metodo de validacion completa de prueba combustion-------*/


        public bool combust()
        {
            
            bool r1 = (com1() == false || com2() == false || com3() == false || com4() == false);
            bool r2 = (com5() == false || com6() == false || com7() == false || com8() == false);
            bool r3 = (com9() == false || com10() == false || com11() == false || com12() == false);
            bool r4 = (com13() == false || com14() == false || com15() == false || com16() == false);
                               

            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false ) ? false : true;

            if (resultado == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        /* --------------- Calculos de combustión -----------------*/


        private void textBoxCo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            else
            {
                
            }
        }



        private void textBoxCo_2_Leave(object sender, EventArgs e)
        {
            if (textBoxCo.Text != "0" && textBoxCo_2.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox1.Text = total_1.ToString();
            }
            else
            {
                textBox1.Text = "0";

            }
        }


        private void textBoxCo_2_2_Leave(object sender, EventArgs e)
        {
            if (textBoxCo2.Text != "0" && textBoxCo_2_2.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo2.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_2.Text);


                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox17.Text = total_1.ToString();

            }
            else
            {
                textBox17.Text = "0";

            }

        }

        private void textBoxCo_2_3_Leave(object sender, EventArgs e)
        {
            if (textBoxCo3.Text != "0" && textBoxCo_2_3.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo3.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_3.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox3.Text = total_1.ToString();
            }
            else
            {
                textBox3.Text = "0";

            }
        }

        private void textBoxCo_2_4_Leave(object sender, EventArgs e)
        {
            if (textBoxCo4.Text != "0" && textBoxCo_2_4.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo4.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_4.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox4.Text = total_1.ToString();
            }
            else
            {
                textBox4.Text = "0";

            }
        }

        private void textBoxCo_2_5_Leave(object sender, EventArgs e)
        {
            if (textBoxCo5.Text != "0" && textBoxCo_2_5.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo5.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_5.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox5.Text = total_1.ToString();
            }
            else
            {
                textBox5.Text = "0";

            }
        }

        private void textBoxCo_2_6_Leave(object sender, EventArgs e)
        {
            if (textBoxCo6.Text != "0" && textBoxCo_2_6.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo6.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_6.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox6.Text = total_1.ToString();
            }
            else
            {
                textBox6.Text = "0";

            }
        }

        private void textBoxCo_2_7_Leave(object sender, EventArgs e)
        {
            if (textBoxCo7.Text != "0" && textBoxCo_2_7.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo7.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_7.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox7.Text = total_1.ToString();
            }
            else
            {
                textBox7.Text = "0";
            }
        }

        private void textBoxCo_2_8_Leave(object sender, EventArgs e)
        {
            if (textBoxCo8.Text != "0" && textBoxCo_2_8.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo8.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_8.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox8.Text = total_1.ToString();
            }
            else
            {
                textBox8.Text = "0";
            }
        }



        private void textBoxCo_2_9_Leave(object sender, EventArgs e)
        {

            if (textBoxCo9.Text != "0" && textBoxCo_2_9.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo9.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_9.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox9.Text = total_1.ToString();
            }
            else if (textBoxCo9.Text == "0" && textBoxCo_2_9.Text == "0")
            {
                textBox9.Text = "0";
            }
        }

        private void textBoxCo_2_10_Leave(object sender, EventArgs e)
        {

            if (textBoxCo10.Text != "0" && textBoxCo_2_10.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo10.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_10.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox10.Text = total_1.ToString();
            }
            else if (textBoxCo10.Text == "0" && textBoxCo_2_10.Text == "0")
            {
                textBox10.Text = "0";
            }
        }

        private void textBoxCo_2_11_Leave(object sender, EventArgs e)
        {

            if (textBoxCo11.Text != "0" && textBoxCo_2_11.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo11.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_11.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox11.Text = total_1.ToString();
            }
            else if (textBoxCo11.Text == "0" && textBoxCo_2_11.Text == "0")
            {
                textBox11.Text = "0";
            }
        }

        private void textBoxCo_2_12_Leave(object sender, EventArgs e)
        {

            if (textBoxCo12.Text != "0" || textBoxCo_2_12.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo12.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_12.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox12.Text = total_1.ToString();
            }
            else if (textBoxCo12.Text == "0" && textBoxCo_2_12.Text == "0")
            {
                textBox12.Text = "0";
            }
        }

        private void textBoxCo_2_13_Leave(object sender, EventArgs e)
        {

            if (textBoxCo13.Text != "0" && textBoxCo_2_13.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo13.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_13.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox13.Text = total_1.ToString();
            }
            else if (textBoxCo13.Text == "0" && textBoxCo_2_13.Text == "0")
            {
                textBox13.Text = "0";
            }
        }

        private void textBoxCo_2_14_Leave(object sender, EventArgs e)
        {

            if (textBoxCo14.Text != "0" && textBoxCo_2_14.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo14.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_14.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox14.Text = total_1.ToString();
            }
            else if (textBoxCo14.Text == "0" && textBoxCo_2_14.Text == "0")

            {
                textBox14.Text = "0";
            }
        }

        private void textBoxCo_2_15_Leave(object sender, EventArgs e)
        {

            if (textBoxCo15.Text != "0" && textBoxCo_2_15.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo15.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_15.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox15.Text = total_1.ToString();
            }
            else if (textBoxCo15.Text == "0" && textBoxCo_2_15.Text == "0")
            {
                textBox15.Text = "0";
            }
        }

        private void textBoxCo_2_16_Leave(object sender, EventArgs e)
        {

            if (textBoxCo16.Text != "0" && textBoxCo_2_16.Text != "0")
            {

                float co1 = Convert.ToSingle(textBoxCo16.Text);
                float co2_1 = Convert.ToSingle(textBoxCo_2_16.Text);

                double total1 = (co1 / co2_1) * 14 * 0.0001;
                float t = Convert.ToSingle(total1);

                double total_1 = (Math.Truncate(t * 10000)) / 10000;
                textBox16.Text = total_1.ToString();
            }
            else if (textBoxCo16.Text == "0" && textBoxCo_2_16.Text == "0")

            {
                textBox16.Text = "0";
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCo_TextChanged(object sender, EventArgs e)
        {

        }
   
        /*------------Creación de if enorme-------------*/

        public bool consulta1()
        {
            string a1 = textBox1.Text;
            string a2 = textBox17.Text;
            string a3 = textBox3.Text;
            string a4 = textBox4.Text;
            string a5 = textBox5.Text;
            string a6 = textBox6.Text;
            string a7 = textBox7.Text;
            string a8 = textBox8.Text;
            string a9 = textBox9.Text;
            string a10 = textBox10.Text;
            string a11 = textBox11.Text;
            string a12 = textBox12.Text;
            string a13 = textBox13.Text;
            string a14 = textBox14.Text;
            string a15 = textBox15.Text;
            string a16 = textBox16.Text;

            string b = "";

            bool r1 = (a1.Equals(b) || a2.Equals(b) || a3.Equals(b) || a4.Equals(b)) ? false : true;
            bool r2 = (a5.Equals(b) || a6.Equals(b) || a7.Equals(b) || a8.Equals(b)) ? false : true;
            bool r3 = (a9.Equals(b) || a10.Equals(b) || a11.Equals(b) || a12.Equals(b)) ? false : true;
            bool r4 = (a13.Equals(b) || a14.Equals(b) || a15.Equals(b) || a16.Equals(b)) ? false : true;

            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false) ? false : true;

            return resultado;
        }

        public bool consulta2()
        {
            string a1 = textBoxCo.Text;
            string a2 = textBoxCo2.Text;
            string a3 = textBoxCo3.Text;
            string a4 = textBoxCo4.Text;
            string a5 = textBoxCo5.Text;
            string a6 = textBoxCo6.Text;
            string a7 = textBoxCo7.Text;
            string a8 = textBoxCo8.Text;
            string a9 = textBoxCo9.Text;
            string a10 = textBoxCo10.Text;
            string a11 = textBoxCo11.Text;
            string a12 = textBoxCo12.Text;
            string a13 = textBoxCo13.Text;
            string a14 = textBoxCo14.Text;
            string a15 = textBoxCo15.Text;
            string a16 = textBoxCo16.Text;

            string b = "";

            bool r1 = (a1.Equals(b) || a2.Equals(b) || a3.Equals(b) || a4.Equals(b)) ? false : true;
            bool r2 = (a5.Equals(b) || a6.Equals(b) || a7.Equals(b) || a8.Equals(b)) ? false : true;
            bool r3 = (a9.Equals(b) || a10.Equals(b) || a11.Equals(b) || a12.Equals(b)) ? false : true;
            bool r4 = (a13.Equals(b) || a14.Equals(b) || a15.Equals(b) || a16.Equals(b)) ? false : true;

            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false) ? false : true;

            return resultado;
        }


        public bool consulta3()
        {
            string a1 = textBoxCo_2.Text;
            string a2 = textBoxCo_2_2.Text;
            string a3 = textBoxCo_2_3.Text;
            string a4 = textBoxCo_2_4.Text;
            string a5 = textBoxCo_2_5.Text;
            string a6 = textBoxCo_2_6.Text;
            string a7 = textBoxCo_2_7.Text;
            string a8 = textBoxCo_2_8.Text;
            string a9 = textBoxCo_2_9.Text;
            string a10 = textBoxCo_2_10.Text;
            string a11 = textBoxCo_2_11.Text;
            string a12 = textBoxCo_2_12.Text;
            string a13 = textBoxCo_2_13.Text;
            string a14 = textBoxCo_2_14.Text;
            string a15 = textBoxCo_2_15.Text;
            string a16 = textBoxCo_2_16.Text;

            string b = "";

            bool r1 = (a1.Equals(b) || a2.Equals(b) || a3.Equals(b) || a4.Equals(b)) ? false : true;
            bool r2 = (a5.Equals(b) || a6.Equals(b) || a7.Equals(b) || a8.Equals(b)) ? false : true;
            bool r3 = (a9.Equals(b) || a10.Equals(b) || a11.Equals(b) || a12.Equals(b)) ? false : true;
            bool r4 = (a13.Equals(b) || a14.Equals(b) || a15.Equals(b) || a16.Equals(b)) ? false : true;

            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false) ? false : true;

            return resultado;
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese los datos correspondientes");
            }
            else
            {
                try
                {

                    string query1 = "select COUNT(*) from ENSAYO_COMB where id_combu = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd4);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    if (cant1 == 0)
                    {
                        string a = "Consumo Total";
                        string b = "Consumo medio (1/2)";

                        string q = "Quemador";

                        string[] quem = { q+" Trasero Derecho", q+" Trasero Izquierdo", q+" Delantero Izquierdo",
                                     q+" Delantero Derecho", q+" Central Delantero", q+" Central Trasero",
                                     q+" Central", "Horno", "Todos los "+q+"es" };


                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";


                        SqlConnection cann = new SqlConnection(connetionString);
                        SqlCommand camm = cann.CreateCommand();

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from ENSAYO_COMB where id_combu = @comb1) INSERT INTO ENSAYO_COMB (id_combu,cumple_comb,fecha_ec,hora_inicio_c,hora_termino_c) VALUES(@comb1,@comb2,@comb3,@comb4,@comb5) else update ENSAYO_COMB set id_combu = @comb1, cumple_comb = @comb2, fecha_ec = @comb3 , hora_inicio_c = @comb4 , hora_termino_c = @comb5 where id_combu = @comb1";

                        camm.Parameters.AddWithValue("@comb1", asd4); //valor que debe cambiarse por un dato que sea autoincrementable

                        camm.Parameters.AddWithValue("@comb2", combust()); // cambiar
                        camm.Parameters.AddWithValue("@comb3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                        camm.Parameters.AddWithValue("@comb4", inicio);
                        camm.Parameters.AddWithValue("@comb5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);


                        camm.ExecuteNonQuery();
                        cann.Close();


                        // 1

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c2,@c3,@c4,@c5,@c6,@c7,@c8) else update COMBU set nom_quemador = @c2, nom_posicion = @c3, co = @c4, co_2 = @c5, co_n = @c6, cumple_comb = @c7, id_combu = @c8 where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8";

                        camm.Parameters.AddWithValue("@c2", quem[0]);
                        camm.Parameters.AddWithValue("@c3", a);
                        camm.Parameters.AddWithValue("@c4", Convert.ToSingle(textBoxCo.Text));
                        camm.Parameters.AddWithValue("@c5", Convert.ToSingle(textBoxCo_2.Text));
                        camm.Parameters.AddWithValue("@c6", Convert.ToSingle(textBox1.Text));
                        camm.Parameters.AddWithValue("@c7", com1());
                        camm.Parameters.AddWithValue("@c8", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        cann.Open();

                        //2
                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c10,@c11,@c12,@c13,@c14,@c15,@c16) else update COMBU set nom_quemador = @c10, nom_posicion = @c11, co = @c12, co_2 = @c13, co_n = @c14, cumple_comb = @c15, id_combu = @c16 where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16";

                        camm.Parameters.AddWithValue("@c10", quem[0]);
                        camm.Parameters.AddWithValue("@c11", b);
                        camm.Parameters.AddWithValue("@c12", Convert.ToSingle(textBoxCo2.Text));
                        camm.Parameters.AddWithValue("@c13", Convert.ToSingle(textBoxCo_2_2.Text));
                        camm.Parameters.AddWithValue("@c14", Convert.ToSingle(textBox17.Text));
                        camm.Parameters.AddWithValue("@c15", com2());
                        camm.Parameters.AddWithValue("@c16", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //3
                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c18,@c19,@c20,@c21,@c22,@c23,@c24) else update COMBU set nom_quemador = @c18, nom_posicion = @c19, co = @c20, co_2 = @c21, co_n = @c22, cumple_comb = @c23, id_combu = @c24 where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24";

                        camm.Parameters.AddWithValue("@c18", quem[1]);
                        camm.Parameters.AddWithValue("@c19", a);
                        camm.Parameters.AddWithValue("@c20", Convert.ToSingle(textBoxCo3.Text));
                        camm.Parameters.AddWithValue("@c21", Convert.ToSingle(textBoxCo_2_3.Text));
                        camm.Parameters.AddWithValue("@c22", Convert.ToSingle(textBox3.Text));
                        camm.Parameters.AddWithValue("@c23", com3());
                        camm.Parameters.AddWithValue("@c24", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //4

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c26,@c27,@c28,@c29,@c30,@c31,@c32) else update COMBU set nom_quemador = @c26, nom_posicion = @c27, co = @c28, co_2 = @c29, co_n = @c30, cumple_comb = @c31, id_combu = @c32 where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32";

                        camm.Parameters.AddWithValue("@c26", quem[1]);
                        camm.Parameters.AddWithValue("@c27", b);
                        camm.Parameters.AddWithValue("@c28", Convert.ToSingle(textBoxCo4.Text));
                        camm.Parameters.AddWithValue("@c29", Convert.ToSingle(textBoxCo_2_4.Text));
                        camm.Parameters.AddWithValue("@c30", Convert.ToSingle(textBox4.Text));
                        camm.Parameters.AddWithValue("@c31", com4());
                        camm.Parameters.AddWithValue("@c32", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //5

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c34,@c35,@c36,@c37,@c38,@c39,@c40) else update COMBU set nom_quemador = @c34, nom_posicion = @c35, co = @c36, co_2 = @c37, co_n = @c38, cumple_comb = @c39, id_combu = @c40 where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40";

                        camm.Parameters.AddWithValue("@c34", quem[2]);
                        camm.Parameters.AddWithValue("@c35", a);
                        camm.Parameters.AddWithValue("@c36", Convert.ToSingle(textBoxCo5.Text));
                        camm.Parameters.AddWithValue("@c37", Convert.ToSingle(textBoxCo_2_5.Text));
                        camm.Parameters.AddWithValue("@c38", Convert.ToSingle(textBox5.Text));
                        camm.Parameters.AddWithValue("@c39", com5());
                        camm.Parameters.AddWithValue("@c40", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //6

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c42,@c43,@c44,@c45,@c46,@c47,@c48) else update COMBU set nom_quemador = @c42, nom_posicion = @c43, co = @c44, co_2 = @c45, co_n = @c46, cumple_comb = @c47, id_combu = @c48 where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48";

                        camm.Parameters.AddWithValue("@c42", quem[2]);
                        camm.Parameters.AddWithValue("@c43", b);
                        camm.Parameters.AddWithValue("@c44", Convert.ToSingle(textBoxCo6.Text));
                        camm.Parameters.AddWithValue("@c45", Convert.ToSingle(textBoxCo_2_6.Text));
                        camm.Parameters.AddWithValue("@c46", Convert.ToSingle(textBox6.Text));
                        camm.Parameters.AddWithValue("@c47", com6());
                        camm.Parameters.AddWithValue("@c48", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //7

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c50,@c51,@c52,@c53,@c54,@c55,@c56) else update COMBU set nom_quemador = @c50, nom_posicion = @c51, co = @c52, co_2 = @c53, co_n = @c54, cumple_comb = @c55, id_combu = @c56 where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56";

                        camm.Parameters.AddWithValue("@c50", quem[3]);
                        camm.Parameters.AddWithValue("@c51", a);
                        camm.Parameters.AddWithValue("@c52", Convert.ToSingle(textBoxCo7.Text));
                        camm.Parameters.AddWithValue("@c53", Convert.ToSingle(textBoxCo_2_7.Text));
                        camm.Parameters.AddWithValue("@c54", Convert.ToSingle(textBox7.Text));
                        camm.Parameters.AddWithValue("@c55", com7());
                        camm.Parameters.AddWithValue("@c56", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //8

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c58,@c59,@c60,@c61,@c62,@c63,@c64) else update COMBU set nom_quemador = @c58, nom_posicion = @c59, co = @c60, co_2 = @c61, co_n = @c62, cumple_comb = @c63, id_combu = @c64 where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64";

                        camm.Parameters.AddWithValue("@c58", quem[3]);
                        camm.Parameters.AddWithValue("@c59", b);
                        camm.Parameters.AddWithValue("@c60", Convert.ToSingle(textBoxCo8.Text));
                        camm.Parameters.AddWithValue("@c61", Convert.ToSingle(textBoxCo_2_8.Text));
                        camm.Parameters.AddWithValue("@c62", Convert.ToSingle(textBox8.Text));
                        camm.Parameters.AddWithValue("@c63", com8());
                        camm.Parameters.AddWithValue("@c64", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //9

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c66,@c67,@c68,@c69,@c70,@c71,@c72) else update COMBU set nom_quemador = @c66, nom_posicion = @c67, co = @c68, co_2 = @c69, co_n = @c70, cumple_comb = @c71, id_combu = @c72 where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72";

                        camm.Parameters.AddWithValue("@c66", quem[4]);
                        camm.Parameters.AddWithValue("@c67", a);
                        camm.Parameters.AddWithValue("@c68", Convert.ToSingle(textBoxCo9.Text));
                        camm.Parameters.AddWithValue("@c69", Convert.ToSingle(textBoxCo_2_9.Text));
                        camm.Parameters.AddWithValue("@c70", Convert.ToSingle(textBox9.Text));
                        camm.Parameters.AddWithValue("@c71", com9());
                        camm.Parameters.AddWithValue("@c72", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //10/////////

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c74,@c75,@c76,@c77,@c78,@c79,@c80) else update COMBU set nom_quemador = @c74, nom_posicion = @c75, co = @c76, co_2 = @c77, co_n = @c78, cumple_comb = @c79, id_combu = @c80 where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80";

                        camm.Parameters.AddWithValue("@c74", quem[4]);
                        camm.Parameters.AddWithValue("@c75", b);
                        camm.Parameters.AddWithValue("@c76", Convert.ToSingle(textBoxCo10.Text));
                        camm.Parameters.AddWithValue("@c77", Convert.ToSingle(textBoxCo_2_10.Text));
                        camm.Parameters.AddWithValue("@c78", Convert.ToSingle(textBox10.Text));
                        camm.Parameters.AddWithValue("@c79", com10());
                        camm.Parameters.AddWithValue("@c80", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //11

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c82,@c83,@c84,@c85,@c86,@c87,@c88) else update COMBU set nom_quemador = @c82, nom_posicion = @c83, co = @c84, co_2 = @c85, co_n = @c86, cumple_comb = @c87, id_combu = @c88 where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88";

                        camm.Parameters.AddWithValue("@c82", quem[5]);
                        camm.Parameters.AddWithValue("@c83", a);
                        camm.Parameters.AddWithValue("@c84", Convert.ToSingle(textBoxCo11.Text));
                        camm.Parameters.AddWithValue("@c85", Convert.ToSingle(textBoxCo_2_11.Text));
                        camm.Parameters.AddWithValue("@c86", Convert.ToSingle(textBox11.Text));
                        camm.Parameters.AddWithValue("@c87", com11());
                        camm.Parameters.AddWithValue("@c88", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //12

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c90,@c91,@c92,@c93,@c94,@c95,@c96) else update COMBU set nom_quemador = @c90, nom_posicion = @c91, co = @c92, co_2 = @c93, co_n = @c94, cumple_comb = @c95, id_combu = @c96 where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96";

                        camm.Parameters.AddWithValue("@c90", quem[5]);
                        camm.Parameters.AddWithValue("@c91", b);
                        camm.Parameters.AddWithValue("@c92", Convert.ToSingle(textBoxCo12.Text));
                        camm.Parameters.AddWithValue("@c93", Convert.ToSingle(textBoxCo_2_12.Text));
                        camm.Parameters.AddWithValue("@c94", Convert.ToSingle(textBox12.Text));
                        camm.Parameters.AddWithValue("@c95", com12());
                        camm.Parameters.AddWithValue("@c96", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //13

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c98,@c99,@c100,@c101,@c102,@c103,@c104) else update COMBU set nom_quemador = @c98, nom_posicion = @c99, co = @c100, co_2 = @c101, co_n = @c102, cumple_comb = @c103, id_combu = @c104 where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104";

                        camm.Parameters.AddWithValue("@c98", quem[6]);
                        camm.Parameters.AddWithValue("@c99", a);
                        camm.Parameters.AddWithValue("@c100", Convert.ToSingle(textBoxCo13.Text));
                        camm.Parameters.AddWithValue("@c101", Convert.ToSingle(textBoxCo_2_13.Text));
                        camm.Parameters.AddWithValue("@c102", Convert.ToSingle(textBox13.Text));
                        camm.Parameters.AddWithValue("@c103", com13());
                        camm.Parameters.AddWithValue("@c104", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();

                        //14

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c106,@c107,@c108,@c109,@c110,@c111,@c112) else update COMBU set nom_quemador = @c106, nom_posicion = @c107, co = @c108, co_2 = @c109, co_n = @c110, cumple_comb = @c111, id_combu = @c112 where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112";

                        camm.Parameters.AddWithValue("@c106", quem[6]);
                        camm.Parameters.AddWithValue("@c107", b);
                        camm.Parameters.AddWithValue("@c108", Convert.ToSingle(textBoxCo14.Text));
                        camm.Parameters.AddWithValue("@c109", Convert.ToSingle(textBoxCo_2_14.Text));
                        camm.Parameters.AddWithValue("@c110", Convert.ToSingle(textBox14.Text));
                        camm.Parameters.AddWithValue("@c111", com14());
                        camm.Parameters.AddWithValue("@c112", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //15

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c114,@c115,@c116,@c117,@c118,@c119,@c120) else update COMBU set nom_quemador = @c114, nom_posicion = @c115, co = @c116, co_2 = @c117, co_n = @c118, cumple_comb = @c119, id_combu = @c120 where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120";

                        camm.Parameters.AddWithValue("@c114", quem[7]);
                        camm.Parameters.AddWithValue("@c115", a);
                        camm.Parameters.AddWithValue("@c116", Convert.ToSingle(textBoxCo15.Text));
                        camm.Parameters.AddWithValue("@c117", Convert.ToSingle(textBoxCo_2_15.Text));
                        camm.Parameters.AddWithValue("@c118", Convert.ToSingle(textBox15.Text));
                        camm.Parameters.AddWithValue("@c119", com15());
                        camm.Parameters.AddWithValue("@c120", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();


                        //16

                        cann.Open();

                        camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c122,@c123,@c124,@c125,@c126,@c127,@c128) else update COMBU set nom_quemador = @c122, nom_posicion = @c123, co = @c124, co_2 = @c125, co_n = @c126, cumple_comb = @c127, id_combu = @c128 where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128";

                        camm.Parameters.AddWithValue("@c122", quem[7]);
                        camm.Parameters.AddWithValue("@c123", b);
                        camm.Parameters.AddWithValue("@c124", Convert.ToSingle(textBoxCo16.Text));
                        camm.Parameters.AddWithValue("@c125", Convert.ToSingle(textBoxCo_2_16.Text));
                        camm.Parameters.AddWithValue("@c126", Convert.ToSingle(textBox16.Text));
                        camm.Parameters.AddWithValue("@c127", com16());
                        camm.Parameters.AddWithValue("@c128", asd4);

                        camm.ExecuteNonQuery();
                        cann.Close();



                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Datos Ensayo de Combustión registrado satisfactoriamente");



                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string a = "Consumo Total";
                            string b = "Consumo medio (1/2)";

                            string q = "Quemador";

                            string[] quem = { q+" Trasero Derecho", q+" Trasero Izquierdo", q+" Delantero Izquierdo",
                                     q+" Delantero Derecho", q+" Central Delantero", q+" Central Trasero",
                                     q+" Central", "Horno", "Todos los "+q+"es" };


                            string connetionString = null;
                            connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";


                            SqlConnection cann = new SqlConnection(connetionString);
                            SqlCommand camm = cann.CreateCommand();

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from ENSAYO_COMB where id_combu = @comb1) INSERT INTO ENSAYO_COMB (id_combu,cumple_comb,fecha_ec,hora_inicio_c,hora_termino_c) VALUES(@comb1,@comb2,@comb3,@comb4,@comb5) else update ENSAYO_COMB set id_combu = @comb1, cumple_comb = @comb2, fecha_ec = @comb3 , hora_inicio_c = @comb4 , hora_termino_c = @comb5 where id_combu = @comb1";

                            camm.Parameters.AddWithValue("@comb1", asd4); //valor que debe cambiarse por un dato que sea autoincrementable

                            camm.Parameters.AddWithValue("@comb2", combust()); // cambiar
                            camm.Parameters.AddWithValue("@comb3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                            camm.Parameters.AddWithValue("@comb4", inicio);
                            camm.Parameters.AddWithValue("@comb5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);


                            camm.ExecuteNonQuery();
                            cann.Close();


                            // 1

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c2,@c3,@c4,@c5,@c6,@c7,@c8) else update COMBU set nom_quemador = @c2, nom_posicion = @c3, co = @c4, co_2 = @c5, co_n = @c6, cumple_comb = @c7, id_combu = @c8 where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8";

                            camm.Parameters.AddWithValue("@c2", quem[0]);
                            camm.Parameters.AddWithValue("@c3", a);
                            camm.Parameters.AddWithValue("@c4", Convert.ToSingle(textBoxCo.Text));
                            camm.Parameters.AddWithValue("@c5", Convert.ToSingle(textBoxCo_2.Text));
                            camm.Parameters.AddWithValue("@c6", Convert.ToSingle(textBox1.Text));
                            camm.Parameters.AddWithValue("@c7", com1());
                            camm.Parameters.AddWithValue("@c8", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            cann.Open();

                            //2
                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c10,@c11,@c12,@c13,@c14,@c15,@c16) else update COMBU set nom_quemador = @c10, nom_posicion = @c11, co = @c12, co_2 = @c13, co_n = @c14, cumple_comb = @c15, id_combu = @c16 where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16";

                            camm.Parameters.AddWithValue("@c10", quem[0]);
                            camm.Parameters.AddWithValue("@c11", b);
                            camm.Parameters.AddWithValue("@c12", Convert.ToSingle(textBoxCo2.Text));
                            camm.Parameters.AddWithValue("@c13", Convert.ToSingle(textBoxCo_2_2.Text));
                            camm.Parameters.AddWithValue("@c14", Convert.ToSingle(textBox17.Text));
                            camm.Parameters.AddWithValue("@c15", com2());
                            camm.Parameters.AddWithValue("@c16", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //3
                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c18,@c19,@c20,@c21,@c22,@c23,@c24) else update COMBU set nom_quemador = @c18, nom_posicion = @c19, co = @c20, co_2 = @c21, co_n = @c22, cumple_comb = @c23, id_combu = @c24 where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24";

                            camm.Parameters.AddWithValue("@c18", quem[1]);
                            camm.Parameters.AddWithValue("@c19", a);
                            camm.Parameters.AddWithValue("@c20", Convert.ToSingle(textBoxCo3.Text));
                            camm.Parameters.AddWithValue("@c21", Convert.ToSingle(textBoxCo_2_3.Text));
                            camm.Parameters.AddWithValue("@c22", Convert.ToSingle(textBox3.Text));
                            camm.Parameters.AddWithValue("@c23", com3());
                            camm.Parameters.AddWithValue("@c24", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //4

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c26,@c27,@c28,@c29,@c30,@c31,@c32) else update COMBU set nom_quemador = @c26, nom_posicion = @c27, co = @c28, co_2 = @c29, co_n = @c30, cumple_comb = @c31, id_combu = @c32 where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32";

                            camm.Parameters.AddWithValue("@c26", quem[1]);
                            camm.Parameters.AddWithValue("@c27", b);
                            camm.Parameters.AddWithValue("@c28", Convert.ToSingle(textBoxCo4.Text));
                            camm.Parameters.AddWithValue("@c29", Convert.ToSingle(textBoxCo_2_4.Text));
                            camm.Parameters.AddWithValue("@c30", Convert.ToSingle(textBox4.Text));
                            camm.Parameters.AddWithValue("@c31", com4());
                            camm.Parameters.AddWithValue("@c32", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //5

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c34,@c35,@c36,@c37,@c38,@c39,@c40) else update COMBU set nom_quemador = @c34, nom_posicion = @c35, co = @c36, co_2 = @c37, co_n = @c38, cumple_comb = @c39, id_combu = @c40 where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40";

                            camm.Parameters.AddWithValue("@c34", quem[2]);
                            camm.Parameters.AddWithValue("@c35", a);
                            camm.Parameters.AddWithValue("@c36", Convert.ToSingle(textBoxCo5.Text));
                            camm.Parameters.AddWithValue("@c37", Convert.ToSingle(textBoxCo_2_5.Text));
                            camm.Parameters.AddWithValue("@c38", Convert.ToSingle(textBox5.Text));
                            camm.Parameters.AddWithValue("@c39", com5());
                            camm.Parameters.AddWithValue("@c40", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //6

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c42,@c43,@c44,@c45,@c46,@c47,@c48) else update COMBU set nom_quemador = @c42, nom_posicion = @c43, co = @c44, co_2 = @c45, co_n = @c46, cumple_comb = @c47, id_combu = @c48 where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48";

                            camm.Parameters.AddWithValue("@c42", quem[2]);
                            camm.Parameters.AddWithValue("@c43", b);
                            camm.Parameters.AddWithValue("@c44", Convert.ToSingle(textBoxCo6.Text));
                            camm.Parameters.AddWithValue("@c45", Convert.ToSingle(textBoxCo_2_6.Text));
                            camm.Parameters.AddWithValue("@c46", Convert.ToSingle(textBox6.Text));
                            camm.Parameters.AddWithValue("@c47", com6());
                            camm.Parameters.AddWithValue("@c48", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //7

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c50,@c51,@c52,@c53,@c54,@c55,@c56) else update COMBU set nom_quemador = @c50, nom_posicion = @c51, co = @c52, co_2 = @c53, co_n = @c54, cumple_comb = @c55, id_combu = @c56 where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56";

                            camm.Parameters.AddWithValue("@c50", quem[3]);
                            camm.Parameters.AddWithValue("@c51", a);
                            camm.Parameters.AddWithValue("@c52", Convert.ToSingle(textBoxCo7.Text));
                            camm.Parameters.AddWithValue("@c53", Convert.ToSingle(textBoxCo_2_7.Text));
                            camm.Parameters.AddWithValue("@c54", Convert.ToSingle(textBox7.Text));
                            camm.Parameters.AddWithValue("@c55", com7());
                            camm.Parameters.AddWithValue("@c56", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //8

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c58,@c59,@c60,@c61,@c62,@c63,@c64) else update COMBU set nom_quemador = @c58, nom_posicion = @c59, co = @c60, co_2 = @c61, co_n = @c62, cumple_comb = @c63, id_combu = @c64 where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64";

                            camm.Parameters.AddWithValue("@c58", quem[3]);
                            camm.Parameters.AddWithValue("@c59", b);
                            camm.Parameters.AddWithValue("@c60", Convert.ToSingle(textBoxCo8.Text));
                            camm.Parameters.AddWithValue("@c61", Convert.ToSingle(textBoxCo_2_8.Text));
                            camm.Parameters.AddWithValue("@c62", Convert.ToSingle(textBox8.Text));
                            camm.Parameters.AddWithValue("@c63", com8());
                            camm.Parameters.AddWithValue("@c64", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //9

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c66,@c67,@c68,@c69,@c70,@c71,@c72) else update COMBU set nom_quemador = @c66, nom_posicion = @c67, co = @c68, co_2 = @c69, co_n = @c70, cumple_comb = @c71, id_combu = @c72 where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72";

                            camm.Parameters.AddWithValue("@c66", quem[4]);
                            camm.Parameters.AddWithValue("@c67", a);
                            camm.Parameters.AddWithValue("@c68", Convert.ToSingle(textBoxCo9.Text));
                            camm.Parameters.AddWithValue("@c69", Convert.ToSingle(textBoxCo_2_9.Text));
                            camm.Parameters.AddWithValue("@c70", Convert.ToSingle(textBox9.Text));
                            camm.Parameters.AddWithValue("@c71", com9());
                            camm.Parameters.AddWithValue("@c72", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //10/////////

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c74,@c75,@c76,@c77,@c78,@c79,@c80) else update COMBU set nom_quemador = @c74, nom_posicion = @c75, co = @c76, co_2 = @c77, co_n = @c78, cumple_comb = @c79, id_combu = @c80 where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80";

                            camm.Parameters.AddWithValue("@c74", quem[4]);
                            camm.Parameters.AddWithValue("@c75", b);
                            camm.Parameters.AddWithValue("@c76", Convert.ToSingle(textBoxCo10.Text));
                            camm.Parameters.AddWithValue("@c77", Convert.ToSingle(textBoxCo_2_10.Text));
                            camm.Parameters.AddWithValue("@c78", Convert.ToSingle(textBox10.Text));
                            camm.Parameters.AddWithValue("@c79", com10());
                            camm.Parameters.AddWithValue("@c80", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //11

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c82,@c83,@c84,@c85,@c86,@c87,@c88) else update COMBU set nom_quemador = @c82, nom_posicion = @c83, co = @c84, co_2 = @c85, co_n = @c86, cumple_comb = @c87, id_combu = @c88 where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88";

                            camm.Parameters.AddWithValue("@c82", quem[5]);
                            camm.Parameters.AddWithValue("@c83", a);
                            camm.Parameters.AddWithValue("@c84", Convert.ToSingle(textBoxCo11.Text));
                            camm.Parameters.AddWithValue("@c85", Convert.ToSingle(textBoxCo_2_11.Text));
                            camm.Parameters.AddWithValue("@c86", Convert.ToSingle(textBox11.Text));
                            camm.Parameters.AddWithValue("@c87", com11());
                            camm.Parameters.AddWithValue("@c88", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //12

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c90,@c91,@c92,@c93,@c94,@c95,@c96) else update COMBU set nom_quemador = @c90, nom_posicion = @c91, co = @c92, co_2 = @c93, co_n = @c94, cumple_comb = @c95, id_combu = @c96 where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96";

                            camm.Parameters.AddWithValue("@c90", quem[5]);
                            camm.Parameters.AddWithValue("@c91", b);
                            camm.Parameters.AddWithValue("@c92", Convert.ToSingle(textBoxCo12.Text));
                            camm.Parameters.AddWithValue("@c93", Convert.ToSingle(textBoxCo_2_12.Text));
                            camm.Parameters.AddWithValue("@c94", Convert.ToSingle(textBox12.Text));
                            camm.Parameters.AddWithValue("@c95", com12());
                            camm.Parameters.AddWithValue("@c96", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //13

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c98,@c99,@c100,@c101,@c102,@c103,@c104) else update COMBU set nom_quemador = @c98, nom_posicion = @c99, co = @c100, co_2 = @c101, co_n = @c102, cumple_comb = @c103, id_combu = @c104 where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104";

                            camm.Parameters.AddWithValue("@c98", quem[6]);
                            camm.Parameters.AddWithValue("@c99", a);
                            camm.Parameters.AddWithValue("@c100", Convert.ToSingle(textBoxCo13.Text));
                            camm.Parameters.AddWithValue("@c101", Convert.ToSingle(textBoxCo_2_13.Text));
                            camm.Parameters.AddWithValue("@c102", Convert.ToSingle(textBox13.Text));
                            camm.Parameters.AddWithValue("@c103", com13());
                            camm.Parameters.AddWithValue("@c104", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();

                            //14

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c106,@c107,@c108,@c109,@c110,@c111,@c112) else update COMBU set nom_quemador = @c106, nom_posicion = @c107, co = @c108, co_2 = @c109, co_n = @c110, cumple_comb = @c111, id_combu = @c112 where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112";

                            camm.Parameters.AddWithValue("@c106", quem[6]);
                            camm.Parameters.AddWithValue("@c107", b);
                            camm.Parameters.AddWithValue("@c108", Convert.ToSingle(textBoxCo14.Text));
                            camm.Parameters.AddWithValue("@c109", Convert.ToSingle(textBoxCo_2_14.Text));
                            camm.Parameters.AddWithValue("@c110", Convert.ToSingle(textBox14.Text));
                            camm.Parameters.AddWithValue("@c111", com14());
                            camm.Parameters.AddWithValue("@c112", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //15

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c114,@c115,@c116,@c117,@c118,@c119,@c120) else update COMBU set nom_quemador = @c114, nom_posicion = @c115, co = @c116, co_2 = @c117, co_n = @c118, cumple_comb = @c119, id_combu = @c120 where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120";

                            camm.Parameters.AddWithValue("@c114", quem[7]);
                            camm.Parameters.AddWithValue("@c115", a);
                            camm.Parameters.AddWithValue("@c116", Convert.ToSingle(textBoxCo15.Text));
                            camm.Parameters.AddWithValue("@c117", Convert.ToSingle(textBoxCo_2_15.Text));
                            camm.Parameters.AddWithValue("@c118", Convert.ToSingle(textBox15.Text));
                            camm.Parameters.AddWithValue("@c119", com15());
                            camm.Parameters.AddWithValue("@c120", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();


                            //16

                            cann.Open();

                            camm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c122,@c123,@c124,@c125,@c126,@c127,@c128) else update COMBU set nom_quemador = @c122, nom_posicion = @c123, co = @c124, co_2 = @c125, co_n = @c126, cumple_comb = @c127, id_combu = @c128 where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128";

                            camm.Parameters.AddWithValue("@c122", quem[7]);
                            camm.Parameters.AddWithValue("@c123", b);
                            camm.Parameters.AddWithValue("@c124", Convert.ToSingle(textBoxCo16.Text));
                            camm.Parameters.AddWithValue("@c125", Convert.ToSingle(textBoxCo_2_16.Text));
                            camm.Parameters.AddWithValue("@c126", Convert.ToSingle(textBox16.Text));
                            camm.Parameters.AddWithValue("@c127", com16());
                            camm.Parameters.AddWithValue("@c128", asd4);

                            camm.ExecuteNonQuery();
                            cann.Close();



                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Datos Ensayo de Combustión actualizados satisfactoriamente");



                            this.Close();
                        }
                        else
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

        private void FormEnsayoCombustion_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}      