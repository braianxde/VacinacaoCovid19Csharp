using System;

namespace ProjetoIntegrador4B.Dtos
{
    public class ResultDto
    {
        private DateTime? date;
        private string description;
        private bool status;

        public string Description { get => description; set => description = value; }
        public bool Status { get => status; set => status = value; }
        public DateTime? Date { get => date; set => date = value; }
    }
}
