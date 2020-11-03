using System;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ContasAPagarAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Instalacao()
        {
                var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
                string versaoCore = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
                return Ok($@"Instalação .NET Core [{versaoCore}]{Environment.NewLine}" +
                           $"Versão Api           [{informationVersion}]{Environment.NewLine}");
        }
    }
}