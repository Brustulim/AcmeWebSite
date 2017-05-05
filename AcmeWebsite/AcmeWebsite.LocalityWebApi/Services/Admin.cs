using System;
using System.Collections.Generic;
using System.Linq;
using AcmeWebsite.LocalityWebApi.Entities;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Services
{
    public class Admin
    {
        public void CreateTables()
        {

            var storageAccount =
                CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));

            var tableClient = storageAccount.CreateCloudTableClient();

            var tableState = tableClient.GetTableReference("state");
            //tableState.DeleteIfExists();
            tableState.CreateIfNotExists();

            var tableCity = tableClient.GetTableReference("city");
            tableCity.CreateIfNotExists();

            /* Only for initial insert
            foreach (var state in CreateStateList())
            {
                var insertOrUpdateOperation = TableOperation.InsertOrReplace(state);
                tableState.Execute(insertOrUpdateOperation);
            }
            */
            var cont = DateTime.Now.Second;
            foreach (var state in CreateStateList())
            {
                var city = new City(state.Acronym, $"{state.Name} City {cont}", cont++ );

                var insertOrUpdateOperation = TableOperation.InsertOrReplace(city);
                tableCity.Execute(insertOrUpdateOperation);
            }
        }

        public void InsertState(CloudTable cloudTable, State state)
        {
            var insertOrUpdateOperation = TableOperation.InsertOrReplace(state);
            cloudTable.Execute(insertOrUpdateOperation);
        }

        public void InsertCity(CloudTable cloudTable, City city)
        {
            var insertOrUpdateOperation = TableOperation.InsertOrReplace(city);
            cloudTable.Execute(insertOrUpdateOperation);
        }

        private static IEnumerable<State> CreateStateList()
        {
            var states = new List<State>
            {
                new State("AL", "Alabama"),
                new State("AK", "Alaska"),
                new State("AR", "Arkansas"),
                new State("AZ", "Arizona"),
                new State("CA", "California"),
                new State("CO", "Colorado"),
                new State("CT", "Connecticut"),
                new State("DC", "District of Columbia"),
                new State("DE", "Delaware"),
                new State("FL", "Florida"),
                new State("GA", "Georgia"),
                new State("HI", "Hawaii"),
                new State("ID", "Idaho"),
                new State("IL", "Illinois"),
                new State("IN", "Indiana"),
                new State("IA", "Iowa"),
                new State("KS", "Kansas"),
                new State("KY", "Kentucky"),
                new State("LA", "Louisiana"),
                new State("ME", "Maine"),
                new State("MD", "Maryland"),
                new State("MA", "Massachusetts"),
                new State("MI", "Michigan"),
                new State("MN", "Minnesota"),
                new State("MS", "Mississippi"),
                new State("MO", "Missouri"),
                new State("MT", "Montana"),
                new State("NE", "Nebraska"),
                new State("NH", "New Hampshire"),
                new State("NJ", "New Jersey"),
                new State("NM", "New Mexico"),
                new State("NY", "New York"),
                new State("NC", "North Carolina"),
                new State("NV", "Nevada"),
                new State("ND", "North Dakota"),
                new State("OH", "Ohio"),
                new State("OK", "Oklahoma"),
                new State("OR", "Oregon"),
                new State("PA", "Pennsylvania"),
                new State("RI", "Rhode Island"),
                new State("SC", "South Carolina"),
                new State("SD", "South Dakota"),
                new State("TN", "Tennessee"),
                new State("TX", "Texas"),
                new State("UT", "Utah"),
                new State("VT", "Vermont"),
                new State("VA", "Virginia"),
                new State("WA", "Washington"),
                new State("WV", "West Virginia"),
                new State("WI", "Wisconsin"),
                new State("WY", "Wyoming")
            };

            return states.ToList();
        }






    }
}