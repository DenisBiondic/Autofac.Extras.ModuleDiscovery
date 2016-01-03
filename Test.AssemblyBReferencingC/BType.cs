using Test.AssemblyC;

namespace Test.AssemblyBReferencingC
{
    public class BType : IBType
    {
        public BType(ICType dummyReference)
        {
            DummyReference = dummyReference;
        }

        public ICType DummyReference { get; set; }
    }
}