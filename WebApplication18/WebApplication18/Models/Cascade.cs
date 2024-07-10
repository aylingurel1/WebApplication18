using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication18.Models
{
    public class Cascade
    {
        public IEnumerable<SelectListItem> AraclarList { get; set; } = null!;
        public IEnumerable<SelectListItem> KullanicilarList { get; set; } = null!;
    }
}
