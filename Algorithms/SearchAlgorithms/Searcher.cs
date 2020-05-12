using SearchAlgorithms.Interfaces;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms
{
    internal class Searcher
    {
        private AbstractSearch _search;
        private IDataLogger _logger;

        public void SetSearch(AbstractSearch search)
        {
            _search = search;
        }

        public void SetDataLogger(IDataLogger logger)
        {
            _logger = logger;
        }

        public void SearchAndBenchmark()
        {
            _search.DoSearch();
            _logger.GetBenchmark();
        }
    }
}
