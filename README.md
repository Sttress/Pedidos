O projeto foi feito em .Net CORE 6, utilizando bibliotecas como o Swagger e EntityFrameWork como ORM. A arquitetura escolhida foi de Repository e abaixo estão algumas 
das suas funcionalidades e configurações:

Para inicializar o banco de dados basta acessar ao arquivo appsettings.json e dentro de ConnectionStrings/DefaultConnection nos campo Source adionar com seus servidor,
em Catalog o nome do seu banco de desejado que será criado caso não exista, ID o usuário do seu servidor, Password a senha do seu servidor. E por final no Package Manager
Console digitar o seguinte comando : Update-Database

https://localhost:44345/api/v1/pedido/get
- Utilizando uma requisição GET enviando o identificador de um Pedido você irá obter todo o pedido com seus itens.

https://localhost:44345/api/v1/pedido/create
- Ultilizando uma requisição POST enviando um objeto com  NomeCliente, EmailCliente, DataCriacao, Pago irá criar um novo Pedido.

https://localhost:44345/api/v1/pedido/edit
-Ultilizando uma requisição PUT e enviando um objeto com Id NomeCliente, EmailCliente, DataCriacao, Pago irá sobre escrever e gravar o pedido com o Id passado.

https://localhost:44345/api/v1/pedido/delete
- Ultilizando uma requisição DELETE e enciando o identificador o pedido será excluido.

