using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{
    public class GroupEntity
    {
        [Key]
        public int Id { get; set; }
        public int[] ParentId { get; set; } = { 0 };
        [AllowNull]
        public string GroupName { get; set; }
    }
}
