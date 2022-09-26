namespace Api.Helpers
{
    public class StudentParams : UserParams
    {
        public string nameFilter { get; set; } = "";
        public DateTime dateFilter { get; set; } = new DateTime(1900, 1, 1);

        public string statusFilter { get; set; } = "";

        public string selectionFilter { get; set; } = "";

        public string OrderBy { get; set; } = "Name";
    }
}
