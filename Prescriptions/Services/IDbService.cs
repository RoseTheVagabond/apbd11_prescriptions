using Prescriptions.DTOs;

namespace Prescriptions.Services;

public interface IDbService
{
    Task<int> CreatePrescriptionAsync(NewPrescriptionDto prescriptionDto);
    Task<PatientDto> GetPatientDetailsAsync(int idPatient);
}