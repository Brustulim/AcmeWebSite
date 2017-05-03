using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Entities
{
    public class City : TableEntity
    {
        public string StateAcronym { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public City(string stateAcronym, string name, int id)
        {
            PartitionKey = stateAcronym;
            RowKey = name;

            StateAcronym = stateAcronym;
            Name = name;
            Id = id;
        }

        public City()
        {
            //For serializations
        }

    }
}