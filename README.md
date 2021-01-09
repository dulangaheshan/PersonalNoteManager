# Personal Note Manager Backend

## Introduction
* Backend service which you can integrate with your Clients (mobile, web, pwa..etc) via Rest API End Points to manage personal notes

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

### Assumptions
*   user and note contain one-to-many relationship
*   it's require userId for confirm update,delete notes by the same user
 

## postman [collection](https://www.getpostman.com/collections/8b5d7da66f4ac58c158e)
or inside repo refer PersonalNoteManager.postman_collection,json file

*   Create User


    * [POST]

    ```
    localhost:{port}/api/user
    ```

    * body

    ```
    {
    "UserName": "testUser"
    }
    ```

    * response

    ```
    {
    "userId": 20,
    "msg": "User Created Successfully",
    }
    ```



*   Create Notes

    * [POST]

    ```
    localhost:{port}/api/note
    ```

    * body

    ```
    (IsArchived : true -> it saved as archived)
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
    localhost:{port}/api/note/{userID}/{noteID}
    ```
    * body

    ```
    (IsArchived : true -> is updadated as archived)
    {
    "NoteID": 17,
    "UserID":1,
    "Title": "Updated Test Doc2",
    "Content" : "Updated Test Content",
    "IsArchived" : true
    }
    ```

    * response

    ```
    {
    "noteId": 17,
    "msg": "Note Updated Successfully",
    }
    ```

*   Delete Notes

    * [DELETE]

    ```
    localhost:{port}/api/note/{userId}/{noteId}
    ```

    * response

    ```
    {
    "msg": "Note Deleted Successfully",
    }
    ```
    
*   Get All Notes, All Archived Notes, and All Not Archived Notes

    * [GET]

    ```
    localhost:{port}/api/Note/allnotes
    localhost:{port}/api/Note/allarchivednotes
    localhost:{port}/api/Note/allnotarchivednotes
    ```

    * response

    ```
    [
        {
            "noteId": 1,
            "dateCreated": "0001-01-01T00:00:00",
            "userID": 1,
            "documentPath": null,
            "title": "Updated Test Doc2",
            "content": "Updated Test Content",
            "isArchived": false,
            
        },
        {
            "noteId": 3,
            "dateCreated": "2020-01-09T00:00:00",
            "userID": 1,
            "documentPath": null,
            "title": "Test3",
            "content": "TestContent2",
            "isArchived": false,
            "user": null
        },
    ]
    ```

*   Get User's All Notes, User's All Archived Notes, and User's All Not Archived Notes

    * [GET]

    ```
    localhost:{port}/api/note/user/allarchivednotes/{userId}
    localhost:{port}/api/note/user/allnotarchivednotes/{userId}
    ```

    * response

    ```
    [
        {
            "noteId": 1,
            "dateCreated": "0001-01-01T00:00:00",
            "userID": 1,
            "documentPath": null,
            "title": "Updated Test Doc2",
            "content": "Updated Test Content",
            "isArchived": false,
            
        },
        {
            "noteId": 3,
            "dateCreated": "2020-01-09T00:00:00",
            "userID": 1,
            "documentPath": null,
            "title": "Test3",
            "content": "TestContent2",
            "isArchived": false,
            "user": null
        },
    ]
    ```
*   Archived Specific Note

    * [GET]

    ```
    localhost:{port}/api/note/user/archived/{userId}/{noteId}
    ```

    * response

    ```
    {
    "msg": "Note Arhived Successfully",
    }
    ```

*   Unarchived Specific Note

    * [GET]

    ```
    localhost:{port}/api/note/user/unarchived/{userId}/{noteId}
    ```

    * response

    ```
    {
    "msg": "Note Unarhived Successfully",
    }
    ```


# choose of technology
*   used .NetCore and MySql for completing the task as I am much experienced and familiar with the aforementioned technologies

*   .NET Core framework is high performance. With recent updates the code gets much more optimized which improves performance at the very end

* MySql is RDBMS and it will make easy to maintain futher requirments which may conatain many entites and relationships 

# improvements

*   integrate x-unit for Unit-testing
*   use visual studio or vs code [extension](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) for run test cases






