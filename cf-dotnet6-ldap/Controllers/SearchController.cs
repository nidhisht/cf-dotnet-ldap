using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.DirectoryServices.Protocols;
using System.Net;


namespace cf_dotnet6_ldap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        LdapConnection _ldapConnection;
        [HttpGet]
        public string Get()
        {
            _ldapConnection = CreateConnection();
            if(_ldapConnection == null)
            {
                return "Failed to establish connection to domain";
            }
            else
            {                
                LdapUser? user = GetUser(LdapSetting.searchEmail);
                if(user != null)
                {
                    string output = JsonConvert.SerializeObject(user);
                    return output;
                }
                else
                {
                    return "Successfully established connection to domain but failed to find user";
                }          
            }   
        }

        private LdapConnection CreateConnection()
        {
            try
            {
                var cred = new NetworkCredential(LdapSetting.ldapUser, LdapSetting.ldapPassword); 
                LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier(server: LdapSetting.ldapHost, LdapSetting.ldapPort);
                var conn = new LdapConnection(identifier, cred);
                conn.SessionOptions.ProtocolVersion = 3;
                conn.SessionOptions.SecureSocketLayer = true;
                conn.AuthType = AuthType.Basic;
                conn.Bind();

                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to establish connection to domain: [{LdapSetting.ldapHost}] exception: {ex.Message}");
                if(ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                if(ex.StackTrace != null)
                {
                    Console.WriteLine($"Stack trace: {ex.StackTrace.ToString()}");
                }
                return null;
            }
        }

        public LdapUser? GetUser(string email)
        {           

            DirectoryRequest request = new SearchRequest(LdapSetting.ldapSearchBase, LdapSetting.ldapSearchFilter, SearchScope.Subtree, new[]
                                       {
                                        "objectguid", "samaccountname", "givenName", "sn", "mail", "telephoneNumber",
                                        "employeeID", "userPrincipalName", "proxyAddresses"
                                        });

            var response = (SearchResponse)_ldapConnection.SendRequest(request);

            return ParseUser(response);    
        }

        private LdapUser? ParseUser(SearchResponse response)
        {
            LdapUser user = null;
            if (response.Entries != null && response.Entries.Count > 0)
            {
                user = new LdapUser();
                foreach (SearchResultEntry result in response.Entries)
                {
                    var dnsRoot = result.Attributes;

                    if (dnsRoot.Contains("objectguid"))
                    {
                        user.objectguid = dnsRoot["objectguid"][0].ToString();
                    }
                    if (dnsRoot.Contains("samaccountname"))
                    {
                        user.samaccountname = dnsRoot["samaccountname"][0].ToString();
                    }
                    if (dnsRoot.Contains("givenName"))
                    {
                        user.givenName = dnsRoot["givenName"][0].ToString();
                    }
                    if (dnsRoot.Contains("sn"))
                    {
                        user.sn = dnsRoot["sn"][0].ToString();
                    }
                    if (dnsRoot.Contains("mail"))
                    {
                        user.mail = dnsRoot["mail"][0].ToString();
                    }
                    if (dnsRoot.Contains("telephoneNumber"))
                    {
                        user.telephoneNumber = dnsRoot["telephoneNumber"][0].ToString();
                    }
                    if (dnsRoot.Contains("employeeID"))
                    {
                        user.employeeID = dnsRoot["employeeID"][0].ToString();
                    }
                    if (dnsRoot.Contains("userPrincipalName"))
                    {
                        user.userPrincipalName = dnsRoot["userPrincipalName"][0].ToString();
                    }
                    if (dnsRoot.Contains("proxyAddresses"))
                    {
                        user.proxyAddresses = dnsRoot["proxyAddresses"][0].ToString();
                    }
                }
            }

            return user;
        }

    }
}
