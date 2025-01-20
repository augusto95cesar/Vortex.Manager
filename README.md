# Vortex.Manager
 
# Perguntas do desafio. [link: exercico prático](https://github.com/augusto95cesar/Vortex.Manager/blob/master/Vortex.Docs/Portal%20Not%C3%ADcias%20-%20Vortex.pdf) 

1) No MVC, o que podemos fazer para enviar uma coleção de dados da classe
Controller para a View?
    - Existem várias maneiras de enviar uma coleção de dados (como uma lista, array ou outro tipo de coleção).
    - Podemos usar o ViewBag ou ViewData por exemplo.
    ---
2) Precisamos validar os dados obrigatórios de um formulário para que não gere
exceção no momento de armazenar na fonte de dados. Como podemos fazer isso?
    - Existem diversas maneiras de realizar essa validação, combinando abordagens no cliente (front-end) e no servidor (back-end).
    - No front podemos usar o javascript ou jquery por exmeplo
    - No back podemos usar Data Annotations e criar uma validação antes de gravar os dados no banco de dados.
    - veja esse exemplo de validação : [NoticiaValidation](https://github.com/augusto95cesar/Vortex.Manager/blob/master/Vortex.Proj.Web/Vortex.Manager.Application/Validations/NoticiaValidation.cs)
    ---
3) Como podemos armazenar configurações (connectionString, urls de apis, chaves de
acesso) da aplicação que variam de acordo com o ambiente (debug,desenv,prod) que
será publicado a aplicação?
    - Existe varias maneiras de guardar essas informações, o mais comum é usar o arquivo appsettings.json para produção e appsettings.Development.json para desenvolvimento.
    - Podemos criar uma class static para ter essa informaçãos. 
    - Podemos guardar essas informação criptografada em uma bando de dados como o sqlite.

---

## **Pré-requisitos**
1. **Windows** com o IIS habilitado:
   - Instale o IIS via "Ativar ou Desativar Recursos do Windows".
2. **.NET Hosting Bundle**:
   - Faça o download do pacote em [Microsoft .NET Hosting Bundle](https://dotnet.microsoft.com/download/dotnet). 
3. **Install Iss no windowns**
    - crie o site da aplicação
    - configure o clr pool para versão 'sem código gerenciado' 

---
## Configurar o Projeto .NET Core API no IIS

1. Este guia descreve como hospedar uma aplicação **.NET Core API** no **IIS (Internet Information Services)**.

---
 
## **1. Publicando o Projeto .NET Core API**
### Passo 1: Publicar a API
1. Abra o terminal no diretório do projeto API.
2. Execute o comando:
    ```bash
    dotnet publish -c Release -o ./publish
    ```
3. copie todos os arquivos da pasta publish e leve para a pasta do site configurado no iis acima.
  
---
 ## Implantação simplificada
  1. baixe o arquivo zip na pasta [downloads](https://github.com/augusto95cesar/Vortex.Manager/blob/master/Downloads/Vortex.Manager.WebApp.zip)
  2. extrair aquivo na pasta do servidor.
  3. configurar servidor para iis core.
  4. o projeto usa o sqllite com entity **está com o banco local na pasta zip.**.
        - caso queira usar outro banco de dados, basta configura o provider no lugar do sqlite no program.cs do projeto princiapal.
        - o banco de dados foi criado execute a migration ef
---
### Como Usar o Systema
1. Passo 01***
	- acessar o site configura no meu caso http://localhost 
	- Use o usuario: **master@gmail.com** e a Senha: **123456**
	
	** Aqui temos a pagina inicial

2. Passo 02***
	- Crie um Novo Usuario
		- usuario: teste01@gmail  Senha: 123456
	- Sair do Sistema 
    - Logar com o Novo Usuario

3. Passo 03***
	- Navegue para Noticias
	
4. Passo 04***
	- Adicionar Noticias
	- Adicionar Tags
        - cadastre ao menos uma tag
    - preencha os campos
	- Salve a Noticias
	
5. Passo 05***
	- Edite a noticia 

5. Passo 06***
	- Delete a noticia 

---



---
[![LinkedIn](https://img.shields.io/badge/-LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/augusto-cesar-61045b167)
[![Gmail](https://img.shields.io/badge/-Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:augusto95cesar@gmail.com)
[![WhatsApp](https://img.shields.io/badge/-WhatsApp-25D366?style=for-the-badge&logo=whatsapp&logoColor=white)](https://wa.me/5562991399381)
---