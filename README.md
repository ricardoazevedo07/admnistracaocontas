# Sistema Financeiro - Fullstack

## Tecnologias

### Backend
- .NET 8
- Clean Architecture
- EF Core
- SQL Server

### Frontend
- React
- Typescript
- React Query
- Axios
- Bootstrap

---

# 📊 Sistema de Gestão Financeira

Aplicação desenvolvida para gerenciamento de Pessoas, Categorias e Transações financeiras, incluindo consultas de totais por pessoa e por categoria.

O sistema segue princípios de arquitetura em camadas (Service + Repository) e validações de regra de negócio.

---

# 🚀 Tecnologias Utilizadas

## Backend

* ASP.NET Core
* Entity Framework Core
* Clean Architecture
* SQL Server

## Frontend

* React + TypeScript
* React Hook Form
* React Query
* Axios
* Bootstrap 5

---

# 📌 Funcionalidades Implementadas

---

# 👤 Cadastro de Pessoas

CRUD completo:

* ✅ Criação
* ✅ Edição
* ✅ Exclusão
* ✅ Listagem

### Regras

* O identificador é gerado automaticamente.
* Nome: texto com tamanho máximo de 200 caracteres.
* Idade: calculada com base na data de nascimento.
* Ao excluir uma pessoa, todas as suas transações são removidas automaticamente (cascade delete).

### Estrutura

| Campo          | Tipo      | Regra                          |
| -------------- | --------- | ------------------------------ |
| Identificador  | Guid      | Gerado automaticamente         |
| Nome           | string    | Máx. 200 caracteres            |
| DataNascimento | Date      | Obrigatório                    |
| Idade          | Calculado | Derivado da data de nascimento |

---

# 🗂 Cadastro de Categorias

Funcionalidades:

* ✅ Criação
* ✅ Listagem

### Regras

* Identificador gerado automaticamente.
* Descrição com tamanho máximo de 400 caracteres.
* Finalidade obrigatória:

  * Despesa
  * Receita
  * Ambas

### Estrutura

| Campo         | Tipo   | Regra                     |
| ------------- | ------ | ------------------------- |
| Identificador | Guid   | Gerado automaticamente    |
| Descrição     | string | Máx. 400 caracteres       |
| Finalidade    | enum   | Despesa / Receita / Ambas |

---

# 💰 Cadastro de Transações

Funcionalidades:

* ✅ Criação
* ✅ Listagem

### Regras de Negócio

1. Identificador gerado automaticamente.
2. Valor deve ser positivo.
3. Tipo:

   * Despesa
   * Receita
4. Pessoa menor de 18 anos:

   * ❌ Não pode registrar receitas.
   * ✅ Apenas despesas são permitidas.
5. Restrição de categoria:

   * Se a transação for Despesa → não pode usar categoria de Receita.
   * Se for Receita → não pode usar categoria de Despesa.
   * Categoria “Ambas” é aceita para ambos os tipos.

### Estrutura

| Campo         | Tipo    | Regra                  |
| ------------- | ------- | ---------------------- |
| Identificador | Guid    | Gerado automaticamente |
| Descrição     | string  | Máx. 400 caracteres    |
| Valor         | decimal | Apenas positivo        |
| Tipo          | enum    | Despesa / Receita      |
| Categoria     | Guid    | Respeita finalidade    |
| Pessoa        | Guid    | Obrigatório            |

---

# 📈 Consulta de Totais por Pessoa

Exibe:

* Total de receitas
* Total de despesas
* Saldo (Receitas – Despesas)

Ao final da listagem:

* Total geral de receitas
* Total geral de despesas
* Saldo líquido consolidado

---

# 📊 Consulta de Totais por Categoria (Opcional)

Exibe:

* Total de receitas
* Total de despesas
* Saldo por categoria

Ao final:

* Total geral consolidado

---

# 🧠 Regras de Negócio Implementadas no Backend

* Validação de maioridade para receitas.
* Validação de coerência entre tipo da transação e finalidade da categoria.
* Exclusão em cascata de transações ao remover pessoa.
* Tratamento global de exceções retornando mensagens amigáveis para o frontend.

---

# 🎨 Interface

* Layout moderno com Bootstrap 5
* Formulários centralizados
* Listagens com totais consolidados
* Modal global para exibição de erros de API

---

# ▶️ Como Executar o Projeto

## Backend

```bash
dotnet restore
dotnet build
dotnet run
```

## Frontend

```bash
npm install
npm run dev
```

---

# 📌 Estrutura do Projeto

```
Backend
 ├── Domain
 ├── Application
 ├── Infrastructure
 └── Web

Frontend
 ├── pages
 ├── components
 ├── services
 └── types
```

---


