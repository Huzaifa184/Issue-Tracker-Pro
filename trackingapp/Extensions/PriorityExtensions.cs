using trackingapp.Models;

namespace trackingapp.Extensions
{
    public static class PriorityExtensions
    {
        static readonly Dictionary<Priority, string> _priorityCssClasses = new()
        {
            [Priority.High] = "badge badge-danger bg-danger",
            [Priority.Medium] = "badge badge-warning bg-warning text-dark",
            [Priority.Low] = "badge badge-success bg-success"
        };

        public static string ToCssClass(this Priority priority) => _priorityCssClasses[priority];
         
    }
}
