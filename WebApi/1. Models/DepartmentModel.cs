namespace WebApi.Models
{
    /// <summary></summary>
    public class DepartmentModel : TrackedModel, IDbEntity
    {
        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public string? Title { get; set; }

        /// <summary></summary>
        public string? Description { get; set; }

        /// <summary></summary>
        public bool? IsActive { get; set; }

        /// <summary></summary>
        public virtual List<WorkerModel> Workers { get; set; } = null!;
    }
}