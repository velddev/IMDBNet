using Newtonsoft.Json;
using System.Net;

namespace IMDBNet
{
    public class IMDBNet
    {
        public IMDBMovie GetIMDBMovie(string title)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetMovieFromTitle(title));
            return movie;
        }
        public IMDBMovieSearchResult SearchIMDBMovie(string title, int page)
        {
            IMDBMovieSearchResult movie = DeserializeIMDBMovieSearchResult(SearchForTitle(title, page));
            return movie;
        }

        IMDBMovie DeserializeIMDBMovie(string json)
        {
            IMDBMovie deserializedProduct = JsonConvert.DeserializeObject<IMDBMovie>(json);
            return deserializedProduct;
        }
        IMDBMovieSearchResult DeserializeIMDBMovieSearchResult(string json)
        {
            IMDBMovieSearchResult deserializedProduct = JsonConvert.DeserializeObject<IMDBMovieSearchResult>(json);
            return deserializedProduct;
        }
        string GetMovieFromTitle(string input, string[] arguments = null)
        {
            WebClient client = new WebClient();
            byte[] data = client.DownloadData("http://www.omdbapi.com/?&t=" + input + "&tomatoes=true");
            string output = System.Text.Encoding.Default.GetString(data);
            return output;
        }
        string SearchForTitle(string input, int page)
        {
            WebClient client = new WebClient();
            byte[] data = client.DownloadData("http://www.omdbapi.com/?&s=" + input + "&tomatoes=true&page=" + page);
            string output = System.Text.Encoding.Default.GetString(data);
            return output;
        }
    }
}
