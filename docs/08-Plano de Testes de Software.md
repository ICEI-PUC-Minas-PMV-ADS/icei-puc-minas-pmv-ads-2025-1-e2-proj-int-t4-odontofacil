# Plano de Testes de Software

Estratégia de teste

Serão feitos testes manuais que servirão para simular a experiência real dos usuários, buscando validar os requisitos funcionais descritos na Especificação do Projeto. 

Projeto do teste

O projeto de teste visa garantir que o sistema atenda aos requisitos funcionais, realizando testes de cadastro, login, agendamento, prontuário, histórico de consultas, visualização e envio de exames. 

Casos de Teste
 
| **Caso de Teste** 	| **CT01 – Cadastro de usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O sistema deve permitir o cadastro de pacientes, dentistas e operadores. |
| Pré-condições 	| Estar na tela de cadastro |
| Passos 	| - Preencher campos obrigatórios : Nome, email, cpf e senha <br> - Clicar em "Pronto" <br> - Clicar em "Criar conta" <br> |
|Dados de entrada | - Nome: Junior Silva, email: juniorsilvabhz@gmail.com, cpf: 000.000.000-00 (cpf inválido) senha: 495857@Aa. |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que o cpf está inválido. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT02 – Login de usuários**	|
|	|	|
|Requisito Associado | RF-002	- O sistema deve permitir login para pacientes, dentistas e operadores. |
| Pré-condições 	| Estar na tela de login |
| Passos 	| - É fornecido um login válido e uma senha inválida  <br> - É selecionada a opção “Entrar”  <br> |
|Dados de entrada | - Login: juniorsilvabhz@gmail.com, senha: 495857@AA (a correta é 495857@Aa)  |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que a senha está inválida. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT03 – Paciente faz agendamento de consultas** 	|
|	|	|
|	Requisito Associado 	| RF-003 - O sistema deve permitir o paciente agendar e cancelar consultas pelo sistema. |
| Pré-condições 	| Estar na tela de consultas |
| Passos 	| - Usuário vai preencher campos de data, horário, mas não vai selecionar a opção do tipo de atendimento <br> - É selecionada a opção “Agendar”  <br> |
|Dados de entrada | - Data: 06/10/2025, horário: 08:00, tipo de atendimento : (Não preenchido)   |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que é necessário informar o tipo do atendimento.  |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT04 – Operador faz agendamento de consultas para paciente**	|
|	|	|
|Requisito Associado | RF-004	- O sistema deve permitir o operador agendar consultas para pacientes. |
| Pré-condições 	| Estar na tela de cadastro <br> Fazer um agendamento para o paciente para o mesmo dia que será selecionado no teste   |
| Passos 	| - Operador selecionará o paciente Junior Silva <br> - Operador selecionará a data, horário e tipo de atendimento  <br> - É selecionada a opção “Agendar”  <br> |
|Dados de entrada | - Paciente: Junior Silva Data/Horário: 06/10/2025 - 08:00 Tipo de atendimento: Manutenção . |
|Resultado esperado (RE)  | - Mensagem de erro do sistema alertando que já existe um agendamento para o dia selecionado. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT05 – Dentista faz alterações na agenda de consultas** 	|
|	|	|
|	Requisito Associado 	| RF-005 - O sistema deve permitir que o dentista visualizar e gerenciar sua agenda de consultas. |
| Pré-condições 	| Estar na tela de agendamentos |
| Passos 	| - Usuário selecionará a data do dia (a depender da data da realização do teste)  <br> - Usuário selecionará a opção “Editar”  <br>  |
|Dados de entrada | Data do dia (a depender da data da realização do teste) . |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que é necessário realizar alterações com 24 horas de antecedência. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT06 – Permissão total aos dentistas a um CRUD dos prontuários dos pacientes**	|
|	|	|
|Requisito Associado | RF-006	- O sistema deve permitir que o dentista adicione, edite e remova informações do prontuário dos pacientes. |
| Pré-condições 	| Acesso à conta do dentista Ademir Roque  <br> Atendimento realizado para o paciente Junior Silva em algum dia que anteceda o teste, pelo dentista Flávio Brasil  |
| Passos 	| - Dentista selecionará o paciente Junior Silva  <br> - Dentista selecionará a exibição o atendimento realizado pelo dentista Flávio Brasil <br> - Dentista selecionará a opção “Editar”  <br> |
|Dados de entrada | - Login: Paciente: Junior Silva . |
|Resultado esperado (RE)  | - Mensagem de erro do sistema alertando que não é possível fazer alterações de prontuário de outro dentista. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT07 – Densita precisa documentar o andamento do tratamento por meio de anotações a cada consulta** 	|
|	|	|
|	Requisito Associado 	| RF-007 - O sistema deve permitir que o dentista possar adicionar anotações sobre o tratamento do paciente a cada consulta. |
| Pré-condições 	| Estar na tela de anotações dos atendimentos <br> Selecionar paciente Junior Silva <br> Selecionar data do atendimento (a depender da data do teste)    |
| Passos 	| - Dentista preencherá os campos que detalham o atendimento, ex: “houve complicações?” “há necessidade de marcar retorno para continuidade?” e etc. <br> - Dentista selecionará a opçao “Salvar” <br> - Preencher campos de login e senha para validar anotações <br>  |
|Dados de entrada | - Login: ademiroqueodon@gmail.com senha: 2984576QQ@ (senha correta 2984576Qq@) . |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que login ou senha estão incorretos. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT08 – Dentista precisa conseguir anexar resultados de exames prescrições ao prontuário do paciente** 	|
|	|	|
|Requisito Associado | RF-008	- O sistema deve permitir que o dentista anexe resultados e prescrições ao prontuário do paciente. |
| Pré-condições 	| Estar na tela de listagem de pacientes <br> Fazer um agendamento para o paciente para o mesmo dia que será selecionado no teste  |
| Passos 	| - Operador selecionará o paciente Junior Silva <br> - Operador selecionará a data, horário e tipo de atendimento <br> - É selecionada a opção “Agendar”  <br> |
|Dados de entrada | - Paciente: Junior Silva Data/Horário: 06/10/2025 - 08:00 Tipo de atendimento: Manutenção. |
|Resultado esperado (RE)  | - Mensagem de erro do sistema alertando que já existe um agendamento para o dia selecionado. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT09 – Paciente precisa enviar e visualizar exames no sistema** 	|
|	|	|
|	Requisito Associado 	| RF-009 - O sistema deve permitir que paciente possa enviar e visualizar exames dentro do sistema. |
| Pré-condições 	| Acesso a conta de paciente <br> Estar na guia “Meus exames”   |
| Passos 	| - Selecionar o primeiro exame na lista <br> - Selecionar opção visualizar  <br> |
|Dados de entrada | - Login: juniorsilvabhz@gmail.com, senha: 495857@Aa . |
|Resultado esperado (RE)  | - Exibição do exame anexado. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT10 – Paciente precisa acessar histórico de exames e consultas**	|
|	|	|
|Requisito Associado | RF-010	- O sistema deve permitir que o paciente visualize seu histórico de exames e consultas. |
| Pré-condições 	| Acesso a conta de paciente <br> Selecionar opção “Meu histórico” |
| Passos 	| - Selecionar primeira data do histórico de atendimento  <br> - Selecionar opção “Anotações”  <br> - Visualizar informações  <br> |
|Dados de entrada | - Login: juniorsilvabhz@gmail.com, senha: 495857@Aa. |
|Resultado esperado (RE)  | - Exibição das anotações feitas pelo dentista. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|
| **Caso de Teste** 	| **CT11 – Sistema deve apresentar organização cronológica do histórico de exames e consultas** 	|
|	|	|
|	Requisito Associado 	| RF-011 - O sistema deve organizar de forma cronológica todos os atendimentos, exames e procedimentos do paciente. |
| Pré-condições 	| Acesso a conta de paciente <br> Selecionar opção “Meu histórico”  |
| Passos 	| - Verificar se a listagem está organizada cronologicamente com filtros de exames e de consultas  <br> |
|Dados de entrada | - Data do dia (a depender da data da realização do teste). |
|Resultado esperado (RE)  | - Mensagem de erro do sistema avisando que é necessário realizar alterações com 24 horas de antecedência. |
|Resultado obtido (RO)  |  |
|Avaliação (pegou / não pegou erro)   |  |
|Evidência (print screen)   |  |
|  	|  	|


 

