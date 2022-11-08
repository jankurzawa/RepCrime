There are 4 ways to run this application:

1) Just go to the website - http://20.107.128.103/ (the easiest way)

2) Join to the 'RepCrime' folder, open PowerShell and enter below commends (works only if you have installed docker desktop):

    1. docker build -t repcrimecontainerregistry.azurecr.io/repcrime.crime.api:v1 -f .\src\RepCrime.Crime.API\Dockerfile .
    2. docker build -t repcrimecontainerregistry.azurecr.io/repcrime.emailservice.api:v1 -f .\src\RepCrime.EmailService.API\Dockerfile .
    3. docker build -t repcrimecontainerregistry.azurecr.io/repcrime.lawenforcement.api:v1 -f .\src\RepCrime.LawEnforcement.API\Dockerfile .
    4. docker build -t repcrimecontainerregistry.azurecr.io/repcrime.mvc:v1 -f .\src\RepCrime.MVC\Dockerfile .
    5. kubectl apply -f .\Kubernetes\deployment.yml
    6. kubectl apply -f .\Kubernetes\service.yml

3) Join to the 'RepCrime' folder, open PowerShell and enter the commend (works only if you have installed docker desktop)

    'docker-compose up' 

4) Join to the 'RepCrime' folder, open PowerShell and enter the commend:

    1. open first PowerShell and enter the commend: 'dotnet run --project .\src\RepCrime.MVC\RepCrime.MVC.csproj'
    2. open second PowerShell and enter the commend: 'dotnet run --project .\src\RepCrime.EmailService.API\RepCrime.EmailService.API.csproj'
    3. open third PowerShell and enter the commend: 'dotnet run --project .\src\RepCrime.Crime.API\RepCrime.Crime.API.csproj'
    4. open fourth PowerShell and enter the commend: 'dotnet run --project .\src\RepCrime.LawEnforcement.API\RepCrime.LawEnforcement.API.csproj'