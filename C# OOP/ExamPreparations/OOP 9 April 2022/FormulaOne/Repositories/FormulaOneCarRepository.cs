using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> formulas;

        public FormulaOneCarRepository()
        {
            formulas = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => formulas;

        public void Add(IFormulaOneCar model)
            => formulas.Add(model);

        public bool Remove(IFormulaOneCar model)
            => formulas.Remove(model);
            
        public IFormulaOneCar FindByName(string name)
            => formulas.FirstOrDefault(n => n.Model == name);
    }
}
