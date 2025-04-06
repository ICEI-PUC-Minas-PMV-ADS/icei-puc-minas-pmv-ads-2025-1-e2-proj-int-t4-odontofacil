# Plano de Testes de Usabilidade

Os testes de usabilidade permitem avaliar a qualidade da interface com o usuário da aplicação interativa.

Um plano de teste de usabilidade deverá conter: 

## Definição do(s) objetivo(s)

Antes de iniciar os testes, é essencial definir o que se deseja avaliar na usabilidade do sistema. 
Alguns exemplos de objetivos são:
- Verificar se os usuários conseguem concluir tarefas essenciais sem dificuldades.
- Identificar barreiras na navegação e interação com o sistema.
- Avaliar a eficiência e a satisfação do usuário ao utilizar a interface.
- Testar a acessibilidade para diferentes perfis de usuários.

## Seleção dos participantes

Para garantir que o teste reflita o uso real do sistema, escolha participantes representativos do público-alvo.

**Critérios para selecionar participantes:**
- Perfis variados (experientes e iniciantes no sistema).
- Diferentes níveis de familiaridade com tecnologia.
- Pessoas com necessidades especiais (se aplicável).

**Quantidade recomendada:**
Mínimo: 5 participantes.
Ideal: Entre 8 e 12 para maior diversidade.

## Definição de cenários de teste

Os cenários representam tarefas reais que os usuários executam no sistema. Neste projeto, cada grupo deverá definir, no mínimo, **CINCO cenários para a aplicação** e cada cenário deve incluir:

- Objetivo: O que será avaliado.
- Contexto: A situação que leva o usuário a interagir com o sistema.
- Tarefa: A ação que o usuário deve realizar.
- Critério de sucesso: Como determinar se a tarefa foi concluída corretamente.

<table border="1">
  <thead>
    <tr>
      <th>CENÁRIOS</th>
      <th>OBJETIVO</th>
      <th>CONTEXTO</th>
      <th>TAREFA</th>
      <th>CRITÉRIO</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Um paciente deseja utilizar um serviço da plataforma</td>
      <td>Agendar Consultas e Exames</td>
      <td>O usuário deseja marcar seus exames e suas consultas por meio do prontuário eletrônico</td>
      <td>
        1- Acessar o Odonto Fácil.<br>
        2- Criar ou informar cadastro<br>
        3- Ir para Informações do Paciente<br>
        4- Agendar Consultas e Exames
      </td>
      <td>Consultar, sem ajuda externa</td>
    </tr>
    <tr>
      <td>Um paciente deseja consultar suas futuras consultas e exames na plataforma</td>
      <td>Consultar Agendamentos</td>
      <td>O usuário quer visualizar os horários e datas das consultas e exames agendados</td>
      <td>
        1- Acessar o Odonto Fácil.<br>
        2- Criar ou informar cadastro<br>
        3- Ir para Informações do Paciente<br>
        4- Agendamentos
      </td>
      <td>Visualizar a informação correta</td>
    </tr>
    <tr>
      <td>Um paciente deseja consultar o histórico das suas consultas e exames já feitos</td>
      <td>Histórico de Consultas e Exames</td>
      <td>O usuário precisa consultar os atendimentos e exames já realizados</td>
      <td>
        1- Acessar o Odonto Fácil.<br>
        2- Criar ou informar cadastro<br>
        3- Ir para Informações do Paciente<br>
        4- Histórico de Consultas e Exames
      </td>
      <td>Achar os registros corretos sem cometer erros</td>
    </tr>
    <tr>
      <td>Um paciente precisa atualizar seus dados para que possa usar a plataforma</td>
      <td>Atualizar Dados</td>
      <td>O usuário deseja atualizar seu telefone e endereço no prontuário</td>
      <td>
        1- Acessar o Odonto Fácil.<br>
        2- Criar ou informar cadastro<br>
        3- Ir para Informações do Paciente<br>
        4- Atualizar Dados
      </td>
      <td>Finalizar a edição e os dados ficam salvos corretamente</td>
    </tr>
    <tr>
      <td>Um paciente deseja fazer o envio de um exame para análise</td>
      <td>Usuário deseja enviar um exame</td>
      <td>O usuário deseja se enviar um exame no prontuário eletrônico</td>
      <td>
        1- Acessar o Odonto Fácil.<br>
        2- Criar ou informar cadastro<br>
        3- Ir para Informações do Paciente<br>
        4- Anexar exame
      </td>
      <td>Arquivo do exame ser anexado</td>
    </tr>
  </tbody>
</table>

/## Métodos de coleta de dados

<table border="1">
  <thead>
    <tr>
      <th>Heurísticas de Nielsen</th>
      <th>Nota dos Avaliadores</th>
      <th>Média</th>
      <th>Consenso</th>
      <th>Considerações</th>
      <th>Melhorias</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Visibilidade do Status do Sistema</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Correspondência entre o Sistema e o Mundo Real</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Controle de usuários e liberdade</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Prevenção de erros</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Consistência e padrões</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Reconhecimento ao invés de lembrar</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Flexibilidade e eficiência de uso</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Design estético e minimalista</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Ajudar os usuários a reconhecer, diagnosticar e recuperar erros</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Ajuda e documentação</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
  </tbody>
</table>
