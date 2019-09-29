using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;

namespace Octo.Net.BL
{
    public class Critique
    {
        private readonly OctoNetDbContext db;

        public Critique()
        {
            db = new OctoNetDbContext();
        }
        ~Critique()
        {
            db.Dispose();
        }

        public List<Models.Critique> Load()
        {
            List<Models.Critique> critiques = new List<Models.Critique>();
            db.Critiques.ToList().ForEach(x => critiques
            .Add(new Models.Critique
            {
                Id = x.Id,
                CategoryDescription = x.CategoryDescription,
            }));

            return critiques;
        }

        public int Insert(Models.Critique critique)
        {
            tblCritique newCritique = new tblCritique { CategoryDescription = critique.CategoryDescription };
            db.Critiques.Add(newCritique);

            db.SaveChanges();
            return newCritique.Id;
        }

        public void Update(Models.Critique critique)
        {
            var existing = db.Critiques.SingleOrDefault(x => x.Id == critique.Id);

            if (existing != null)
            {
                existing.CategoryDescription = critique.CategoryDescription;

                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var existing = db.Critiques.SingleOrDefault(x => x.Id == id);

            if (existing != null)
            {
                db.Critiques.Remove(existing);
                return true;
            }
            else { return false; }
        }
    }
}
