using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prescriptions.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [ForeignKey("Patient")]
    public int IdPatient { get; set; }
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }
}