﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ilida.Api.Models;

namespace Ilida.Api.Controllers
{
    public class RolesController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();

        // GET: api/Roles
        public IQueryable<Role> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> GetRole(long id)
        {
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRole(long id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(role);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> DeleteRole(long id)
        {
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            await db.SaveChangesAsync();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(long id)
        {
            return db.Roles.Count(e => e.Id == id) > 0;
        }
    }
}