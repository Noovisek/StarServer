using System;

namespace StarServer.Utils.Panel
{
    public static class Panel
    {
        public static string GetHtml()
        {
            return @"
<html>
  <head><title>StarServer Panel</title></head>
  <body>
    <h1>Welcome to StarServer Panel</h1>
    <p>This is your server running on Cosmos.Network.</p>
  </body>
</html>";
        }
    }
}
