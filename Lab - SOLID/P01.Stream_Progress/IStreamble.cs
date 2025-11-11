namespace P01.Stream_Progress
{

    public interface IStreamble
    {

        public int Length { get; }

        public int BytesSent { get; }
    }
}
