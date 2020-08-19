using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.NodeServices;

namespace JSEngineBenchmark
{
    class Program
    {
        static void  Main(string[] args)
        {
            BenchmarkRunner.Run<JintVsNodeServices>();
        }
    }
}