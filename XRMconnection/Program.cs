using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Net;
using System.ServiceModel;

namespace XRMconnection
{
	class Program
	{
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string _connectstring = @"authtype=OAuth;username=xxx@xxx.xx;password=xxx;url=https://d365test2.crm.dynamics.cn;appid=xxxx-227b-4e31-a9cf-717495945fc2;redirecturi=https://d365test2.crm.dynamics.cn;loginprompt=Auto;";

                CrmServiceClient conn = new CrmServiceClient(_connectstring);
                string f = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                  <entity name='account'>
                                    <attribute name='name' />
                                  </entity>
                                </fetch>";
                EntityCollection listaccount = conn.RetrieveMultiple(new FetchExpression(f));
                Console.WriteLine("====listaccount====" + listaccount.Entities.Count.ToString());
                Console.WriteLine("Microsoft Dynamics CRM version {0}.");
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                string message = ex.Message;
                throw;
            }

        }

    }
}
