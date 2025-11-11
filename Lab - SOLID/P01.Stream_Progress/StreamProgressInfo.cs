namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamble streamble;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamble streamble)
        {
            this.streamble = streamble;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamble.BytesSent * 100) / this.streamble.Length;
        }
    }
}
