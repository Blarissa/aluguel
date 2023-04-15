# Sistema de Controle de Biciclet�rio

A equipe deve implementar uma API para o controle de bicicletas de uma empresa que faz o aluguel em totens disponibilizados na rua. A implementa��o deve respeitar a especifica��o de software e a modelagem Swagger [V� de bike](https://app.swaggerhub.com/apis/pasemes/sistema-de_controle_de_bicicletario/1).

## Microsservi�o aluguel

Respons�veis pelos endpoints abaixo, como informado no Swagger:

- **/ciclista**
  - POST  - Cadastrar um ciclista.

- **/ciclista/{idCiclista}**
  - GET - Recuperar dados de um ciclista.
  - PUT- Alterar dados de um ciclista.

- **/ciclista/{idCiclista}/ativar**
  - POST - Ativar cadastro do ciclista.

- **/ciclista/{idCiclista}/permiteAluguel**
  - GET - Verifica se o ciclista pode alugar uma bicicleta, j� que s� pode alugar uma por vez.

- **/ciclista/{idCiclista}/bicicletaAlugada**
  - GET - Verifica se o ciclista pode alugar uma bicicleta, j� que s� pode alugar uma por vez.

- **/ciclista/existeEmail/{email}**
  - GET - Verifica se o e-mail j� foi utilizado por algum ciclista.

- **/funcionario**
  - GET - Recuperar funcion�rios cadastrados.
  - POST - Cadastrar funcion�rio.

- **/funcionario/{idFuncionario}**
  - GET- Recupera funcion�rio.
  - PUT - Editar funcion�rio.
  - DELETE - Remover funcion�rio.

- **/cartaoDeCredito/{idCiclista}**
  - GET - Recupera dados de cart�o de cr�dito de um ciclista.
  - PUT - Alterar dados de cart�o de cr�dito de um ciclista.
- **/aluguel**
  - POST - Realizar aluguel.
- **/devolucao**
  - POST - Realizar devolu��o, sendo invocado de maneira autom�tica pelo hardware do totem ao encostar a bicicleta na tranca.