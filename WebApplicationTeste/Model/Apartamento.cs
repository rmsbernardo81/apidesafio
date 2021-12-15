using System.Collections.Generic;

namespace WebApplicationTeste.Model
{
    public class Apartamento
    {
        public int ApartamentoId { get; set; }
        public int BlocoId { get; set; }
        public string Numero { get; set; }
        public string Andar { get; set; }
        public List<Morador> Moradores { get; set; }
    }
}
