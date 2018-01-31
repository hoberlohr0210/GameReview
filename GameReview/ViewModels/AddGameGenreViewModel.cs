using System.ComponentModel.DataAnnotations;

namespace GameReview.ViewModels
{
    public class AddGameGenreViewModel

    {
        [Required]
        [Display(Name="Genre Name")]
        public string Name { get; set; }
    }
    
}
