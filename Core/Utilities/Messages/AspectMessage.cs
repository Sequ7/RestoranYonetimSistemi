using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class AspectMessage
    {
        public static string WrongValidationType { get; } = "Wrong validation type.";
        public static string ValidatorCannotBeNull { get; } = "Validator base type cannot be null.";
        public static string ValidatorMustGeneric { get; } = "Validator must have a generic argument.";
    }
}
