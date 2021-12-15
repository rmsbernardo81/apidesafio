using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTeste.Data;
using WebApplicationTeste.Interface;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Repository
{
    public class MoradorRepository : IMorador
    {
        private readonly WebApiTesteDesafioContext context;
        public MoradorRepository(WebApiTesteDesafioContext baseContext)
        {
            context = baseContext;
        }
        public Morador AddMorador(Morador morador)
        {
            context.Morador.Add(morador);
            context.SaveChanges();
            return morador;
        }
        public Morador DeletaMorador(int moradorId)
        {
            var cat = context.Morador.FirstOrDefault(e => e.MoradorId == moradorId);
            context.Morador.Remove(cat);
            return cat;
        }
        public IEnumerable<Morador> GetAllMorador()
        {
            return context.Morador;
        }
        public Morador GetMorador(int id)
        {
            return context.Morador.FirstOrDefault(e => e.MoradorId == id);
        }
        public Morador UpdateMorador(Morador morador)
        {
            var entity = context.Morador.Attach(morador);
            entity.State = EntityState.Modified;
            context.SaveChanges();
            return morador;
        }
    }
}
