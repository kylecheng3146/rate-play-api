using System.Collections.Generic;
using System.Threading.Tasks;
using rate_play_api.Services;
using rate_play_api.Services.RatePlayContext;

namespace rate_play_api.Interfaces
{
    public interface ILoginRepository
    {
        Member AuthenticateAsync(string username, string password);
    }
}