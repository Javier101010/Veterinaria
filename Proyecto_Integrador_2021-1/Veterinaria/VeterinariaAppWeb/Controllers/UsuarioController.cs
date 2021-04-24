using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager
                            .ConnectionStrings["cnx"].ConnectionString);

        /*Metodos del Usuario*/
        List<UsuarioO> ListUsuarioOriginal()
        {
            List<UsuarioO> aUsuario = new List<UsuarioO>();
            SqlCommand cmd = new SqlCommand("SP_LISTAUSUARIO_ORIGINAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aUsuario.Add(new UsuarioO()
                {
                    idUsuario = int.Parse(dr[0].ToString()),
                    idRol = int.Parse(dr[1].ToString()),
                    nombre = dr[2].ToString(),
                    apePaterno = dr[3].ToString(),
                    apeMaterno = dr[4].ToString(),
                    idTipoDoc = int.Parse(dr[5].ToString()),
                    numeroDoc = dr[6].ToString(),
                    telefono = dr[7].ToString(),
                    direccion = dr[8].ToString(),
                    correo = dr[9].ToString(),
                    contraseña = dr[10].ToString(),
                    estado = dr[11].ToString(),
                    foto = dr[12].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return aUsuario;
        }
        List<Usuario> ListUsuario()
        {
            List<Usuario> aUsuario = new List<Usuario>();
            SqlCommand cmd = new SqlCommand("SP_LISTARUSUARIOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aUsuario.Add(new Usuario()
                {
                    idUsuario = int.Parse(dr[0].ToString()),
                    idRol = dr[1].ToString(),
                    nombre = dr[2].ToString(),
                    apePaterno = dr[3].ToString(),
                    apeMaterno = dr[4].ToString(),
                    idTipoDoc = dr[5].ToString(),
                    numeroDoc = dr[6].ToString(),
                    telefono = dr[7].ToString(),
                    direccion = dr[8].ToString(),
                    correo = dr[9].ToString(),
                    contraseña = dr[10].ToString(),
                    estado = dr[11].ToString(),
                    foto = dr[12].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return aUsuario;
        }

        List<Usuario> ListUsuarioxNombre(string nombre)
        {
            List<Usuario> aUsuario = new List<Usuario>();
            SqlCommand cmd = new SqlCommand("SP_LISTAUSUARIOXNOMBRE", cn);
            cmd.Parameters.AddWithValue("@NOM", nombre);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    aUsuario.Add(new Usuario()
                    {
                        idUsuario = int.Parse(dr[0].ToString()),
                        idRol = dr[1].ToString(),
                        nombre = dr[2].ToString(),
                        apePaterno = dr[3].ToString(),
                        apeMaterno = dr[4].ToString(),
                        idTipoDoc = dr[5].ToString(),
                        numeroDoc = dr[6].ToString(),
                        telefono = dr[7].ToString(),
                        direccion = dr[8].ToString(),
                        correo = dr[9].ToString(),
                        contraseña = dr[10].ToString(),
                        estado = dr[11].ToString(),
                        foto = dr[12].ToString()
                    });
                }
                dr.Close();
                cn.Close();
                return aUsuario;
            }
            catch
            {
                cn.Close();
            }
            return aUsuario;
        }

        List<Rol> ListRol()
        {
            List<Rol> aRol = new List<Rol>();
            SqlCommand cmd = new SqlCommand("SP_LISTARROLES", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rol objR = new Rol()
                {
                    idRol = int.Parse(dr[0].ToString()),
                    descripcion = dr[1].ToString(),
                    tipo = dr[2].ToString()
                };
                aRol.Add(objR);
            }

            dr.Close();
            cn.Close();
            return aRol;
        }

        List<TipoDocumento> ListTipoDoc()
        {
            List<TipoDocumento> aDoc = new List<TipoDocumento>();
            SqlCommand cmd = new SqlCommand("SP_LISTARDOCUMENTOS", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TipoDocumento objD = new TipoDocumento()
                {
                    idTipoDoc = int.Parse(dr[0].ToString()),
                    descripcion = dr[1].ToString(),
                    estado = dr[2].ToString()
                };
                aDoc.Add(objD);
            }
            dr.Close();
            cn.Close();
            return aDoc;
        }

        string codigoCorrelativo()
        {
            string codigo = null;
            SqlCommand cmd = new SqlCommand("SP_ULTIMOUSUARIO", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                codigo = dr[0].ToString();
            }
            dr.Close();
            cn.Close();

            int cod = int.Parse(codigo) +1;
            codigo = cod.ToString();

            return codigo;
        }

        string CRUD(string proceso, List<SqlParameter> p)
        {
            string mensaje = "No se registro";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(proceso, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(p.ToArray());
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Registro actualizado";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

        /*Action Result*/
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarUsuario(int p = 0, string nombre = "")
        {
            List<Usuario> aUsuario;
            if (nombre == "")
            {
                aUsuario = ListUsuario();
            }
            else
            {
                aUsuario = ListUsuarioxNombre(nombre);
                if(aUsuario.Count == 0)
                {
                    ViewBag.mensaje = "Usuario no encontrado";
                    aUsuario = ListUsuario();
                }
            }
            int filas = 10;
            int n = aUsuario.Count;
            int pag = n % filas > 0 ? n / filas + 1 : n / filas;

            ViewBag.pag = pag;
            ViewBag.p = p;
            return View(aUsuario.Skip(p * filas).Take(filas));
        }

        public ActionResult DetalleUsuario(int id)
        {
            Usuario objU = ListUsuario().Where(p => p.idUsuario == id).FirstOrDefault();
            return View(objU);
        }

        public ActionResult RegistrarUsuario()
        {
            ViewBag.codigo = codigoCorrelativo();
            ViewBag.rol = new SelectList(ListRol(), "idRol", "descripcion");
            ViewBag.documento = new SelectList(ListTipoDoc(), "idTipoDoc", "descripcion");
            return View(new UsuarioO());
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioO objU, HttpPostedFileBase f)
        {
            List<SqlParameter> parametros = new List<SqlParameter>() {
                new SqlParameter(){ParameterName="@ID_USU",SqlDbType=SqlDbType.Int, Value=objU.idUsuario},
                new SqlParameter(){ParameterName="@ID_ROL",SqlDbType=SqlDbType.Int, Value=objU.idRol},
                new SqlParameter(){ParameterName="@NOMBRE",SqlDbType=SqlDbType.VarChar, Value=objU.nombre},
                new SqlParameter(){ParameterName="@APE_PAT",SqlDbType=SqlDbType.VarChar, Value=objU.apePaterno},
                new SqlParameter(){ParameterName="@APE_MAT",SqlDbType=SqlDbType.VarChar, Value=objU.apeMaterno},
                new SqlParameter(){ParameterName="@TIP_DOC",SqlDbType=SqlDbType.Int, Value=objU.idTipoDoc},
                new SqlParameter(){ParameterName="@NUM_DOC",SqlDbType=SqlDbType.VarChar, Value=objU.numeroDoc},
                new SqlParameter(){ParameterName="@TELEF",SqlDbType=SqlDbType.VarChar, Value=objU.telefono},
                new SqlParameter(){ParameterName="@DIRECC",SqlDbType=SqlDbType.VarChar, Value=objU.direccion},
                new SqlParameter(){ParameterName="@CORREO",SqlDbType=SqlDbType.VarChar, Value=objU.correo},
                new SqlParameter(){ParameterName="@PASSW",SqlDbType=SqlDbType.VarChar, Value=objU.contraseña},
                new SqlParameter(){ParameterName="@ESTADO",SqlDbType=SqlDbType.VarChar, Value=objU.estado},
                new SqlParameter(){ParameterName="@FOTO",SqlDbType=SqlDbType.VarChar, Value=
                            "~/Image/"+Path.GetFileName(f.FileName)}
            };
            ViewBag.mensaje = CRUD("SP_NUEVOUSUARIO", parametros);
            f.SaveAs(Path.Combine(Server.MapPath("~/Image/"),
                Path.GetFileName(f.FileName)));
            return RedirectToAction("ListarUsuario");
        }

        public ActionResult EditarUsuario(int id)
        {
            UsuarioO usuaO = ListUsuarioOriginal().Where(x => x.idUsuario == id).FirstOrDefault();
            ViewBag.rol = new SelectList(ListRol(), "idRol", "descripcion");
            ViewBag.documento = new SelectList(ListTipoDoc(), "idTipoDoc", "descripcion");
            return View(usuaO);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioO objU, HttpPostedFileBase f)
        {
            List<SqlParameter> parametros = new List<SqlParameter>() {
                new SqlParameter(){ParameterName="@ID_USU",SqlDbType=SqlDbType.Int, Value=objU.idUsuario},
                new SqlParameter(){ParameterName="@ID_ROL",SqlDbType=SqlDbType.Int, Value=objU.idRol},
                new SqlParameter(){ParameterName="@NOMBRE",SqlDbType=SqlDbType.VarChar, Value=objU.nombre},
                new SqlParameter(){ParameterName="@APE_PAT",SqlDbType=SqlDbType.VarChar, Value=objU.apePaterno},
                new SqlParameter(){ParameterName="@APE_MAT",SqlDbType=SqlDbType.VarChar, Value=objU.apeMaterno},
                new SqlParameter(){ParameterName="@TIP_DOC",SqlDbType=SqlDbType.Int, Value=objU.idTipoDoc},
                new SqlParameter(){ParameterName="@NUM_DOC",SqlDbType=SqlDbType.VarChar, Value=objU.numeroDoc},
                new SqlParameter(){ParameterName="@TELEF",SqlDbType=SqlDbType.VarChar, Value=objU.telefono},
                new SqlParameter(){ParameterName="@DIRECC",SqlDbType=SqlDbType.VarChar, Value=objU.direccion},
                new SqlParameter(){ParameterName="@CORREO",SqlDbType=SqlDbType.VarChar, Value=objU.correo},
                new SqlParameter(){ParameterName="@PASSW",SqlDbType=SqlDbType.VarChar, Value=objU.contraseña},
                new SqlParameter(){ParameterName="@ESTADO",SqlDbType=SqlDbType.VarChar, Value=objU.estado},
                new SqlParameter(){ParameterName="@FOTO",SqlDbType=SqlDbType.VarChar, Value=
                            "~/Image/"+Path.GetFileName(f.FileName)}
            };
            ViewBag.mensaje = CRUD("SP_EDITARUSUARIO", parametros);
            f.SaveAs(Path.Combine(Server.MapPath("~/Image/"),
                Path.GetFileName(f.FileName)));
            return RedirectToAction("ListarUsuario");
        }

        public ActionResult EliminarUsuario(int id)
        {
            Usuario objU = ListUsuario().Where(x => x.idUsuario == id).FirstOrDefault();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName="@ID_USU",SqlDbType=SqlDbType.Int, Value=objU.idUsuario}
            };
            CRUD("SP_ELIMINARUSUARIO", parameters);
            return RedirectToAction("ListarUsuario");
        }
    }
}