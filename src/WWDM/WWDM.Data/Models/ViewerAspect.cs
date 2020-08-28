using System;

namespace WWDM.Models
{
    [Flags]
    public enum ViewerAspect
    {
        None = 0,
        KdhAbs = 1,
        KdhPerc = 2,
        KtaPerc = 4,
        All = KdhAbs | KdhPerc | KtaPerc
    }
}