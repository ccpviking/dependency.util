# dependency.util
## Build dependency.util project
From the < Project > folder:
```
$ dotnet restore
$ dotnet build
```

## Test dependency.util
From the < Project >/dependency.tests/ folder:
```
$ dotnet restore
$ dotnet build
$ dotnet test
```

## Run dependency.web
From the < Project >/dependency.web/ folder:
```
$ dotnet run
```
Open a browser and you can run any of these GET commands:

Valid Input Examples:
* https://localhost:5001/api/dependency/["KittenService: ", "Leetmeme: Cyberportal", "Cyberportal: Ice", "CamelCaser: KittenService", "Fraudstream: Leetmeme", "Ice: " ]
* https://localhost:5001/api/dependency/["zero: one","one: two","two: three","three: ","four: five","five: six","six: "]

Expected Invalid Input Examples:
* https://localhost:5001/api/dependency/["KittenService: ", "Leetmeme: Cyberportal", "Cyberportal: Ice", "CamelCaser: KittenService", "Fraudstream: ", "Ice: Leetmeme" ]
* https://localhost:5001/api/dependency/["zero: one","one: two","two: three","three: zero","four: five","five: six","six: "]

## Notes:
* Following the instructions, I assumed that a package can have only one dependency.

## ToDo:
* **[Done]** Setup the project, tests, and web app
* **[Done]** Add support to parse the input via text, or file.
* **[Done]** Build the Node<T> and NodeList<T> objects & functionality.
* **[Done]** Add functionality to get a dependency string result.
* **[Done]** Add functionality to create the NodeList for the tuples from the input text.
* **[Done]** Add functionality to identify circular dependencies.
* **[Done]** Tie in a DependencyController from the web app.