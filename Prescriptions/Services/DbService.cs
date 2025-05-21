using Prescriptions.DTOs;

namespace Prescriptions.Services;

public class DbService : IDbService
{
    public Task<int> CreatePrescriptionAsync(NewPrescriptionDto prescriptionDto)
    {
        throw new NotImplementedException();
    }

    public Task<PatientDto> GetPatientDetailsAsync(int idPatient)
    {
        throw new NotImplementedException();
    }
}