using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTrackerBot.API.Logger
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
                                        string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
