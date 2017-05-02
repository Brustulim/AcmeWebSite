using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Entities
{
    public class City : TableEntity
    {
        public string StateAcronym { get; set; }
        public string Name { get; set; }

        public City(string stateAcronym, string name)
        {
            PartitionKey = stateAcronym;
            RowKey = name;

            StateAcronym = stateAcronym;
            Name = name;
        }

        public City()
        {
            //For serializations
        }

    }
}