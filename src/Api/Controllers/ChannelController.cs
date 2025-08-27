using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Kfc.Controllers;

[Route("api/canales")]
public class ChannelController : AbpController
{
    [HttpGet]
    public List<Channel> GetChannels()
    {
        return new List<Channel>
        {
            new Channel { Name = "RAPPI", Code = "RAPPI" },
            new Channel { Name = "DIDI", Code = "DIDI" },
            new Channel { Name = "PEYA", Code = "PEYA" },
            new Channel { Name = "WEB", Code = "WEB" }
        };
    }
}