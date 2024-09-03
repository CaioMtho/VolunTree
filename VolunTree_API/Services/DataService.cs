using Dapper;
using Microsoft.Data.Sqlite;
using VolunTree_API.Models;

namespace VolunTree_API.Services
{
    public class DataService : IDataService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Métodos para Voluntario
        public async Task<IEnumerable<Voluntario>> GetVoluntariosAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Voluntario>("SELECT * FROM voluntarios");
            }
        }

        public async Task<Voluntario> GetVoluntarioByIdAsync(string cpf)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Voluntario>("SELECT * FROM voluntarios WHERE cpf = @Cpf", new { Cpf = cpf });
            }
        }

        public async Task AddVoluntarioAsync(Voluntario voluntario)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO voluntarios (cpf, nome_volun, email_volun, telefone_volun, endereco_volun, interesses, habilidades, data_registro_volun) VALUES (@Cpf, @NomeVolun, @EmailVolun, @TelefoneVolun, @EnderecoVolun, @Interesses, @Habilidades, @DataRegistroVolun)";
                await connection.ExecuteAsync(sql, voluntario);
            }
        }

        public async Task UpdateVoluntarioAsync(Voluntario voluntario)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE voluntarios SET nome_volun = @NomeVolun, email_volun = @EmailVolun, telefone_volun = @TelefoneVolun, endereco_volun = @EnderecoVolun, interesses = @Interesses, habilidades = @Habilidades WHERE cpf = @Cpf";
                await connection.ExecuteAsync(sql, voluntario);
            }
        }

        public async Task DeleteVoluntarioAsync(string cpf)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM voluntarios WHERE cpf = @Cpf";
                await connection.ExecuteAsync(sql, new { Cpf = cpf });
            }
        }

        // Métodos para Ong
        public async Task<IEnumerable<Ong>> GetOngsAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Ong>("SELECT * FROM ongs");
            }
        }

        public async Task<Ong> GetOngByIdAsync(string cnpj)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Ong>("SELECT * FROM ongs WHERE cnpj = @Cnpj", new { Cnpj = cnpj });
            }
        }

        public async Task AddOngAsync(Ong ong)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO ongs (cnpj, nome_ong, email_ong, telefone_ong, endereco_ong, missao, necessidades, contato_principal, data_registro_ong) VALUES (@Cnpj, @NomeOng, @EmailOng, @TelefoneOng, @EnderecoOng, @Missao, @Necessidades, @ContatoPrincipal, @DataRegistroOng)";
                await connection.ExecuteAsync(sql, ong);
            }
        }

        public async Task UpdateOngAsync(Ong ong)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE ongs SET nome_ong = @NomeOng, email_ong = @EmailOng, telefone_ong = @TelefoneOng, endereco_ong = @EnderecoOng, missao = @Missao, necessidades = @Necessidades, contato_principal = @ContatoPrincipal WHERE cnpj = @Cnpj";
                await connection.ExecuteAsync(sql, ong);
            }
        }

        public async Task DeleteOngAsync(string cnpj)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM ongs WHERE cnpj = @Cnpj";
                await connection.ExecuteAsync(sql, new { Cnpj = cnpj });
            }
        }

        // Métodos para VoluntarioOng
        public async Task<IEnumerable<VoluntarioOng>> GetVoluntarioOngsAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<VoluntarioOng>("SELECT * FROM voluntario_ongs");
            }
        }

        public async Task AddVoluntarioOngAsync(VoluntarioOng voluntarioOng)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO voluntario_ongs (cpf, cnpj, data_interesse) VALUES (@Cpf, @Cnpj, @DataInteresse)";
                await connection.ExecuteAsync(sql, voluntarioOng);
            }
        }

        public async Task DeleteVoluntarioOngAsync(int idLigacao)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM voluntario_ongs WHERE id_ligacao = @IdLigacao";
                await connection.ExecuteAsync(sql, new { IdLigacao = idLigacao });
            }
        }

        // Métodos para Sugestao
        public async Task<IEnumerable<Sugestao>> GetSugestoesAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Sugestao>("SELECT * FROM sugestoes");
            }
        }

        public async Task<Sugestao> GetSugestaoByIdAsync(int idSuges)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Sugestao>("SELECT * FROM sugestoes WHERE id_suges = @IdSuges", new { IdSuges = idSuges });
            }
        }

        public async Task AddSugestaoAsync(Sugestao sugestao)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO sugestoes (cpf, cnpj, score, data_sugestao) VALUES (@Cpf, @Cnpj, @Score, @DataSugestao)";
                await connection.ExecuteAsync(sql, sugestao);
            }
        }

        public async Task UpdateSugestaoAsync(Sugestao sugestao)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE sugestoes SET cpf = @Cpf, cnpj = @Cnpj, score = @Score, data_sugestao = @DataSugestao WHERE id_suges = @IdSuges";
                await connection.ExecuteAsync(sql, sugestao);
            }
        }

        public async Task DeleteSugestaoAsync(int idSuges)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM sugestoes WHERE id_suges = @IdSuges";
                await connection.ExecuteAsync(sql, new { IdSuges = idSuges });
            }
        }
    }

}

