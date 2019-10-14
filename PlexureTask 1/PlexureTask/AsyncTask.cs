using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlexureTask
{
    public class AsyncTask
    {
        public async Task<int> DownloadResourcesAsync(CancellationToken cancellationToken)
        {
            var resourcesList = GetResourceList();
            var total = 0;
            
            // Declare an HttpClient object, and increase the buffer size. 
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            
            foreach (var resourceUrl in resourcesList)
            {

                Task<int> resResult = GetDownloadResultAsync(resourceUrl, client, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    throw new TaskCanceledException(resResult);

                var resLength = await resResult;

                total += resLength;
            }
       

            return total;


        }



        async Task<int> GetDownloadResultAsync(string url, HttpClient client, CancellationToken ct)
        {
            HttpResponseMessage response = await client.GetAsync(url, ct);
            var responseResult = await response.Content.ReadAsStringAsync();
          
            return responseResult.Length;
        }




        private List<string> GetResourceList()
        {
            List<string> urls = new List<string>
            {
                "https://resource1.test.com",
                "https://resource2.test.com",
                "https://resource3.test.com"
            };
            return urls;
        }



    }
}
