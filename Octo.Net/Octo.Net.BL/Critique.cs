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

        public int Insert(Models.Critique critique)
        {
            tblCritique newCritique = new tblCritique { CategoryDescription = critique.CategoryDescription };
            db.Critiques.Add(newCritique);

            db.SaveChanges();
            return newCritique.Id;
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
