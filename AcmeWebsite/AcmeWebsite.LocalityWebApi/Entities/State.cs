using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Entities
{
    public class State : TableEntity
    {
        public string Acronym { get; set; }
        public string Name { get; set; }

        public State(string acronym, string name)
        {
            PartitionKey = acronym;
            RowKey = name;

            Acronym = acronym;
            Name = name;
        }

        public State()
        {
            //For serializations
        }

    }
}