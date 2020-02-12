using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanAndSaveMobile.Helpers
{
    public class Settings
    {

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }



        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserName", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserName", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static DateTime AccessTokenExpiration
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpiration", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpiration", value);
            }
        }
    }
}

