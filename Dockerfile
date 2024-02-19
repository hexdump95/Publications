FROM mcr.microsoft.com/dotnet/aspnet:8.0

LABEL maintainer="Sergio Villanueva <sergiovillanueva@protonmail.com>"

WORKDIR /app

COPY ./src/Publications/bin/Release/net8.0/publish/ .

RUN ls . -lA

CMD ["dotnet", "Publications.dll"]
