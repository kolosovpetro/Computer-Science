namespace DVDRentalStore.Models
{
    public partial class StarringModel
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public virtual ActorsModel Actor { get; set; }
        public virtual MoviesModel Movie { get; set; }
    }
}
