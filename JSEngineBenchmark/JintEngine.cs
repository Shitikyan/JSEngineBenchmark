using System.IO;
using System.Net;
using System.Text;
using Jint;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JSEngineBenchmark
{
    public class JintEngine : IJavascriptEngine
    {
        private static readonly string PredefinedModulePath = "Scripts/PredefinedJint.js";
        private static readonly string WrapperFuncName = "expressionWrapperFunc";
        private string _expressionWrapper;
        private Engine _engine;
        
        public void Prepare(string expression)
        {
            string predefinedModule = File.ReadAllText(PredefinedModulePath);
            string wrapperFunc = $"function {WrapperFuncName}() {{return {expression};}}";
            _expressionWrapper = wrapperFunc;
            _engine = new Engine();
            _engine.Execute(predefinedModule);
        }

        public object Execute()
        {
            _engine.Execute(_expressionWrapper);
            return _engine.Invoke(WrapperFuncName);
        }
    }
}