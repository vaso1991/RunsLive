using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.BindingModels
{
    public class RequestStreamBindingModel
    {
        [Required,MinLength(3)]
        public string StreamName { get; set; }

        [Required]
        public string RequestedBy { get; set; }
    }
}
