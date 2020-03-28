mkdir output

dotnet build
dotnet publish -r osx-x64 --self-contained false -o output/
