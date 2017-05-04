using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.BindingModels
{
    public class RequestGameBindingModel
    {
        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string GenreName { get; set; }


        [Required]
        public string RequestedBy { get; set; }
    }
}
