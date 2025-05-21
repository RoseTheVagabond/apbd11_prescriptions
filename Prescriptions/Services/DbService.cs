using Microsoft.EntityFrameworkCore;
using Prescriptions.Data;
using Prescriptions.DTOs;
using Prescriptions.Models;

namespace Prescriptions.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<int> CreatePrescriptionAsync(NewPrescriptionDto prescriptionDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Validate the prescription
            if (prescriptionDto.MedicamentsDto.Count > 10)
            {
                throw new ArgumentException("A prescription can include a maximum of 10 medications.");
            }

            if (prescriptionDto.DueDate < prescriptionDto.Date)
            {
                throw new ArgumentException("DueDate must be greater than or equal to Date.");
            }

            // Check if doctor exists
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == prescriptionDto.Doctor.IdDoctor);
            if (doctor == null)
            {
                throw new ArgumentException($"Doctor with ID {prescriptionDto.Doctor.IdDoctor} does not exist.");
            }

            // Check if all medicaments exist
            foreach (var medicamentDto in prescriptionDto.MedicamentsDto)
            {
                var medicament = await _context.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == medicamentDto.IdMedicament);
                if (medicament == null)
                {
                    throw new ArgumentException($"Medicament with ID {medicamentDto.IdMedicament} does not exist.");
                }
            }

            // Check if patient exists, if not, create a new one
            Patient patient;
            if (prescriptionDto.Patient.IdPatient != 0)
            {
                patient = await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == prescriptionDto.Patient.IdPatient);
                if (patient == null)
                {
                    // Create a new patient
                    patient = new Patient
                    {
                        FirstName = prescriptionDto.Patient.FirstName,
                        LastName = prescriptionDto.Patient.LastName,
                        BirthDate = prescriptionDto.Patient.BirthDate
                    };
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                // Create a new patient
                patient = new Patient
                {
                    FirstName = prescriptionDto.Patient.FirstName,
                    LastName = prescriptionDto.Patient.LastName,
                    BirthDate = prescriptionDto.Patient.BirthDate
                };
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            // Create the prescription
            var prescription = new Prescription
            {
                Date = prescriptionDto.Date,
                DueDate = prescriptionDto.DueDate,
                IdDoctor = prescriptionDto.Doctor.IdDoctor,
                IdPatient = patient.IdPatient
            };
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            // Add prescription medicaments
            foreach (var medicamentDto in prescriptionDto.MedicamentsDto)
            {
                var prescriptionMedicament = new PrescriptionMedicament
                {
                    IdPrescription = prescription.IdPrescription,
                    IdMedicament = medicamentDto.IdMedicament,
                    Details = medicamentDto.Description
                };
                _context.PrescriptionMedicaments.Add(prescriptionMedicament);
            }
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return prescription.IdPrescription;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<PatientDto> GetPatientDetailsAsync(int idPatient)
    {
        var patient = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .FirstOrDefaultAsync();

        if (patient == null)
        {
            throw new ArgumentException($"Patient with ID {idPatient} not found.");
        }

        var prescriptions = await _context.Prescriptions
            .Where(p => p.IdPatient == idPatient)
            .OrderBy(p => p.DueDate)
            .Select(p => new PrescriptionDetailsDto
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = new DoctorDetailsDto
                {
                    IdDoctor = p.IdDoctor,
                    FirstName = _context.Doctors.Where(d => d.IdDoctor == p.IdDoctor).Select(d => d.FirstName).FirstOrDefault(),
                    LastName = _context.Doctors.Where(d => d.IdDoctor == p.IdDoctor).Select(d => d.LastName).FirstOrDefault(),
                    Email = _context.Doctors.Where(d => d.IdDoctor == p.IdDoctor).Select(d => d.Email).FirstOrDefault()
                },
                Medicaments = _context.PrescriptionMedicaments
                    .Where(pm => pm.IdPrescription == p.IdPrescription)
                    .Select(pm => new MedicamentDetailsDto
                    {
                        IdMedicament = pm.IdMedicament,
                        Name = _context.Medicaments.Where(m => m.IdMedicament == pm.IdMedicament).Select(m => m.Name).FirstOrDefault(),
                        Description = _context.Medicaments.Where(m => m.IdMedicament == pm.IdMedicament).Select(m => m.Description).FirstOrDefault(),
                        Type = _context.Medicaments.Where(m => m.IdMedicament == pm.IdMedicament).Select(m => m.Type).FirstOrDefault(),
                        Dose = pm.Dose,
                        Details = pm.Details
                    }).ToList()
            })
            .ToListAsync();

        return new PatientDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = prescriptions
        };
    }
}