using CrudMVC5AngularJs.Context;
using CrudMVC5AngularJs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudMVC5AngularJs.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ContatoController : ApiController
    {
        private readonly EFContext _db = new EFContext();

        [HttpGet]
        [Route("Contatos")]
        public IQueryable<Contato> ObterContatos()
        {
            return _db.Contatos.Include(x => x.Operadora);
        }

        [HttpGet]
        [Route("contato/{id:int}")]
        public HttpResponseMessage ObterPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var celular = _db.Contatos.Include(x => x.Operadora).SingleOrDefault(x => x.Id == id);

            return Request.CreateResponse(HttpStatusCode.OK, celular);
        }

        [HttpPut]
        [Route("putContato")]
        public HttpResponseMessage Alterar(Contato contato)
        {
            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(contato).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("postContato")]
        public HttpResponseMessage Incluir(Contato contato)
        {
            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Contatos.Add(contato);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("deleteContato/{id:int}")]
        public HttpResponseMessage Excluir(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var contato = _db.Contatos.Find(id);

            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Contato não encontrado");

            _db.Contatos.Remove(contato);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("deleteContato")]
        public HttpResponseMessage Excluir([FromBody]IEnumerable<Contato> contatos)
        {
            if (contatos == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lista vazia");

            foreach (var item in contatos)
            {
                var contato = _db.Contatos.Find(item.Id);

                if (contato == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Contato não encontrado");

                _db.Contatos.Remove(contato);
            }
                      
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
