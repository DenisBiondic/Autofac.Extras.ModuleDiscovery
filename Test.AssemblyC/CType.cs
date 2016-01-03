using Autofac;

namespace Test.AssemblyC
{
    public class CType : ICType, IStartable
    {
        public bool IsStarted { get; set; }

        public void Start()
        {
            IsStarted = true;
        }
    }
}