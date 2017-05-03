namespace AcmeWebsite.Web.Models
{
    public class CityModel 
    {

        public string StateAcronym { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public CityModel()
        {
            
        }

        public CityModel(string stateAcronym, string name, int id)
        {
            StateAcronym = stateAcronym;
            Name = name;
            Id = id;
        }

    }
}