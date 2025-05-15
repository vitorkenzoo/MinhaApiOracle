Minha API Oracle

DescriçãoÇ

Este projeto que simula um sistema de gerenciamento de estacionamento de motos, com cadastros de:

- Clientes  
- Endereços  
- Motos  
- Vagas  

A documentação da API está disponível via Swagger

---

Rotas da API:

### Clientes
| Método | Rota                  | Descrição                 |
|--------|-----------------------|---------------------------|
| GET    | `/api/Clientes`       | Lista todos os clientes   |
| GET    | `/api/Clientes/{id}`  | Busca cliente por ID      |
| POST   | `/api/Clientes`       | Cadastra um novo cliente  |
| PUT    | `/api/Clientes/{id}`  | Atualiza um cliente       |
| DELETE | `/api/Clientes/{id}`  | Remove um cliente         |

### Endereços, Motos, Vagas
As rotas seguem o mesmo padrão acima com os respectivos endpoints `/api/Enderecos`, `/api/Motos`, `/api/Vagas`.

---

Instalação e Execução:

Requisitos:
- .NET SDK 9.0
- Acesso a um Banco de Dados Oracle
- Visual Studio Code

Clonando o projeto:
```bash
git clone https://github.com/vitorkenzoo/MinhaApiOracle.git
cd MinhaApiOracle
