using System.Collections.Generic;
using ofco_projects_api.Services.OfcoContext;

namespace ofco_projects_api.Interfaces
{
    public interface ILoginRepository
    {
        Users Authenticate(string username, string password);
    }
}