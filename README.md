# Personal Note Manager Backend

## Introduction
* Backend service you can use for mange your personal notes

    ### Framework and DataBase
    * .NetCore 3.1
    * MySQL


## Getting Started
* Local Environment 
        
    * Install .NetCore 3.1 from [here](https://dotnet.microsoft.com/download/dotnet-core/3.1)
    * Install [xampp](https://www.apachefriends.org/index.html) or any other mysql DBMS
    * create DataBase called NoteManager
    * update appsettings.Development.json with your DB connection string  

* install packages and db migration
    
    * open package manager console or cmd and run below commands  

    ```
    dotnet restore
    ```

    * database migrations(before run below commands start your local mysql db server)

    ```
    Enable-Migrations
    Add-Migration {migration comment}
    update-database
    ```
    * start backend

    ```
    dotnet run
    ```
    * api will be served at

    ```node
    localhost:[port]/api/....
    ```

# Feature and API End Points
*   Create Notes

    * [POST]

    ```
    localhost:{port}/api/note
    ```

    * body

    ```
    {
    "UserID" : 1,
    "Title": "Test Doc",
    "Content" : "Test Content",
    "IsArchived" : true
    }
    ```

    * response

    ```
    {
    "noteId": 20,
    "msg": "Note Created Successfully",
    }
    ```

*   Update Notes

    * [PUT]

    ```
    localhost:{port}/api/note
    ```

    * body

    ```
    {
    "UserID" : 1,
    "Title": "Test Doc",
    "Content" : "Test Content",
    "IsArchived" : true
    }
    ```

    * response

    ```
    {
    "noteId": 20,
    "msg": "Note Created Successfully",
    }
    ```




