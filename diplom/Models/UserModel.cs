using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace diplom.Models
{
    public class UserModel
    {
            public int UserModelId { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }
        
    }
}
