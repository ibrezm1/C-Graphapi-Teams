// See https://aka.ms/new-console-template for more information
// <using_identity_directives> 
using Azure.Core;
using Azure.Identity;
// </using_identity_directives>
// <using_directives> 
using Microsoft.Graph;  
using Microsoft.Identity.Client; 

using System.ComponentModel;


// dotnet add package Microsoft.Extensions.Configuration.Binder
// dotnet add package Microsoft.Extensions.Configuration.Json 
// dotnet add package Azure.Identity 
// dotnet add package Microsoft.Graph

// The client credentials flow requires that you request the
// /.default scope, and preconfigure your permissions on the
// app registration in Azure. An administrator must grant consent
// to those permissions beforehand.

var scopes = new[] { "https://graph.microsoft.com/.default" };

// Multi-tenant apps can use "common",
// single-tenant apps must use the tenant ID from the Azure portal
//var tenantId = "common";
var tenantId = "XXXXXXXXXXXXXXXXX37b5";

// Values from app registration
var clientId = "XXXXXXXXXXXXXXXXXXXXXX80b1aaa";
var clientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXE4ZOCbk.";

// using Azure.Identity;
var options = new TokenCredentialOptions
{
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
};

// https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
var clientSecretCredential = new ClientSecretCredential(
    tenantId, clientId, clientSecret, options);

var graphClient = new GraphServiceClient(clientSecretCredential, scopes);


var chat = new Chat
{
	ChatType = ChatType.Group,
	Topic = "Group chat title",
	Members = new ChatMembersCollectionPage()
	{
		new AadUserConversationMember
		{
			Roles = new List<String>()
			{
				"owner"
			},
			AdditionalData = new Dictionary<string, object>()
			{
				{"user@odata.bind", "https://graph.microsoft.com/v1.0/users('50407aa3-18af-4741-b75c-168bd9cd9b52')"}
			}
		},
		new AadUserConversationMember
		{
			Roles = new List<String>()
			{
				"owner"
			},
			AdditionalData = new Dictionary<string, object>()
			{
				{"user@odata.bind", "https://graph.microsoft.com/v1.0/users('ffead83e-3c6f-49a8-a8ba-31d15130d509')"}
			}
		},
		new AadUserConversationMember
		{
			Roles = new List<String>()
			{
				"guest"
			},
			AdditionalData = new Dictionary<string, object>()
			{
				{"user@odata.bind", "https://graph.microsoft.com/v1.0/users('050185c5-df7b-44ff-bc3d-d23837a072c6')"}
			}
		}
	}
};

var chat3 = await graphClient.Chats
	.Request()
	.AddAsync(chat);

Console.WriteLine(chat3.Id);

var members = await graphClient.Chats[chat3.Id].Members
	.Request()
	.GetAsync();
var mem_tmp = "";
 foreach( Microsoft.Graph.AadUserConversationMember mem in members)
            {
                Console.WriteLine("Hell");
                Console.WriteLine(mem.Id );
                mem_tmp = mem.Id;
            }




await graphClient.Chats[chat3.Id]
            .Members[mem_tmp]
            .Request()
            .DeleteAsync();

