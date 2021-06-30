# GestaoDeUsinas
Simulação de um sistema de gestão de usinas, com inserção, edição e listagem de dados.

# Rotas da Aplicação
###### Index ou /Usinas
Página inicial com a listagem de usinas cadastradas.<br>
_Nessa tela é possível filtrar as usinas pelos campos de fornecedor e ativo. Existe paginação e links para editar e deletar as usinas_

###### /Usinas/Create
Rota para cadastro de usinas.<br>
_Através dos parâmetros da entidade usina oferece a possibilidade de adicionar uma nova ao banco de dados_

###### /Usinas/Edit/{id}
Rota para editar os dados cadastrais da usina de identificador = id<br>
_A edição pode ser feita nessa tela informando os novos parâmetros que compõe a usina_

###### /Usinas/Delete/{id}
Rota para deletar a usina de identificador = id<br>

# Entidades da Aplicação
#### Usina
###### - Id (int)
###### - UCusina (string)
###### - FornecedorId (int)
###### - Fornecedor (Fornecedor)
###### - Ativo (bool)

#### Fornecedor
###### - Id (int)
###### - Nome (string)

# Como executar?
1. Adequar a string de conexão em appsettings.json.
2. Executar o update-database para aplicar as migrations. Nesse ponto são criadas as tabelas e os valores default de fornecedores.
3. Executar a aplicação.
