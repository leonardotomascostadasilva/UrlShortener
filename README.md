# UrlShortener

Esta é uma API simples em C# que permite encurtar URLs usando a biblioteca Nano ID. Ela também inclui um ambiente Docker para fácil implantação e testes unitários e integrados para garantir a qualidade do código.

## Funcionalidades

- Encurte URLs longas em URLs curtas.
- Redirecione URLs curtas para suas correspondentes URLs longas.
- Testes unitários e integrados para garantir a confiabilidade do sistema.

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) (versão 7 ou superior)
- [Docker](https://www.docker.com/get-started)

## Configuração

1. Clone este repositório:

   ```bash
   git clone https://github.com/leonardotomascostadasilva/UrlShortener.git

2. Navegue até o diretório do projeto:
    
    ```bash
    cd /UrlShortener/src/UrlShortner.App
 
3. Execute o comando para criar e iniciar o ambiente Docker:
     ```bash
     docker-compose up -d
 
4. No mesmo diretorio criar as migrações para EF Core:
    ```bash
    add-migration 

5. Aplicação pronta para uso

# Uso

### Encurtando URLs
Faça uma solicitação POST para http://localhost/api/shorten com o seguinte corpo JSON:

```
{
  "url": "" 
}
```

A resposta conterá a URL encurtada.

### Redirecionando URLs
Acesse a URL encurtada gerada para ser redirecionado para a URL original.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas (issues) ou enviar solicitações de pull (pull requests) para melhorar este projeto.



