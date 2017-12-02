FROM microsoft/dotnet:2.0.0-sdk-jessie AS builder
MAINTAINER supermomonga

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=-1
ENV DOTNET_CLI_TELEMETRY_OPTOUT=-1

WORKDIR /app/src/Shipwreck.AppCenterRegistration
COPY ./src/Shipwreck.AppCenterRegistration/Shipwreck.AppCenterRegistration.csproj ./Shipwreck.AppCenterRegistration/Shipwreck.AppCenterRegistration.csproj
COPY ./src/Shipwreck.AppCenterRegistration.sln ./Shipwreck.AppCenterRegistration.sln
RUN dotnet restore
COPY ./src/Shipwreck.AppCenterRegistration ./Shipwreck.AppCenterRegistration
RUN dotnet publish -c Release -o /app/bin -p:PublishWithAspNetCoreTargetManifest=false


FROM microsoft/dotnet:2.0.0-runtime-jessie
WORKDIR /app
COPY --from=BUILDER /app/bin /app
RUN ls
ENV ASPNETCORE_URLS http://+:5000
ENTRYPOINT ["dotnet", "Shipwreck.AppCenterRegistration.dll"]

