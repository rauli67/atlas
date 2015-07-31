using Atlas.Factories;
using Atlas.Configuration;

namespace Atlas
{
    public partial class Host
    {
        private readonly ICreateInitializationStrategies _initilaizationStrategyFactory;

        internal Host(ICreateInitializationStrategies initilaizationStrategyFactory)
        {
            _initilaizationStrategyFactory = initilaizationStrategyFactory;
        }

        public virtual void Run<THostedProcess>(Configuration<THostedProcess> configuration)
        {
            foreach (var dependency in configuration.Dependencies)
            {
                dependency.Start();
            }

            _initilaizationStrategyFactory.Create(configuration.InstallMode).Initialize(configuration);
        }

    }
}