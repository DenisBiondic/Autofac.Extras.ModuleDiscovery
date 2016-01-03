using System;
using Autofac;
using Test.AssemblyBReferencingC;

namespace Test.AssemblyAReferencingB
{
    public class AType : IAType, IStartable
    {
        public AType(IBType dummyReference)
        {
            DummyReference = dummyReference;
        }

        public IBType DummyReference { get; set; }

        public bool IsStarted { get; set; }

        public void Start()
        {
            if (!DummyReference.IsStarted)
                throw new InvalidOperationException("Dependency needs to be started first!");

            IsStarted = true;
        }
    }
}