using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)models;

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }
    }
}
