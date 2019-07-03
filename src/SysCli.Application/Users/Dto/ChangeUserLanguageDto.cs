using System.ComponentModel.DataAnnotations;

namespace SysCli.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}