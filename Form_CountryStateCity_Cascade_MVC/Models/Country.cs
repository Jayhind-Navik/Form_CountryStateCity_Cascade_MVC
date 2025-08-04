namespace Form_CountryStateCity_Cascade_MVC.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
    }
}
