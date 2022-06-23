namespace WebApi.Models
{
    public abstract class TrackedModel
    {
        /// <summary></summary>
        public DateTimeOffset? CreatedDate { get; set; }

        /// <summary></summary>
        public string? CreatedUserIp { get; set; }

        /// <summary></summary>
        public DateTimeOffset? UpdatedDate { get; set; }

        /// <summary></summary>
        public string? UpdatedUserIp { get; set; }
    }
}