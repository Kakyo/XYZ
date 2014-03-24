using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using PostSharp.Aspects;
using XYZ.Serialization;

namespace XYZ.Aspects
{
    [Serializable]
    internal class LogEntry
    {
        private const string _ENTER_MESSAGE = "ENTER ARGUMENTS";
        private const string _SUCCESS_MESSAGE = "SUCCESS RETURN";
        private const string _ERROR_MESSAGE = "EXCEPTION";
        private const string _GENERIC_PARAMETER = "<GENERIC>";

        private const string _PARAMETER_NAME_FORMAT = "{0} [ {1} ]";
        private const string _LINE_FORMAT = "[{0}] - {1}:\n";
        private const string _FOOTER_FORMAT = "- Ellapsed time: {0}ms\t-\t{1} ticks.\n\n";
        private const string _HEADER_FORMAT = "( thread : {0} ) : {1}\n";

        private const string _NAME_VALUE_FORMAT = "\t. {0} : {1}\n";


        private string[] parameters;
        private StringBuilder stringBuilder;
//#if DEBUG
        private bool started;
        private DateTime startTime;
//#endif

        public LogEntry(MethodBase method)
        {
            this.stringBuilder = new StringBuilder(1024);
            this.stringBuilder.AppendFormat(_HEADER_FORMAT
                , GetThreadId()
                , method.DeclaringType.FullName + "." + method.Name);
            this.started = false;

            var param = method.GetParameters();
            this.parameters = new string[param.Length];
            for (var i = 0; i < param.Length; i++)
            {
                string typeName = param[i].ParameterType.FullName;
                if (string.IsNullOrEmpty(typeName))
                    typeName = _GENERIC_PARAMETER;

                this.parameters[i] = string.Format(_PARAMETER_NAME_FORMAT
                    , param[i].Name, typeName);
            }
        }

        private static int GetThreadId()
        {
            int threadId;
            try
            {
                threadId = AppDomain.GetCurrentThreadId();
            }
            catch
            {
                try
                {
                    threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                }
                catch
                {
                    threadId = 0;
                }
            }
            return threadId;
        }
        private DateTime GetTime()
        {
            var now = DateTime.Now;
//#if DEBUG
            if (!this.started)
            {
                this.started = true;
                this.startTime = now;
            }
//#endif
            return now;
        }

        public void WriteLine(string header, Action<StringBuilder> action)
        {
            this.stringBuilder.AppendFormat(LogEntry._LINE_FORMAT, GetTime(), header);
            action(this.stringBuilder);
        }

        public void OnEntry(MethodExecutionArgs args)
        {
            this.WriteLine(LogEntry._ENTER_MESSAGE, sb =>
            {
                if (args.Arguments.Count == 0)
                    sb.AppendLine("\t. none");
                else
                    for (int i = 0; i < args.Arguments.Count; i++)
                    {
                        var arg = args.Arguments.GetArgument(i);
                        var value = arg == null ? "null" : arg/*Json.From(arg)*/;
                        var name = this.parameters[i].Replace(_GENERIC_PARAMETER, arg.ToString());
                        sb.AppendFormat(_NAME_VALUE_FORMAT, name, value);
                    }
            });

        }
        public void OnSuccess(MethodExecutionArgs args)
        {
            this.WriteLine(LogEntry._SUCCESS_MESSAGE, sb =>
            {
                var value = args.ReturnValue == null
                    ? "null|void" : Json.From(args.ReturnValue);

                sb.AppendFormat(LogEntry._NAME_VALUE_FORMAT, "<return type>", value);
            });
        }
        public void OnException(MethodExecutionArgs args)
        {
            this.WriteLine(LogEntry._ERROR_MESSAGE, sb =>
            {
                // Write the exception message. 
                sb.AppendFormat("\t. Exception {0}:{1}"
                    , args.Exception.GetType().Name
                    , args.Exception.Message);
            });

        }
        public void OnFinish(Action<StringBuilder> action = null)
        {
//#if DEBUG
            TimeSpan timespan = DateTime.Now.Subtract(startTime);
            stringBuilder.AppendFormat(LogEntry._FOOTER_FORMAT
                , timespan.TotalMilliseconds, timespan.Ticks);
//#endif
            if (action != null)
                action(this.stringBuilder);
            string msg = stringBuilder.ToString();

#if DEBUG
            Debug.WriteLine(msg);
#else 
            Trace.WriteLine(msg);
#endif
        }
    }
    
    [Serializable]
    public class LogAttribute : PostSharp.Aspects.OnMethodBoundaryAspect 
    {
        #region [ Overriden methods ]

        /// <summary>
        /// Method executed at build time. 
        /// After execution getters/setters from properties and add/remove from events
        /// are omitted from the log.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public override bool CompileTimeValidate(MethodBase method)
        {
            return !(method.IsConstructor
                //  or is getter/setter from properties or, also, add/remove from event handlers
                || Regex.IsMatch(method.Name, ".[get|set|add|remove]_", RegexOptions.IgnoreCase));
        }

        /// <summary> 
        /// Method invoked before the execution of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnEntry(MethodExecutionArgs args)
        {
            var entry = new LogEntry(args.Method);
            entry.OnEntry(args);
            args.MethodExecutionTag = entry;
        }

        /// <summary> 
        /// Method invoked after successfull execution of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnSuccess(MethodExecutionArgs args)
        {
            (args.MethodExecutionTag as LogEntry).OnSuccess(args);
        }

        /// <summary> 
        /// Method invoked after failure of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnException(MethodExecutionArgs args)
        {
            (args.MethodExecutionTag as LogEntry).OnException(args);
        }

        /// <summary> 
        /// Method invoked after failure or successfull execution of the method 
        /// to which the current aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnExit(MethodExecutionArgs args)
        {
            (args.MethodExecutionTag as LogEntry).OnFinish();
        }

        #endregion
    }
}
