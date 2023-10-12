# Purpose
This is a dotnet6 sample for LDAP connectivity. It accepts Email address as input and returns user details from LDAP

# Pre-requisites
Set values to the variables (ldapHost, ldapPort, ldapUser, ldapPassword, searchEmail & ldapSearchBase) in [LdapSettings.cs](https://github.com/nidhisht/cf-dotnet-ldap/blob/c4d84a86c51210c35fd582da0a066d529c0b4156/cf-dotnet6-ldap/LdapSetting.cs#L5C17-L5C17)
![image](https://github.com/nidhisht/cf-dotnet-ldap/assets/42999787/08f87727-63ec-446c-8bbe-fd33237a5728)

# How to run code on local machine
On Windows machine, open visual studio & hit F5
https://localhost:5127/search

![image](https://github.com/nidhisht/cf-dotnet-ldap/assets/42999787/e9269ddf-c2cf-49f4-9210-d88296048279)

# How to deploy code on PCF
1) Publish the code
   ![image](https://github.com/nidhisht/cf-dotnet-ldap/assets/42999787/0a5f5144-81a5-4063-ab27-87e552bf07cb)

3) cf push
   ![image](https://github.com/nidhisht/cf-dotnet-ldap/assets/42999787/209ebaf4-f7dd-4980-aac5-e444b5d68da6)

5) Run the app
   **NOTE**: App with cflinuxfs3 stack successfully query user details from LDAP. But it fails to query with cflinuxfs4 stack. Below screenshot refers to app with cflinuxfs3 stack.
  ![image](https://github.com/nidhisht/cf-dotnet-ldap/assets/42999787/ef2c7c9c-d6be-43f6-8b2d-9dffdca5d3f8)


