document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('form-cadastro').addEventListener('submit', async function (event) {
        event.preventDefault();

        const now = new Date();
        const formData = {
            cnpj: document.getElementById('input-cnpj').value,
            nomeOng: document.getElementById('input-nome').value,
            emailOng: document.getElementById('input-email').value,
            telefoneOng: document.getElementById('input-telefone').value,
            enderecoOng: document.getElementById('input-endereco').value,
            missao: document.getElementById('input-missao').value,
            necessidades: document.getElementById('input-necessidades').value,
            contatoPrincipal: document.getElementById('input-contato').value,
            dataRegistroOng: now.toISOString()
        };

        console.log('Dados do formulário:', formData);

        try {
            const response = await fetch('https://localhost:7071/api/Ongs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                const result = await response.json();
                alert('ONG cadastrada com sucesso!');
            } else {
                const errorText = await response.text();
                console.error('Erro na resposta:', errorText);
                alert('Erro ao cadastrar ONG.');
            }
        } catch (error) {
            console.error('Erro:', error);
            alert('Erro ao cadastrar ONG.');
        }
    });
});
