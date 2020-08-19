using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;
#pragma warning disable 618

namespace JSEngineBenchmark
{
    public class NodeServicesEngine : IJavascriptEngine
    {
        private string _expression;
        private readonly INodeServices _nodeServices;
        private static readonly string PredefinedModulePath = "Scripts/PredefinedNodeServices.js";
        
        public NodeServicesEngine()
        {
            var options = new NodeServicesOptions(new EmptyServiceProvider())
            {
                EnvironmentVariables = {["NODE_ENV"] = "production"}
            };
            
            _nodeServices = NodeServicesFactory.CreateNodeServices(options);
        }
        
        public void Prepare(string expression) => _expression = expression;

        public object Execute() => _nodeServices.InvokeAsync<object>(PredefinedModulePath, _expression).Result;
    }
    
    public class EmptyServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType) => null;
    }
}