﻿using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; }
        [Required]
        public int GunWeight { get; set; }
        [Required]
        public double BarrelLength { get; set; }
        public int? NumberBuild {  get; set; }
        [Required]
        public int Range {  get; set; }
        [Required]
        public GunType GunType { get; set; }
        [Required]
        public int ShellId { get; set; }
        [Required]
        [ForeignKey(nameof(ShellId))]
        public virtual Shell Shell { get; set; }
        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	ManufacturerId – integer, foreign key (required)
//•	GunWeight– integer in range [100…1_350_000] (required)
//•	BarrelLength – double in range [2.00….35.00] (required)
//•	NumberBuild – integer
//•	Range – integer in range [1….100_000] (required)
//•	GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
//•	ShellId – integer, foreign key (required)
//•	CountriesGuns – a collection of CountryGun
