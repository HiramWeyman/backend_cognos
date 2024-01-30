using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace ApiCognosV1.Repositorio
{
    public class UsuariosRepositorio: IUsuariosRepositorio
    {
        //Variable para el acceso a la base de datos
        private readonly ApplicationDBContext _bd;

        //Llamar la clave secreta
        private string claveSecreta;
        public UsuariosRepositorio(ApplicationDBContext bd,IConfiguration config)
        {
            _bd = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreto");
        }
     

        public Usuarios GetUsuario(int id)
        {
            return _bd.Usuarios.FirstOrDefault(u=>u.usr_id==id);
        }

        public ICollection<Usuarios> GetUsuarios()
        {
            return _bd.Usuarios.OrderBy(p => p.usr_paterno).ToList();
        }

        public bool IsUniqueUser(string email)
        {
           var usuariobd= _bd.Usuarios.FirstOrDefault(u => u.usr_email==email);
            if (usuariobd == null)
            {
                return true;
            }
            return false;
        }

        public async Task<UsuarioLoginRespuestaDto> Login(UsuariosLoginDto usuariosLoginDto)
        {
            var passwordEncriptado = obtenerMD5(usuariosLoginDto.usr_password);
            var usuario = _bd.Usuarios.FirstOrDefault(
                u=>u.usr_email.ToLower()== usuariosLoginDto.usr_email.ToLower() && u.usr_password== passwordEncriptado
                );

            //Validamos si el usuario no existe con la combinacion de emaily password
            if (usuario==null) {
                return new UsuarioLoginRespuestaDto()
                {
                    token = "",
                    usuario = null
                };
            }

            //Validamos si el usuario si existe con la combinacion de emaily password
            var manejadortoken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);
            //var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret phase"));
            var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject=new ClaimsIdentity(new Claim[]
                    { 
                        new Claim(ClaimTypes.Name,usuario.usr_email.ToString()),
                        new Claim(ClaimTypes.Role,usuario.usr_per_id.ToString())
                    }),
                    Expires=DateTime.UtcNow.AddDays(7),

                SigningCredentials=new (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
           
            };
            var token = manejadortoken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDto usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                token = manejadortoken.WriteToken(token),
                usuario=usuario
            };

            return usuarioLoginRespuestaDto;
        }

        public async Task<Usuarios> Registro(UsuariosRegistroDto usuariosRegistroDto)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            var passwordEncriptado = obtenerMD5(usuariosRegistroDto.usr_password);
            Usuarios usuario = new Usuarios()
            {
                usr_paterno = usuariosRegistroDto.usr_paterno,
                usr_materno = usuariosRegistroDto.usr_materno,
                usr_nombre = usuariosRegistroDto.usr_nombre,
                usr_email = usuariosRegistroDto.usr_email,
                usr_password = passwordEncriptado,
                usr_fecha_creacion= enteredDate,
                usr_per_id = usuariosRegistroDto.usr_per_id,

            };
            _bd.Usuarios.Add(usuario);
            await _bd.SaveChangesAsync();
            usuario.usr_password = passwordEncriptado;
            return usuario;
        }

        //Metodo para encripar password
        public static string obtenerMD5(string valor) 
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data=System.Text.Encoding.UTF8.GetBytes(valor);
            data=x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }

        public ICollection<Usuarios> GetUsuariosRole(int id)
        {
            return _bd.Usuarios.Where(p=>p.usr_per_id==id).OrderBy(p=>p.usr_paterno).ToList();
        }
    }
}
