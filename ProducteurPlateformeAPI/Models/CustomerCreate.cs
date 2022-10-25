namespace ProducteurPlateformeAPI.Models
{
    public class CustomerCreate
    {
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Rue { get; set; }
        public string? Numero { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
