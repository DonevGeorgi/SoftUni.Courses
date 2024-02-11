using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User() 
        {
            Cards = new List<Card>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string FullName {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Username – text with length [3, 20] (required)
//•	FullName – text, which has two words, consisting of Latin letters.
//Both start with an upper letter and are followed by lower letters.
//The two words are separated by a single space (ex. "John Smith") (required) ^[A-Z][a-z]+\s[A-Z][a-z]+$
//•	Email – text (required)
//•	Age – integer in the range [3, 103] (required)
//•	Cards – collection of type Card

