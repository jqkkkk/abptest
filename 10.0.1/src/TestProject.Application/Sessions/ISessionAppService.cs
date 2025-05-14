using Abp.Application.Services;
using TestProject.Sessions.Dto;
using System.Threading.Tasks;

namespace TestProject.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
