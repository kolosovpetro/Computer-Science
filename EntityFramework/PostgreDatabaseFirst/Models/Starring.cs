namespace PostgreDatabaseFirst.Models
{
    public partial class Starring
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public virtual Actors Actor { get; set; }
        public virtual Movies Movie { get; set; }
    }
}
