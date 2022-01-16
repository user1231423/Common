using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IConfigurationService
    {
        string GetStringSetting(string settingKey);

        bool GetBoolSetting(string settingKey);

        int GetIntSetting(string settingKey);

        string GetConnectionString(string connectionStringKey);

        public T GetSectionValue<T>(string sectionName, string key);

        T GetSectionSettings<T>(string settingKey);
    }
}
