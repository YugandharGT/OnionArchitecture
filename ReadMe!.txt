Login Functionality:
Asp.Net Core Identity - https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/identity/sample
Core 5.0 Example: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio
Custom Build Events:
if $(ConfigurationName) == Release (
 copy /Y "$(TargetDir)" "DestPath"
 del "DestPath\*.pdb"
)
Using Batch Script:
if $(ConfigurationName) == Release (
for /r "$(TargetDir)" %%I in (*.dll *.json *.config *.xml) do copy "%%I" "D:\Technology\Dotnet-Projects\VS19\AutomaticPublish\OnionArchWebApi\"
)
