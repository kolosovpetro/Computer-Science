using SortAlgorithms.Interfaces;
using SortAlgorithms.SortMethods;

namespace SortAlgorithms
{
    class Sorter
    {
        public AbstractSort AbsSort { get; private set; }
        public IDataLogger DataLogger { get; private set; }

        public void SetAbsSort(AbstractSort newAbsSort)
        {
            AbsSort = newAbsSort;
        }

        public void SetDataLogger(IDataLogger newDataLogger)
        {
            DataLogger = newDataLogger;
        }
    }
}
