using SerialPortListener.Serial;
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
    public partial class FormEnsayoTermocuplaIndi : Form
    {
        string inicio = DateTime.Now.ToString("HH:mm:ss");

        int a = 30;
        int b = 45;
        int c = 60;
        int d = 70;
        int e = 80;
        int f = 100;
        int g = 200;

        SerialPortManager _spManager;


        public FormEnsayoTermocuplaIndi()
        {
            InitializeComponent();
            UserInitialization();
            btnStop.Enabled = false;
        }

        //grupo de booleanos
        public static string asd5 = "";


        public void UserInitialization()

        {


            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));



            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            this.FormClosing += new FormClosingEventHandler(FormEnsayoTermocuplaIndi_FormClosing);





        }
        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            int maxTextLength = 1000; // maximum text length in text box
            if (richTextBox1.TextLength > maxTextLength)
                richTextBox1.Text = richTextBox1.Text.Remove(0, richTextBox1.TextLength - maxTextLength);

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            string str = Encoding.ASCII.GetString(e.Data);
            richTextBox1.AppendText(str);
            richTextBox1.ScrollToCaret();

        }

        //45

        public bool ter9()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor9 = Convert.ToSingle(textBoxTerm9.Text);

            bool resultado = (valor9 > (20 + b)) ? false : true;

            return resultado;

        }


        //30

        public bool ter10()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor10 = Convert.ToSingle(textBoxTerm10.Text);

            bool resultado = (valor10 > (20 + a)) ? false : true;

            return resultado;

        }

        //60

        public bool ter1()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor1 = Convert.ToSingle(textBoxTerm1.Text);

            bool resultado = (valor1 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter2()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor2 = Convert.ToSingle(textBoxTerm2.Text);

            bool resultado = (valor2 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter3()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor3 = Convert.ToSingle(textBoxTerm3.Text);

            bool resultado = (valor3 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter4()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor4 = Convert.ToSingle(textBoxTerm4.Text);

            bool resultado = (valor4 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter5()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor5 = Convert.ToSingle(textBoxTerm5.Text);

            bool resultado = (valor5 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter6()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor6 = Convert.ToSingle(textBoxTerm6.Text);

            bool resultado = (valor6 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter7()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor7 = Convert.ToSingle(textBoxTerm7.Text);

            bool resultado = (valor7 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter8()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor8 = Convert.ToSingle(textBoxTerm8.Text);

            bool resultado = (valor8 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter11()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor11 = Convert.ToSingle(textBoxTerm11.Text);

            bool resultado = (valor11 > (20 + c)) ? false : true;

            return resultado;

        }


        public bool ter15()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor15 = Convert.ToSingle(textBoxTerm15.Text);

            bool resultado = (valor15 > (20 + c)) ? false : true;

            return resultado;

        }

        public bool ter17()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor17 = Convert.ToSingle(textBoxTerm17.Text);

            bool resultado = (valor17 > (20 + c)) ? false : true;

            return resultado;

        }

        //70

        public bool ter18()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor18 = Convert.ToSingle(textBoxTerm18.Text);

            bool resultado = (valor18 > (20 + d)) ? false : true;

            return resultado;

        }

        //80

        public bool ter13()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor13 = Convert.ToSingle(textBoxTerm13.Text);

            bool resultado = (valor13 > (20 + e)) ? false : true;

            return resultado;

        }

        public bool ter12()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor12 = Convert.ToSingle(textBoxTerm12.Text);

            bool resultado = (valor12 > (20 + e)) ? false : true;

            return resultado;

        }

        //100

        public bool ter14()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor14 = Convert.ToSingle(textBoxTerm14.Text);

            bool resultado = (valor14 > (20 + f)) ? false : true;

            return resultado;

        }


        //200

        public bool ter16()
        {

            //el 20 cambia por el valor de temperatura ambiente

            float valor16 = Convert.ToSingle(textBoxTerm16.Text);

            bool resultado = (valor16 < 200 || valor16 > 204) ? false : true;

            return resultado;

        }

        public bool termo()
        {

            bool r1 = (ter1() == false || ter2() == false || ter3() == false || ter4() == false);
            bool r2 = (ter5() == false || ter6() == false || ter7() == false || ter8() == false);
            bool r3 = (ter9() == false || ter10() == false || ter11() == false || ter12() == false);
            bool r4 = (ter13() == false || ter14() == false || ter15() == false || ter16() == false);
            bool r5 = (ter17() == false || ter18() == false);


            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false || r5 == false) ? false : true;

            if (resultado == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool consulta()
        {
            string a1 = textBoxTerm1.Text;
            string a2 = textBoxTerm2.Text;
            string a3 = textBoxTerm3.Text;
            string a4 = textBoxTerm4.Text;
            string a5 = textBoxTerm5.Text;
            string a6 = textBoxTerm6.Text;
            string a7 = textBoxTerm7.Text;
            string a8 = textBoxTerm8.Text;
            string a9 = textBoxTerm9.Text;
            string a10 = textBoxTerm10.Text;
            string a11 = textBoxTerm11.Text;
            string a12 = textBoxTerm12.Text;
            string a13 = textBoxTerm13.Text;
            string a14 = textBoxTerm14.Text;
            string a15 = textBoxTerm15.Text;
            string a16 = textBoxTerm16.Text;
            string a17 = textBoxTerm17.Text;
            string a18 = textBoxTerm18.Text;

            string b = "";

            bool r1 = (a1.Equals(b) || a2.Equals(b) || a3.Equals(b) || a4.Equals(b)) ? false : true;
            bool r2 = (a5.Equals(b) || a6.Equals(b) || a7.Equals(b) || a8.Equals(b)) ? false : true;
            bool r3 = (a9.Equals(b) || a10.Equals(b) || a11.Equals(b) || a12.Equals(b)) ? false : true;
            bool r4 = (a13.Equals(b) || a14.Equals(b) || a15.Equals(b) || a16.Equals(b)) ? false : true;
            bool r5 = (a17.Equals(b) || a18.Equals(b)) ? false : true;

            bool resultado = (r1 == false || r2 == false || r3 == false || r4 == false || r5 == false) ? false : true;

            return resultado;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (portNameComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un puerto COM");
                }
                else
                {
                    _spManager.StartListening();


                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                    portNameComboBox.Enabled = false;
                    baudRateComboBox.Enabled = false;
                    dataBitsComboBox.Enabled = false;
                    parityComboBox.Enabled = false;
                    stopBitsComboBox.Enabled = false;

                    richTextBox1.Text = "";





                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _spManager.StopListening();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                portNameComboBox.Enabled = true;
                baudRateComboBox.Enabled = true;
                dataBitsComboBox.Enabled = true;
                parityComboBox.Enabled = true;
                stopBitsComboBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void FormEnsayoTermocuplaIndi_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (consulta() == true)
            {
                try
                {
                    string query1 = "select COUNT(*) from ensayo_termocup where id_termo = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd5);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    if (cant1 == 0)
                    {
                        string p = "Perrilla ";

                        string[] pieza = { p+"QTD", p+"QDD", p+"QTI", p+"QDI", p+"Horno", p+"QC", p+"QCD", p+"QCT"
                                      , "Tirador puerta", "Conexión boquilla","Frente llaves","Piso panel"
                                      , "Panel lateral", "Panel posterior","Costado libre","Centro horno"
                                      , "Puerta vidrio", "Paredes flexibles"};


                        string a = "Ta+";
                        string b = "C°";

                        //8

                        string[] ta = { a + "60" + b, a + "45" + b, a + "30" + b, a + "80" + b, a + "70" + b, a + "100" + b, "T° 200" + b + "+4/-0" };

                        string connetionString = null;
                        connetionString = "Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        SqlCommand comm = conn.CreateCommand();


                        conn.Open();

                        comm.CommandText = "INSERT INTO ensayo_termocup(id_termo,cumple_termo,fecha_termo,hora_inicio_t,hora_termino_t) VALUES(@termo1, @termo2, @termo3,@termo4,@termo5)";
                        comm.Parameters.AddWithValue("@termo1", asd5); //cambiar parametro
                        comm.Parameters.AddWithValue("@termo2", termo()); // cambiar parametro
                        comm.Parameters.AddWithValue("@termo3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                        comm.Parameters.AddWithValue("@termo4", inicio);
                        comm.Parameters.AddWithValue("@termo5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //1
                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t2,@t3,@t4,@t5,@t6)";
                        comm.Parameters.AddWithValue("@t2", pieza[0]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t3", Convert.ToSingle(textBoxTerm1.Text));
                        comm.Parameters.AddWithValue("@t4", ter1());
                        comm.Parameters.AddWithValue("@t5", asd5);
                        comm.Parameters.AddWithValue("@t6", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //2

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t8,@t9,@t10,@t11,@t12)";
                        comm.Parameters.AddWithValue("@t8", pieza[1]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t9", Convert.ToSingle(textBoxTerm2.Text));
                        comm.Parameters.AddWithValue("@t10", ter2());
                        comm.Parameters.AddWithValue("@t11", asd5);
                        comm.Parameters.AddWithValue("@t12", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //3

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t14,@t15,@t16,@t17,@t18)";
                        comm.Parameters.AddWithValue("@t14", pieza[2]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t15", Convert.ToSingle(textBoxTerm3.Text));
                        comm.Parameters.AddWithValue("@t16", ter3());
                        comm.Parameters.AddWithValue("@t17", asd5);
                        comm.Parameters.AddWithValue("@t18", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //4

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t20,@t21,@t22,@t23,@t24)";
                        comm.Parameters.AddWithValue("@t20", pieza[3]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t21", Convert.ToSingle(textBoxTerm4.Text));
                        comm.Parameters.AddWithValue("@t22", ter4());
                        comm.Parameters.AddWithValue("@t23", asd5);
                        comm.Parameters.AddWithValue("@t24", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();


                        //5

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t26,@t27,@t28,@t29,@t30)";
                        comm.Parameters.AddWithValue("@t26", pieza[4]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t27", Convert.ToSingle(textBoxTerm5.Text));
                        comm.Parameters.AddWithValue("@t28", ter5());
                        comm.Parameters.AddWithValue("@t29", asd5);
                        comm.Parameters.AddWithValue("@t30", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //6

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t32,@t33,@t34,@t35,@t36)";
                        comm.Parameters.AddWithValue("@t32", pieza[5]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t33", Convert.ToSingle(textBoxTerm6.Text));
                        comm.Parameters.AddWithValue("@t34", ter6());
                        comm.Parameters.AddWithValue("@t35", asd5);
                        comm.Parameters.AddWithValue("@t36", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //7

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t38,@t39,@t40,@t41,@t42)";
                        comm.Parameters.AddWithValue("@t38", pieza[6]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t39", Convert.ToSingle(textBoxTerm7.Text));
                        comm.Parameters.AddWithValue("@t40", ter7());
                        comm.Parameters.AddWithValue("@t41", asd5);
                        comm.Parameters.AddWithValue("@t42", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //8

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t44,@t45,@t46,@t47,@t48)";
                        comm.Parameters.AddWithValue("@t44", pieza[7]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t45", Convert.ToSingle(textBoxTerm8.Text));
                        comm.Parameters.AddWithValue("@t46", ter8());
                        comm.Parameters.AddWithValue("@t47", asd5);
                        comm.Parameters.AddWithValue("@t48", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //9

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t50,@t51,@t52,@t53,@t54)";
                        comm.Parameters.AddWithValue("@t50", pieza[8]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t51", Convert.ToSingle(textBoxTerm9.Text));
                        comm.Parameters.AddWithValue("@t52", ter9());
                        comm.Parameters.AddWithValue("@t53", asd5);
                        comm.Parameters.AddWithValue("@t54", ta[1]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //10

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t56,@t57,@t58,@t59,@t60)";
                        comm.Parameters.AddWithValue("@t56", pieza[9]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t57", Convert.ToSingle(textBoxTerm10.Text));
                        comm.Parameters.AddWithValue("@t58", ter10());
                        comm.Parameters.AddWithValue("@t59", asd5);
                        comm.Parameters.AddWithValue("@t60", ta[2]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //11

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t62,@t63,@t64,@t65,@t66)";
                        comm.Parameters.AddWithValue("@t62", pieza[10]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t63", Convert.ToSingle(textBoxTerm11.Text));
                        comm.Parameters.AddWithValue("@t64", ter11());
                        comm.Parameters.AddWithValue("@t65", asd5);
                        comm.Parameters.AddWithValue("@t66", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //12

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t68,@t69,@t70,@t71,@t72)";
                        comm.Parameters.AddWithValue("@t68", pieza[11]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t69", Convert.ToSingle(textBoxTerm12.Text));
                        comm.Parameters.AddWithValue("@t70", ter12());
                        comm.Parameters.AddWithValue("@t71", asd5);
                        comm.Parameters.AddWithValue("@t72", ta[3]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //13

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t74,@t75,@t76,@t77,@t78)";
                        comm.Parameters.AddWithValue("@t74", pieza[12]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t75", Convert.ToSingle(textBoxTerm13.Text));
                        comm.Parameters.AddWithValue("@t76", ter13());
                        comm.Parameters.AddWithValue("@t77", asd5);
                        comm.Parameters.AddWithValue("@t78", ta[3]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //14

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t80,@t81,@t82,@t83,@t84)";
                        comm.Parameters.AddWithValue("@t80", pieza[13]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t81", Convert.ToSingle(textBoxTerm14.Text));
                        comm.Parameters.AddWithValue("@t82", ter14());
                        comm.Parameters.AddWithValue("@t83", asd5);
                        comm.Parameters.AddWithValue("@t84", ta[5]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //15

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t86,@t87,@t88,@t89,@t90)";
                        comm.Parameters.AddWithValue("@t86", pieza[14]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t87", Convert.ToSingle(textBoxTerm15.Text));
                        comm.Parameters.AddWithValue("@t88", ter15());
                        comm.Parameters.AddWithValue("@t89", asd5);
                        comm.Parameters.AddWithValue("@t90", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //16

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t92,@t93,@t94,@t95,@t96)";
                        comm.Parameters.AddWithValue("@t92", pieza[15]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t93", Convert.ToSingle(textBoxTerm16.Text));
                        comm.Parameters.AddWithValue("@t94", ter16());
                        comm.Parameters.AddWithValue("@t95", asd5);
                        comm.Parameters.AddWithValue("@t96", ta[6]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //17

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t98,@t99,@t100,@t101,@t102)";
                        comm.Parameters.AddWithValue("@t98", pieza[16]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t99", Convert.ToSingle(textBoxTerm17.Text));
                        comm.Parameters.AddWithValue("@t100", ter17());
                        comm.Parameters.AddWithValue("@t101", asd5);
                        comm.Parameters.AddWithValue("@t102", ta[0]);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        //18

                        conn.Open();

                        comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t104,@t105,@t106,@t107,@t108)";
                        comm.Parameters.AddWithValue("@t104", pieza[17]); // cambiar parametro
                        comm.Parameters.AddWithValue("@t105", Convert.ToSingle(textBoxTerm18.Text));
                        comm.Parameters.AddWithValue("@t106", ter18());
                        comm.Parameters.AddWithValue("@t107", asd5);
                        comm.Parameters.AddWithValue("@t108", ta[4]);

                        comm.ExecuteNonQuery();
                        conn.Close();


                        /*----------------------------------------------------*/


                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Ensayo de Termocupla registrada satisfactoriamente");



                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string p = "Perrilla ";

                            string[] pieza = { p+"QTD", p+"QDD", p+"QTI", p+"QDI", p+"Horno", p+"QC", p+"QCD", p+"QCT"
                                      , "Tirador puerta", "Conexión boquilla","Frente llaves","Piso panel"
                                      , "Panel lateral", "Panel posterior","Costado libre","Centro horno"
                                      , "Puerta vidrio", "Paredes flexibles"};


                            string a = "Ta+";
                            string b = "C°";

                            //8

                            string[] ta = { a + "60" + b, a + "45" + b, a + "30" + b, a + "80" + b, a + "70" + b, a + "100" + b, "T° 200" + b + "+4/-0" };

                            string connetionString = null;
                            connetionString = "Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$";
                            SqlConnection conn = new SqlConnection(connetionString);
                            SqlCommand comm = conn.CreateCommand();


                            conn.Open();

                            comm.CommandText = "UPDATE ensayo_termocup SET id_termo = @termo1 ,cumple_termo = @termo2 ,fecha_termo = @termo3 ,hora_inicio_t = @termo4 ,hora_termino_t = @termo5 where id_termo = @termo1";
                            comm.Parameters.AddWithValue("@termo1", asd5); //cambiar parametro
                            comm.Parameters.AddWithValue("@termo2", termo()); // cambiar parametro
                            comm.Parameters.AddWithValue("@termo3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                            comm.Parameters.AddWithValue("@termo4", inicio);
                            comm.Parameters.AddWithValue("@termo5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //1
                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t2,temp_pieza = @t3 ,cumple_term = @t4 ,id_termo = @t5 ,temp_norma = @t6 WHERE descrip_pieza = @t2 and id_termo = @t5 ";
                            comm.Parameters.AddWithValue("@t2", pieza[0]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t3", Convert.ToSingle(textBoxTerm1.Text));
                            comm.Parameters.AddWithValue("@t4", ter1());
                            comm.Parameters.AddWithValue("@t5", asd5);
                            comm.Parameters.AddWithValue("@t6", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //2

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t8 ,temp_pieza = @t9 ,cumple_term = @t10 ,id_termo = @t11 ,temp_norma = @t12 WHERE descrip_pieza = @t8 and id_termo = @t11";
                            comm.Parameters.AddWithValue("@t8", pieza[1]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t9", Convert.ToSingle(textBoxTerm2.Text));
                            comm.Parameters.AddWithValue("@t10", ter2());
                            comm.Parameters.AddWithValue("@t11", asd5);
                            comm.Parameters.AddWithValue("@t12", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //3

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t14 ,temp_pieza = @t15 ,cumple_term = @t16 ,id_termo = @t17,temp_norma = @t18 where descrip_pieza = @t14 and id_termo = @t17";
                            comm.Parameters.AddWithValue("@t14", pieza[2]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t15", Convert.ToSingle(textBoxTerm3.Text));
                            comm.Parameters.AddWithValue("@t16", ter3());
                            comm.Parameters.AddWithValue("@t17", asd5);
                            comm.Parameters.AddWithValue("@t18", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //4

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t20 ,temp_pieza = @t21 ,cumple_term = @t22 ,id_termo = @t23 ,temp_norma = @t24 where descrip_pieza = @t20 and id_termo =@t23";
                            comm.Parameters.AddWithValue("@t20", pieza[3]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t21", Convert.ToSingle(textBoxTerm4.Text));
                            comm.Parameters.AddWithValue("@t22", ter4());
                            comm.Parameters.AddWithValue("@t23", asd5);
                            comm.Parameters.AddWithValue("@t24", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();


                            //5

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t26 ,temp_pieza = @t27 ,cumple_term = @t28 ,id_termo = @t29 ,temp_norma = @t30 where descrip_pieza = @t26 and id_termo = @t29";
                            comm.Parameters.AddWithValue("@t26", pieza[4]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t27", Convert.ToSingle(textBoxTerm5.Text));
                            comm.Parameters.AddWithValue("@t28", ter5());
                            comm.Parameters.AddWithValue("@t29", asd5);
                            comm.Parameters.AddWithValue("@t30", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //6

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t32 ,temp_pieza = @t33 ,cumple_term = @t34 ,id_termo = @t35 ,temp_norma = @t36 where descrip_pieza = @t32 and id_termo = @t35";
                            comm.Parameters.AddWithValue("@t32", pieza[5]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t33", Convert.ToSingle(textBoxTerm6.Text));
                            comm.Parameters.AddWithValue("@t34", ter6());
                            comm.Parameters.AddWithValue("@t35", asd5);
                            comm.Parameters.AddWithValue("@t36", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //7

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t38 ,temp_pieza = @t39 ,cumple_term = @t40 ,id_termo = @t41,temp_norma = @t42 where descrip_pieza = @t38 and id_termo = @t41";
                            comm.Parameters.AddWithValue("@t38", pieza[6]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t39", Convert.ToSingle(textBoxTerm7.Text));
                            comm.Parameters.AddWithValue("@t40", ter7());
                            comm.Parameters.AddWithValue("@t41", asd5);
                            comm.Parameters.AddWithValue("@t42", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //8

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t44 ,temp_pieza = @t45 ,cumple_term = @t46 ,id_termo = @t47 ,temp_norma = @t48 where descrip_pieza = @t44 and id_termo = @t47";
                            comm.Parameters.AddWithValue("@t44", pieza[7]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t45", Convert.ToSingle(textBoxTerm8.Text));
                            comm.Parameters.AddWithValue("@t46", ter8());
                            comm.Parameters.AddWithValue("@t47", asd5);
                            comm.Parameters.AddWithValue("@t48", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //9

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t50 ,temp_pieza = @t51,cumple_term = @t52 ,id_termo = @t53 ,temp_norma = @t54 where descrip_pieza = @t50 and id_termo = @t53";
                            comm.Parameters.AddWithValue("@t50", pieza[8]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t51", Convert.ToSingle(textBoxTerm9.Text));
                            comm.Parameters.AddWithValue("@t52", ter9());
                            comm.Parameters.AddWithValue("@t53", asd5);
                            comm.Parameters.AddWithValue("@t54", ta[1]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //10

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t56 ,temp_pieza = @t57 ,cumple_term = @t58 ,id_termo = @t59 ,temp_norma = @t60 where descrip_pieza = @t56 and id_termo = @t59";
                            comm.Parameters.AddWithValue("@t56", pieza[9]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t57", Convert.ToSingle(textBoxTerm10.Text));
                            comm.Parameters.AddWithValue("@t58", ter10());
                            comm.Parameters.AddWithValue("@t59", asd5);
                            comm.Parameters.AddWithValue("@t60", ta[2]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //11

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t62 ,temp_pieza = @t63 ,cumple_term = @t64 ,id_termo = @t65 ,temp_norma = @t66 where descrip_pieza = @t62 and id_termo = @t65";
                            comm.Parameters.AddWithValue("@t62", pieza[10]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t63", Convert.ToSingle(textBoxTerm11.Text));
                            comm.Parameters.AddWithValue("@t64", ter11());
                            comm.Parameters.AddWithValue("@t65", asd5);
                            comm.Parameters.AddWithValue("@t66", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //12

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t68 ,temp_pieza = @t69 ,cumple_term = @t70 ,id_termo = @t71 ,temp_norma = @t72 where descrip_pieza = @t68 and id_termo = @t71";
                            comm.Parameters.AddWithValue("@t68", pieza[11]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t69", Convert.ToSingle(textBoxTerm12.Text));
                            comm.Parameters.AddWithValue("@t70", ter12());
                            comm.Parameters.AddWithValue("@t71", asd5);
                            comm.Parameters.AddWithValue("@t72", ta[3]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //13

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t74 ,temp_pieza = @t75 ,cumple_term = @t76 ,id_termo = @t77 ,temp_norma = @t78 where descrip_pieza = @t74 and id_termo = @t77";
                            comm.Parameters.AddWithValue("@t74", pieza[12]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t75", Convert.ToSingle(textBoxTerm13.Text));
                            comm.Parameters.AddWithValue("@t76", ter13());
                            comm.Parameters.AddWithValue("@t77", asd5);
                            comm.Parameters.AddWithValue("@t78", ta[3]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //14

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t80 ,temp_pieza = @t81 ,cumple_term = @t82 ,id_termo = @t83 ,temp_norma = @t84 where descrip_pieza = @t80 and id_termo = @t83";
                            comm.Parameters.AddWithValue("@t80", pieza[13]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t81", Convert.ToSingle(textBoxTerm14.Text));
                            comm.Parameters.AddWithValue("@t82", ter14());
                            comm.Parameters.AddWithValue("@t83", asd5);
                            comm.Parameters.AddWithValue("@t84", ta[5]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //15

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t86 ,temp_pieza = @t87 ,cumple_term = @t88 ,id_termo = @t89 ,temp_norma = @t90 where descrip_pieza = @t86 and id_termo = @t89";
                            comm.Parameters.AddWithValue("@t86", pieza[14]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t87", Convert.ToSingle(textBoxTerm15.Text));
                            comm.Parameters.AddWithValue("@t88", ter15());
                            comm.Parameters.AddWithValue("@t89", asd5);
                            comm.Parameters.AddWithValue("@t90", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //16

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t92 ,temp_pieza = @t93,cumple_term = @t94 ,id_termo = @t95 ,temp_norma = @t96 where descrip_pieza = @t92 and id_termo = @t95";
                            comm.Parameters.AddWithValue("@t92", pieza[15]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t93", Convert.ToSingle(textBoxTerm16.Text));
                            comm.Parameters.AddWithValue("@t94", ter16());
                            comm.Parameters.AddWithValue("@t95", asd5);
                            comm.Parameters.AddWithValue("@t96", ta[6]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //17

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t98 ,temp_pieza = @t99 ,cumple_term = @t100,id_termo = @t101 ,temp_norma = @t102 where descrip_pieza = @t98 and id_termo = @t101";
                            comm.Parameters.AddWithValue("@t98", pieza[16]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t99", Convert.ToSingle(textBoxTerm17.Text));
                            comm.Parameters.AddWithValue("@t100", ter17());
                            comm.Parameters.AddWithValue("@t101", asd5);
                            comm.Parameters.AddWithValue("@t102", ta[0]);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            //18

                            conn.Open();

                            comm.CommandText = "UPDATE termoc SET descrip_pieza = @t104 ,temp_pieza = @t105 ,cumple_term = @t106,id_termo = @t107,temp_norma = @t108 where descrip_pieza = @t104 and id_termo = @t107";
                            comm.Parameters.AddWithValue("@t104", pieza[17]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t105", Convert.ToSingle(textBoxTerm18.Text));
                            comm.Parameters.AddWithValue("@t106", ter18());
                            comm.Parameters.AddWithValue("@t107", asd5);
                            comm.Parameters.AddWithValue("@t108", ta[4]);

                            comm.ExecuteNonQuery();
                            conn.Close();


                            /*----------------------------------------------------*/


                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Pruebas Ensayo de Termocupla actualizada satisfactoriamente");



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
            else
            {
                MessageBox.Show("Ingrese los datos correspondientes");

            }

        }

        private void FormEnsayoTermocuplaIndi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 1)
            {
                string dato = richTextBox1.Text;



                textBoxTerm1.Text = dato.Substring(169, 6);
                if (textBoxTerm1.Text == "888888") { textBoxTerm1.Text = "0"; };


                textBoxTerm2.Text = dato.Substring(176, 6);
                if (textBoxTerm2.Text == "888888") { textBoxTerm2.Text = "0"; };

                textBoxTerm3.Text = dato.Substring(183, 6);
                if (textBoxTerm3.Text == "888888") { textBoxTerm3.Text = "0"; };

                textBoxTerm4.Text = dato.Substring(190, 6);
                if (textBoxTerm4.Text == "888888") { textBoxTerm4.Text = "0"; };

                textBoxTerm5.Text = dato.Substring(197, 6);
                if (textBoxTerm5.Text == "888888") { textBoxTerm5.Text = "0"; };

                textBoxTerm6.Text = dato.Substring(204, 6);
                if (textBoxTerm6.Text == "888888") { textBoxTerm6.Text = "0"; };

                textBoxTerm7.Text = dato.Substring(211, 6);
                if (textBoxTerm7.Text == "888888") { textBoxTerm7.Text = "0"; };

                textBoxTerm8.Text = dato.Substring(218, 6);
                if (textBoxTerm8.Text == "888888") { textBoxTerm8.Text = "0"; };

                textBoxTerm9.Text = dato.Substring(225, 6);
                if (textBoxTerm9.Text == "888888") { textBoxTerm9.Text = "0"; };

                textBoxTerm10.Text = dato.Substring(232, 6);
                if (textBoxTerm10.Text == "888888") { textBoxTerm10.Text = "0"; };

                textBoxTerm11.Text = dato.Substring(239, 6);
                if (textBoxTerm11.Text == "888888") { textBoxTerm11.Text = "0"; };

                textBoxTerm12.Text = dato.Substring(246, 6);
                if (textBoxTerm12.Text == "888888") { textBoxTerm12.Text = "0"; };

                textBoxTerm13.Text = dato.Substring(253, 6);
                if (textBoxTerm13.Text == "888888") { textBoxTerm13.Text = "0"; };

                textBoxTerm14.Text = dato.Substring(260, 6);
                if (textBoxTerm14.Text == "888888") { textBoxTerm14.Text = "0"; };

                textBoxTerm15.Text = dato.Substring(267, 6);
                if (textBoxTerm15.Text == "888888") { textBoxTerm15.Text = "0"; };

                textBoxTerm16.Text = dato.Substring(274, 6);
                if (textBoxTerm16.Text == "888888") { textBoxTerm16.Text = "0"; };

                textBoxTerm17.Text = dato.Substring(281, 6);
                if (textBoxTerm17.Text == "888888") { textBoxTerm17.Text = "0"; };

                textBoxTerm18.Text = dato.Substring(288, 6);
                if (textBoxTerm18.Text == "888888") { textBoxTerm18.Text = "0"; };

            }
            else
            {
                MessageBox.Show("No hay dato para cargar", "DAT0");
            }
        }

        private void FormEnsayoTermocuplaIndi_Leave(object sender, EventArgs e)
        {
            _spManager.Dispose();
            this.Close();
        }

        private void richTextBox1_Validated(object sender, EventArgs e)
        {
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("E") == true)
            {
                try
                {
                    _spManager.StopListening();
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    portNameComboBox.Enabled = true;
                    baudRateComboBox.Enabled = true;
                    dataBitsComboBox.Enabled = true;
                    parityComboBox.Enabled = true;
                    stopBitsComboBox.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
        }

        private void FormEnsayoTermocuplaIndi_Load(object sender, EventArgs e)
        {
            baudRateComboBox.Text = "9600";
            dataBitsComboBox.Text = "8";
            stopBitsComboBox.Text = "1";
            parityComboBox.Text = "None";
        }
    }
}
