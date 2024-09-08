namespace DigitalBank.Domain.Entities;

public class Entity
{
    public int Id { get; set; }

    public DateTime CreateddAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}