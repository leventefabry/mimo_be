# MIMO
## Set up the project
Create a `mimo.db` file in the `Mimo.API` folder. The project's first run will seed the database.

Build the project then:
```
dotnet build
```
Run the project.
```
dotnet run
```
The application will start in the following URL and open up the Swagger documentation:
```
https://localhost:7001/swagger/index.html
```

## Testing
Login with the following data:
```
POST api/Auth
{        
  "username": "john_doe",
  "password": "password"
}
```
Get project for lesson ids.
```
GET /api/Courses/47111973-d176-4feb-848d-0ea22641c31a
```
Open a lesson to start progressing in the lesson.
```
GET /api/Lessons/48f07e4a-2b21-4edc-a8e9-6deca6185c99
```
Finish a lesson
```
POST /api/Lessons/finish/48f07e4a-2b21-4edc-a8e9-6deca6185c99
```
Check the logged-in user's progress:
```
GET /api/UserProgress
```
Check the logged-in user's achievements:
```
GET /api/UserAchievement
```