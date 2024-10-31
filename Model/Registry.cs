using Pps.Avpratica.Composites;
using Pps.Avpratica.Contracts;

namespace Pps.Avpratica
{
    public class Registry
    {
        public Guid Id { get; set; }
        public Patient Patient { get; set; }
        public IHealthcareMethod HealthcareMethod { get; set; }
    }
}