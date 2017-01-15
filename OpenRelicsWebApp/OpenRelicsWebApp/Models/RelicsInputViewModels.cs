using System.ComponentModel.DataAnnotations;

public class LocationViewModel
{
    public string PlaceName { get; set; }

    public string CommuneName { get; set; }

    public string DistrictName { get; set; }

    [Required]
    public string VoivodeshipName { get; set; }
}