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
        public List<WorkerModel>? Workers { get; set; } // note: going here against ef core's explicit instructions ("Collection navigations, which contain references to multiple related entities, should always be non-nullable. An empty collection means that no related entities exist, but the list itself should never be null."); this project has a core issue of not having independent models for different usages... need to fix this up.
    }
}