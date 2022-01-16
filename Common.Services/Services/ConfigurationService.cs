using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Services.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException("Missing configuration object");
        }

        public bool GetBoolSetting(string settingKey)
        {
            bool canConvert = bool.TryParse(_configuration.GetSection(settingKey).Value, out bool parsedValue);

            return canConvert ? parsedValue : throw new FormatException("Setting was not in the correct format");
        }

        public string GetConnectionString(string connectionStringKey)
        {
            return _configuration.GetConnectionString(connectionStringKey);
        }

        public int GetIntSetting(string settingKey)
        {
            bool canConvert = int.TryParse(_configuration.GetSection(settingKey).Value, out int parsedValue);

            return canConvert ? parsedValue : throw new FormatException("Setting was not in the correct format");
        }

        public T GetSectionSettings<T>(string settingKey)
        {
            return _configuration.GetSection("JwtSettings").Get<T>();
        }

        public T GetSectionValue<T>(string sectionName, string key )
        {
            return _configuration.GetSection(sectionName).GetValue<T>(key);
        }


        public string GetStringSetting(string settingKey)
        {
            return _configuration.GetSection(settingKey).Value;
        }
    }
}
