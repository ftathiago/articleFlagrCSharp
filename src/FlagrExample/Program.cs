using System;
using FlagrExample.FlagrResolver;
using FlagrExample.FlagrResolver.Impl;
using FlagrExample.Providers;
using FlagrExample.Providers.Impl;

namespace FlagrExample
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("What feature is active?");
            IFlagResolver flagResolver = new FlagResolver();
            IFeatureProvider featureProvider = new FeatureProvider(flagResolver, "app3");
            var feature = featureProvider.GetFeature();
            feature.Execute();
        }
    }
}
