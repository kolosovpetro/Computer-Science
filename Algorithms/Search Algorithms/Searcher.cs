using SearchAlgorithms.Interfaces;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms
{
    class Searcher
    {
        AbstractSearch AbsSearch;
        IDataLogger Logger;

        public void SetSearch(AbstractSearch newAbsSearch)
        {
            AbsSearch = newAbsSearch;
        }

        public void SetDataLogger(IDataLogger newLogger)
        {
            Logger = newLogger;
        }

        public void DoSearchAndBenchmark()
        {
            AbsSearch.DoSearch();
            Logger.GetBenchmark();
        }
    }
}
