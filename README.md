<h1 align="center">
  <p>VOLUNTREE</p>
  <p>🌳</p>
</h1>

<p align="center"><i>Uma plataforma online para conectar voluntários e organizações</i></p>
<br>
<br>

## 🏗️ Como foi construido?
VolunTree é uma aplicação web criada com ASP.NET Core e suas funcionalidades.
Existem várias camadas na API:
- Models: Classes do domínio usadas na aplicação e mapeadas com o Dapper;
- Services: Regras de negócio são aplicadas aqui, tal qual acesso a serviços externos;
- Controllers: Expõe os serviços para acesso por meio de requisições HTTP, adicionam endpoints para a aplicação, definem parâmetros e métodos.
- Pages: Interface web com Razor Pages, separadas por layouts, páginas e models(code-behinds);
<br>
<br>
Utilizamos a BrasilAPI para verificação de CNPJs e o micro-ORM Dapper para mapear as entidades para as classes internas.
<br>
<br>
Utilizamos Bootstrap no Front End e Swagger para proporcionar uma documentação automática da aplicação.

## 🕵️ Como usar?
Baixe os arquivos do projeto ou use "git clone". Inicialize "dotnet run" na pasta "VolunTree_API".
> O projeto depende do .NET 8

## 🤖 Tecnologias
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
