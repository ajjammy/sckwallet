# sckwallet

## Build -> Test -> Run
* Build: build all projects in solution 

  `$ dotnet build`
* Test: run test project
  
  `$ dotnet test test/hello-test/hello-test.csproj`
* Run: run api project

  `$ dotnet run --project src/hello/hello.csproj`




# Task list

- [ ] Not Complete
- [/] Complete

## hello and hello-test project
- [/] Create API Project
- [/] Create Test Project
- [/] Create Sulution and Add Reference Project
- [/] Modify API Project connect to database use Sqlite
    - [/] GET Multiple records (All)
    - [/] GET Multiple records by search
    - [/] GET One record by id
    - [/] POST Add data 
    - [/] PUT Update data 
- [ ] Create Test
    - [/] Unit Test Simple Method
    - [/] Unit Test Service Method (Use In Memory Database)
    - [ ] APIs Test
    - [ ] Controller Test

## Design A-DAPT Blueprint Customer Invisible

## sckwallet.api and sckwallet.test project
- [ ] Create sckwallet.api Project connect to database use Sqlite
    - [ ] GET Balance
    - [ ] POST Topup
- [ ] Create sckwallet.test Project
- [ ] Create Sulution and Add Reference Project
- [ ] Create Test
    - [ ] Unit Test Simple Method
    - [ ] Unit Test Service Method (Use In Memory Database)
    - [ ] APIs Test
    - [ ] Controller Test
