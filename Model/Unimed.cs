using Pps.Avpratica.Contracts;

namespace Pps.Avpratica
{
    public class Unimed : IHealthcareMethod
    {
        public bool Charge()
        {
            return true;
        }
    }
}