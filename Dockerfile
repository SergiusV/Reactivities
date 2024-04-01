# Используем SDK образ для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Копируем файл решения
COPY *.sln .

# Копируем проектные файлы и восстанавливаем зависимости для каждого проекта
COPY API/*.csproj ./API/
COPY Domain/*.csproj ./Domain/
COPY Application/*.csproj ./Application/
COPY Persistence/*.csproj ./Persistence/
RUN dotnet restore

# Копируем исходный код проектов
COPY API/ ./API/
COPY Domain/ ./Domain/
COPY Application/ ./Application/
COPY Persistence/ ./Persistence/

# Указание переменных среды
ENV ASPNETCORE_ENVIRONMENT=Development

# Указание порта
EXPOSE 5000

# Собираем и публикуем API проект
WORKDIR /app/API
RUN dotnet publish -c Release -o out

# Билдим runtime-образ с нашим приложением
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/API/out ./
ENTRYPOINT ["dotnet", "API.dll"]
