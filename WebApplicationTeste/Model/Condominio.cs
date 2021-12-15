using System.Collections.Generic;

namespace WebApplicationTeste.Model
{
    public class Condominio
    {
        public int CondominioId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Bloco> Blocos { get; set; }
    }
}
