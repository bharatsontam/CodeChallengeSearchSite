using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SearchSite.External
{
    public class TeleportSearchEngine
    {
        public List<string> SearchLocation(string searchTerm)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    var result = new List<string>();

                    string url = "https://api.teleport.org/api/cities/?search=" + searchTerm;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    var searchData = JsonConvert.DeserializeObject<dynamic>(client.DownloadString(url));

                    foreach (dynamic obj in searchData["_embedded"]["city:search-results"])
                    {
                        foreach (dynamic _obj in obj["matching_alternate_names"])
                        {
                            result.Add(_obj["name"].ToString());
                        }
                    }

                    return result.Select(x=>x.ToLower()).Distinct().Select(s=>s.UppercaseFirst()).ToList();
                }
                catch (Exception exe)
                {
                    return null;
                }
            }
        }

        
    }

}