using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IUrlService
    {
        Task<string> GetUrlAlias(string url, string generatedAlias);

        Task<string> GetFullUrl(string alias);
    }
}