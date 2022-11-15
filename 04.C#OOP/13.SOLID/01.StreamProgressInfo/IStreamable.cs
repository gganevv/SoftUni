namespace StreamProgressInfo
{
    public interface IStreamable
    {
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
