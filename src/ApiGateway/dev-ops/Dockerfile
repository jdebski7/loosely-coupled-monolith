FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /app

COPY ./ApiGateway ./ApiGateway

RUN dotnet restore ./ApiGateway/ApiGateway.GraphQL/ApiGateway.GraphQL.csproj
RUN dotnet publish ./ApiGateway/ApiGateway.GraphQL -c Release -o ApiGateway.GraphQL --runtime alpine-x64 --self-contained true


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime

WORKDIR /app

COPY --from=build /app/ApiGateway.GraphQL ./ApiGateway.GraphQL

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "ApiGateway.GraphQL/ApiGateway.GraphQL.dll"]