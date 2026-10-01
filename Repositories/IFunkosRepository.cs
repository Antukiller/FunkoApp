
using FunkoApp.Models;

namespace FunkoApp.Repositories;

/// <summary>
/// Contrato de acceso a datos de productos (almacenamiento en memoria).
/// </summary>
/// <remarks>
/// Toda la colección de trabajo son solo productos activos
/// (la eliminación lógica con <see cref="Producto.DeletedAt"/> la oculta el repositorio).
/// </remarks>
public interface IFunkosRepository
{
    /// <summary>
    /// Devuelve todos los productos activos.
    /// </summary>
    IReadOnlyList<Funko> GetAll();

    /// <summary>
    /// Devuelve un producto activo por su identificador, o <c>null</c> si no existe o está eliminado.
    /// </summary>
    Funko? GetById(long id);

    /// <summary>
    /// Inserta un producto asignándole <see cref="Producto.Id"/> y <see cref="Producto.CreatedAt"/>.
    /// </summary>
    /// <param name="producto">Producto a crear.</param>
    /// <returns>El producto ya almacenado.</returns>
    Funko Add(Funko producto);

    /// <summary>
    /// Actualiza los campos de un producto existente.
    /// </summary>
    /// <returns>El producto actualizado, o <c>null</c> si no existe o está eliminado.</returns>
    Funko? Update(long id, Funko producto);

    /// <summary>
    /// Actualiza solo el precio de un producto (PATCH).
    /// </summary>
    /// <returns>El producto actualizado, o <c>null</c> si no existe o está eliminado.</returns>
    Funko? UpdatePrecio(long id, decimal precio);

    /// <summary>
    /// Marca un producto como eliminado (borrado lógico).
    /// </summary>
    /// <returns><c>true</c> si se ha eliminado; <c>false</c> si no existía o ya estaba eliminado.</returns>
    bool SoftDelete(long id);

    /// <summary>
    /// Busca productos activos cuyo nombre contenga el texto indicado.
    /// </summary>
    IReadOnlyList<Funko> Search(string? nombre);

    /// <summary>
    /// Devuelve los productos activos de una categoría (sin distinguir mayúsculas/minúsculas).
    /// </summary>
    IReadOnlyList<Funko> GetByCategoria(string categoria);

    /// <summary>
    /// Devuelve los productos activos cuyo precio está entre <paramref name="min"/> y <paramref name="max"/>, ordenados por precio.
    /// </summary>
    IReadOnlyList<Funko> GetByPrecio(decimal? min, decimal? max);

    /// <summary>
    /// Devuelve los productos activos ordenados por precio.
    /// </summary>
    /// <param name="asc"><c>true</c> ascendente, <c>false</c> descendente.</param>
    IReadOnlyList<Funko> GetOrdered(bool asc);

    /// <summary>
    /// Agrupa los productos activos por categoría.
    /// </summary>
    Dictionary<string, List<Funko>> GroupByCategoria();
    
}