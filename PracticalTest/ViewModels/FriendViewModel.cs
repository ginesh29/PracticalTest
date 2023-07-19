using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PracticalTest.ViewModels
{
    public class FriendViewModel
    {
        [HiddenInput]
        public Guid Guid { get; set; }
        [Required(ErrorMessage = ValidationMessage.REQUIRED)]
        [Remote("ValidateFriendId", "Friend")]
        [Display(Name = "Friend Id")]
        public int FriendId { get; set; }
        [Required(ErrorMessage = ValidationMessage.EMPTY_NOT_ALLOWED)]
        [MaxLength(25, ErrorMessage = ValidationMessage.MAX_CHAR_ALLOWED)]
        [Display(Name = "Friend Name")]
        public string FriendName { get; set; } = string.Empty;
        public string? Place { get; set; } = string.Empty;
    }
}
