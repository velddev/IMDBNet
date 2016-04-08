using System.Collections.Generic;

namespace IMDBNet
{
    public class IMDBMovieSearchResult
    {
        public List<IMDBMovieSearchResultItem> search = new List<IMDBMovieSearchResultItem>();
        public int totalResults;

        public bool response;
        public string error;
    }
}
