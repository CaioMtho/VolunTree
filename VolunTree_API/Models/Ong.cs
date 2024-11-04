namespace VolunTree_API.Models
{
    public class Ong
    {
		public string Cnpj { get; set; }
		public string NomeOng { get; set; }
		public string EmailOng { get; set; }
		public string TelefoneOng { get; set; }
		public string EnderecoOng { get; set; }
		public string Missao { get; set; }
		public string Necessidades { get; set; }
		public string ContatoPrincipal { get; set; }
		public DateTime DataRegistroOng { get; set; } = DateTime.UtcNow;
        public override string ToString() { return $"Cnpj: {Cnpj}, NomeOng: {NomeOng}, EmailOng: {EmailOng}, TelefoneOng: {TelefoneOng}, EnderecoOng: {EnderecoOng}, Missao: {Missao}, Necessidades: {Necessidades}, ContatoPrincipal: {ContatoPrincipal}, DataRegistroOng: {DataRegistroOng}"; }
    }
}
