namespace JSEngineBenchmark
{
    public interface IJavascriptEngine
    {
        public void Prepare(string expression);
        
        public object Execute();
    }
}