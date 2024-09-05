namespace VolunTree_API.Models
{
    public class Voluntario
    {
        public string Cpf { get; set; }
        public string NomeVolun { get; set; }
        public string EmailVolun { get; set; }
        public string TelefoneVolun { get; set; }
        public string EnderecoVolun { get; set; }
        public string Interesses { get; set; }
        public string Habilidades { get; set; }
        public DateTime DataRegistroVolun { get; set; }
    }

}
   