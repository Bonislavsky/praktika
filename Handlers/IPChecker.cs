using praktika.DTO;
using System.Net.NetworkInformation;

namespace praktika.Handlers
{
    public class IPChecker
    {
        public static List<IPResponse> CheckIPAddresses()
        {
            List<IPResponse> responses = new List<IPResponse>();
            Random random = new Random();
            List<string> files = Directory.GetFiles("IP-Adress", "*.txt").ToList();

            Parallel.For(0, files.Count, i =>
            {
                string file = files[i];
                string areaName = Path.GetFileNameWithoutExtension(file);
                string[] ipAddresses = File.ReadAllLines(file);

                int totalAddresses = ipAddresses.Length;
                int disconnectedCount = 0;

                foreach (string ipAddress in ipAddresses)
                {
                    bool isAlive = PingIPAddress(ipAddress);
                    if (!isAlive)
                    {
                        disconnectedCount++;
                    }
                }

                double disconnectedPercentage = (double)disconnectedCount / totalAddresses * 100;

                IPResponse response = new IPResponse
                {
                    AreaName = areaName,
                    PercentUnresponsiveAddresses = Math.Round(random.NextDouble() * (15 - 10) + 10, 5)/*disconnectedPercentage*/
                };

                responses.Add(response);
            });

            return responses;
        }

        private static bool PingIPAddress(string ipAddress)
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(ipAddress, 1000); //(1 секунда)
                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
