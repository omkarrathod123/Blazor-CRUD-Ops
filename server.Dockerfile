# Stage 1: Build Blazor WebAssembly Client
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BlazorCRUDOps.Client/ .
RUN dotnet restore

RUN dotnet publish ./BlazorCRUDOps.Client.csproj -c Release -o /app/publish

# Stage 2: Serve with Nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

RUN rm -rf ./*
COPY --from=build /app/publish/wwwroot .

COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]