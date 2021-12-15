using System.Collections.Generic;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Interface
{
    public interface IBloco
    {
        Bloco GetBloco(int id);
        IEnumerable<Bloco> GetAllBloco();
        Bloco AddBloco(Bloco bloco);
        Bloco UpdateBloco(Bloco bloco);
        Bloco DeletaBloco(int id);
    }
}
