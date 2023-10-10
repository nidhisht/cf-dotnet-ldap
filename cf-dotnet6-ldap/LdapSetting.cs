namespace cf_dotnet6_ldap
{
    public static class LdapSetting
    {
        public static string ldapHost = "add ldap host here";
        public static int ldapPort = 3269;
        //Credentials for connecting with LDAP host
        public static string ldapUser = "add username for authenticate with ldap host";
        public static string ldapPassword = "add password for authenticate with ldap host";
        //Email as LDAP search input. Meaning user information to be fetched for this email.
        public static string searchEmail = "add email here";
        //LDAP search base and filter
        public static string ldapSearchBase = "add search base here";
        public static string ldapSearchFilter = "(&(objectClass=user)(mail=" + searchEmail + "))";
    }
}
