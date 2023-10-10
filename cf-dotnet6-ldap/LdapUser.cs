namespace cf_dotnet6_ldap
{
    public class LdapUser
    {
        public string objectguid { get; set; }
        public string samaccountname { get; set; }
        public string givenName { get; set; }
        public string sn { get; set; }
        public string mail { get; set; }
        public string telephoneNumber { get; set; }
        public string employeeID { get; set; } 
        public string userPrincipalName { get; set; }
        public string proxyAddresses { get; set; }
    }
}
