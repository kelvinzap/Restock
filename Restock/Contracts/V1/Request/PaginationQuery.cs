namespace Restock.Contracts.v1.Request;

public class PaginationQuery
{
    public PaginationQuery()
    {
        PageNumber = 1;
        PageSize = 20;
    }
    
    public PaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}