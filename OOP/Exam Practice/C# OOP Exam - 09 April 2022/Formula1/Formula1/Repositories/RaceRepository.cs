using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)models;

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(r => r.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
