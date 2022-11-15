namespace StreamProgressInfo
{
    public class Stream : IStreamable
    {
        public Stream(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
