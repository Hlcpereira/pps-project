using Pps.Avpratica.Builder;

namespace Pps.Avpratica.Services
{
    public class PatientService
    {
        public Patient Register(string? name, string? birthDate, string? documentNumber)
        {
            var patientBuilder = PatientBuilder.GetInstance();

            var patient = patientBuilder.CreatePatient(name, birthDate, documentNumber);

            return patient;
        }
    }
}