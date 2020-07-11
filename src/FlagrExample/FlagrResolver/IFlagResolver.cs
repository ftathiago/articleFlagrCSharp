using System;
using FlagrExample.FlagrResolver.Response;

namespace FlagrExample.FlagrResolver
{
    public interface IFlagResolver
    {
        EvaluationResponse ResolveFlag<T>(object entityContext);
    }
}