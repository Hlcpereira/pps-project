namespace Pps.Avpratica.Builder
{
    public class PatientBuilder
    {
        protected List<Patient> patients = new List<Patient>();
        protected static PatientBuilder? _instance;

        public PatientBuilder()
        {

        }

        public static PatientBuilder GetInstance()
        {
            if (_instance == null)
                _instance = new PatientBuilder();

            return _instance;
        }

        public Patient CreatePatient(string? name, string? birthDate, string? documentNumber)
        {
            var entity = new Patient()
            {
                Id = Guid.NewGuid(),
                Name = name,
                BirthDate = birthDate,
                DocumentNumber = documentNumber
            };

            patients.Add(entity);

            return entity;
        }

        public Patient GetPatient(string? documentNumber)
        {
            if (documentNumber != null)
            {
                foreach (var patient in patients)
                {
                    if (patient.DocumentNumber == documentNumber)
                        return patient;
                }
            }

            return null;
        }
    }
}