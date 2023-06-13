using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace praktika.Handlers
{
    public class TwilioHandler
    {
        public static string Send()
        {
            string accountSid = "AC7d11780af1d9ac3277900f5bf0d84185";
            string authToken = "4fd123686721c1ee8bf0858caeb31a86";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "практика",
                from: new Twilio.Types.PhoneNumber("+14302435049"),
                to: new Twilio.Types.PhoneNumber("+380508268200")
            );

            return message.Sid;
        }
    }
}
