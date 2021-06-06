namespace ProjetoIntegrador4B.Models
{
    public partial class Persongroup
    {
        public Persongroup(int idperson, int idgroup)
        {
            Idperson = idperson;
            Idgroup = idgroup;
        }

        public int Id { get; set; }
        public int Idperson { get; set; }
        public int Idgroup { get; set; }
    }
}
