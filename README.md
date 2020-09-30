# SimpleBBS

A simple BBS (Bulletin Board Service) for posting/reading basic text
messages.

There is currently no UI, it's just a basic REST API service with a
single endpoint exposing two actions: GET and POST. To interact with it
use a tool such as Postman or with PowerShell like so:

- Retrieve all posts:
`Invoke-RestMethod -Method Get -Uri "https://localhost:5001/BBS"`

- Add new post:
`Invoke-RestMethod -Method Post -Uri "https://localhost:5001/BBS"
-ContentType "application/json" -Body
'{"username":"test_user","message":"test message"}'`

#### Next steps
Due to time constraints this is a very sparse demo with some issues that
need addressing to take it further:

1. **Async** : currently all the code is synchronous. This has the
   potential to cause performance bottlenecks for any long-running
   tasks.
2. **Persistence** : There is currently no long-term data persistence.
   The "database" is currently just an in-memory list. However, the
   persistence layer has been abstracted out of the BBService itself so
   swapping out he InMemoryDatabase for a proper database/ORM solution
   is very trivial.
3. **Testing** : There are tests around some of the business logic of
   the BBService but there are currently no tests around the API itself.
   For proper integration testing some API tests would be of benefit.
4. **UI** : A UI would be nice to properly demonstrate the API and it's
   use.
