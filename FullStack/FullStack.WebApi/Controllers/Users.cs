using System;
using System.Data;
using System.Linq;
using FullStack.Data;

namespace FullStack.WebApi.Controllers
{
    using System.Web.Http;

    public class UsersController : ApiController
    {
        [Route("~/api/users/{userId:int}/roles/{roleId:int}")]
        public IHttpActionResult Post(int userId, int roleId)
        {
            using (var fullStackContext = new FullStackContext())
            {
                fullStackContext.UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId });
                fullStackContext.SaveChanges();
                var retVal = fullStackContext.UserRoles
                    .Include(ur => ur.Role)
                    .Single(ur => ur.UserId == userId && ur.RoleId == roleId);

                return Ok(new
                {
                    roleId = retVal.RoleId,
                    role = new
                    {
                        roleId = retVal.RoleId, 
                        roleName = retVal.Role.RoleName
                    }
                });
            }
        }

        [Route("~/api/users/{userId:int}/roles/{roleId:int}")]
        public IHttpActionResult Delete(int userId, int roleId)
        {
            using (var fullStackContext = new FullStackContext())
            {
                try
                {
                    var userRole = fullStackContext.UserRoles.Single(ur => ur.UserId == userId && ur.RoleId == roleId);
                    fullStackContext.UserRoles.Remove(userRole);
                    fullStackContext.SaveChanges();
                    return Ok();
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return Conflict();
                }
            }
        }

        public IHttpActionResult Get()
        {
            using (var fullStackContext = new FullStackContext())
            {
                var users = fullStackContext.Users.ToList();
                return Ok(users);
            }
        }

        public IHttpActionResult Get(int id)
        {
            using (var fullStackContext = new FullStackContext())
            {
                var user = fullStackContext.Users
                    .Include(u => u.UserRoles)
                    .Single(u => u.UserId == id);
                
                var roles = fullStackContext.Roles.ToList();
                var retVal = new
                {
                    user = new
                    {
                        userRoles = user.UserRoles.Select(ur => new { roleId = ur.RoleId }),
                        user.UserName,
                        user.UserId
                    }, 
                    roles = roles.Select(r => new
                    {
                        roleId = r.RoleId,
                        roleName = r.RoleName
                    })
                };

                return Ok(retVal);
            }
        }

        public IHttpActionResult Post(User user)
        {
            using (var fullStackContext = new FullStackContext())
            {
                fullStackContext.Users.Add(user);
                fullStackContext.SaveChanges();
                return Ok(user);
            }
        }

        public IHttpActionResult Put(int id, User user)
        {
            using (var fullStackContext = new FullStackContext())
            {
                try
                {
                    var dbUser = fullStackContext.Users.Single(r => r.UserId == id);
                    dbUser.UserName = user.UserName;
                    fullStackContext.SaveChanges();
                    return Ok(dbUser);
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return Conflict();
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            using (var fullStackContext = new FullStackContext())
            {
                try
                {
                    var user = fullStackContext.Users.Single(r => r.UserId == id);
                    fullStackContext.Users.Remove(user);
                    fullStackContext.SaveChanges();
                    return Ok();
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return Conflict();
                }
            }
        }
    }
}
