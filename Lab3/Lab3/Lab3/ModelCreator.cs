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
    public static NetMO CreateShopModel()
    {
        var createDelay = new ExponentialDelay(0.5);
        var processDelay = new ExponentialDelay(0.3);

        var create = new Create(createDelay, new SimpleItemFactory()) { Name = "CARS_CREATOR", TimeNext = 0.1 };

        var smo1 = new SystemMO(processDelay, 1) { Name = "CASHIER1" };
        var smo2 = new SystemMO(processDelay, 1) { Name = "CASHIER2" };

        smo1.Devices[0].IsServing = true;
        smo1.Devices[0].TimeNext = new NormalDelay(1, 0.3).Generate(null!);
        
        smo2.Devices[0].IsServing = true;
        smo2.Devices[0].TimeNext = new NormalDelay(1, 0.3).Generate(null!);

        create.NextElement = new PriorityNextElementPicker(new List<(Element Element, int Priority)> { (smo1, 2), (smo2, 1) });

        var elements = new List<Element> { create, smo1, smo2 };
        smo1.Queue = new BankQueue(new []{ new SimpleItem(), new SimpleItem()}, 3) { Elements = elements };
        smo2.Queue = new BankQueue(new []{ new SimpleItem(), new SimpleItem()}, 3) { Elements = elements };

        return new NetMO(elements);
    }

    public static NetMO CreateHospitalModel()
    {
        // Час між прибуттями в приймальне відділення
        var arrivalHospitalReceptionDepartment = new Create(new ExponentialDelay(15), new PatientFactory()) { Name = "PATIENTS_CREATOR" };
        var doctorsOnDuty = new SystemMO(new PatientRegistrationDelay(), 2)
        {
            Name = "DOCTORS_ON_DUTY",
            Queue = new DoctorPriorityQueue(PatientType.ReadyForTreatment)
        };
        var hospitalWards = new SystemMO(new UniformDelay(3, 8), 3) { Name = "HOSPITAL_WARDS" };
        var transferFromReceptionDepartmentToLaboratory = new SystemMO(new UniformDelay(2, 5), 1) { Name = "TRANSFER_FROM_RECEPTION_DEPARTMENT_TO_LABORATORY" };
        var laboratoryRegister = new SystemMO(new ErlangDelay(4.5, 3), 1){ Name = "LABORATORY_REGISTER" };
        var analysisInLaboratory = new SystemMO(new ErlangDelay(4, 2), 2){ Name = "ANALYSIS_IN_LABORATORY" };

        var transferFromLaboratoryToReceptionDepartment = new UniformDelay(2, 5);

        arrivalHospitalReceptionDepartment.NextElement = new OneNextElementPicker(doctorsOnDuty);
        doctorsOnDuty.NextElement = new NextElementByPatientTypePicker(
            new List<(Element Element, PatientType PatientType)>
            {
                (hospitalWards, PatientType.ReadyForTreatment),
                (transferFromReceptionDepartmentToLaboratory, PatientType.UndergoPreliminaryExamination),
                (transferFromReceptionDepartmentToLaboratory, PatientType.JustGotToHospital)
            });

        transferFromReceptionDepartmentToLaboratory.NextElement = new OneNextElementPicker(laboratoryRegister);
        laboratoryRegister.NextElement = new OneNextElementPicker(analysisInLaboratory);

        var elements = new List<Element> { arrivalHospitalReceptionDepartment, doctorsOnDuty, hospitalWards, transferFromReceptionDepartmentToLaboratory, laboratoryRegister, analysisInLaboratory };

        return new NetMO(elements);
    }
}