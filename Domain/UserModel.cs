using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using System.Threading.Tasks;
using Common.Cache;
using System.ComponentModel;

namespace Domain
{
    public class UserModel
    {
        private UserDao userdao = new UserDao();


        // Attributes
        private string rut_usuario;
        private string nombre_usuario;
        private string pass_usuario;
        private int rol_usuario;
        private string apellido_usuario;
        private string nom_supervisor;
        private UserDao _userDao;

        // Constructors
        //Constructor whit parameters. / Constructor con parámetros

        public UserModel()
        {
            _userDao = new UserDao();
        }
        public UserModel(string rut, string nombre, string pass, int rol, string apellido,string supervisor)
        {
            Rut = rut;
            Nombre = nombre;
            Apellido = apellido;
            Contra = pass;
            Supervisor = supervisor;
            Rol = rol;
        }

        [DisplayName("Rut")]//Nombre a visualizar (Por ejemplo en la columna del datagridview se mostrará como Num).
        public string Rut
        {
            get { return rut_usuario; }
            set { rut_usuario = value; }
        }
        //Posición 1 
        [DisplayName("Nombre")]//Nombre a visualizar.
        public string Nombre
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        //Posición 2
        [DisplayName("Apellido")]//Nombre a visualizar.
        public string Apellido
        {
            get { return apellido_usuario; }
            set { apellido_usuario = value; }
        }

        //Posición 3
        [DisplayName("Contraseña")]//Nombre a visualizar.
        public string Contra
        {
            get { return pass_usuario; }
            set { pass_usuario = value; }
        }

        //Posición 4
        [DisplayName("Supervisor")]//Nombre a visualizar.
        public string Supervisor
        {
            get { return nom_supervisor; }
            set { nom_supervisor = value; }
        }

        //Posición 4
        [DisplayName("Rol")]//Nombre a visualizar.
        public int Rol
        {
            get { return rol_usuario; }
            set { rol_usuario = value; }
        }
        //Constructor whitout parameters. / Constructor sin parámetros
     

        private User MapUserEntity(UserModel userModel)
        {
            var userEntity = new User
            {
                Rut = userModel.Rut,
                Nombre = userModel.Nombre,
                Apellido = userModel.Apellido,
                Contraseña = userModel.Contra,
                Supervisor = userModel.Supervisor,
                Rol = userModel.Rol
            };
            return userEntity;
        }

        private UserModel MapUserModel(User userEntity)
        {//Mapear un solo objeto.
            var userModel = new UserModel()
            {
                Rut = userEntity.Rut,
                Nombre = userEntity.Nombre,
                Apellido = userEntity.Apellido,
                Contra = userEntity.Contraseña,
                Supervisor = userEntity.Supervisor,
                Rol = userEntity.Rol
            };
            return userModel;
        }

        private IEnumerable<UserModel> MapUserModel(IEnumerable<User> userEntities)
        {//Mapear colección de objetos.
            var userModels = new List<UserModel>();
            foreach (var user in userEntities)
            {
                userModels.Add(MapUserModel(user));
            }
            return userModels;
        }
        public UserModel GetUserById(string rut_usuario)
        {//Obtener usuario por ID.
            var result = _userDao.GetUserById(rut_usuario);
            if (result != null)
                return MapUserModel(result);
            else
                return null;
        }

        public UserModel Login(string username, string password)
        {//Iniciar sesion.
            var result = _userDao.Login(username, password);
            if (result != null)
                return MapUserModel(result);
            else
               
                return null;
        }

        public bool ValidateActiveUser()
        {//Seguridad
            return _userDao.ValidateActiveUser();
        }

        // Methods/ behaviors

        // Register new user. //Registrar nuevo usuario
        public bool validUser = false;

        //public string registerUser()
        //{
        //    try
        //    {
        //        var result = userdao.register(loginName, password, firstName, lastName, position, email);
        //        if (result >= 1)
        //        {
        //            LoginUser(loginName, password);
        //            validUser = true;
        //            return "[ : ) ]  EN HORA BUENEA¡¡\n\nYour account has been created successful, please login\n" +
        //                    "Su cuenta ha sido creada exitosamente, por favor inicie sesión";
        //        }
        //        else
        //        {
        //            validUser = false;
        //            return "An error has occurred, try again or contact the system administrator\n" +
        //                "Ha ocurrido un error, inténtalo de nuevo o contacta con el administrador del sistema";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        validUser = false;
        //        return "[ : ( ]  LO SENTIMOS¡¡\n\nUser name is already registered, try another.\n" +
        //            "Nombre de usuario ya está registrado, pruebe con otro";
        //    }
        //}

        // validate user and password when starting session.//validar usuario y contraseña al iniciar sesion
      
    }
}
