FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
LABEL maintainer 'Stenio Neves<stenioneves@outlook.com'
WORKDIR /app
COPY ./sistem/  .
EXPOSE 80 443
ENTRYPOINT [ "dotnet","sistemE.dll" ]
