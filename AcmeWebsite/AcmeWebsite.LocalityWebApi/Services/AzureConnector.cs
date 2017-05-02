using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using AcmeWebsite.LocalityWebApi.Entities;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Services
{
    public class AzureConnector
    {
        private readonly CloudTableClient _cloudTableClient;

        public AzureConnector()
        {
            CloudStorageAccount storageAccount =
             CloudStorageAccount.Parse(
                 CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));

            _cloudTableClient = storageAccount.CreateCloudTableClient();
        }

        public List<State> GetStates()
        {

            CloudTable stateTable = _cloudTableClient.GetTableReference("state");
            TableQuery<State> query = new TableQuery<State>();

            var states = stateTable.ExecuteQuery(query);

            return states.ToList();
        }

        public List<City> GetCities(string stateAcronym)
        {
            CloudTable cityTable = _cloudTableClient.GetTableReference("city");
            
            TableQuery<City> query = new TableQuery<City>();

            var cities = cityTable.ExecuteQuery(query).Where(c => c.PartitionKey.Equals(stateAcronym));

            return cities.ToList();

        }


    }
}