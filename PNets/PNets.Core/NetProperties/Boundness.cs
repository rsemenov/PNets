using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core.NetProperties
{
    [Translate("Структурна обмеженість")]
    public enum StructurallyBoundness
    {
        [Translate("Структурно обмежена")]
        StructurallyBounded = 1,
        [Translate("Не структурно обмежена")]
        NotStructurallyBounded = 2
    }

    [Translate("Обмеженість")]
    public enum Boundness
    {
        [Translate("Обмежена")]
        Bounded = 1,
        [Translate("Необмежена")]
        Unbounded = 2
    }

    [Translate("Консервативність")]
    public enum Conservativeness
    {
        [Translate("Консервативна")]
        Conservative = 1, //structurally
        [Translate("Частково консервативна")]
        PartiallyConservative = 2,
        [Translate("Не консервативна")]
        NotConservative = 3
    }

    [Translate("Повторюваність")]
    public enum Repetitiveness
    {
        [Translate("Повторювана")]
        Repetitive = 1,
        [Translate("Частково повторювана")]
        PartiallyRepetitive = 2,
        [Translate("Не повторювана")]
        NotRepetitive = 3
    }

    [Translate("Несуперечність")]
    public enum Consistency
    {
        [Translate("Несуперечна")]
        Consistent = 1,
        [Translate("Частково несуперечна")]
        PartiallyConsistent = 2,
        [Translate("Суперечна")]
        NotConsistent = 3        
    }
}
