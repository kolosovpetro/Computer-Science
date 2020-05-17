namespace DVDRentalStore.Misc
{
    public class ClientHistoryQueryObject
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int? AgeRestriction { get; set; }
        public int MovieId { get; set; }
        public float? Price { get; set; }
        public int ClientId { get; set; }
    }
}
