## Integração SQL - StudyToTech

### 📋 Arquivos Criados:

1. **Data/ConexaoDB.cs** - Gerencia conexão com banco de dados
2. **Repositories/UsuarioRepositorio.cs** - Operações CRUD de usuários
3. **Repositories/DisciplinaRepositorio.cs** - Operações CRUD de disciplinas
4. **Repositories/TarefaRepositorio.cs** - Operações CRUD de tarefas
5. **Data/script_banco.sql** - Script para criar banco e tabelas

### 🔧 Como Configurar:

#### 1. Criar o Banco de Dados:
- Abra **SQL Server Management Studio**
- Execute o arquivo `Data/script_banco.sql`
- Ou execute no terminal:
  ```bash
  sqlcmd -S localhost -U sa -P sua_senha -i script_banco.sql
  ```

#### 2. Atualizar Credenciais:
No arquivo `Data/ConexaoDB.cs`, altere:
```csharp
private string connectionString = "Server=localhost;Database=StudyToTech;User Id=sa;Password=sua_senha;";
```

Substitua:
- `localhost` → seu servidor SQL
- `sa` → seu usuário SQL
- `sua_senha` → sua senha

#### 3. Restaurar dependências:
```bash
dotnet restore
```

### 📝 Como Usar:

#### Exemplo - Adicionar Usuário:
```csharp
using StudyToTech.Repositories;

UsuarioRepositorio repo = new UsuarioRepositorio();
Usuario user = new Usuario { nome = "João", email = "joao@email.com" };
repo.AdicionarUsuario(user);
```

#### Exemplo - Listar Usuários:
```csharp
UsuarioRepositorio repo = new UsuarioRepositorio();
repo.ListarTodos();
```

### ⚠️ Importante:
- Certifique-se de ter SQL Server instalado
- Se usar SQL Express local, use `(localdb)\mssqllocaldb` como server
- Você pode usar Azure SQL Database alterando o connection string

### 🚀 Próximos Passos:
- Integrar repositórios no `Program.cs`
- Adicionar mais funcionalidades aos repositórios
- Implementar tratamento de exceções mais robusto
