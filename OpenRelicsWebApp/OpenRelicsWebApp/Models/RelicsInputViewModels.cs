using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class LocationViewModel
{
    [DisplayName("Place name")]
    public string PlaceName { get; set; }

    [DisplayName("Commune name")]
    public string CommuneName { get; set; }

    [DisplayName("District name")]
    public string DistrictName { get; set; }

    [Required(ErrorMessage = "You must set at least voivodenship to run search")]
    [DisplayName("Voivodeship name")]
    public string VoivodeshipName { get; set; }
}