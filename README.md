# S3 File Upload API

Esta é uma pequena API em **ASP.NET Core** que permite o upload de arquivos em formato **Base64** para um bucket no **Amazon S3**. O código utiliza as credenciais de acesso **Access Key** e **Secret Key** para interagir com o serviço da AWS.

## Índice

1. [O que é Amazon S3?](#o-que-é-amazon-s3)
2. [Pré-requisitos](#pré-requisitos)
3. [Criando um Bucket no Amazon S3](#criando-um-bucket-no-amazon-s3)
4. [Criando um Usuário IAM e Gerando Credenciais](#criando-um-usuário-iam-e-gerando-credenciais)
5. [Configurando a API](#configurando-a-api)
6. [Como Rodar a Aplicação](#como-rodar-a-aplicação)
7. [Exemplo de Requisição](#exemplo-de-requisição)

---

## O que é Amazon S3?

O **Amazon Simple Storage Service (Amazon S3)** é um serviço de armazenamento de objetos em nuvem altamente escalável oferecido pela Amazon Web Services (AWS). Ele é amplamente utilizado para armazenar e recuperar qualquer quantidade de dados, em qualquer momento, de qualquer lugar da internet.

S3 oferece durabilidade, segurança e escalabilidade para armazenar e acessar seus dados. Com ele, você pode armazenar arquivos de mídia, backups, logs de aplicativos, entre outros.

---

## Pré-requisitos

Antes de iniciar, certifique-se de ter os seguintes itens:

- Uma conta na **AWS**.
- **Visual Studio** ou qualquer outro ambiente para rodar o projeto **ASP.NET Core**.
- Conhecimentos básicos de **C#** e **REST APIs**.

---

## Criando um Bucket no Amazon S3

1. Acesse a **Console da AWS** em [aws.amazon.com](https://aws.amazon.com).
2. No painel principal, digite **S3** na barra de busca e selecione **S3**.
3. Clique no botão **Create Bucket**.
4. Dê um nome ao seu bucket (esse nome deve ser único globalmente).
5. Escolha a **região** do seu bucket.
6. Clique em **Create Bucket** para finalizar o processo.

---

## Criando um Usuário IAM e Gerando Credenciais

Para que sua aplicação possa acessar o **S3**, você precisará criar um usuário IAM com permissões de acesso ao S3.

1. Acesse a **Console da AWS** e, na barra de busca, digite **IAM**.
2. Vá para a seção de **Users** e clique em **Add User**.
3. Dê um nome para o usuário (exemplo: `s3-upload-user`).
4. Selecione a opção **Programmatic access** (Acesso programático).
5. Na seção de **Permissions**, clique em **Attach existing policies directly**.
6. Procure por **AmazonS3FullAccess** e selecione essa política.
7. Finalize a criação do usuário. Na última tela, as credenciais serão exibidas (Access Key e Secret Key). **Guarde essas credenciais**, pois elas não poderão ser vistas novamente.

---

## Configurando a API

1. No arquivo `FileController.cs`, substitua as seguintes variáveis com suas credenciais e o nome do bucket:

    ```csharp
    const string accessKeyId = "SEU_ACCESS_KEY";
    const string secretAccessKey = "SUA_SECRET_ACCESS_KEY";
    const string bucketName = "NOME_DO_BUCKET";
    ```

---

## Como Rodar a Aplicação

1. Clone este repositório:

    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. Abra o projeto no Visual Studio ou em seu ambiente preferido.
3. Certifique-se de restaurar os pacotes NuGet:

    ```bash
    dotnet restore
    ```

4. Execute a aplicação:

    ```bash
    dotnet run
    ```

5. Teste a API com Swagger: Ao rodar a aplicação, você pode testá-la diretamente pelo Swagger, que será acessível no navegador no seguinte endereço:

    ```bash
    http://localhost:{porta}/swagger
    ```

---

## Exemplo de Requisição

Para enviar um arquivo codificado em Base64 para o bucket S3, faça uma requisição POST para o endpoint `/upload`. O corpo da requisição deve seguir este formato:

**Exemplo de JSON (POST /upload):**

```json
{
  "contentBase64": "dGVzdGUgd2FnbmVy", 
  "key": "arquivo-teste.txt"
}
