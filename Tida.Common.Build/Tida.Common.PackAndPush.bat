.\nuget pack Tida.Util.nuspec
.\nuget pack Tida.Application.Contracts.nuspec
.\nuget pack Tida.Application.nuspec

.\nuget push "Tida.Util.0.4.1.nupkg" sky -src http://192.168.1.234:8086/NugetServer/nuget 
.\nuget push "Tida.Application.Contracts.0.4.1.nupkg" sky -src http://192.168.1.234:8086/NugetServer/nuget 
.\nuget push "Tida.Application.0.4.8.nupkg" sky -src http://192.168.1.234:8086/NugetServer/nuget 
