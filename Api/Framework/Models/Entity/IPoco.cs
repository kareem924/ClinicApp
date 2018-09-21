namespace Framework.Models.Entity
{
    
     public interface IPoco<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        bool IsDeleted { get; set; }
    }
}