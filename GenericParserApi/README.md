# GenericParserApi

## Description

GenericParserApi is an ASP.NET Core Web API application built with .NET 10.

The API accepts Base64 encoded content and parses it depending on the selected type.

Supported formats:
- CSV
- INTERNAL_JSON

Endpoint:

```
POST /api/v1/parse-content
```

---

## Technologies

- .NET 10
- ASP.NET Core Web API
- Swagger
- Dependency Injection
- System.Text.Json

---

## Running the application

1. Clone the repository:

```bash
git clone https://github.com/TomaszBachor/GenericParserApi.git
```

2. Navigate to the project directory.

3. Run the application:

```bash
dotnet run
```

4. Open Swagger:

```
https://localhost:7218/swagger
```

5. In Swagger:
   - expand **POST /api/v1/parse-content**
   - click **Try it out**
   - enter the request body
   - click **Execute**

---

## Example request (CSV)

```json
{
  "type": "CSV",
  "content": "TmFtZSxBZ2UsQ2l0eQpKYW4sMjUsS3Jha293CkFubmEsMzAsV2Fyc3phd2E="
}
```

---

## Example request (INTERNAL_JSON)

```json
{
  "type": "INTERNAL_JSON",
  "content": "WwogIHsKICAgICJOYW1lIjoiSmFuIiwKICAgICJBZ2UiOjI1LAogICAgIkNpdHkiOiJLcmFrb3ciCiAgfSwKICB7CiAgICAiTmFtZSI6IkFubmEiLAogICAgIkFnZSI6MzAsCiAgICAiQ2l0eSI6IldhcnN6YXdhIgogIH0KXQ=="
}
```

---

## Response

The API returns:

- operation status,
- number of parsed records,
- processing date,
- parsed data in a unified structure.