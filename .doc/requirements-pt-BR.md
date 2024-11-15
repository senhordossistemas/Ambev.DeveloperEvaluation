# Projeto de Avaliação do Desenvolvedor

`LEIA COM ATENÇÃO`

## Instruções
**O teste abaixo terá até 7 dias corridos para ser entregue a partir da data de recebimento deste manual.**

- O código deve ser versionado em um repositório público do Github e um link deve ser enviado para avaliação após a conclusão
- Carregue este modelo para seu repositório e comece a trabalhar a partir dele
- Leia as instruções cuidadosamente e certifique-se de que todos os requisitos estão sendo atendidos
- O repositório deve fornecer instruções sobre como configurar, executar e testar o projeto
- A documentação e a organização geral também serão levadas em consideração

## Caso de Uso
**Você é um desenvolvedor na equipe do DeveloperStore. Agora precisamos implementar os protótipos da API.**

Como trabalhamos com `DDD`, para referenciar entidades de outros domínios, usamos o padrão `External Identities` com desnormalização de descrições de entidades.

Portanto, você escreverá uma API (CRUD completo) que manipula registros de vendas. A API precisa conseguir informar:

* Número da venda
* Data em que a venda foi realizada
* Cliente
* Valor total da venda
* Filial onde a venda foi realizada
* Produtos
* Quantidades
* Preços unitários
* Descontos
* Valor total de cada item
* Cancelado/Não cancelado

Não é obrigatório, mas seria um diferencial construir um código para publicar eventos de:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

Se você escrever o código, **não é obrigatório** realmente publicar em nenhum Message Broker. Você pode registrar uma mensagem no log do aplicativo ou da forma que achar mais conveniente.

### Regras de negócios

* Compras acima de 4 itens idênticos têm 10% de desconto
* Compras entre 10 e 20 itens idênticos têm 20% de desconto
* Não é possível vender acima de 20 itens idênticos
* Compras abaixo de 4 itens não podem ter desconto

Estas regras de negócios definem níveis e limitações de desconto com base na quantidade:

1. Níveis de desconto:
- 4+ itens: 10% de desconto
- 10-20 itens: 20% de desconto

2. Restrições:
- Limite máximo: 20 itens por produto
- Nenhum desconto permitido para quantidades abaixo de 4 itens

## Visão geral
Esta seção fornece uma visão geral de alto nível do projeto e das várias habilidades e competências que ele visa avaliar para candidatos a desenvolvedores.

Consulte [Visão geral](/.doc/overview.md)

## Pilha de tecnologia
Esta seção lista as principais tecnologias usadas no projeto, incluindo os componentes de backend, teste, frontend e banco de dados.

Veja [Tech Stack](/.doc/tech-stack.md)

## Frameworks
Esta seção descreve os frameworks e bibliotecas que são aproveitados no projeto para melhorar a produtividade e a manutenibilidade do desenvolvimento.

Veja [Frameworks](/.doc/frameworks.md)

<!--
## Estrutura da API
Esta seção inclui links para a documentação detalhada dos diferentes recursos da API:
- [API Geral](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Estrutura do Projeto
Esta seção descreve a estrutura geral e a organização dos arquivos e diretórios do projeto.

Veja [Estrutura do Projeto](/.doc/project-structure.md)