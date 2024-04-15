namespace Scorpio.Data
{
    public class SoftDeleteEntity : ISoftDelete
    {
        public SoftDeleteEntity(bool isDeleted) => IsDeleted = isDeleted;

        public bool IsDeleted { get; set; }
    }
}