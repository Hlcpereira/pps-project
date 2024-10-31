using Pps.Avpratica.Composites;
using Pps.Avpratica.Contracts;

namespace Pps.Avpratica.Builder
{
    public class HospitalizationBuilder
    {
        protected List<Hospitalization> hospitalizations = new List<Hospitalization>();
        protected static HospitalizationBuilder? _instance;

        public HospitalizationBuilder()
        {

        }

        public static HospitalizationBuilder GetInstance()
        {
            if (_instance == null)
                _instance = new HospitalizationBuilder();

            return _instance;
        }

        public Hospitalization CreateHospitalization(
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

            var entity = new Hospitalization()
            {
                Id = Guid.NewGuid(),
                Patient = patient,
                HealthcareMethod = healthcareMethod
            };

            hospitalizations.Add(entity);

            return entity;
        }

        public Hospitalization GetHospitalization(string? documentNumber)
        {
            if (documentNumber != null)
            {
                foreach (var hospitalization in hospitalizations)
                {
                    if (hospitalization.Patient.DocumentNumber == documentNumber)
                        return hospitalization;
                }
            }

            return null;
        }
    }
}