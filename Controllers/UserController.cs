using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using praktika.Database;
using praktika.Domain;
using praktika.DTO;
using praktika.Handlers;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace praktika.Controllers
{
    [ApiController]
    [Route("api/praktika")]
    public class UserController : ControllerBase
    {
        private PraktikaContext _context;
        private ITwilioRestClient _client;

        public UserController(PraktikaContext context, ITwilioRestClient client)
        {
            _context = context;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "request is null" });
            }

            if (!await _context.Areas.AnyAsync(x => x.Name.Equals(request.AreaName)))
            {
                return BadRequest(new { message = "в киевe нет такого района" });
            }

            var user = new User
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                AreaName = request.AreaName,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user.Id);
        }

        [HttpGet("Areas")]
        public async Task<IActionResult> GetAreas()
        {
            return Ok(_context.Areas.AsNoTracking().Select(x => x.Name));
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = _context.Users
                .AsNoTracking()
                .Select(x => new ReadUserResponse(x))
                .AsQueryable();

            return Ok(result);
        }

        //[HttpPost("message")]
        //public async Task<IActionResult> fdsfs()
        //{
        //    var message = MessageResource.Create(
        //        to: new PhoneNumber("+380508268200"),
        //        from: new PhoneNumber("+14302435049"),
        //        body: "практика тест",
        //        client: _client);

        //    return Ok(message);
        //}

        [HttpPost("ip-test")]
        public IActionResult IpChecker()
        {
            var ipsCheckList = IPChecker.CheckIPAddresses();

            List<ResponseMessage> SMSMessageRecipients = new List<ResponseMessage>();

            foreach (var item in ipsCheckList)
            {
                if(item.PercentUnresponsiveAddresses > 30)
                {
                    IQueryable<ResponseMessage> users = _context.Users
                        .AsNoTracking()
                        .Where(x => x.AreaName.Equals(item.AreaName))
                        .Select(x => new ResponseMessage
                        {
                            UserNumber = x.PhoneNumber,
                            Message = $"{x.Name}, у тебя в районе:{x.AreaName}, вырубают свет, гаси кампуктер или сгорит",
                        }).AsQueryable();

                    SMSMessageRecipients.AddRange(users.ToList());
                }
            }

            return Ok(SMSMessageRecipients);
        }
    }
}
