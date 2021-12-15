using System.Collections.Generic;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Interface
{
    public interface ICondominio
    {
        Condominio GetCondominio(int id);
        IEnumerable<Condominio> GetAllCondominio();
        Condominio AddCondominio(Condominio condominio);
        Condominio UpdateCondominio(Condominio condominio);
        Condominio DeletaCondominio(int id);
    }
}
