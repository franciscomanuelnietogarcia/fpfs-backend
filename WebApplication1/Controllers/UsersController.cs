using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ServiceContext _serviceContext;

        public UsersController(IUserService userService, ServiceContext serviceContext)
        {
            _userService = userService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertUser")]

        //Unidad de verificación de los derechos de acceso
        public int Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] UserItem userItem)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.UserName == userNombreUsuario
                                    && u.Contraseña == userContraseña
                                    && u.Rol == "Admin")
                                .FirstOrDefault();
            if ( seletedUser != null)
            {

                return _userService.InsertUser(userItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }


        [HttpGet(Name = "GetAllUsers")]
        public List<UserItem> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpDelete(Name = "DeleteUser")]
        public void Delete([FromQuery] int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpGet(Name = "GetUsersById")]
        public List<UserItem> GetUserById([FromQuery] int id)
        {
            return _userService.GetUsersById(id);
        }

        [HttpPut(Name = "UpdateUser")]
        public IActionResult UpdateUser(int userId, [FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] UserItem updatedUser)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                                   .Where(u => u.UserName == userNombreUsuario
                                        && u.Contraseña == userContraseña
                                        && u.Rol == "Admin")
                                    .FirstOrDefault();

            if (seletedUser != null)
            {
                var user = _serviceContext.Users.FirstOrDefault(p => p.UserId == userId);

                if (user != null)
                {
                    user.UserName = updatedUser.UserName;
                    user.Rol = updatedUser.Rol;
                    user.Contraseña = updatedUser.Contraseña;
                    user.Email = updatedUser.Email;

                    _serviceContext.SaveChanges();

                    return Ok("El ususario se ha actualizado correctamente.");
                }
                else
                {
                    return NotFound("No se ha encontrado el usuario con el identificador especificado.");
                }
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
        }



        //[HttpDelete("{userId}", Name = "DeleteUser")]
        //public IActionResult DeleteUser(int userId, [FromQuery] string userNombreUsuario, [FromQuery] string userContraseña)
        //{
        //    var seletedUser = _serviceContext.Set<UserItem>()
        //                           .Where(u => u.NombreUsuario == userNombreUsuario
        //                                && u.Contraseña == userContraseña
        //                                && u.RolId == 1)
        //                            .FirstOrDefault();

        //    if (seletedUser != null)
        //    {
        //        var user = _serviceContext.Users.FirstOrDefault(p => p.UsuarioId == userId);

        //        if (user != null)
        //        {
        //            _serviceContext.Users.Remove(user); // Удаляем пользователя
        //            _serviceContext.SaveChanges(); // Сохраняем изменения в базе данных

        //            return Ok("El ususario se ha eliminado correctamente.");
        //        }
        //        else
        //        {
        //            return NotFound("No se ha encontrado el usuario con el identificador especificado.");
        //        }
        //    }
        //    else
        //    {
        //        return Unauthorized("El usuario no está autorizado o no existe");
        //    }
        //}


    }
}
