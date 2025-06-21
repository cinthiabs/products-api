namespace Products.Domain.Constants;

public static class ProcessNames
{
    public const string PROCESS_CREATE_PRODUCT = nameof(PROCESS_CREATE_PRODUCT);
    public const string PROCESS_GET_PRODUCTS = nameof(PROCESS_GET_PRODUCTS);
    public const string PROCESS_REMOVE_PRODUCT = nameof(PROCESS_REMOVE_PRODUCT);
    public const string PROCESS_GET_PRODUCT_BY_ID = nameof(PROCESS_GET_PRODUCT_BY_ID);
}

public static class ErrorsNames
{
    public const string ERROR_CREATE_PRODUCT = "Error create new product";
    public const string ERROR_GET_PRODUCTS = "Error getting products";
    public const string INVALID_PRODUCTS = "Invalid code";
    public const string ERROR_REMOVE_PRODUCT = "Error removing product ";
}

public static class Logs
{
    public const string LOG_ERROR = "Process:{Process} Message:{Menssage} Error:{Error}";
}
