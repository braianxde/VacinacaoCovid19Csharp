namespace ProjetoIntegrador4B.Dtos
{
    public class LoginDto
    {
        private string? token;
        private string name;
        private bool success = false;

        public string Name { get => name; set => name = value; }
        public bool Success { get => success; set => success = value; }
        public string Token { get => token; set => token = value; }
    }
}
