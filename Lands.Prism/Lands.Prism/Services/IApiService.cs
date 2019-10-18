using Lands.Prism.Models;
using System.Threading.Tasks;


namespace Lands.Prism.Services
{
    public interface IApiService
    {
        Task<bool> CheckConnection(string url);

        Task<Response> GetListAsync<T>(
                    string urlBase,
                    string servicePrefix,
                    string controller);
    }
}