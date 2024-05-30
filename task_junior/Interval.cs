namespace task_junior
{
    internal class Interval
    {
        public string startTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;

        public Interval(string start, string stop)
        {
            startTime = start;
            EndTime = stop;
        }
    }
}
