using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DonatasSimpleUniversal_MVVM_App.Services
{
    public class MashapeAPI
    {
        public async Task<string> getGenderInformation(string _name) 
        {
            string apiUrl = "https://montanaflynn-gender-guesser.p.mashape.com/?name=" + _name;

            // Set client's information
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = false;

            using (HttpClient client = new HttpClient(handler))
            {
                // Limit the max buffer size for the response so we don't get overwhelmed
                client.MaxResponseContentBufferSize = 256000;

                // Add a header
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)"); // Optional
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "8SaLUeJaswmshSbfvBBgLJTXrzXJp15b2ErjsnnIdKUavubFs1");

                // Obtain relevant JSON data from the API web page.
                string jsonContents = await client.GetStringAsync(new Uri(@apiUrl)).ConfigureAwait(false); // Preventing the Deadlock

                return jsonContents;
            }
        }
    }
}
