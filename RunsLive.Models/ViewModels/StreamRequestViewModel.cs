using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class StreamRequestViewModel
    {
        public int Id { get; set; }
        [Required,MinLength(3)]
        [Display(Name = "Stream Name: ")]
        public string StreamName { get; set; }

        public string Status { get; set; }
    }
}
