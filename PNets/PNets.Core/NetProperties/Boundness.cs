using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core.NetProperties
{
    public enum Boundness
    {
        StructurallyBounded = 1,
        NotStructurallyBounded = 2,
        Bounded = 3,
        Unbounded = 4
    }

    public enum Conservativeness
    {
        Conservative = 1, //structurally
        PartiallyConservative = 2,
        NotConservative = 3
    }

    public enum Repetitiveness
    {
        Repetitive = 1,
        PartiallyRepetitive = 2,
        NotRepetitive = 3
    }

    public enum Consistency
    {
        Consistent = 1,
        PartiallyConsistent = 2,
        NotConsistent = 3        
    }
}
