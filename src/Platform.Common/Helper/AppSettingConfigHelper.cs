﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Platform.Common.Helper
{
    public class AppSettingConfigHelper
    {
        /// <summary>
        /// 读取appsettings.json配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetAppSettings<T>(string fileName = "appsettings.json", string key = "") where T : class, new()
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).Name;
            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }

            var config = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true).Build();

            var appconfig = new ServiceCollection()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }
    }
}
