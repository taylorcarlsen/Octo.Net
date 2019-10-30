using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;
using Octo.Net.Models;

namespace Octo.Net.BL
{
    public class FlagOption : IDisposable
    {
        private readonly OctoNetDbContext db;

        public FlagOption()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.FlagOption> Load()
        {
            List<Models.FlagOption> flagOptions = new List<Models.FlagOption>();
            db.FlagOptions
                .ToList()
                .ForEach(f => flagOptions
                .Add(
                    new Models.FlagOption
                    {
                        Id = f.Id,
                        Description = f.Description
                    }));

            return flagOptions;
        }
    }
}
