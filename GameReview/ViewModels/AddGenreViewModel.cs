using System.ComponentModel.DataAnnotations;

namespace GameReview.ViewModels
{
    public class AddGenreViewModel

    {
        [Required]
        [Display(Name="Genre Name")]
        public string Name { get; set; }
    }
    
}
