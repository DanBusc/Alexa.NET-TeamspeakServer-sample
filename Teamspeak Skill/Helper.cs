using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpeak3QueryApi.Net.Specialized;

namespace Teamspeak
{
    public static class Helper
    {
        #region Logon data
        static string host = "xxxxxxx.xxx";
        static string username = "serveradmin";
        static string pass = "pass";
        #endregion
        
        public async static Task<List<TeamSpeak3QueryApi.Net.Specialized.Responses.GetClientInfo>> GetClients()
        {
            try
            {
                var rc = new TeamSpeakClient(host);

                await rc.Connect();
                await rc.Login(username, pass);

                await rc.UseServer(1);

                await rc.WhoAmI();

                await rc.RegisterServerNotification();
                await rc.RegisterChannelNotification(30);

                var serverGroups = await rc.GetServerGroups();
                var firstNormalGroup = serverGroups?.FirstOrDefault(s => s.ServerGroupType == ServerGroupType.NormalGroup);
                var groupClients = await rc.GetServerGroupClientList(firstNormalGroup.Id);

                var currentClients = await rc.GetClients();

                var fullClients = currentClients.Where(c => c.Type == ClientType.FullClient).ToList();
                await rc.Logout();
                return fullClients;
            }
            catch { }
            return null;
        }


        public async static Task<IReadOnlyList<TeamSpeak3QueryApi.Net.Specialized.Responses.GetServerListInfo>> GetServerinfo()
        {
            try
            {
                var rc = new TeamSpeakClient(host);

                await rc.Connect();
                await rc.Login(username, pass);

                await rc.UseServer(1);

                await rc.WhoAmI();

                await rc.RegisterServerNotification();
                await rc.RegisterChannelNotification(30);

                var servers = await rc.GetServers();

                await rc.Logout();

                return servers;
            }
            catch { }
            return null;
        }

        public static string ssmlString(string cleanstring)
        {
            if (!cleanstring.StartsWith("<speak>"))
                cleanstring = "<speak>" + cleanstring;
            if (!cleanstring.EndsWith("</speak>"))
                cleanstring += "</speak>";

            return cleanstring;

        }

        public static List<TeamSpeak3QueryApi.Net.Specialized.Responses.GetClientInfo> NormalizeClients(List<TeamSpeak3QueryApi.Net.Specialized.Responses.GetClientInfo> clients)
        {
            foreach (var item in clients)
            {
                switch (item.NickName.ToUpper())
                {
                    case "COMPLICATEDNAME":
                        item.NickName = " <lang xml:lang=\"en-US\">NAME</lang> ";
                        break;
                    default:
                        break;   
                }
            }

            return clients;
        }

    }
}
