FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
 
WORKDIR /Mutant.Hamburgueria.Web
COPY bin/Debug/netcoreapp2.1/publish .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
 
ENTRYPOINT ["dotnet", "Mutant.Hamburgueria.Web.dll"]