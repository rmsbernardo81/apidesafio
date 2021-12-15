using System.Collections.Generic;

namespace WebApplicationTeste.Model
{
    public class Bloco
    {
        public int BlocoId { get; set; }
        public int CondominioId { get; set; }
        public string Nome { get; set; }
        public List<Apartamento> Apartamentos { get; set; }
    }
}
