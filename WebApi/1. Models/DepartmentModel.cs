namespace PopDb.Models
{
    /// <summary></summary>
    public class DepartmentModel : TrackedModel
    {
        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public string? Title { get; set; }

        /// <summary></summary>
        public string? Description { get; set; }

        /// <summary></summary>
        public bool? IsActive { get; set; }
    }
}