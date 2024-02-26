using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Models.AdViewModels
{
    public class AdInfoViewModel
    {
        public AdInfoViewModel(
            int id,
            string name,
            string description,
            decimal price,
            IdentityUser owner,
            string imageUrl,
            DateTime createdOn,
            Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price.ToString();
            Owner = owner.UserName;
            ImageUrl = imageUrl;
            CreatedOn = createdOn.ToString(DataConstants.DataFormatConstant);
            Category = category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedOn { get; set; }
        public string Category { get; set; }
    }
}
