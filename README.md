# To-Do List API
Este é um projeto de API de lista de tarefas desenvolvido usando .NET 6 Minimal API. Ele utiliza o padrão Fluent para construir uma interface intuitiva e expressiva para o desenvolvedor, e o banco de dados SQLite para armazenar as tarefas. Além disso, o projeto utiliza o Swagger para fornecer uma documentação detalhada da API.

## Instalação
1. Clone o repositório para o seu computador
2. Execute o comando `dotnet restore` para instalar as dependências
3. Execute o comando `dotnet run` para iniciar o projeto

## Utilização
A API fornece os seguintes endpoints:

- `GET /tarefas`: Retorna todas as tarefas armazenadas
- `GET /tarefas/{id}`: Retorna uma tarefa específica pelo seu ID
- `POST /tarefas`: Adiciona uma nova tarefa à lista
- `PUT /tarefas/{id}`: Atualiza uma tarefa existente
- `DELETE /tarefas/{id}`: Exclui uma tarefa existente

Os dados da tarefa devem ser enviados no formato JSON no corpo da requisição, com as seguintes propriedades:

- `titulo (string)`: Título da tarefa
- `finalizada (boolean)`: Indica se a tarefa está concluída ou não

A documentação detalhada da API pode ser acessada através do endpoint `/swagger/index.html` quando o projeto estiver em execução.

## Contribuição
Este projeto é aberto a contribuições. Se você encontrar algum bug ou deseja sugerir uma nova funcionalidade, por favor abra uma issue ou envie um pull request.