namespace ErrorLoggingMiddleware__real_world_scenario.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string RequestPath { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime LogTime { get; set; }
    }
}
