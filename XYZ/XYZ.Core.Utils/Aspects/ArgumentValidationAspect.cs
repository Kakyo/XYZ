using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace XYZ.Aspects
{
    public class ArgumentValidationAspect : OnMethodBoundaryAspect
    {
        private const string _INVALID_ARGUMENT
            = "The method does not include the requerid parameters.\n"
            + "It should have the following ones:\n{0}";
        private Type[] _arguments;
        private string _paramNames;

        public ArgumentValidationAspect(params Type[] arguments)
        {
            this._arguments = arguments;
            this._paramNames = string.Join("\n", arguments.Select(s => s.Name));
        }
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            var parameters = method.GetParameters().ToArray();
            for (var i = 0; i < parameters.Length; i++)
                if (this._arguments[i] != parameters[i].ParameterType)
                {
                    var msg = string.Format(ArgumentValidationAspect._INVALID_ARGUMENT, _paramNames);
                    throw new ArgumentException(msg, parameters[i].Name);
                }

            return true;
        }
    }
}
