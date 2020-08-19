using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace JSEngineBenchmark
{
    public class JintVsNodeServices
    {
        private IJavascriptEngine _jint;
        private IJavascriptEngine _nodeServices;
        private string _expression;
        
        [Params(10, 100, 1000)]
        public int N;
        
        [GlobalSetup]
        public void Setup()
        {
            _jint = new JintEngine();
            _nodeServices = new NodeServicesEngine();
            _expression = $"calculateSum({BuildArrayExpr(N)})";
            _jint.Prepare(_expression);
            _nodeServices.Prepare(_expression);
            
            static string BuildArrayExpr(int size) =>
                Enumerable.Range(1, size)
                    .Select(s => s == 1 ? "[" + s : (s == size ? "," + s + "]" : "," + s))
                    .Aggregate(new StringBuilder(), (builder, str) => builder.Append(str))
                    .ToString();
        }

        [Benchmark]
        public object JintArraySum() => _jint.Execute();

        [Benchmark]
        public object NodeServicesArraySum() => _nodeServices.Execute();
    }
}