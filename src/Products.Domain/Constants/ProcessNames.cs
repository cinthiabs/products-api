namespace Products.Domain.Constants;

public static class ProcessNames
{
    public const string PROCESS_CREATE_PRODUCT = nameof(PROCESS_CREATE_PRODUCT);
    public const string PROCESS_GET_PRODUCTS = nameof(PROCESS_GET_PRODUCTS);
}

public static class ErrorsNames
{
    public const string ERROR_CREATE_PRODUCT = "Error create new product";
    public const string ERROR_GET_PRODUCTS = "Error getting products";
}
