// See https://aka.ms/new-console-template for more information
using Pps.Avpratica;
using Pps.Avpratica.Composites;
using Pps.Avpratica.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        bool dontStop = true;
        while (dontStop)
        {
            Console.WriteLine("Escolha a opção a ser utilizada:");
            Console.WriteLine("1 - Registrar paciente");
            Console.WriteLine("2 - Registrar Internação ou atendimento");
            Console.WriteLine("3 - Adicionar equipamento utilizado durante atendimento/internação");
            Console.WriteLine("4 - Verificar quantidade de equipamento utilizado durante atendimento/internação");
            Console.WriteLine("5 - Cobrar atendimento");
            Console.WriteLine("6 - Buscar atendimento");
            Console.WriteLine("9 - Sair");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                var service = new PatientService();
                Console.WriteLine("Nome: ");
                string name = Console.ReadLine();
                Console.WriteLine("Data de nascimento: ");
                string birthDate = Console.ReadLine();
                Console.WriteLine("Número de documento: ");
                string documentNumber = Console.ReadLine();

                var patient = service.Register(name, birthDate, documentNumber);

                Console.WriteLine("Deseja realizar atendimento? (S/N): ");
                string shouldGoTreatment = Console.ReadLine();

                if (shouldGoTreatment == "S")
                {
                    Console.WriteLine("Qual tipo de atendimento?: ");
                    Console.WriteLine("1 - Internação");
                    Console.WriteLine("2 - Atendimento normal");
                    var treatmentType = Int32.Parse(Console.ReadLine());
                    if (treatmentType == 1)
                    {
                        Console.WriteLine("Plano de Saúde (SUS/UNIMED/Amil): ");
                        string healthcareMethodName = Console.ReadLine();

                        var hospitalizationService = new HospitalizationService();
                        hospitalizationService.Register(patient.DocumentNumber, healthcareMethodName);
                    }
                    if (treatmentType == 2)
                    {
                        Console.WriteLine("Plano de Saúde (SUS/UNIMED/Amil): ");
                        string healthcareMethodName = Console.ReadLine();

                        var treatmentService = new TreatmentService();
                        treatmentService.Register(patient.DocumentNumber, healthcareMethodName);
                    }
                }
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Qual tipo de atendimento?: ");
                Console.WriteLine("1 - Internação");
                Console.WriteLine("2 - Atendimento normal");
                var treatmentType = Int32.Parse(Console.ReadLine());

                if (treatmentType == 1)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();
                    Console.WriteLine("Plano de Saúde (SUS/UNIMED/Amil): ");
                    string healthcareMethodName = Console.ReadLine();

                    var hospitalizationService = new HospitalizationService();

                    hospitalizationService.Register(documentNumber, healthcareMethodName);
                }
                else if (treatmentType == 2)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();
                    Console.WriteLine("Plano de Saúde (SUS/UNIMED/Amil): ");
                    string healthcareMethodName = Console.ReadLine();

                    var treatmentService = new TreatmentService();

                    treatmentService.Register(documentNumber, healthcareMethodName);
                }
            }
            else if(opcao == 3)
            {
                //Opções hardcoded devido a falta de maleabilidade. Tratando tal sistema como PoC
                Console.WriteLine("Qual tipo de atendimento?: ");
                Console.WriteLine("1 - Internação");
                Console.WriteLine("2 - Atendimento normal");
                var treatmentType = Int32.Parse(Console.ReadLine());

                if (treatmentType == 1)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var hospitalizationService = new HospitalizationService();

                    var hospitalization = hospitalizationService.Find(documentNumber);

                    var composite = EquipmentComposite.GetInstance();

                    composite.Add(new Mask(){Registry = hospitalization});
                    composite.Add(new HeartRateMonitor(){Registry = hospitalization});
                    composite.Add(new Syringe(){Registry = hospitalization});
                }
                else if (treatmentType == 2)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var treatmentService = new TreatmentService();

                    var treatment = treatmentService.Find(documentNumber);

                    var composite = EquipmentComposite.GetInstance();

                    composite.Add(new Mask(){Registry = treatment});
                    composite.Add(new HeartRateMonitor(){Registry = treatment});
                    composite.Add(new Syringe(){Registry = treatment});
                }
            }
            else if (opcao == 4)
            {
                Console.WriteLine("Qual tipo de atendimento?: ");
                Console.WriteLine("1 - Internação");
                Console.WriteLine("2 - Atendimento normal");
                var treatmentType = Int32.Parse(Console.ReadLine());

                if (treatmentType == 1)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var hospitalizationService = new HospitalizationService();


                    Console.WriteLine(hospitalizationService.TotalOfEquipments(documentNumber));
                }
                else if (treatmentType == 2)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var treatmentService = new TreatmentService();

                    Console.WriteLine(treatmentService.TotalOfEquipments(documentNumber));
                }
            }
            else if(opcao == 5)
            {
                Console.WriteLine("Qual tipo de atendimento?: ");
                Console.WriteLine("1 - Internação");
                Console.WriteLine("2 - Atendimento normal");
                var treatmentType = Int32.Parse(Console.ReadLine());

                if (treatmentType == 1)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var hospitalizationService = new HospitalizationService();

                    var hospitalization = hospitalizationService.Find(documentNumber);

                    Console.WriteLine(hospitalization.HealthcareMethod.Charge());
                }
                else if (treatmentType == 2)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var treatmentService = new TreatmentService();

                    var treatment = treatmentService.Find(documentNumber);

                    Console.WriteLine("Resultado da operação: " + treatment.HealthcareMethod.Charge());
                }
            }
            else if(opcao == 6)
            {
                Console.WriteLine("Qual tipo de atendimento?: ");
                Console.WriteLine("1 - Internação");
                Console.WriteLine("2 - Atendimento normal");
                var treatmentType = Int32.Parse(Console.ReadLine());

                if (treatmentType == 1)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var hospitalizationService = new HospitalizationService();

                    var hospitalization = hospitalizationService.Find(documentNumber);

                    Console.WriteLine("Nome: " + hospitalization.Patient.Name);
                    Console.WriteLine("Data de nascimento: " + hospitalization.Patient.BirthDate);
                    Console.WriteLine("CPF: " + hospitalization.Patient.DocumentNumber);
                }
                else if (treatmentType == 2)
                {
                    Console.WriteLine("Numero do documento do paciente: ");
                    string documentNumber = Console.ReadLine();

                    var treatmentService = new TreatmentService();

                    var treatment = treatmentService.Find(documentNumber);

                    Console.WriteLine("Nome: " + treatment.Patient.Name);
                    Console.WriteLine("Data de nascimento: " + treatment.Patient.BirthDate);
                    Console.WriteLine("CPF: " + treatment.Patient.DocumentNumber);
                }
            }
            else if (opcao == 9)
            {
                dontStop = false;
            }
        }
    }
}