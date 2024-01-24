using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AgentieDeTurism.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IStatiuneService _statiuneService;

        private const int SaltSize = 16; // You can adjust the salt size based on your needs
        private const int HashSize = 20; // Hash size for SHA-1, adjust if you use a different algorithm
        private const int Iterations = 10000; // Number of iterations, you can adjust for desired complexity

        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Create the hash with the password and salt using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combine the salt and hash
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert the combined bytes to a base64 string for storage
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public static bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            // Convert the stored hash back to bytes
            byte[] storedHashBytes = Convert.FromBase64String(storedHashedPassword);

            // Extract the salt from the stored hash
            byte[] salt = new byte[SaltSize];
            Array.Copy(storedHashBytes, 0, salt, 0, SaltSize);

            // Create a hash with the input password and extracted salt
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compare the generated hash with the stored hash
            for (int i = 0; i < HashSize; i++)
            {
                if (hash[i] != storedHashBytes[i + SaltSize])
                    return false;
            }

            return true;
        }

        public ClientService(IRepositoryWrapper repositoryWrapper, IStatiuneService statiuneService)
        {
            _repositoryWrapper = repositoryWrapper;
            _statiuneService = statiuneService;
        }

        public void AddRezervare(Client client, Sejur sejur)
        {
            //create rezervare
            Rezervare rezervare = new Rezervare()
            {
                ClientID = client.ID,
                SejurID = sejur.ID,
            };

            //add to the db
            _repositoryWrapper.RezervareRepository.Create(rezervare);
            _repositoryWrapper.Save();
        }

        public ICollection<Client> GetAllClientiPerioada(string dataDeInceput, string dataDeSfarsit)
        {
            ICollection<Client> clientiInPeriodaa = new List<Client>();
            
            //get list of clients
            ICollection<Client> clienti = GetAllClients();

            //iterate through the list
            foreach (Client client in clienti)
            {
                //for each client check if there are any rezevations made
                ICollection<Tuple<string, string>> perioade = GetRezervareClient(client);

                //filter list such that the time intervals match
                foreach (var perioada in perioade)
                {
                    //if both dates match then we add it to the list
                    if (perioada.Item1 == dataDeInceput && perioada.Item2 == dataDeSfarsit)
                    {
                        clientiInPeriodaa.Add(client);
                        break;
                    }
                }
            }

            return clientiInPeriodaa;
        }

        public ICollection<Tuple<string, string>> GetRezervareClient(Client client)
        {
            //get all reservations of a client
            ICollection<Rezervare> rezervari = _repositoryWrapper.RezervareRepository.FindByID(client.ID);

            ICollection<Tuple<string, string>> perioade = new List<Tuple<string, string>>();

            //extract start and end date for a reservation
            foreach (int sejurID in rezervari.Select(rezervare => rezervare.SejurID))
            {
                Sejur sejur = _statiuneService.GetSejurByID(sejurID);
                string dataDeInceput = sejur.DataDeInceput;
                string dataDeSfarsit = sejur.DataDeSfarsit;

                //create new start and end date pair
                Tuple<string, string> perioada = new Tuple<string, string>(dataDeInceput, dataDeSfarsit);

                perioade.Add(perioada);
            }
            
            //order list based on starting date
            return perioade.OrderBy(perioada => perioada.Item1).ToList();
        }

        public ICollection<Client> GetAllClients()
        {
            var query = _repositoryWrapper.ClientRepository.FindAll();
            ICollection<Client> clienti = query.ToList();
            return clienti;
        }

        public void AddClient(string nume, string prenume, string numarCI, string serieCI, string strada, string numar, string telefon, string username, string password)
        {
            string  hashedPassword=HashPassword(password);

            //create client object
            Client client = new Client()
            {
                Nume = nume,
                Prenume = prenume,
                NumarCI = numarCI,
                SerieCI = serieCI,
                Adresa = strada + " " + numar,
                Telefon = telefon,
                Username = username,
                Password = hashedPassword
            };

            //add to the db
            _repositoryWrapper.ClientRepository.Create(client);
            _repositoryWrapper.Save();
        }

        public bool CheckIfClientExist(string username, string password)
        {
            var query = _repositoryWrapper.ClientRepository.FindByCondition(client=> client.Username == username);
            List<Client> clienti = query.ToList();

            if(clienti.Count > 0)
            {
                string hashedPassword = clienti[0].Password;
                if(VerifyPassword(password, hashedPassword))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
