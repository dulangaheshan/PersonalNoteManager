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




## When a user wants to update a note which is already archived, the user wants to update the archived note as well
## When a user wants to delete a note which is already archived, the user wants to delete the archived note as well



# APIS

## API postman samples

https://www.getpostman.com/collections/a4bab7641ab17859fb0e

## add a note



## update a note

### if archived, update archived note too

* api

```node
localhost:4000/api/v1/notes/update/
```

* sample body

```node
{
	"userId":"chamupathi",
	"content":"this is my  note baby archived",
	"id":"5e07375e14bf4d65365435a7"
}
```

* sample success response body

```node
{
    "note": "Note updated!",
    "id": "5e07375e14bf4d65365435a7"
}
```


## get all notes of a user

* api

```node
localhost:4000/api/v1/notes/[userId]
```


* sample success response body

```node
[
    {
        "_id": "5e070ef4620e6d2bb221ca69",
        "content": "5e071892f3296439563a7c74 updated",
        "userId": "chamupathi",
        "archived": true,
        "__v": 0
    },
    {
        "_id": "5e071023aef9392d27b6ded6",
        "content": "first content",
        "userId": "chamupathi",
        "archived": false,
        "__v": 0
    },
]
```

## get a specific note with userId and noteId

* api

```node
localhost:4000/api/v1/notes/[userId]/[id]
```


* sample success response body

```node
{
    "_id": "5e07375e14bf4d65365435a7",
    "content": "this is my  note baby archived",
    "userId": "chamupathi",
    "archived": true,
    "__v": 0
}
```

## get all archived notes of a user


* api

```node
localhost:4000/api/v1/notes/[userId]/archived
```


* sample success response body

```node
[
    {
        "_id": "5e070ef4620e6d2bb221ca69",
        "content": "5e071892f3296439563a7c74 updated",
        "userId": "chamupathi",
        "archived": true,
        "__v": 0
    },
    {
        "_id": "5e071892f3296439563a7c74",
        "content": "5e071892f3296439563a7c74 updated",
        "userId": "chamupathi",
        "archived": true,
        "__v": 0
    }
]
```

## get all un-archived notes of a user


* api

```node
localhost:4000/api/v1/notes/[userId]/notArchived
```


* sample success response body

```node
[
    {
        "_id": "5e071023aef9392d27b6ded6",
        "content": "first content",
        "userId": "chamupathi",
        "archived": false,
        "__v": 0
    },
    {
        "_id": "5e0721b59668694518e55bab",
        "content": "second content",
        "userId": "chamupathi",
        "archived": false,
        "__v": 0
    }
]
```

## delete a note

### if archived, delete archived note too

* api

```node
localhost:4000/api/v1/notes/delete/
```

* sample body

```node
{
	"userId":"chamupathi",
	"id":"5e073b6d7ac788699360ba57"
}
```

* sample success response body

```node
{
    "note": "Note Deleted!",
    "id": "5e073b6d7ac788699360ba57"
}
```



## archive a note


* api

```node
localhost:4000/api/v1/notes/archive/
```

* sample body

```node
{
	"userId":"chamupathi",
	"id":"5e07375e14bf4d65365435a7"
}
```

* sample success response body

```node
{
    "note": "Note Archived!",
    "id": "5e07375e14bf4d65365435a7"
}
```


## un-archive a note

* api

```node
localhost:4000/api/v1/notes/unarchive/
```

* sample body

```node
{
	"userId":"chamupathi",
	"id":"5e07375e14bf4d65365435a7"
}
```

* sample success response body

```node
{
    "note": "Note unarchived",
    "id": "5e07375e14bf4d65365435a7"
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

