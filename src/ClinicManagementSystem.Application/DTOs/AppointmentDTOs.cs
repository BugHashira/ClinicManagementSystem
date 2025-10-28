namespace ClinicManagementSystem.Application.DTOs;

public class AppointmentCreateDto
{
    public Guid PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; }
    public string DoctorName { get; set; }
}

public class AppointmentUpdateDto
{
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; }
    public string DoctorName { get; set; }
}

public class AppointmentReadDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; } // optional, include via join
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; }
    public string DoctorName { get; set; }
}
