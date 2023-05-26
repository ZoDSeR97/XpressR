using System.Security.Claims;
using System.Text;
using XpressR.Server.Models;
using XpressR.Shared;

namespace XpressR.Server
{
    public class JwtManager
    {
        public const string JWT_KEY = "Fz?81.9G%I+t_'n5]BNX+c]#Y#j+5fG&~V3;d1`6U7qhj+nq5YG4F1:N)G$.5pr";
        private const int EXPR = 1;
        MyContext _context;
        public JwtManager(MyContext context)
        {
            _context = context;
        }
        public string GetJWT(User u)
        {
            var ExpireTime = DateTime.Now.AddDays(EXPR);
            var Token = Encoding.ASCII.GetBytes(JWT_KEY);
            var Identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, u.FirstName+" "+u.LastName)
            });
            
            return "";
        }
    }
}
