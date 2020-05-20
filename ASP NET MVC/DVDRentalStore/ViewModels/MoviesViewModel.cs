namespace DVDRentalStore.ViewModels
{
    public class MoviesViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int? AgeRestriction { get; set; }
        public int MovieId { get; set; }
        public float? Price { get; set; }
        public bool? Available { get; set; }
    }
}
