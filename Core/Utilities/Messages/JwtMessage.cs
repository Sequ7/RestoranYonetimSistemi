using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class JwtMessage
    {
        public static string TokenOptionsMissing { get; } =
        "TokenOptions configuration is missing.";

        public static string SecurityKeyCannotBeNullOrEmpty { get; } =
            "TokenOptions.SecurityKey cannot be null or empty.";

        public static string TokenOptionsCannotBeNull { get; } =
        "TokenOptions section is missing in appsettings.json.";
    }
}
