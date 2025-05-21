namespace Prescriptions.DTOs;

public class PatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<PrescriptionDetailsDto> Prescriptions { get; set; }
}

public class PrescriptionDetailsDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentDetailsDto> Medicaments { get; set; }
    public DoctorDetailsDto Doctor { get; set; }
}

public class DoctorDetailsDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class MedicamentDetailsDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}