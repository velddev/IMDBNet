using System.Drawing;
using System.IO;
using System.Net;

namespace IMDBNet
{
    public class IMDBMovie
    {
        public string title;
        public string year;
        public string rated;
        public string released;
        public string runTime;
        public string genre;
        public string director;
        public string writer;
        public string actors;
        public string plot;
        public string language;
        public string country;
        public string awards;
        public string poster;
        public string metaScore;

        public string imdbRating;
        public string imdbVotes;
        public string imdbID;
        public string type;
        public string tomatoMeter;
        public string tomatoImage;
        public string tomatoRating;
        public string tomatoReviews;
        public string tomatoFresh;
        public string tomatoRotten;
        public string tomatoConsensus;
        public string tomatoUserMeter;
        public string tomatoUserRating;
        public string tomatoUserReviews;
        public string tomatoURL;
        public string dvd;
        public string boxOffice;
        public string production;
        public string website;

        public string response;
        public string error;

        Image downloadedPoster;

        public Image getPoster()
        {
            if(downloadedPoster == null)
            {
                WebClient client = new WebClient();
                byte[] data = client.DownloadData(poster);
                using (var ms = new MemoryStream(data))
                {
                    downloadedPoster = Image.FromStream(ms);
                    return downloadedPoster;
                }
            }
            return downloadedPoster;
        }
        public IMDB.IMDBType getType()
        {
            switch (type)
            {
                case "Episode": return IMDB.IMDBType.Episode;
                case "Movie": return IMDB.IMDBType.Movie;
                case "Series": return IMDB.IMDBType.Series;
            }
            return IMDB.IMDBType.Error;
        }

        public bool apiCallSucceeded()
        {
            return bool.Parse(response);
        }
    }
}
