using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => cars;

        public void Add(ICar model)
            => cars.Add(model);
        public bool Remove(ICar model)
            => cars.Remove(cars.FirstOrDefault(v => v.Model == model.Model));
        public ICar FindBy(string property)
            => cars.FirstOrDefault(v => v.VIN == property);

    }
}
