using Pps.Avpratica.Builder;
using Pps.Avpratica.Composites;

namespace Pps.Avpratica.Services
{
    public class TreatmentService
    {
        public Treatment Register(
            string? patientDocumentNumber,
            string? healthcareMethodName
        )
        {
            var treatmentBuilder = TreatmentBuilder.GetInstance();

            var patientBuilder = PatientBuilder.GetInstance();

            var patient = patientBuilder.GetPatient(patientDocumentNumber);

            var treatment = treatmentBuilder.CreateTreatment(patient, healthcareMethodName);

            return treatment;
        }

        public Treatment Find(string? patientDocumentNumber)
        {
            var treatmentBuilder = TreatmentBuilder.GetInstance();
            var treatment = treatmentBuilder.GetTreatment(patientDocumentNumber);

            return treatment;
        }

        public int TotalOfEquipments(string? patientDocumentNumber)
        {
            var composite = EquipmentComposite.GetInstance();
            var treatmentBuilder = TreatmentBuilder.GetInstance();
            var treatment = treatmentBuilder.GetTreatment(patientDocumentNumber);
    
            var totalOfEquipments = composite.GetEquipmentAmount(treatment);

            return totalOfEquipments;
        }
    }
}