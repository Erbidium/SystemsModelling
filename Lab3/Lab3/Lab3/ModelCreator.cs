using Lab3.Delays;
using Lab3.Elements;
using Lab3.Enums;
using Lab3.ItemFactories;
using Lab3.Items;
using Lab3.NextElement;
using Lab3.Queues;

namespace Lab3;

public static class ModelCreator
{
    public static NetMO CreateBankModel()
    {
        var createDelay = new ExponentialDelay(0.5);
        var processDelay = new ExponentialDelay(0.3);

        var create = new Create(createDelay, new SimpleItemFactory()) { Name = "CARS_CREATOR", TimeNext = 0.1 };

        var smo1 = new SystemMO(processDelay, 1) { Name = "CASHIER1" };
        var smo2 = new SystemMO(processDelay, 1) { Name = "CASHIER2" };

        var processedItemSmo1 = new SimpleItem();
        smo1.Devices[0].IsServing = true;
        smo1.Devices[0].TimeNext = new NormalDelay(1, 0.3).Generate(null!);
        smo1.Devices[0].ProcessedItem = processedItemSmo1;
        
        var processedItemSmo2 = new SimpleItem();
        smo2.Devices[0].IsServing = true;
        smo2.Devices[0].TimeNext = new NormalDelay(1, 0.3).Generate(null!);
        smo2.Devices[0].ProcessedItem = processedItemSmo2;

        create.NextElement = new PriorityNextElementPicker(new List<(Element Element, int Priority)> { (smo1, 2), (smo2, 1) });

        var elements = new List<Element> { create, smo1, smo2 };
        smo1.Queue = new BankQueue(new []{ new SimpleItem(), new SimpleItem()}, 3) { Elements = elements };
        smo2.Queue = new BankQueue(new []{ new SimpleItem(), new SimpleItem()}, 3) { Elements = elements };

        return new NetMO(elements);
    }

    public static NetMO CreateHospitalModel()
    {
        var arrivalHospitalReceptionDepartment = new Create(new ExponentialDelay(15), new PatientFactory()) { Name = "PATIENTS_CREATOR" };
        var doctorsOnDuty = new SystemMO(new PatientRegistrationDelay(), 2)
        {
            Name = "DOCTORS_ON_DUTY",
            Queue = new DoctorPriorityQueue(PatientType.ReadyForTreatment)
        };
        var hospitalWards = new SystemMO(new UniformDelay(3, 8), 3) { Name = "HOSPITAL_WARDS" };
        var transferFromReceptionDepartmentToLaboratory = new SystemMO(new UniformDelay(2, 5), 200)
        {
            Name = "TRANSFER_FROM_RECEPTION_DEPARTMENT_TO_LABORATORY",
            Queue = new Queue(0)
        };
        var laboratoryRegister = new SystemMO(new ErlangDelay(4.5, 3), 1){ Name = "LABORATORY_REGISTER" };
        var analysisInLaboratory = new SystemMO(new ErlangDelay(4, 2), 2){ Name = "ANALYSIS_IN_LABORATORY" };
        var transferFromLaboratoryToReceptionDepartment = new SystemMO(new UniformDelay(2, 5), 200)
        {
            Name = "TRANSFER_FROM_LABORATORY_TO_RECEPTION_DEPARTMENT",
            Queue = new Queue(0)
        };
        
        var endPatientsServing = new EndPatientsServing(new ConstantDelay(0)){ Name = "END_PATIENTS_SERVING" };

        arrivalHospitalReceptionDepartment.NextElement = new OneNextElementPicker(doctorsOnDuty);
        doctorsOnDuty.NextElement = new NextElementByPatientTypePicker(
            new List<(Element Element, PatientType PatientType)>
            {
                (hospitalWards, PatientType.ReadyForTreatment),
                (transferFromReceptionDepartmentToLaboratory, PatientType.WantToHospitalButHaveToPassPreliminaryExamination),
                (transferFromReceptionDepartmentToLaboratory, PatientType.OnlyUndergoPreliminaryExamination)
            });

        hospitalWards.NextElement = new OneNextElementPicker(endPatientsServing);
        transferFromReceptionDepartmentToLaboratory.NextElement = new OneNextElementPicker(laboratoryRegister);
        laboratoryRegister.NextElement = new OneNextElementPicker(analysisInLaboratory);
        analysisInLaboratory.NextElement = new NextElementAfterAnalysisPicker(transferFromLaboratoryToReceptionDepartment, endPatientsServing);
        transferFromLaboratoryToReceptionDepartment.NextElement = new OneNextElementPicker(doctorsOnDuty);

        var elements = new List<Element> { arrivalHospitalReceptionDepartment, doctorsOnDuty, hospitalWards, transferFromReceptionDepartmentToLaboratory, laboratoryRegister, analysisInLaboratory, transferFromLaboratoryToReceptionDepartment, endPatientsServing };

        return new NetMO(elements);
    }
}