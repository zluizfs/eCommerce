using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            // migrationBuilder.CreateTable(
            //     name: "Pessoa",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //         CpfCnpj = table.Column<long>(type: "bigint", nullable: false),
            //         Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Pessoa__7061465D49C7CF21", x => x.IdPessoa);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "TabelaDescritiva",
            //     columns: table => new
            //     {
            //         IdTabelaDescritiva = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__TabelaDe__5C5135773EEC0060", x => x.IdTabelaDescritiva);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "TipoMovimento",
            //     columns: table => new
            //     {
            //         IdTipoMovimento = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Compra, venda, orçamento"),
            //         OperacaoEstoque = table.Column<short>(type: "smallint", nullable: false, comment: "-1: diminuir estoque (movimento de Venda para cliente)\r\n0: não afetar estoque (orçamento)\r\n1: aumenta estoque (movimento de Compra - fornecedor)"),
            //         Cliente = table.Column<bool>(type: "bit", nullable: false, comment: "Busca dados de clientes ao realizar a operação, caso seja verdadeiro (1).\r\nCaso contrário (0), busca dados de fornecedores")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__TipoMovi__A9321B46715BAB59", x => x.IdTipoMovimento);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "UF",
            //     columns: table => new
            //     {
            //         IdUF = table.Column<short>(type: "smallint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //         Sigla = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__UF__B770025B9D18DDA3", x => x.IdUF);
            //     });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateTable(
            //     name: "Cliente",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         IsPreferencial = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Cliente__7061465D4B0B807C", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Cliente",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Fornecedor",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         PrazoPrevistoEntrega = table.Column<short>(type: "smallint", nullable: false, comment: "Prazo médio de entrega pelo fornecedor em dias\r\nCalculado a partir das compras feitas")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Forneced__7061465DE71F5FAE", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Fornecedor",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Funcionario",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         CarteiraTrabalho = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Funciona__7061465DE535F0CB", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Funcionario",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "PessoaFisica",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
            //         RG = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__PessoaFi__7061465D0AA9C6A4", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_PessoaFisica",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "PessoaJuridica",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         InscricaoEstadual = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //         NomeFantasia = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__PessoaJu__7061465D232A187D", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_PessoaJuridica",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "TabelaDescritivaConteudo",
            //     columns: table => new
            //     {
            //         IdTabelaDescritivaConteudo = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdTabelaDescritiva = table.Column<int>(type: "int", nullable: false),
            //         Descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__TabelaDe__839A5D7F263BD181", x => x.IdTabelaDescritivaConteudo);
            //         table.ForeignKey(
            //             name: "FK_TabelaDescritiva_TabelaDescritivaConteudo",
            //             column: x => x.IdTabelaDescritiva,
            //             principalTable: "TabelaDescritiva",
            //             principalColumn: "IdTabelaDescritiva",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Movimento",
            //     columns: table => new
            //     {
            //         IdMovimento = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdTipoMovimento = table.Column<int>(type: "int", nullable: false),
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         Data = table.Column<DateTime>(type: "datetime", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Moviment__9EBD6E4D04E8E227", x => x.IdMovimento);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Movimento",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_TipoMovimento_Movimento",
            //             column: x => x.IdTipoMovimento,
            //             principalTable: "TipoMovimento",
            //             principalColumn: "IdTipoMovimento",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Cidade",
            //     columns: table => new
            //     {
            //         IdCidade = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdUF = table.Column<short>(type: "smallint", nullable: false),
            //         Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Cidade__160879A35C50D101", x => x.IdCidade);
            //         table.ForeignKey(
            //             name: "FK_UF_Cidade",
            //             column: x => x.IdUF,
            //             principalTable: "UF",
            //             principalColumn: "IdUF",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Loja",
            //     columns: table => new
            //     {
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         IdTipoLoja = table.Column<int>(type: "int", nullable: false, comment: "Matriz ou Filial"),
            //         IdLojaMatriz = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Loja__7061465DA3E63FAE", x => x.IdPessoa);
            //         table.ForeignKey(
            //             name: "FK_Matriz_Filial",
            //             column: x => x.IdLojaMatriz,
            //             principalTable: "Loja",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Loja",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_TipoLoja_Loja",
            //             column: x => x.IdTipoLoja,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Produto",
            //     columns: table => new
            //     {
            //         IdProduto = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //         IdCategoria = table.Column<int>(type: "int", nullable: false),
            //         IdMarca = table.Column<int>(type: "int", nullable: false),
            //         IdCor = table.Column<int>(type: "int", nullable: false),
            //         IdTamanho = table.Column<int>(type: "int", nullable: false),
            //         IdUnidade = table.Column<int>(type: "int", nullable: false),
            //         ValorUnitario = table.Column<decimal>(type: "money", nullable: false),
            //         EstoqueMinimoSugerido = table.Column<short>(type: "smallint", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Produto__2E883C23C0F19D0D", x => x.IdProduto);
            //         table.ForeignKey(
            //             name: "FK_Categoria_Produto",
            //             column: x => x.IdCategoria,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Cor_Produto",
            //             column: x => x.IdCor,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Marca_Produto",
            //             column: x => x.IdMarca,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Tamanho_Produto",
            //             column: x => x.IdTamanho,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Unidade_Produto",
            //             column: x => x.IdUnidade,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Telefone",
            //     columns: table => new
            //     {
            //         IdTelefone = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         Numero = table.Column<long>(type: "bigint", nullable: false),
            //         IdTipo = table.Column<int>(type: "int", nullable: false, comment: "Comercial\r\nResidencial\r\nPessoal")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Telefone__9B8AC7A915EE557C", x => x.IdTelefone);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Telefone",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FKTelefone206041",
            //             column: x => x.IdTipo,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Endereco",
            //     columns: table => new
            //     {
            //         IdEndereco = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         Logradouro = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //         Numero = table.Column<int>(type: "int", nullable: false),
            //         Bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //         CEP = table.Column<int>(type: "int", nullable: false),
            //         IdCidade = table.Column<int>(type: "int", nullable: false),
            //         IdTipo = table.Column<int>(type: "int", nullable: false, comment: "Residencial ou Comercial")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Endereco__0B7C7F17261E23E7", x => x.IdEndereco);
            //         table.ForeignKey(
            //             name: "Fk_Cidade_Endereco",
            //             column: x => x.IdCidade,
            //             principalTable: "Cidade",
            //             principalColumn: "IdCidade",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Pessoa_Endereco",
            //             column: x => x.IdPessoa,
            //             principalTable: "Pessoa",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_TipoEndereco_Endereco",
            //             column: x => x.IdTipo,
            //             principalTable: "TabelaDescritivaConteudo",
            //             principalColumn: "IdTabelaDescritivaConteudo",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "ProdutoLoja",
            //     columns: table => new
            //     {
            //         IdProdutoLoja = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         IdProduto = table.Column<int>(type: "int", nullable: false),
            //         IdPessoa = table.Column<int>(type: "int", nullable: false),
            //         EstoqueMinimo = table.Column<short>(type: "smallint", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__ProdutoL__5DBEBBFF7D42DEAD", x => x.IdProdutoLoja);
            //         table.ForeignKey(
            //             name: "FK_Loja_Produto",
            //             column: x => x.IdPessoa,
            //             principalTable: "Loja",
            //             principalColumn: "IdPessoa",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_Produto_Loja",
            //             column: x => x.IdProduto,
            //             principalTable: "Produto",
            //             principalColumn: "IdProduto",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "MovimentoItem",
            //     columns: table => new
            //     {
            //         IdMovimento = table.Column<int>(type: "int", nullable: false),
            //         IdProdutoLoja = table.Column<int>(type: "int", nullable: false),
            //         Quantidade = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
            //         ValorUnitario = table.Column<decimal>(type: "money", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Moviment__7B6685F2850D5DC6", x => new { x.IdMovimento, x.IdProdutoLoja });
            //         table.ForeignKey(
            //             name: "FK_Movimento_MovimentoItem",
            //             column: x => x.IdMovimento,
            //             principalTable: "Movimento",
            //             principalColumn: "IdMovimento",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_ProdutoLoja_MovimentoItem",
            //             column: x => x.IdProdutoLoja,
            //             principalTable: "ProdutoLoja",
            //             principalColumn: "IdProdutoLoja",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_IdUF",
                table: "Cidade",
                column: "IdUF");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCidade",
                table: "Endereco",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPessoa",
                table: "Endereco",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdTipo",
                table: "Endereco",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_IdLojaMatriz",
                table: "Loja",
                column: "IdLojaMatriz");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_IdTipoLoja",
                table: "Loja",
                column: "IdTipoLoja");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdPessoa",
                table: "Movimento",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdTipoMovimento",
                table: "Movimento",
                column: "IdTipoMovimento");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoItem_IdProdutoLoja",
                table: "MovimentoItem",
                column: "IdProdutoLoja");

            migrationBuilder.CreateIndex(
                name: "UQ__Pessoa__0BCA032AA427C2C3",
                table: "Pessoa",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCategoria",
                table: "Produto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCor",
                table: "Produto",
                column: "IdCor");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdMarca",
                table: "Produto",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdTamanho",
                table: "Produto",
                column: "IdTamanho");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdUnidade",
                table: "Produto",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoLoja_IdPessoa",
                table: "ProdutoLoja",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoLoja_IdProduto",
                table: "ProdutoLoja",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDescritivaConteudo_IdTabelaDescritiva",
                table: "TabelaDescritivaConteudo",
                column: "IdTabelaDescritiva");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdPessoa",
                table: "Telefone",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdTipo",
                table: "Telefone",
                column: "IdTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "MovimentoItem");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "ProdutoLoja");

            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DropTable(
                name: "TipoMovimento");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "TabelaDescritivaConteudo");

            migrationBuilder.DropTable(
                name: "TabelaDescritiva");
        }
    }
}
