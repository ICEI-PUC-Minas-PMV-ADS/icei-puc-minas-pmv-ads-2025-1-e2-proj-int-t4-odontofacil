# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Para garantir que nosso projeto atenda de forma satisfatória às necessidades reais dos usuários, desenvolvemos um conjunto de personas. Essas personas foram criadas com base em dados e pesquisas para refletir uma variedade de perfis e situações que nossos usuários podem enfrentar.

Com base nelas, identificamos possíveis cenários e desafios que nossos usuários reais podem encontrar. Esse processo de criação e análise nos ajudou a visualizar melhor as suas necessidades e expectativas, permitindo que orientássemos o projeto de maneira mais precisa e centrada no usuário.

As personas não apenas serviram como guia para entender os comportamentos e preferências dos nossos usuários, mas também foram fundamentais para direcionar as decisões de design e desenvolvimento. Ao alinhar nosso trabalho com as situações e desafios que essas personas enfrentam, conseguimos garantir que nosso projeto seja mais relevante, útil e eficaz para o público que pretendemos atingir.

>Pacientes
<img src="https://github.com/user-attachments/assets/bbacd153-9e37-47f2-b80f-c5a9d414c49e" alt="Persona1"/>
<img src="https://github.com/user-attachments/assets/fe1bc90a-d123-49a0-a0ca-13afe9d85836" alt="Persona2"/>

>Operador
<img src="https://github.com/user-attachments/assets/84f53593-e8dd-4371-b865-811274a8354d" alt="Persona3"/>

>Dentista/Auxiliar de Dentista
<img src="https://github.com/user-attachments/assets/76f8c6a8-3cbd-40d1-8c14-76a1ec11b558" alt="Persona4"/>
<img src="https://github.com/user-attachments/assets/174f6434-1985-4077-900c-f17e1eeccdc4" alt="Persona5"/>

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... | QUERO/PRECISO ...  |PARA ...                |
|--------------------|------------------------------------|----------------------------------------|
|Marcos| Marcar ou cancelar horários para consultas pelo site           | Buscando organizar a rotina               |
|Lucas| Ter um FAQ ou canal de dúvidas                 | Que eu possa sanar todas as minhas dúvidas rapidamente |
|Lucas| Fazer um agendamento para avaliação pelo site           | Evitar filas de espera ao telefone ou conversas em chats               |
|Rafaela| Realizar cadastro de pacientes                 | Acessar seus cadastros de qualquer computador com acesso à internet |
|Rafaela| Quadro de horários atualizado           | Identificar possíveis realocações de horários               |
|Rafaela| Informativo de valores de procedimentos                 | Tirar dúvidas de pacientes |
|Rafaela| Automatização de envio de lembretes para equipe/pacientes | Evitar a falha em atendimentos por falta de material ou exames  |
|Daniela  | Prontuário digital interativo                 | Adicionar informações sobre o paciente |
|Daniela  | Solicitar e receber resultados de exames | Garantir que o paciente receberá orientações para fazer os exames e por vezes prever próximas etapas do tratamento               |
|Daniela    | Organização cronológica dos procedimentos do paciente                 | Observar evolução do tratamento  |
|Leandro | Avaliar histórico do paciente           | Identificar o que pode ser feito para prepará-lo para a consulta               |
|Leandro | Preencher etapas realizadas                | Criar um histórico de cada atendimento |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir que o usuário avalie uma agência de intercâmbio com base na sua experiência| ALTA | 
|RF-002| A aplicação deve permitir que o usuário inclua comentários ao fazer uma avaliação de uma agência de intercâmbio    | ALTA |
|RF-003| A aplicação deve permitir que o usuário consulte todas as agências de intercâmbio cadastradas ordenando-as com base em suas notas | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | MÉDIA | 
|RNF-002| A aplicação deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
