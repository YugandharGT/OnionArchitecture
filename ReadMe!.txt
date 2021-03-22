Custom Build Events:
if $(ConfigurationName) == Release (
 copy /Y "$(TargetDir)" "DestPath"
 del "DestPath\*.pdb"
)
Using Batch Script:
if $(ConfigurationName) == Release (
for /r "$(TargetDir)" %%I in (*.dll *.json *.config *.xml) do copy "%%I" "D:\Technology\Dotnet-Projects\VS19\AutomaticPublish\OnionArchWebApi\"
)
