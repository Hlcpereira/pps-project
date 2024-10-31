namespace Pps.Avpratica
{
    public class HeartRateMonitor : Equipment
    {
        public override void SetRegistry(Registry registry)
        {
            this.Registry = registry;
        }
    }
}