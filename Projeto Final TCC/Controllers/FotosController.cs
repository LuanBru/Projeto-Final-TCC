using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Projeto_Final_TCC.Data;
using Projeto_Final_TCC.Models;

namespace Projeto_Final_TCC.Controllers
{
    public class FotosController : ApiController
    {
        private Projeto_Final_TCCContext db = new Projeto_Final_TCCContext();

        // GET: api/Fotos
        public IQueryable<Fotos> GetFotos()
        {
            return db.Fotos;
        }

        // GET: api/Fotos/5
        [ResponseType(typeof(Fotos))]
        public IHttpActionResult GetFotos(int id)
        {
            Fotos fotos = db.Fotos.Find(id);
            if (fotos == null)
            {
                return NotFound();
            }

            return Ok(fotos);
        }

        // PUT: api/Fotos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFotos(int id, Fotos fotos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fotos.FotoId)
            {
                return BadRequest();
            }

            db.Entry(fotos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotosExists(id))
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

        // POST: api/Fotos
        [ResponseType(typeof(Fotos))]
        public IHttpActionResult PostFotos(Fotos fotos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fotos.Add(fotos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fotos.FotoId }, fotos);
        }

        // DELETE: api/Fotos/5
        [ResponseType(typeof(Fotos))]
        public IHttpActionResult DeleteFotos(int id)
        {
            Fotos fotos = db.Fotos.Find(id);
            if (fotos == null)
            {
                return NotFound();
            }

            db.Fotos.Remove(fotos);
            db.SaveChanges();

            return Ok(fotos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FotosExists(int id)
        {
            return db.Fotos.Count(e => e.FotoId == id) > 0;
        }
    }
}