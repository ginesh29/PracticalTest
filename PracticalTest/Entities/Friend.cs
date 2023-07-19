using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Entities
{
    public class Friend
    {
        [Key]
        public Guid Guid { get; set; }
        public int FriendId { get; set; }
        [StringLength(25)]
        public string FriendName { get; set; } = string.Empty;
        public string? Place { get; set; } = string.Empty;
    }
}
