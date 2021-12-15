using System;

namespace WebApplicationTeste.Model
{
    public class Morador
    {
        public int MoradorId { get; set; }
        public int ApartamentoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
