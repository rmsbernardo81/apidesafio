using System.Collections.Generic;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Interface
{
    public interface IApartamento
    {
        Apartamento GetApartamento(int id);
        IEnumerable<Apartamento> GetAllApartamento();
        Apartamento AddApartamento(Apartamento apartamento);
        Apartamento UpdateApartamento(Apartamento apartamento);
        Apartamento DeletaApartamento(int id);
    }
}
