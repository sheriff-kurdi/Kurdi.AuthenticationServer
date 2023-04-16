using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Shared;
using NLog;

namespace Kurdi.AuthenticationService.Services.Services
{
    public class SimpleService
    {
        private Logger logger = LoggerConfiguration.GetSimpleLogger().GetCurrentClassLogger();
        public void Simple()
        {
            logger.Info("hiiii from SimpleService");
        }
    }
}