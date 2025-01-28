namespace IMLO.Entity.Exceptions;

public class StoreNotFonudException : NotFoundException
{
    public StoreNotFonudException(int storeId) : base($"The store with the identifier {storeId} was not found.")
    {
    }
}