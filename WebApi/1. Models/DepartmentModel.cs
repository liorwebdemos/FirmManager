namespace PopDb.Models
{
    /// <summary></summary>
    public class DepartmentModel
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
        public DateTimeOffset? InsertDate { get; set; }

        /// <summary></summary>
        public string? InsertUserIp { get; set; }

        /// <summary></summary>
        public DateTimeOffset? LastUpdateDate { get; set; }

        /// <summary></summary>
        public string? LastUpdateUserIp { get; set; }

        /// <summary></summary>
        public ICollection<WorkerModel>? Workers { get; set; }
    }
}