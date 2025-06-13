# LogiTrack.Core - Documentação

## 📋 Índice

1. [Visão Geral](#-visão-geral)
2. [Arquitetura](#-arquitetura)
3. [Modelos (Models)](#-modelos-models)
4. [Serviços (Services)](#-serviços-services)
5. [Contexto de Dados (Data)](#-contexto-de-dados-data)
6. [Configuração](#-configuração)
7. [Migrations](#-migrations)
---

## 🎯 Visão Geral

O **LogiTrack.Core** é uma bibliteca .NET 8 que fornece a camada de domínio e acesso a dados para um sistema completo de gerenciamento de estoque. Esta biblioteca implementa o padrão Repository/Service e utiliza Entity Framework Core com MySQL como banco de dados.

### Principais Funcionalidades

- ✅ Gerenciamento completo de produtos
- ✅ Organização por categorias
- ✅ Controle de movimentações de estoque
- ✅ Validações robustas com Data Annotations
- ✅ Soft Delete para segurança dos dados
- ✅ Relacionamentos bem definidos
- ✅ Dados iniciais (Seed Data)
- ✅ Índices otimizados para performance

---

## 🏗️ Arquitetura

A biblioteca segue uma arquitetura em camadas bem definida:

```
LogiTrack.Core/
├── Models/                 # Entidades de domínio
│   ├── Produto.cs
│   ├── Categoria.cs
│   └── MovimentoEstoque.cs
├── Services/               # Camada de serviços
│   ├── Interfaces/
│   │   ├── IProdutoService.cs
│   │   └── ICategoriaService.cs
│   ├── ProdutoService.cs
│   └── CategoriaService.cs
└── Data/                   # Camada de dados
    ├── EstoqueDbContext.cs
    └── DatabaseConfig.cs
```

### Padrões Utilizados

- **Repository Pattern**: Implementado através dos serviços
- **Dependency Injection**: Interfaces bem definidas
- **Unit of Work**: Através do DbContext
- **Data Annotations**: Para validações
- **Eager Loading**: Para otimizar consultas

---

## 📊 Modelos (Models)

### Produto

Representa um item do estoque com todas suas características e controles.

```csharp
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public string CodigoBarras { get; set; }
    public bool Ativo { get; set; }
    
    // Propriedades calculadas
    public decimal ValorTotalEstoque => Preco * QuantidadeEstoque;
    public bool EstoqueBaixo => QuantidadeEstoque <= 10;
}
```

#### Validações

| Campo | Regra | Mensagem |
|-------|-------|----------|
| Nome | Obrigatório, máx 100 caracteres | "Nome é obrigatório" |
| Descrição | Máx 500 caracteres | "Descrição deve ter no máximo 500 caracteres" |
| Preço | Obrigatório, > 0 | "Preço deve ser maior que zero" |
| QuantidadeEstoque | Obrigatório, >= 0 | "Quantidade não pode ser negativa" |
| CategoriaId | Obrigatório | "Categoria é obrigatória" |
| CodigoBarras | Máx 50 caracteres | - |

#### Relacionamentos

- **Categoria**: Many-to-One (um produto pertence a uma categoria)
- **MovimentosEstoque**: One-to-Many (um produto pode ter várias movimentações)

### Categoria

Organiza os produtos em grupos lógicos.

```csharp
public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Ativa { get; set; }
    public virtual ICollection<Produto> Produtos { get; set; }
}
```

#### Validações

| Campo | Regra | Mensagem |
|-------|-------|----------|
| Nome | Obrigatório, máx 50 caracteres | "Nome da categoria é obrigatório" |
| Descrição | Máx 200 caracteres | "Descrição deve ter no máximo 200 caracteres" |

### MovimentoEstoque

Registra todas as movimentações de entrada, saída e ajustes de estoque.

```csharp
public enum TipoMovimento
{
    Entrada = 1,    // Compras, devoluções de clientes
    Saida = 2,      // Vendas, perdas, devoluções para fornecedor
    Ajuste = 3      // Correções de inventário
}

public class MovimentoEstoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public virtual Produto? Produto { get; set; }
    public TipoMovimento Tipo { get; set; }
    public int Quantidade { get; set; }
    public string Observacao { get; set; }
    public DateTime DataMovimento { get; set; }
    public string Usuario { get; set; }
    public decimal? PrecoUnitario { get; set; }
    public decimal? ValorTotal => PrecoUnitario * Quantidade;
}
```

#### Validações

| Campo | Regra | Mensagem |
|-------|-------|----------|
| Quantidade | Obrigatório, > 0 | "Quantidade deve ser maior que zero" |
| Usuario | Obrigatório, máx 100 caracteres | - |
| Observacao | Máx 200 caracteres | - |

---

## ⚙️ Serviços (Services)

### IProdutoService

Interface que define todas as operações disponíveis para produtos.

```csharp
public interface IProdutoService
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto?> ObterPorIdAsync(int id);
    Task<Produto> AdicionarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<bool> ExcluirAsync(int id);
    Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome);
    Task<IEnumerable<Produto>> ObterPorCategoriaAsync(int categoriaId);
    Task<IEnumerable<Produto>> ObterEstoqueBaixoAsync();
    Task<bool> AtualizarEstoqueAsync(int produtoId, int novaQuantidade);
}
```

#### Métodos Detalhados

##### `ObterTodosAsync()`
- **Descrição**: Retorna todos os produtos ativos
- **Retorno**: `IEnumerable<Produto>`
- **Características**: Inclui categoria, ordenado por nome

##### `ObterPorIdAsync(int id)`
- **Descrição**: Busca um produto específico por ID
- **Parâmetros**: `id` - ID do produto
- **Retorno**: `Produto?` (null se não encontrado)
- **Características**: Inclui categoria

##### `AdicionarAsync(Produto produto)`
- **Descrição**: Adiciona um novo produto
- **Parâmetros**: `produto` - Instância do produto
- **Retorno**: `Produto` (com ID gerado)
- **Características**: Define DataCadastro automaticamente

##### `AtualizarAsync(Produto produto)`
- **Descrição**: Atualiza um produto existente
- **Parâmetros**: `produto` - Produto com dados atualizados
- **Retorno**: `Produto` atualizado
- **Exceções**: `ArgumentException` se produto não encontrado
- **Características**: Define DataUltimaAtualizacao automaticamente

##### `ExcluirAsync(int id)`
- **Descrição**: Remove um produto (soft delete)
- **Parâmetros**: `id` - ID do produto
- **Retorno**: `bool` - true se removido com sucesso
- **Características**: Marca como inativo ao invés de deletar

##### `BuscarPorNomeAsync(string nome)`
- **Descrição**: Busca produtos que contenham o nome especificado
- **Parâmetros**: `nome` - Termo de busca
- **Retorno**: `IEnumerable<Produto>`
- **Características**: Case-insensitive, apenas produtos ativos

##### `ObterPorCategoriaAsync(int categoriaId)`
- **Descrição**: Retorna produtos de uma categoria específica
- **Parâmetros**: `categoriaId` - ID da categoria
- **Retorno**: `IEnumerable<Produto>`

##### `ObterEstoqueBaixoAsync()`
- **Descrição**: Retorna produtos com estoque baixo (≤ 10 unidades)
- **Retorno**: `IEnumerable<Produto>`
- **Características**: Ordenado por quantidade (menor primeiro)

##### `AtualizarEstoqueAsync(int produtoId, int novaQuantidade)`
- **Descrição**: Atualiza apenas a quantidade em estoque
- **Parâmetros**: 
  - `produtoId` - ID do produto
  - `novaQuantidade` - Nova quantidade
- **Retorno**: `bool` - true se atualizado com sucesso

### ICategoriaService

Interface para operações com categorias.

```csharp
public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> ObterTodasAsync();
    Task<Categoria?> ObterPorIdAsync(int id);
    Task<Categoria> AdicionarAsync(Categoria categoria);
    Task<Categoria> AtualizarAsync(Categoria categoria);
    Task<bool> ExcluirAsync(int id);
    Task<IEnumerable<Categoria>> ObterAtivasAsync();
}
```

#### Características Especiais

- **Soft Delete Inteligente**: Se a categoria tem produtos, apenas marca como inativa. Se não tem produtos, remove completamente.
- **Validação de Integridade**: Impede remoção de categorias com produtos ativos.

---

## 🗄️ Contexto de Dados (Data)

### EstoqueDbContext

Classe principal que gerencia a conexão e mapeamento com o banco de dados.

```csharp
public class EstoqueDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<MovimentoEstoque> MovimentosEstoque { get; set; }
}
```

#### Configurações Específicas

##### Produto
- **Índices**: Nome, CodigoBarras (único)
- **Relacionamentos**: FK para Categoria com Restrict
- **Campos Especiais**: 
  - Preco: `decimal(10,2)`
  - DataCadastro: Default `CURRENT_TIMESTAMP`

##### MovimentoEstoque
- **Índices**: Composto (ProdutoId, DataMovimento)
- **Relacionamentos**: FK para Produto com Restrict
- **Campos Especiais**: 
  - PrecoUnitario: `decimal(10,2)`
  - DataMovimento: Default `CURRENT_TIMESTAMP`

### Dados Iniciais (Seed Data)

O sistema inclui dados de exemplo:

#### Categorias
1. **Eletrônicos** - Produtos eletrônicos e informática
2. **Papelaria** - Materiais de escritório e papelaria
3. **Casa e Jardim** - Produtos para casa e jardim
4. **Roupas** - Vestuário em geral

#### Produtos de Exemplo
- Notebook Dell Inspiron (R$ 2.500,00)
- Mouse Logitech MX (R$ 299,90)
- Teclado Mecânico Gamer (R$ 450,00)
- Caneta BIC Cristal (R$ 1,50)
- Caderno Universitário (R$ 15,90)

### DatabaseConfig

Classe utilitária para configuração da conexão.

```csharp
public static class DatabaseConfig
{
    public static string GetConnectionString()
    {
        return "Server=localhost;Port=3306;Database=sistema_estoque;Uid=root;Pwd=;";
    }
    
    public static string GetMySqlVersion()
    {
        return "8.0.21";
    }
}
```

---

## 🔧 Configuração

### Requisitos

- **.NET 8.0** ou superior
- **MySQL** 8.0+ ou **MariaDB** 10.4+
- **XAMPP** (ou qualquer servidor MySQL)

### Pacotes NuGet Necessários

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.x" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.x" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.x" />
<PackageReference Include="System.ComponentModel.Annotations" Version="5.0.0" />
```

### Configuração da String de Conexão

Edite o arquivo `DatabaseConfig.cs` conforme sua configuração:

```csharp
public static string GetConnectionString()
{
    // Para XAMPP padrão (sem senha)
    return "Server=localhost;Port=3306;Database=sistema_estoque;Uid=root;Pwd=;";
    
    // Para MySQL com senha
    // return "Server=localhost;Port=3306;Database=sistema_estoque;Uid=root;Pwd=suasenha;";
    
    // Para MySQL em porta diferente
    // return "Server=localhost;Port=3307;Database=sistema_estoque;Uid=root;Pwd=;";
}
```

### Injeção de Dependência

Para usar em aplicações, configure no `Program.cs` ou `Startup.cs`:

```csharp
// Program.cs (WPF/Console)
services.AddDbContext<EstoqueDbContext>(options =>
    options.UseMySql(DatabaseConfig.GetConnectionString(), 
        ServerVersion.Parse(DatabaseConfig.GetMySqlVersion())));

services.AddScoped<IProdutoService, ProdutoService>();
services.AddScoped<ICategoriaService, CategoriaService>();

// Startup.cs (ASP.NET Core)
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<EstoqueDbContext>(options =>
        options.UseMySql(DatabaseConfig.GetConnectionString(), 
            ServerVersion.Parse(DatabaseConfig.GetMySqlVersion())));
            
    services.AddScoped<IProdutoService, ProdutoService>();
    services.AddScoped<ICategoriaService, CategoriaService>();
}
```

---

## 🔄 Migrations

### Comandos Essenciais

No **Package Manager Console** com projeto `LogiTrack.Core` selecionado:

```bash
# Criar nova migração
Add-Migration NomeDaMigracao

# Aplicar migrações no banco
Update-Database

# Reverter para migração específica
Update-Database NomeDaMigracao

# Remover última migração (se não aplicada)
Remove-Migration

# Ver status das migrações
Get-Migration
```

### Migração Inicial

```bash
# Criar a estrutura inicial
Add-Migration InitialCreate

# Aplicar no banco
Update-Database
```

### Estrutura de Tabelas Criadas

```sql
-- Tabela: categorias
CREATE TABLE `categorias` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  `Ativa` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`)
);

-- Tabela: produtos
CREATE TABLE `produtos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Descricao` varchar(500) DEFAULT NULL,
  `Preco` decimal(10,2) NOT NULL,
  `QuantidadeEstoque` int NOT NULL,
  `CategoriaId` int NOT NULL,
  `DataCadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DataUltimaAtualizacao` datetime DEFAULT NULL,
  `CodigoBarras` varchar(50) DEFAULT NULL,
  `Ativo` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_produtos_CodigoBarras` (`CodigoBarras`),
  KEY `IX_produtos_Nome` (`Nome`),
  KEY `IX_produtos_CategoriaId` (`CategoriaId`),
  CONSTRAINT `FK_produtos_categorias_CategoriaId` 
    FOREIGN KEY (`CategoriaId`) REFERENCES `categorias` (`Id`) ON DELETE RESTRICT
);

-- Tabela: movimentosestoque
CREATE TABLE `movimentosestoque` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProdutoId` int NOT NULL,
  `Tipo` int NOT NULL,
  `Quantidade` int NOT NULL,
  `Observacao` varchar(200) DEFAULT NULL,
  `DataMovimento` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Usuario` varchar(100) NOT NULL,
  `PrecoUnitario` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_movimentosestoque_ProdutoId_DataMovimento` (`ProdutoId`,`DataMovimento`),
  CONSTRAINT `FK_movimentosestoque_produtos_ProdutoId` 
    FOREIGN KEY (`ProdutoId`) REFERENCES `produtos` (`Id`) ON DELETE RESTRICT
);
```

---

## 💻 Exemplos de Uso

### Exemplo Básico - Console Application

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LogiTrack.Core.Data;
using LogiTrack.Core.Services;

class Program
{
    static async Task Main(string[] args)
    {
        // Configurar DI
        var services = new ServiceCollection();
        ConfigureServices(services);
        var provider = services.BuildServiceProvider();
        
        // Usar os serviços
        var produtoService = provider.GetService<IProdutoService>();
        
        // Listar todos os produtos
        var produtos = await produtoService.ObterTodosAsync();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Nome} - R$ {produto.Preco:F2} - Estoque: {produto.QuantidadeEstoque}");
        }
    }
    
    static void ConfigureServices(ServiceCollection services)
    {
        services.AddDbContext<EstoqueDbContext>(options =>
            options.UseMySql(DatabaseConfig.GetConnectionString(), 
                ServerVersion.Parse(DatabaseConfig.GetMySqlVersion())));
                
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
    }
}
```

### Exemplo - Operações CRUD

```csharp
public class ExemploOperacoes
{
    private readonly IProdutoService _produtoService;
    private readonly ICategoriaService _categoriaService;
    
    public ExemploOperacoes(IProdutoService produtoService, ICategoriaService categoriaService)
    {
        _produtoService = produtoService;
        _categoriaService = categoriaService;
    }
    
    public async Task ExemplosAsync()
    {
        // 1. Criar nova categoria
        var novaCategoria = new Categoria
        {
            Nome = "Livros",
            Descricao = "Livros técnicos e literatura",
            Ativa = true
        };
        var categoriaAdicionada = await _categoriaService.AdicionarAsync(novaCategoria);
        
        // 2. Criar novo produto
        var novoProduto = new Produto
        {
            Nome = "C# in Depth",
            Descricao = "Livro avançado sobre C#",
            Preco = 89.90m,
            QuantidadeEstoque = 15,
            CategoriaId = categoriaAdicionada.Id,
            CodigoBarras = "9781234567890",
            Ativo = true
        };
        var produtoAdicionado = await _produtoService.AdicionarAsync(novoProduto);
        
        // 3. Buscar produtos por nome
        var produtosEncontrados = await _produtoService.BuscarPorNomeAsync("C#");
        
        // 4. Atualizar estoque
        await _produtoService.AtualizarEstoqueAsync(produtoAdicionado.Id, 20);
        
        // 5. Verificar produtos com estoque baixo
        var produtosEstoqueBaixo = await _produtoService.ObterEstoqueBaixoAsync();
        
        // 6. Listar produtos por categoria
        var produtosDaCategoria = await _produtoService.ObterPorCategoriaAsync(categoriaAdicionada.Id);
    }
}
```

### Exemplo - Tratamento de Erros

```csharp
public async Task<bool> AtualizarProdutoComTratamento(Produto produto)
{
    try
    {
        var produtoAtualizado = await _produtoService.AtualizarAsync(produto);
        Console.WriteLine($"Produto {produtoAtualizado.Nome} atualizado com sucesso!");
        return true;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        return false;
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Erro no banco de dados: {ex.Message}");
        return false;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro inesperado: {ex.Message}");
        return false;
    }
}
```

### Exemplo - Validações

```csharp
public async Task<(bool Sucesso, List<string> Erros)> ValidarEAdicionarProduto(Produto produto)
{
    var erros = new List<string>();
    
    // Validações personalizadas
    if (string.IsNullOrWhiteSpace(produto.Nome))
        erros.Add("Nome é obrigatório");
        
    if (produto.Preco <= 0)
        erros.Add("Preço deve ser maior que zero");
        
    if (produto.QuantidadeEstoque < 0)
        erros.Add("Quantidade não pode ser negativa");
    
    // Verificar se categoria existe
    var categoria = await _categoriaService.ObterPorIdAsync(produto.CategoriaId);
    if (categoria == null)
        erros.Add("Categoria não encontrada");
    
    // Verificar código de barras único (se fornecido)
    if (!string.IsNullOrWhiteSpace(produto.CodigoBarras))
    {
        var produtoExistente = await _produtoService.BuscarPorNomeAsync(produto.CodigoBarras);
        if (produtoExistente.Any())
            erros.Add("Código de barras já existe");
    }
    
    if (erros.Any())
        return (false, erros);
    
    try
    {
        await _produtoService.AdicionarAsync(produto);
        return (true, new List<string>());
    }
    catch (Exception ex)
    {
        erros.Add(ex.Message);
        return (false, erros);
    }
}
```


