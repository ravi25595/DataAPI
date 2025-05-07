using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{
    public class PersonEntity
    {
        [Key]
        public int Id { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public string Email { get; set; }
        [AllowNull]
        public string Phone { get; set; }
        public string[] Subjects { get; set; } = { "" };
        public int GroupId { get; set; }
    }
}
