using ActiveRecordPattern.DBActions;

namespace ActiveRecordPattern.CopyRecordEntity
{
    interface ICopyRecord : IMovieEntity
    {
        // properties

        int CopyId { get; }
        bool Available { get; }

        // setters

        void ChangeCopyId(int newId);
        void ChangeAvailable(bool newState);
        void ChangeMovieId(int newId);


    }
}
