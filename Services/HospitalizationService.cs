using Pps.Avpratica.Builder;
using Pps.Avpratica.Composites;

namespace Pps.Avpratica.Services
{
    public class HospitalizationService
    {
        public Hospitalization Register(
            string? patientDocumentNumber,
            string? healthcareMethodName
        )
        {
            var hospitalizationBuilder = HospitalizationBuilder.GetInstance();

            var patientBuilder = PatientBuilder.GetInstance();

            var patient = patientBuilder.GetPatient(patientDocumentNumber);

            var hospitalization = hospitalizationBuilder.CreateHospitalization(patient, healthcareMethodName);

            return hospitalization;
        }

        public Hospitalization Find(string? patientDocumentNumber)
        {
            var hospitalizationBuilder = HospitalizationBuilder.GetInstance();
            var hospitalization = hospitalizationBuilder.GetHospitalization(patientDocumentNumber);
            
            return hospitalization;
        }

        public int TotalOfEquipments(string? patientDocumentNumber)
        {
            var composite = EquipmentComposite.GetInstance();
            var hospitalizationBuilder = HospitalizationBuilder.GetInstance();
            var hospitalization = hospitalizationBuilder.GetHospitalization(patientDocumentNumber);
    
            var totalOfEquipments = composite.GetEquipmentAmount(hospitalization);

            return totalOfEquipments;
        }
    }
}