FROM microsoft/dotnet:2.2-sdk
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet","CelebioBackend.dll"]
