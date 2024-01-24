using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services.Interfaces
{
    public interface IClientService
    {
        void AddClient(string nume, string prenume, string numarCI, string serieCI, string strada, string numar, string telefon, string username, string password);
        void AddRezervare(Client client, Sejur sejur);
        ICollection<Client> GetAllClientiPerioada(string dataDeInceput, string dataDeSfarsit);
        ICollection<Tuple<string, string>> GetRezervareClient(Client client);
        ICollection<Client> GetAllClients();
        bool CheckIfClientExist (string username, string password);
    }
}
