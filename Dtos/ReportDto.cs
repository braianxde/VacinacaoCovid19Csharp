using System;

namespace ProjetoIntegrador4B.Dtos
{
    public class ReportDto
    {
        private string name;
        private string email;
        private string description;
        private DateTime? liberationDate;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? LiberationDate { get => liberationDate; set => liberationDate = value; }
    }
}
