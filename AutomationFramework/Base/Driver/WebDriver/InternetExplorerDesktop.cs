﻿using AutomationFrameWork.Driver.Interface;
using System;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver.WebDriver
{
    class InternetExplorerDesktop : IDrivers<IWebDriver, InternetExplorerDriverService, InternetExplorerOptions>
    {
        public InternetExplorerDesktop() { }
        public IWebDriver Driver
        {
            get; set;
        }
        public InternetExplorerOptions DesiredCapabilities
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top;
                options.EnableNativeEvents = true;
                options.EnsureCleanSession = true;
                options.IgnoreZoomLevel = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.RequireWindowFocus = false;
                options.EnablePersistentHover = false;
                options.PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager;
                options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore;
                return options;
            }
        }

        public InternetExplorerDriverService DriverServices
        {
            get
            {
                InternetExplorerDriverService serivces = InternetExplorerDriverService.CreateDefaultService();
                serivces.HideCommandPromptWindow = true;
                serivces.Implementation = InternetExplorerDriverEngine.AutoDetect;
                serivces.SuppressInitialDiagnosticInformation = false;
                return serivces;
            }
        }

        public void StartDriver(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            IWebDriver driver = new InternetExplorerDriver((InternetExplorerDriverService)driverServices, (InternetExplorerOptions)desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            Driver = driver;
        }

    }
}