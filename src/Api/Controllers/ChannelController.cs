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
            new Channel { Name = "Web", Code = "WEB" },
            new Channel { Name = "Point of Sale", Code = "POS" },
            new Channel { Name = "Marketing", Code = "MKT" }
        };
    }

}