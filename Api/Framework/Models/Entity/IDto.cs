namespace Framework.Models.Entity
{
     public interface IDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }

    }
}