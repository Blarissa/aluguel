# Sistema de Controle de Bicicletário

A equipe deve implementar uma API para o controle de bicicletas de uma empresa que faz o aluguel em totens disponibilizados na rua. A implementação deve respeitar a especificação de software e a modelagem Swagger.

## Microsserviço aluguel

Responsáveis pelos endpoints abaixo, como informado no Swagger:

- **/ciclista**
  - POST  - Cadastrar um ciclista.

- **/ciclista/{idCiclista}**
  - GET - Recuperar dados de um ciclista.
  - PUT- Alterar dados de um ciclista.

- **/ciclista/{idCiclista}/ativar**
  - POST - Ativar cadastro do ciclista.

- **/ciclista/{idCiclista}/permiteAluguel**
  - GET - Verifica se o ciclista pode alugar uma bicicleta, já que só pode alugar uma por vez.

- **/ciclista/{idCiclista}/bicicletaAlugada**
  - GET - Verifica se o ciclista pode alugar uma bicicleta, já que só pode alugar uma por vez.

- **/ciclista/existeEmail/{email}**
  - GET - Verifica se o e-mail já foi utilizado por algum ciclista.

- **/funcionario**
  - GET - Recuperar funcionários cadastrados.
  - POST - Cadastrar funcionário.

- **/funcionario/{idFuncionario}**
  - GET- Recupera funcionário.
  - PUT - Editar funcionário.
  - DELETE - Remover funcionário.

- **/cartaoDeCredito/{idCiclista}**
  - GET - Recupera dados de cartão de crédito de um ciclista.
  - PUT - Alterar dados de cartão de crédito de um ciclista.
- **/aluguel**
  - POST - Realizar aluguel.
- **/devolucao**
  - POST - Realizar devolução, sendo invocado de maneira automática pelo hardware do totem ao encostar a bicicleta na tranca.
