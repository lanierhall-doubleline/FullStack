using System;
using System.Linq;
using FullStack.Data;

namespace FullStack.WebApi.Controllers
{
    using System.Web.Http;

    public class RolesController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var fullStackContext = new FullStackContext())
            {
                var roles = fullStackContext.Roles.ToList();
                return Ok(roles);
            }
        }

        public IHttpActionResult Post(Role role)
        {
            using (var fullStackContext = new FullStackContext())
            {
                fullStackContext.Roles.Add(role);
                fullStackContext.SaveChanges();
                return Ok(role);
            }
        }

        public IHttpActionResult Put(int id, Role role)
        {
            using (var fullStackContext = new FullStackContext())
            {
                try
                {
                    var dbRole = fullStackContext.Roles.Single(r => r.RoleId == id);
                    dbRole.RoleName = role.RoleName;
                    fullStackContext.SaveChanges();
                    return Ok(dbRole);
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
                    var role = fullStackContext.Roles.Single(r => r.RoleId == id);
                    fullStackContext.Roles.Remove(role);
                    fullStackContext.SaveChanges();
                    return Ok(true);
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
