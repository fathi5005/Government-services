using System.ComponentModel.DataAnnotations;

namespace Government.Authentication
{
    public class JwtOption
    {
        [Required]
        public string Key { get; set; }=string.Empty;
        [Required]
        public string Issuer { get; set; } = string.Empty;
        [Required]
        public string Audience { get; set; } = string.Empty;

        [Range(1,int.MaxValue,ErrorMessage = "invalid Expiry Minutes")]
        public int ExpiryMinutes { get; set; }
    }
}
