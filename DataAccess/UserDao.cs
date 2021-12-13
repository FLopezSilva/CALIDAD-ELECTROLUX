using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;
using Common;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        public User Login (string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                
                //using reemplaza el cerrar conexion y limpiar los parametros al momento de haer el comando sql
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuario where rut_usuario = @user and contr_usuario = @pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var userObj = new User //OBTENEMOS LOS DATOS DE LAS COLUMNAS Y ASIGNAMOS A LOS CAMPOS DE LA CACHE DE USUARIO
                        {
                            Rut = reader[0].ToString(),
                            Nombre = reader[1].ToString(),
                            Apellido = reader[2].ToString(),
                            Contraseña = reader[3].ToString(),
                            Supervisor = reader[4].ToString(),
                            Rol = (int)reader[5]
                            //rut_usuario = reader.GetString(0);
                            //UserCache.nom_usuario = reader.GetString(1);
                            //UserCache.apell_usuario = reader.GetString(2);
                            //UserCache.contr_usuario = reader.GetString(3);
                            //UserCache.nom_supervisor = reader.GetString(4);
                            //UserCache.id_rol = reader.GetInt32(5);                            
                        };

                        ActiveUser.Rut = userObj.Rut;
                        ActiveUser.Rol = userObj.Rol;

                        return userObj;
                    }
                    else
                        return null;
                }
            }
        }
        //Register new user. //Registrar nuevo usuario
        //public int register(string user, string pass, string name, string lastName, string position, string mail)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "insert into users values( @user, @pass, @name, @lastname,@position, @mail)";
        //            command.Parameters.AddWithValue("@user", user);
        //            command.Parameters.AddWithValue("@pass", pass);
        //            command.Parameters.AddWithValue("@name", name);
        //            command.Parameters.AddWithValue("@lastName", lastName);
        //            command.Parameters.AddWithValue("@position", position);
        //            command.Parameters.AddWithValue("@mail", mail);
        //            command.CommandType = CommandType.Text;
        //            return command.ExecuteNonQuery();
        //        }
        //    }
        //}
        public bool existsUser(string id, string loginName, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuario rut_usuario=@id and nom_usuario=@loginName and apell_usuario=@lastName and contr_usuario=@pass";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@loginName", loginName);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }
        public void AnyMethod()
        {
            if (UserCache.id_rol == Rol.Adminsitrador)
            {
                //Codes
            }
            if (UserCache.id_rol == Rol.Operador || UserCache.id_rol == Rol.Coordinador)
            {
                //Codes
            }
        }

        public User GetUserById(string rut)
        {//Obtener usuario por id.
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuario where rut_usuario=@id";
                    command.Parameters.AddWithValue("@id", rut);
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var userObj = new User
                        {
                            Rut = reader[0].ToString(),
                            Nombre = reader[1].ToString(),
                            Apellido = reader[2].ToString(),
                            Contraseña = reader[3].ToString(),
                            Supervisor = reader[4].ToString(),
                            Rol = (int)reader[5]
                        };
                        return userObj; //Retornar resultado (objeto).
                    }
                    else
                        return null;//Retornar NULL si no hay resultado.
                }
            }
        }
        public bool ValidateActiveUser()
        {//Seguridad de la aplicacion, utiliza este metodo para verificar que el usuario conectado sea valido.
            bool validUser = false;//Obtiene o establece si el usuario conectado es valido (Valor por defecto =falso).
            string activeUserPass = "";//Obtiene o establece la contraseña del usuario conectado.
            if (string.IsNullOrWhiteSpace(ActiveUser.Rut) == false) //Ejecutar este fragmento de codigo siempre en cuando que el nombre usuario NO sea nulo o espacios en blanco.
            {
                using (var connection = GetConnection())//Obtener conexion
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        //Obtener la contraseña del usuario conectado.
                        command.CommandText = "select password from usuario where rut_usuario=@id";//Establecer el comando de texto
                        command.Parameters.AddWithValue("@id", ActiveUser.Rut);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())//Si el lector tiene filas que leer, almacenar el resultado (Contraseña) en el campo activeUserPass.
                                activeUserPass = reader[0].ToString();
                            command.Parameters.Clear();//Limpiar los parametros para la siguiente consulta.
                        }
                        //Validar usuario conectado.
                        command.CommandText = "select *from usuario where  contr_usuario=@pass and rut_usuario=@id";
                        command.Parameters.AddWithValue("@pass", activeUserPass);
                        command.Parameters.AddWithValue("@id", ActiveUser.Rut);

                        command.CommandType = CommandType.Text;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) //Si el lector tiene filas, establer validUser en verdadero.
                                validUser = true;
                            else //Caso contrario, establer validUser en falso.
                                validUser = false;
                        }
                    }
                }
            }
            return validUser; //Retornar el resultado.
        }
    }
}
