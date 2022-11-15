namespace StreamProgressInfo
{
    public class File : Stream
    {
        private string name;

        public File(string name, int length, int bytesSent)
            : base(length, bytesSent)
        {
            this.name = name;
        }
    }
}
