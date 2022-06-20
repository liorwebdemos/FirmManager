namespace PopDb.Models
{
    public enum Gender // not the best of practices to start at 1
    {
        Male = 1,
        Female = 2
    }

    /// <summary></summary>
    public class WorkerModel
    {
        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public int? IsraeliIdentityNumber { get; set; }

        /// <summary></summary>
        public string? FirstName { get; set; }

        /// <summary></summary>
        public string? LastName { get; set; }

        /// <summary></summary>
        public Gender? Gender { get; set; }

        /// <summary></summary>
        public DateTimeOffset? JobStartDate { get; set; }

        /// <summary></summary>
        public DateTimeOffset? JobEndDate { get; set; }

        /// <summary></summary>
        public string? JobDescription { get; set; }

        /// <summary></summary>
        /// https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#fully-defined-relationships
        public DepartmentModel? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}