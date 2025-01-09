# VideoSp

VideoSp is a Video Game Store built on ASP.NET Core Web API template
VideoSp is the shortform of VideoSpielen meaning Video Games in German

## Installation

Use the package manager dotnet-sdk

```bash
# after cloning the project
cd src/
dotnet restore
dotnet build

```

## Usage

```bash
# to run project
dotnet run

# initial seed
dotnet ef migrations add InitialMigration
dotnet ef database update

```

Test all API endpoints with a nice [Scalar UI](http://localhost:5015/scalar/v1)

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.
