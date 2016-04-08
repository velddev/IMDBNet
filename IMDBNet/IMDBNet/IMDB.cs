using Newtonsoft.Json;
using System.Net;

namespace IMDBNet
{
    public class IMDB
    {
        public enum IMDBType { Error, Movie, Series, Episode};

        public static IMDBMovie GetMovie(string title)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, int year)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "y=" + year.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, IMDBType type)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "type=" + type.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, int year, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "y=" + year,
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, IMDBType type, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "type=" + type.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, bool fullPlot, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "plot=" + fullPlot.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovie(string title, bool fullPlot, IMDBType type, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + title,
            "plot=" + fullPlot.ToString(),
            "type=" + type.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }

        public static IMDBMovie GetMovieFromID(string id)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + id.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, int year)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "i=" + id.ToString(),
            "y=" + year
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + id.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, IMDBType type)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + id.ToString(),
            "type=" + type.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, int year, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "i=" + id.ToString(),
            "y=" + year,
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, IMDBType type, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "t=" + id.ToString(),
            "type=" + type.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, bool fullPlot, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "i=" + id.ToString(),
            "plot=" + fullPlot.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }
        public static IMDBMovie GetMovieFromID(string id, bool fullPlot, IMDBType type, bool tomatoes)
        {
            IMDBMovie movie = DeserializeIMDBMovie(GetDataFromOMDB(new string[] {
            "i=" + id.ToString(),
            "plot=" + fullPlot.ToString(),
            "type=" + type.ToString(),
            "tomatoes=" + tomatoes.ToString()
            }));
            return movie;
        }

        public static IMDBMovieSearchResult SearchMovie(string title)
        {
            IMDBMovieSearchResult movie = DeserializeIMDBMovieSearchResult(GetDataFromOMDB(new string[] {
            "s=" + title
            }));
            return movie;
        }
        public static IMDBMovieSearchResult SearchMovie(string title, int page)
        {
            IMDBMovieSearchResult movie = DeserializeIMDBMovieSearchResult(GetDataFromOMDB(new string[] {
            "s=" + title,
            "page=" + page
            }));
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

        static string GetDataFromOMDB(string[] args)
        {
            string input = "";
            for(int i = 0; i < args.Length; i++)
            {
                input += "&" + args[i];
            }
            WebClient client = new WebClient();
            byte[] data = client.DownloadData("http://www.omdbapi.com/?" + input);
            string output = System.Text.Encoding.Default.GetString(data);
            return output;
        }
    }
}
