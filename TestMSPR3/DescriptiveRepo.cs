using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMSPR3
{
    public class DescriptiveRepo
    {
        private readonly IConfiguration _configuration;
        private static readonly List<DescriptiveEntity> _database = new List<DescriptiveEntity>();
        private readonly TestServer _server;
        public void InitializeTestData()
        {
            _database.Clear();
            _database.Add(new DescriptiveEntity { IDDescriptive = 1, IDLanguage = 2, descriptionShort = "testCourt", descriptionLong = "testLong" });
        }
        public DescriptiveRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Created(DescriptiveEntity model)
        {
            // Vérifie si l'entité existe déjà pour éviter les doublons.
            if (_database.Any(e => e.IDDescriptive == model.IDDescriptive))
            {
                throw new Exception("Une entité avec cet ID existe déjà.");
            }

            // Simule l'ajout d'une entité à une bdd
            _database.Add(model);
        }

        public DescriptiveEntity Read(int id)
        {
            return _database.FirstOrDefault(e => e.IDDescriptive == id);
        }

        public void Update(DescriptiveEntity model)
        {
            var existingEntity = _database.FirstOrDefault(e => e.IDDescriptive == model.IDDescriptive);
            if (existingEntity != null)
            {
                // Met à jour les propriétés de existingEntity avec celles de updatedEntity
                existingEntity.IDLanguage = model.IDLanguage;
                existingEntity.descriptionShort = model.descriptionShort;
                existingEntity.descriptionLong = model.descriptionLong;
            }
        }

        public void Delete(int idDescriptive)
        {
            var entity = _database.FirstOrDefault(e => e.IDDescriptive == idDescriptive);
            if (entity == null)
            {
                throw new Exception("L'entité n'a pas été trouvée.");
            }

            _database.Remove(entity);
        }
    }
}
