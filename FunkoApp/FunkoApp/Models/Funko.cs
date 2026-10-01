using FunkoApp.Enum;

namespace FunkoApp.Models;

public record Funko {
    
    public long Id { get; init; }

    public string Nombre { get; init; } = string.Empty;
    
    public decimal Precio { get; init; }
    
    public int Stock { get; init; }
    
    public Categoria Categoria { get; init; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; init; }
    
    public DateTime? DeletedAt { get; init; }

    public bool IsDeleted => DeletedAt is null;
}