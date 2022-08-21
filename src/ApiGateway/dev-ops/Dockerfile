FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /app

COPY ./ApiGateway ./ApiGateway

RUN dotnet restore ./ApiGateway/ApiGateway.GraphQL/ApiGateway.GraphQL.csproj
RUN dotnet publish ./ApiGateway/ApiGateway.GraphQL -c Release -o ApiGateway.GraphQL --runtime alpine-x64 --self-contained true


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime

WORKDIR /app

COPY --from=build /app/ApiGateway.GraphQL ./ApiGateway.GraphQL
COPY ApiGateway/dev-ops/startup.sh ./

RUN chown -R 1000:1000 /app
USER 1000:1000
RUN chmod +x ./startup.sh

ENTRYPOINT ["sh", "./startup.sh"]