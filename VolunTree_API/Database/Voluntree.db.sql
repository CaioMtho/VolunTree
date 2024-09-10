-- Inserir dados na tabela voluntarios
INSERT INTO voluntarios (cpf, nome_volun, email_volun, telefone_volun, endereco_volun, interesses, habilidades)
VALUES 
('12345678901', 'João Silva', 'joao.silva@example.com', '11987654321', 'Rua A, 123', 'Educação, Saúde', 'Primeiros Socorros, Ensino'),
('23456789012', 'Maria Oliveira', 'maria.oliveira@example.com', '11987654322', 'Rua B, 456', 'Meio Ambiente, Tecnologia', 'Programação, Gestão de Projetos');

-- Inserir dados na tabela ongs
INSERT INTO ongs (cnpj, nome_ong, email_ong, telefone_ong, endereco_ong, missao, necessidades, contato_principal)
VALUES 
('12345678000199', 'ONG Esperança', 'contato@ongesperanca.org', '1134567890', 'Avenida Central, 1000', 'Apoiar comunidades carentes', 'Alimentos, Roupas', 'Ana Souza'),
('23456789000188', 'ONG Futuro', 'contato@ongfuturo.org', '1134567891', 'Rua das Flores, 200', 'Promover a educação', 'Livros, Voluntários', 'Carlos Pereira');

-- Inserir dados na tabela voluntario_ongs
INSERT INTO voluntario_ongs (cpf, cnpj, data_interesse)
VALUES 
('12345678901', '12345678000199', '2024-09-07 10:00:00'),
('23456789012', '23456789000188', '2024-09-07 11:00:00');

-- Inserir dados na tabela sugestoes
INSERT INTO sugestoes (cpf, cnpj, score, data_sugestao)
VALUES 
('12345678901', '12345678000199', 8.5, '2024-09-07 12:00:00'),
('23456789012', '23456789000188', 9.0, '2024-09-07 13:00:00');