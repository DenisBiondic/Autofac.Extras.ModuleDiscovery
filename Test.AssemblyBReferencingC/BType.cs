using System;
using Autofac;
using Test.AssemblyC;

namespace Test.AssemblyBReferencingC
{
    public class BType : IBType, IStartable
    {
        public BType(ICType dummyReference)
        {
            DummyReference = dummyReference;
        }

        public ICType DummyReference { get; set; }

        public bool IsStarted { get; set; }

        public void Start()
        {
            if (!DummyReference.IsStarted)
                throw new InvalidOperationException("Dependency needs to be started first!");

            IsStarted = true;
        }
    }
}