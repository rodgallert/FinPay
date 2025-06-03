﻿namespace Domain.Entities;
public abstract class BaseEntity
{
    public long Id { get; set; }
    public Guid PublicId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}
