using Prescriptions.Models;

namespace Prescriptions.DTOs;

public class NewPrescriptionDto
{
    public PatientDto Patient { get; set; }
    public List<MedicamentDto> MedicamentsDto { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class PatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
}