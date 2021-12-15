using System.Collections.Generic;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Interface
{
    public interface IMorador
    {
        Morador GetMorador(int id);
        IEnumerable<Morador> GetAllMorador();
        Morador AddMorador(Morador morador);
        Morador UpdateMorador(Morador morador);
        Morador DeletaMorador(int id);
    }
}
