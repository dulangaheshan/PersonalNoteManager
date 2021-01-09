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
## API postman samples

https://www.getpostman.com/collections/a4bab7641ab17859fb0e

*   Create User


    * [POST]

    ```
    localhost:{port}/api/user
    ```

    * body

    ```
    (IsArchived : true -> it saved as archived)
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

* node.js 
app does not require heavy processing 
have more I/O operations

* mongo db
to save notes and note status
adding more fields to a scema is less time consuming

# improvements

* authentication

add authentication layer and authenticate users before they access their notes,
[probably JWT]

(currently the request must have userId in it's body field)

* improved logging of the application

currently the app logs internal server error in a same file, log them in to different files

* large notes support

notes which are larger needs to store it's content in some file format, 
it's status can be saved in a db for faster access.




