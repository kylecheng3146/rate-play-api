using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ofco_projects_api.DataModel;
using ofco_projects_api.Helpers;
using ofco_projects_api.Interfaces;
using ofco_projects_api.Services.OfcoContext;

namespace ofco_projects_api.Repositories
{

    public class LoginRepository : ILoginRepository
    {

        private readonly OfcoContext _context;
        private readonly AppSettings _appSettings;
        public LoginRepository(OfcoContext context, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == username && x.Pwd == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Salt = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Pwd = null;

            return user;
        }
    }
}