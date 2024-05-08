using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class FollowerDto
    {
        public int userId {  get; set; }
        public string username { get; set; }
        public long followingUserId { get; set; }
        public string followingUsername { get; set; }
    }
}
