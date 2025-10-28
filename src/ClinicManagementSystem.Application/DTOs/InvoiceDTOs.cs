namespace ClinicManagementSystem.Application.DTOs;

public class InvoiceCreateDto
{
    public Guid PatientId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime InvoiceDate { get; set; }
}

public class InvoiceUpdateDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime InvoiceDate { get; set; }
}

public class InvoiceReadDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; } // optional, include via join
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime InvoiceDate { get; set; }
}
