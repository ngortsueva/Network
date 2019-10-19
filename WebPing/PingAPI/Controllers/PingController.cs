using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PingAPI.model;

namespace WebPing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("{address}")]
        public ActionResult<PingResult> Get(string address)
        {            
            Ping ping = null;

            try
            {
                ping = new Ping();
                
                PingReply res = ping.Send(address);

                return new PingResult
                {
                    Address = res.Address.ToString(),
                    Time = res.RoundtripTime.ToString(),
                    Status = res.Status.ToString()
                };                
            }
            catch (Exception ex)
            {
                return new PingResult { Address = address, Status = ex.Message };
            }
            finally
            {
                if (ping != null)
                    ping.Dispose();
            }            
        }
    }
}