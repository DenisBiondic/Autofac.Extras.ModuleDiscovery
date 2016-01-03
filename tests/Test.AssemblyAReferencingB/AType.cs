using Test.AssemblyBReferencingC;

namespace Test.AssemblyAReferencingB
{
    public class AType : IAType
    {
        public AType(IBType dummyReference)
        {
            DummyReference = dummyReference;
        }

        public IBType DummyReference { get; set; }
    }
}