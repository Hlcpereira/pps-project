using Pps.Avpratica.Contracts;

namespace Pps.Avpratica.Builder
{
    public class TreatmentBuilder
    {
        protected List<Treatment> treatments = new List<Treatment>();
        protected static TreatmentBuilder? _instance;

        public TreatmentBuilder()
        {

        }

        public static TreatmentBuilder GetInstance()
        {
            if (_instance == null)
                _instance = new TreatmentBuilder();

            return _instance;
        }

        public Treatment CreateTreatment(
           Patient patient,
           string? healthcareMethodName
        )
        {
            IHealthcareMethod healthcareMethod = null;
    
            switch (healthcareMethodName)
            {
                case "Amil":
                    healthcareMethod = new Amil();
                    break;
                case "Unimed":
                    healthcareMethod = new Unimed();
                    break;
                case "Sus":
                    healthcareMethod = new Sus();
                    break;
                default:
                    break;
            }

            var entity = new Treatment()
            {
                Id = Guid.NewGuid(),
                Patient = patient,
                HealthcareMethod = healthcareMethod
            };

            treatments.Add(entity);

            return entity;
        }

        public Treatment GetTreatment(string? documentNumber)
        {
            if (documentNumber != null)
            {
                foreach (var treatment in treatments)
                {
                    if (treatment.Patient.DocumentNumber == documentNumber)
                        return treatment;
                }
            }

            return null;
        }
    }
}