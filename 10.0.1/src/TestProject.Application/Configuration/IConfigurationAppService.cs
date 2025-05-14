using TestProject.Configuration.Dto;
using System.Threading.Tasks;

namespace TestProject.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
