# Crossplatform Programming Labs

## Running the Lab

To run a lab without printing temporary results:

```bash
dotnet run --project .\LabN\App\App.csproj
```
To run a lab with temporary results (verbose mode):
```bash
dotnet run --project .\LabN\App\App.csproj --verbose
```
Where N is the number of the lab.
For example, to run Laboratory Work 1:
```bash
dotnet run --project .\Lab1\App\App.csproj
dotnet run --project .\Lab1\App\App.csproj --verbose
```
## Running Tests
To run tests for a specific lab:
```bash
dotnet test .\LabN
```
For example, to run tests for Laboratory Work 1:
```bash
dotnet test .\Lab1
```
### Note: All these commands should be executed from the root directory.

