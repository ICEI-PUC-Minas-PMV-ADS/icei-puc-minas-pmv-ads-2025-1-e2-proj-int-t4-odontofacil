# Plano de Testes de Software

Estratégia de teste

Serão feitos testes manuais que servirão para simular a experiência real dos usuários, buscando validar os requisitos funcionais descritos na Especificação do Projeto.

Projeto do teste

O projeto de teste visa garantir que o sistema atenda aos requisitos funcionais, realizando testes de cadastro, login, agendamento, prontuário, histórico de consultas, visualização e envio de exames.

---

## Caso de Teste CT01 – Cadastro de usuário

| Campo | Conteúdo |
|:------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT01 – Cadastro de usuário |
| Requisito Associado | RF-001 - O sistema deve permitir o cadastro de pacientes, dentistas e operadores. |
| Pré-condições | Estar na tela de cadastro |
| Passos | * Preencher campos obrigatórios: Nome, email, cpf e senha <br> * Marcar caixa "Aceitar os termos de uso" <br> * Clicar em "Cadastrar" |
| Dados de entrada | Nome: Paulo Ferreira Marques, email: pauloferreiram@gmail.com, cpf: 000.000.000-11 <br> Senha: 495857@Aa |
| Resultado esperado (RE) | Acessar tela de login |
| Resultado obtido (RO) | Acesso a tela de login |
| Avaliação (pegou / não pegou erro) | Não pegou erro |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/3ba135ba-6efe-4388-9324-9527be63ac42" alt="ct01"/> <br> <img src="https://github.com/user-attachments/assets/0eeccfb2-1a9e-47f4-8f06-128d6b50ea65" alt="ct001"> |

---

## Caso de Teste CT02 – Login de usuários

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT02 – Login de usuários                                                                                              |
| Requisito Associado     | RF-002 - O sistema deve permitir login para pacientes, dentistas e operadores.                                   |
| Pré-condições           | Estar na tela de login                                                                                             |
| Passos                  | * Preencher campos com um login de dentista válido e uma senha válida <br> * Selecionar opção “Login”           |
| Dados de entrada        | * Login: pauloferreiram@gmail.com <br> * Senha: 495857@Aa                                                       |
| Resultado esperado (RE) | Login e acesso a lista de pacientes                                                                                |
| Resultado obtido (RO)   | Login funcionou e tela de lista de pacientes foi exibida                                                           |
| Avaliação (pegou / não pegou erro) | Não pegou erro                                                                                              |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/ae56b889-a09c-4d6d-9d5f-94f0772d85c5" alt="ct02"/> <br> <img src="https://github.com/user-attachments/assets/2585a531-136d-4daf-af36-8f3972f000ae" alt="ct002"> |

---

## Caso de Teste CT03 – Paciente faz agendamento de consultas

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT03 – Paciente faz agendamento de consultas                                                                         |
| Requisito Associado     | RF-003 - O sistema deve permitir o paciente agendar e cancelar consultas pelo sistema.                             |
| Pré-condições           | Estar na tela de "Agendar"                                                                                           |
| Passos                  | * Usuário selecionará o dentista, a data e o horário <br> * Selecionar a opção “Confirmar agendamento”            |
| Dados de entrada        | * Dentista: Nome Dois <br> * Data: 11/06/2025 <br> * Horário: 09:00                                                  |
| Resultado esperado (RE) | Redirecionamento para tela de agendamentos constando agendamento criado na lista                                   |
| Resultado obtido (RO)   | Redirecionado para tela de agendamentos e agendamento realizado.                                                   |
| Avaliação (pegou / não pegou erro) | Não pegou erro                                                                                              |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/c1fff23c-e781-471f-8b30-afe6fe03df56" alt="ct03"/> <br> <img src="https://github.com/user-attachments/assets/f0c1f06e-79a2-4c7a-b14f-274fe2a344ba" alt="ct003"> |

---

## Caso de Teste CT04 – Operador faz agendamento de consultas para paciente

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT04 – Operador faz agendamento de consultas para paciente                                                            |
| Requisito Associado     | RF-004 - O sistema deve permitir o operador agendar consultas para pacientes.                                       |
| Pré-condições           | Estar na tela "Agendar" em uma conta de operador                                                                   |
| Passos                  | * Selecionar paciente <br> * Selecionar dentista <br> * Selecionar data, e clicar em “Confirmar Agendamento”      |
| Dados de entrada        | * Paciente: Junior Silva <br> * Dentista: Nome Dois <br> * Data/Horário: 12/06/25 - 10:00                          |
| Resultado esperado (RE) | Redirecionamento para tela de agendamentos com agendmento listado                                                   |
| Resultado obtido (RO)   | Redirecionamento para tela de agendamentos com agendmento listado                                                   |
| Avaliação (pegou / não pegou erro) | Não pegou erro                                                                                              |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/8ad6d8ed-20ae-435d-beaa-fa02ecde341f" alt="ct04"/> <br> <img src="https://github.com/user-attachments/assets/089f8a67-73ea-4646-ba78-4cd90656135e" alt="ct004"> |

---

## Caso de Teste CT05 – Dentista faz alterações na agenda de consultas

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT05 – Dentista faz alterações na agenda de consultas                                                                 |
| Requisito Associado     | RF-005 - O sistema deve permitir que o dentista visualizar e gerenciar sua agenda de consultas.                     |
| Pré-condições           | Estar na tela de agendamentos numa conta de dentista                                                               |
| Passos                  | * Selecionar a opção “Cancelar” em um agendamento <br> * Selecionar opção OK para confirmar cancelamento        |
| Dados de entrada        |                                                                                                                    |
| Resultado esperado (RE) | Mensagem "Agendamento cancelado com sucesso"                                                                      |
| Resultado obtido (RO)   | Mensagem "Agendamento cancelado com sucesso"                                                                      |
| Avaliação (pegou / não pegou erro) | Não pegou erro                                                                                              |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/b77cae5b-6167-44ed-9472-ef251e115f7f" alt="ct05"/> <br> <img src="https://github.com/user-attachments/assets/9b2b40cc-de00-4052-a7f6-db4c8bef9367" alt="ct005"> <br> <img src="https://github.com/user-attachments/assets/40592fdb-bebe-495d-9071-bdaf6af55655" alt="ct0005"/> |

---

## Caso de Teste CT06 – Permissão total aos dentistas a um CRUD dos prontuários dos pacientes

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT06 – Permissão total aos dentistas a um CRUD dos prontuários dos pacientes                                      |
| Requisito Associado     | RF-006 - O sistema deve permitir que o dentista adicione, edite e remova informações do prontuário dos pacientes. |
| Pré-condições           | * Acesso à conta de perfil dentista <br> * Acesso à lista de pacientes <br> * Acesso ao prontuário do paciente Junior Silva |
| Passos                  | * Alterar plano de saúde do paciente de : "HapVida" para : "Unimed" <br> * Clicar em "Salvar" |
| Dados de entrada        | * Paciente: Junior Silva                                                                                           |
| Resultado esperado (RE) | Recarregamento da página e informação atualizada        |
| Resultado obtido (RO)   | Página recarregada armazenando informação alterada                                                                                                                   |
| Avaliação (pegou / não pegou erro) |  Não pegou erro.                                                                                                                  |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/1ab85536-8236-4cd6-8c37-970bd4e78709" alt="ct06"/> <br> <img src="https://github.com/user-attachments/assets/7cd95827-03a1-49fe-b960-1f0c0e6b7702" alt="ct006"> <br> <img src="https://github.com/user-attachments/assets/28796368-886f-4ccd-8e80-c3191074ac03" alt="ct0006"/>|

---

## Caso de Teste CT07 – Dentista precisa documentar o andamento do tratamento por meio de anotações a cada consulta

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT07 – Dentista precisa documentar o andamento do tratamento por meio de anotações a cada consulta                |
| Requisito Associado     | RF-007 - O sistema deve permitir que o dentista possa adicionar anotações sobre o tratamento do paciente a cada consulta. |
| Pré-condições           | * Estar na tela de anotações dos atendimentos <br> * Selecionar paciente Junior Silva <br> * Selecionar data do atendimento (a depender da data do teste) |
| Passos                  | * Dentista preencherá os campos que detalham o atendimento, ex: “houve complicações?” “há necessidade de marcar retorno para continuidade?” e etc. <br> * Dentista selecionará a opção “Salvar” <br> * Preencher campos de login e senha para validar anotações |
| Dados de entrada        | * Login: pauloferreiram@gmail.com  <br> * Senha: 495857@Aa |
| Resultado esperado (RE) | Alteração realizada com sucesso. |
| Resultado obtido (RO)   | Alteração realizada com sucesso. |
| Avaliação (pegou / não pegou erro) |                                                                                                                    |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/0d17db9b-5705-4ebb-b986-f0b675f9225c" alt="ct07"/> <br> <img src="https://github.com/user-attachments/assets/e8401509-4ceb-4c4b-9fc9-56ba604b2d1a" alt="ct007"/> |

---

## Caso de Teste CT08 – Dentista precisa conseguir anexar resultados de exames prescrições ao prontuário do paciente

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT08 – Dentista precisa conseguir anexar resultados de exames prescrições ao prontuário do paciente               |
| Requisito Associado     | RF-008 - O sistema deve permitir que o dentista anexe resultados e prescrições ao prontuário do paciente.         |
| Pré-condições           | * Estar na tela de listagem de pacientes <br> * Fazer um agendamento para o paciente para o mesmo dia que será selecionado no teste |
| Passos                  | * Operador selecionará o paciente Junior Silva <br> * Operador selecionará a data, horário e tipo de atendimento <br> * É selecionada a opção “Agendar” |
| Dados de entrada        | * Login: pauloferreiram@gmail.com  <br> * Senha: 495857@Aa |
| Resultado esperado (RE) | Resultado de exame listado. |
| Resultado obtido (RO)   | Resultado de exame listado. |
| Avaliação (pegou / não pegou erro) | Não pegou erro. |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/ae56b889-a09c-4d6d-9d5f-94f0772d85c5" alt="ct08"/> <br> <img src="https://github.com/user-attachments/assets/5512b5db-6f26-4317-b32a-7c4e63acec3e" alt="ct008"/> |

---

## Caso de Teste CT09 – Paciente precisa enviar e visualizar exames no sistema

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT09 – Paciente precisa enviar e visualizar exames no sistema                                                     |
| Requisito Associado     | RF-009 - O sistema deve permitir que paciente possa enviar e visualizar exames dentro do sistema.                 |
| Pré-condições           | Estar na tela "Resultados de exames" na conta paciente                                                           |
| Passos                  | * Clicar em Visualizar/Baixar no ação do primeiro exame da lista                                                 |
| Dados de entrada        |                                                                                                                    |
| Resultado esperado (RE) | Exibição resultado do exame                                                                                        |
| Resultado obtido (RO)   | Arquivo não encontrado no servidor                                                                                 |
| Avaliação (pegou / não pegou erro) | Pegou erro                                                                                                  |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/694ed756-9362-49c9-b59a-8fe4ba9324bb" alt="ct09"/> <br> <img src="https://github.com/user-attachments/assets/3fadc4bb-6d0a-4fcb-a90c-d1e1e53a8d82" alt="ct009"> |

---

## Caso de Teste CT10 – Paciente precisa acessar histórico de exames e consultas

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT10 – Paciente precisa acessar histórico de exames e consultas                                                   |
| Requisito Associado     | RF-010 - O sistema deve permitir que o paciente visualize seu histórico de exames e consultas.                    |
| Pré-condições           | * Acesso a conta de paciente <br> * Selecionar opção “Meu histórico”                                            |
| Passos                  | * Selecionar primeira data do histórico de atendimento <br> * Selecionar opção “Anotações” <br> * Visualizar informações |
| Dados de entrada        | * Login: juniorsilvabhz@gmail.com <br> * Senha: 495857@Aa |
| Resultado esperado (RE) | Exibição do histórico de consultas. |
| Resultado obtido (RO)   | Exibição do histórico de consultas. |
| Avaliação (pegou / não pegou erro) | Não pegou erro. |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/dc04fc33-f8dd-4773-887c-128b7b6b96d7" alt="ct010"/> |

---

## Caso de Teste CT11 – Sistema deve apresentar organização cronológica do histórico de exames e consultas

| Campo | Conteúdo |
|:------------------------|:-------------------------------------------------------------------------------------------------------------------|
| **Caso de Teste** | CT11 – Sistema deve apresentar organização cronológica do histórico de exames e consultas |
| Requisito Associado     | RF-011 - O sistema deve organizar de forma cronológica todos os atendimentos, exames e procedimentos do paciente. |
| Pré-condições           | * Acesso a conta perfil operador <br> * Selecionar opção “Agendamentos” |
| Passos                  | * Verificar se a listagem está organizada cronologicamente. |
| Dados de entrada        | * Login: pauloferreiram@gmail.com <br> * Senha: 495857@Aa. |
| Resultado esperado (RE) | Exibição organizada das consultas. |
| Resultado obtido (RO)   | Exibição organizada das consultas. |
| Avaliação (pegou / não pegou erro) | Não pegou erro. |
| Evidência (print screen) | <img src="https://github.com/user-attachments/assets/430470f0-ea5e-46f3-bb7f-2afa9267a47a" alt="ct011"/> |
