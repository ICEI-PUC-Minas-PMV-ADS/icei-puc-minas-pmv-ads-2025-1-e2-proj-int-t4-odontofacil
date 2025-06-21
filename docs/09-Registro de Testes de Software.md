# Registro de Testes de Software

---

## Caso de Teste CT01 – Cadastrar perfil

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT01 – Cadastrar perfil |
| Requisito Associado | RF-00X - A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/3ba135ba-6efe-4388-9324-9527be63ac42" alt="ct01"/> <br> <img src="https://github.com/user-attachments/assets/0eeccfb2-1a9e-47f4-8f06-128d6b50ea65" alt="ct001"> |
| Resultado esperado (RE) | Acessar tela de login |
| Resultado obtido (RO)   | Acesso a tela de login |

---

## Caso de Teste CT02 – Realizar login

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT02 – Realizar login |
| Requisito Associado | RF-00Y - A aplicação deve permitir que um usuário previamente cadastrado faça login |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/ae56b889-a09c-4d6d-9d5f-94f0772d85c5" alt="ct02"/> <br> <img src="https://github.com/user-attachments/assets/2585a531-136d-4daf-af36-8f3972f000ae" alt="ct002"> |
| Resultado esperado (RE) | Login e acesso a lista de pacientes |
| Resultado obtido (RO)   | Login funcionou e tela de lista de pacientes foi exibida |

---

## Caso de Teste CT03 – Paciente faz agendamento de consultas

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT03 – Paciente faz agendamento de consultas |
| Requisito Associado | RF-003 - O sistema deve permitir o paciente agendar e cancelar consultas pelo sistema. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/c1fff23c-e781-471f-8b30-afe6fe03df56" alt="ct03"/> <br> <img src="https://github.com/user-attachments/assets/f0c1f06e-79a2-4c7a-b14f-274fe2a344ba" alt="ct003"> |
| Resultado esperado (RE) | Redirecionamento para tela de agendamentos constando agendamento criado na lista |
| Resultado obtido (RO)   | Redirecionado para tela de agendamentos e agendamento realizado. |

---

## Caso de Teste CT04 – Operador faz agendamento de consultas para paciente

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT04 – Operador faz agendamento de consultas para paciente |
| Requisito Associado | RF-004 - O sistema deve permitir o operador agendar consultas para pacientes. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/8ad6d8ed-20ae-435d-beaa-fa02ecde341f" alt="ct04"/> <br> <img src="https://github.com/user-attachments/assets/089f8a67-73ea-4646-ba78-4cd90656135e" alt="ct004"> |
| Resultado esperado (RE) | Redirecionamento para tela de agendamentos com agendmento listado |
| Resultado obtido (RO)   | Redirecionamento para tela de agendamentos com agendmento listado |

---

## Caso de Teste CT05 – Dentista faz alterações na agenda de consultas

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT05 – Dentista faz alterações na agenda de consultas |
| Requisito Associado | RF-005 - O sistema deve permitir que o dentista visualizar e gerenciar sua agenda de consultas. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/b77cae5b-6167-44ed-9472-ef251e115f7f" alt="ct05"/> <br> <img src="https://github.com/user-attachments/assets/9b2b40cc-de00-4052-a7f6-db4c8bef9367" alt="ct005"> <br> <img src="https://github.com/user-attachments/assets/40592fdb-bebe-495d-9071-bdaf6af55655" alt="ct0005"/> |
| Resultado esperado (RE) | Mensagem "Agendamento cancelado com sucesso" |
| Resultado obtido (RO)   | Mensagem "Agendamento cancelado com sucesso" |

---

## Caso de Teste CT06 – Permissão total aos dentistas a um CRUD dos prontuários dos pacientes

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT06 – Permissão total aos dentistas a um CRUD dos prontuários dos pacientes |
| Requisito Associado | RF-006 - O sistema deve permitir que o dentista adicione, edite e remova informações do prontuário dos pacientes. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/1ab85536-8236-4cd6-8c37-970bd4e78709" alt="ct06"/> <br> <img src="https://github.com/user-attachments/assets/7cd95827-03a1-49fe-b960-1f0c0e6b7702" alt="ct006"> <br> <img src="https://github.com/user-attachments/assets/28796368-886f-4ccd-8e80-c3191074ac03" alt="ct0006"/> |
| Resultado esperado (RE) | Recarregamento da página e informação atualizada |
| Resultado obtido (RO)   | Página recarregada armazenando informação alterada |

---

## Caso de Teste CT07 – Dentista precisa documentar o andamento do tratamento por meio de anotações a cada consulta

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT07 – Dentista precisa documentar o andamento do tratamento por meio de anotações a cada consulta |
| Requisito Associado | RF-007 - O sistema deve permitir que o dentista possa adicionar anotações sobre o tratamento do paciente a cada consulta. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/0d17db9b-5705-4ebb-b986-f0b675f9225c" alt="ct07"/> <br> <img src="https://github.com/user-attachments/assets/e8401509-4ceb-4c4b-9fc9-56ba604b2d1a" alt="ct007"/> |
| Resultado esperado (RE) | Alteração realizada com sucesso. |
| Resultado obtido (RO)   | Alteração realizada com sucesso. |

---

## Caso de Teste CT08 – Dentista precisa conseguir anexar resultados de exames prescrições ao prontuário do paciente

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT08 – Dentista precisa conseguir anexar resultados de exames prescrições ao prontuário do paciente |
| Requisito Associado | RF-008 - O sistema deve permitir que o dentista anexe resultados e prescrições ao prontuário do paciente. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/ae56b889-a09c-4d6d-9d5f-94f0772d85c5" alt="ct08"/> <br> <img src="https://github.com/user-attachments/assets/5512b5db-6f26-4317-b32a-7c4e63acec3e" alt="ct008"/> |
| Resultado esperado (RE) | Resultado de exame listado. |
| Resultado obtido (RO)   | Resultado de exame listado. |

---

## Caso de Teste CT09 – Paciente precisa enviar e visualizar exames no sistema

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT09 – Paciente precisa enviar e visualizar exames no sistema |
| Requisito Associado | RF-009 - O sistema deve permitir que paciente possa enviar e visualizar exames dentro do sistema. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/694ed756-9362-49c9-b59a-8fe4ba9324bb" alt="ct09"/> <br> <img src="https://github.com/user-attachments/assets/3fadc4bb-6d0a-4fcb-a90c-d1e1e53a8d82" alt="ct009"> |
| Resultado esperado (RE) | Exibição resultado do exame |
| Resultado obtido (RO)   | Arquivo não encontrado no servidor |

---

## Caso de Teste CT10 – Paciente precisa acessar histórico de exames e consultas

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT10 – Paciente precisa acessar histórico de exames e consultas |
| Requisito Associado | RF-010 - O sistema deve permitir que o paciente visualize seu histórico de exames e consultas. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/dc04fc33-f8dd-4773-887c-128b7b6b96d7" alt="ct10"/> |
| Resultado esperado (RE) | Exibição do histórico de consultas. |
| Resultado obtido (RO)   | Exibição do histórico de consultas. |

---

## Caso de Teste CT11 – Sistema deve apresentar organização cronológica do histórico de exames e consultas

| Campo | Conteúdo |
|:---:|:---:|
| **Caso de Teste** | CT11 – Sistema deve apresentar organização cronológica do histórico de exames e consultas |
| Requisito Associado | RF-011 - O sistema deve organizar de forma cronológica todos os atendimentos, exames e procedimentos do paciente. |
| Registro de evidência | <img src="https://github.com/user-attachments/assets/430470f0-ea5e-46f3-bb7f-2afa9267a47a" alt="ct011"/> |
| Resultado esperado (RE) | Exibição organizada das consultas. |
| Resultado obtido (RO)   | Exibição organizada das consultas. |
