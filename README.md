Supports encrypted and plain text configuration entries.

Usage:
```c#
Context.GetConfigurationValue("SomethingConfig", "ConnectionString");
```

Building:
```
nuget.exe pack ServiceFabricConfigDecryptionHelper.csproj -properties Configuration=Release -Build -Prop "Platform=x64"
```

Ref:
https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-manage-multiple-environment-app-configuration
