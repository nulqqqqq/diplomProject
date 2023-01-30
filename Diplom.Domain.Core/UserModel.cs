using System.ComponentModel.DataAnnotations;

namespace Diplom.Domain.Core
{
    public class UserModel
    {
        [Key]
        public int UserModelId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
