using Abp.Authorization;
using Abp.Runtime.Session;
using TestProject.Configuration.Dto;
using System.Threading.Tasks;

namespace TestProject.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : TestProjectAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
