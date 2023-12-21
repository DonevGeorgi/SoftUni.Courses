using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments;

        public EquipmentRepository()
        {
            equipments = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => equipments;

        public void Add(IEquipment model)
            => equipments.Add(model);
        public bool Remove(IEquipment model)
            => equipments.Remove(equipments.FirstOrDefault(x => x.Weight == model.Weight && x.Price == model.Price));

        public IEquipment FindByType(string type)
            => equipments.FirstOrDefault(x => x.GetType().Name == type);

    }
}
