# UpStyle API

## Visão Geral

A API da empresa UpStyle é um serviço feito com ASP.NET Core que fornece uma interface para gerenciar informações relacionadas a empresas. Nessa API utilizamos o Entity Framework Core para interagir com um banco de dados Oracle e inclui validação personalizada de CNPJ para garantir a integridade dos dados.

## Arquitetura

### Arquitetura Monolítica

Escolhemos uma arquitetura monolítica para este projeto. Na arquitetura monolítica, todos os componentes da aplicação são integrados em um único projeto, facilitando a implementação e a gestão inicial. Com isso, a API, o contexto do banco de dados e os controladores estão todos presentes em um único serviço. Além disso permite uma gestão mais simples do projeto.

### Design Patterns Utilizados

**Singleton**: Utilizado para garantir que o serviço de configuração (`ConfigurationService`) seja instanciado uma única vez e compartilhado por toda a aplicação. Isso é implementado através da configuração dos serviços na `Program.cs`.

## Instruções para Rodar a API

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Oracle Database
- Rider ou Visual Code

### Configuração

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/seu-usuario/upstyle-api.git
   cd upstyle-api

### Instalação de Pacotes

Para rodar o código essa intalações são necessárias

1. **Microsoft.AspNetCore.Mvc**

   ```bash
   dotnet add package Microsoft.AspNetCore.Mvc --version 2.2.0

2. **Microsoft.EntityFrameworkCore**
    
  ```bash
  dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
