using ProjetoIntegrador4B.Models;

namespace ProjetoIntegrador4B.Dtos
{
    public class AddFormDto
    {
        private Person person;
        private int[] idGroups;

        public Person Person { get => person; set => person = value; }
        public int[] IdGroups { get => idGroups; set => idGroups = value; }
    }
}
