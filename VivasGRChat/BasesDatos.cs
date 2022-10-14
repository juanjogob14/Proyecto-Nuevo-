using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivasGRChat
{
    public class BasesDatos
    {
        static string cadenaConexion = "Database = vivasgram; Data Source=localhost; Port = 3306; User id=root; ";

        MySqlConnection conectbd = new MySqlConnection(cadenaConexion);

        MySqlDataReader reader = null;

        public List<string> nombresBase = new List<string>();
        public List<string> passBase = new List<string>();

        public void ConectarBase()
        {
            conectbd.Open();
        }

        public void CerrarConexion()
        {
            conectbd.Close();
        }

        public bool ComprobarUsuarioRegistrado(string nombre, string contrasenha)
        {
            bool registrado = false;
            try
            {
                nombresBase.Clear();
                string consultaSiEsta = "Select nombreusuario, contrasenha from usuarios";
                MySqlCommand comando1 = new MySqlCommand(consultaSiEsta);
                comando1.Connection = conectbd;
                ConectarBase();
                reader = comando1.ExecuteReader();
                while (reader.Read())
                {
                    nombresBase.Add(reader.GetString(0));
                    passBase.Add(reader.GetString(1));
                }

                for (int i = 0; i < nombresBase.Count; i++)
                {
                    for (int j = 0; j < passBase.Count; j++)
                    {
                        if (nombresBase[i] == nombre && passBase[i] == contrasenha)
                        {
                            registrado = true;
                        }

                    }

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.ErrorCode);

            }
            finally
            {
                CerrarConexion();
            }
            return registrado;
        }

        public void AnhadirUsuario(string nombre, string contrasenha)
        {
            CerrarConexion();
            string consultaInsercion = "insert into usuarios (nombreusuario, contrasenha) values ('" + nombre.ToLower() + "','" + contrasenha + "');";
            MySqlCommand comando2 = new MySqlCommand(consultaInsercion, conectbd);

            try
            {
                ConectarBase();
                comando2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("error " + e.Message);
            }
            finally
            {
                CerrarConexion();

            }

        }

        public bool UsuarioYaRegistrado(string nombre)
        {
            bool yaRegistrado = false;
            try
            {
                nombresBase.Clear();
                string consultaSiEsta = "Select nombreusuario from usuarios";
                MySqlCommand comando1 = new MySqlCommand(consultaSiEsta);
                comando1.Connection = conectbd;
                ConectarBase();
                reader = comando1.ExecuteReader();
                while (reader.Read())
                {
                    nombresBase.Add(reader.GetString(0));
                }

                for (int i = 0; i < nombresBase.Count; i++)
                {
                    if (nombresBase[i] == nombre)
                    {
                        yaRegistrado = true;
                    }

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.ErrorCode);

            }
            finally
            {
                CerrarConexion();
            }
            return yaRegistrado;
        }

    }
}