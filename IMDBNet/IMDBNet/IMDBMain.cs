using Newtonsoft.Json;
using System.Net;

namespace IMDBNet
{
    public class IMDBMain
    {
        public static IMDBMovie GetIMDBMovie(string title)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetMovieFromTitle(title));
            return movie;
        }
        public static IMDBMovie GetIMDBMovieFromID(string id)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetIMDBMovieDataFromID(id))
            return movie;
        }
        public static IMDBMovieSearchResult SearchIMDBMovie(string title, int page)
        {
            IMDBMovieSearchResult movie = DeserializeIMDBMovieSearchResult(SearchForTitle(title, page));
            return movie;
        }

        static IMDBMovie DeserializeIMDBMovie(string json)
        {
            IMDBMovie deserializedProduct = JsonConvert.DeserializeObject<IMDBMovie>(json);
            return deserializedProduct;
        }
        static IMDBMovieSearchResult DeserializeIMDBMovieSearchResult(string json)
        {
            IMDBMovieSearchResult deserializedProduct = JsonConvert.DeserializeObject<IMDBMovieSearchResult>(json);
            return deserializedProduct;
        }
        static string GetMovieFromTitle(string input)
        {
            return GetDataFromOMDB("t=" + input + "&tomatoes = true");
        }
        static string GetIMDBMovieDataFromID(string input)
        {
            return GetDataFromOMDB("i=" + input + "&tomatoes = true");
        }
        static string GetDataFromOMDB(string input)
        {
            WebClient client = new WebClient();
            byte[] data = client.DownloadData("http://www.omdbapi.com/?&" + input);
            string output = System.Text.Encoding.Default.GetString(data);
            return output;
        }
    }
}
