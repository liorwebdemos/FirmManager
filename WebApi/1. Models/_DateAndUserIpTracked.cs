namespace PopDb.Models
{
    public abstract class DateAndUserIpTracked
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