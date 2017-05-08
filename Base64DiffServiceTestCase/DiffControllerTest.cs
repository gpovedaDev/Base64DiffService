using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base64DiffService;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Base64DiffServiceTestCase
{
    public class DiffControllerTest
    {
        [Fact]
        public void TestNotFoundData()
        {
            Assert.Equal(1, 2);
           /* using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("v1/diff/7");
                string responseContent = await result.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<string>(responseContent);

                Assert.Equal(1,2);
                System.Console.Out.WriteLine(entity);
            }*/
        }
    }
}
