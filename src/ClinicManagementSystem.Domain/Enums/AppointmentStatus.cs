namespace ClinicManagementSystem.Domain.Enums;

public enum AppointmentStatus
{
    Pending = 0,
    Processing = 1,
    AwaitingVitals = 2,
    InConsultation = 3,
    Completed = 4,
    Cancelled = 5,
    NoShow = 6
}