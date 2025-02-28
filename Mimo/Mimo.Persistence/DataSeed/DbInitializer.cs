using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.DataSeed;

public static class DbInitializer
{
    public static void InitDb(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetService<MimoDbContext>();
        if (context is null)
        {
            return;
        }

        context.Database.Migrate();
        
        SeedCourseData(context);
        SeedUserData(context);
        SeedAchievementData(context);
    }

    private static void SeedCourseData(MimoDbContext context)
    {
        if (context.Courses.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var courses = new List<Course>
        {
            new()
            {
                Id = new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Name = "Swift Programming Fundamentals",
                Description =
                    "Learn the basics of Swift programming language. This course covers variables, data types, control structures, functions, and basic object-oriented programming concepts. Perfect for beginners with no prior programming experience.",
                Chapters =
                [
                    new Chapter
                    {
                        Id = new Guid("c9e396d8-1053-4b21-8b33-5d9a9a5d8814"),
                        Name = "Swift Basics",
                        Description =
                            "Introduction to Swift syntax, variables, data types, and basic operations. Learn how to write and execute your first Swift program.",
                        Order = 1,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Your First Swift Program",
                                Description =
                                    "Write and execute your first Swift program. Learn about the Swift interpreter and how to use print statements.",
                                LessonsCopy =
                                    "print('Hello, World!')\n\n# This is your first Swift program\n# It displays the text 'Hello, World!' on the screen",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Variables and Constants",
                                Description =
                                    "Learn how to declare and use variables and constants in Swift. Understand the difference between 'var' and 'let'.",
                                LessonsCopy =
                                    "// Variables - can change after declaration\nvar name = \"John\"\nname = \"Jane\"\nprint(name) // Outputs: Jane\n\n// Constants - cannot be changed after declaration\nlet pi = 3.14159\n// pi = 3.14 // This would cause an error\nprint(pi)\n\n// Type annotations\nvar score: Int = 0\nvar average: Double = 42.5\nvar isActive: Bool = true\nvar message: String = \"Hello Swift!\"\n\nprint(\"The score is \\(score) and the average is \\(average)\")\n// String interpolation example",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Swift Data Types",
                                Description =
                                    "Explore Swift's fundamental data types including numbers, strings, booleans and basic collections.",
                                LessonsCopy =
                                    "// Basic Types\nlet integer: Int = 42\nlet float: Float = 3.14\nlet double: Double = 3.14159265359\nlet boolean: Bool = true\nlet text: String = \"Swift Programming\"\nlet character: Character = \"A\"\n\n// Collection Types\n\n// Arrays - ordered collections\nvar fruits = [\"Apple\", \"Banana\", \"Orange\"]\nprint(fruits[0]) // Access first element\nfruits.append(\"Mango\") // Add element\nprint(\"We have \\(fruits.count) fruits\")\n\n// Dictionaries - key-value pairs\nvar scores = [\"Alice\": 95, \"Bob\": 85, \"Charlie\": 90]\nprint(scores[\"Alice\"] ?? 0) // Access value by key\nscores[\"Dave\"] = 88 // Add new key-value pair\n\n// Optionals - represent values that might be absent\nvar optionalName: String? = nil\noptionalName = \"Swift Learner\"\nif let name = optionalName {\n    print(\"Hello, \\(name)\")\n} else {\n    print(\"Name is nil\")\n}",
                                Order = 3,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("75e28838-00d5-4187-90e1-f814c8a8e882"),
                        Name = "Control Flow",
                        Description =
                            "Master Swift's control structures including if-else statements, loops, and conditional expressions. Learn how to control the flow of your programs.",
                        Order = 2,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Conditional Statements",
                                Description =
                                    "Learn how to make decisions in your Swift code using if, else if, and else statements.",
                                LessonsCopy =
                                    "// If-else statements\nlet temperature = 25\n\nif temperature > 30 {\n    print(\"It's hot outside!\")\n} else if temperature > 20 {\n    print(\"It's a pleasant day.\")\n} else {\n    print(\"It's cold today.\")\n}\n\n// Using the ternary conditional operator\nlet message = temperature > 20 ? \"It's warm\" : \"It's cold\"\nprint(message)\n\n// Switch statements\nlet dayOfWeek = \"Monday\"\n\nswitch dayOfWeek {\ncase \"Monday\":\n    print(\"Start of the work week\")\ncase \"Friday\":\n    print(\"End of the work week\")\ncase \"Saturday\", \"Sunday\":\n    print(\"It's the weekend!\")\ndefault:\n    print(\"It's a weekday\")\n}",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Loops and Iterations",
                                Description =
                                    "Explore different ways to repeat code execution with for-in loops, while loops, and control transfer statements.",
                                LessonsCopy =
                                    "// For-in loops with ranges\nprint(\"Counting from 1 to 5:\")\nfor i in 1...5 {\n    print(\"Number \\(i)\")\n}\n\n// For-in with arrays\nlet fruits = [\"Apple\", \"Banana\", \"Orange\"]\nprint(\"\\nFruit list:\")\nfor fruit in fruits {\n    print(fruit)\n}\n\n// While loop\nprint(\"\\nCountdown:\")\nvar countdown = 3\nwhile countdown > 0 {\n    print(\"\\(countdown)...\")\n    countdown -= 1\n}\nprint(\"Blast off!\")\n\n// Repeat-while loop\nprint(\"\\nAdding numbers:\")\nvar sum = 0\nvar number = 1\nrepeat {\n    sum += number\n    number += 1\n} while number <= 5\nprint(\"Sum of 1 to 5: \\(sum)\")",
                                Order = 2,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("59591cf9-71f6-404f-bc13-37a882175a78"),
                        Name = "Functions and Modules",
                        Description =
                            "Learn to create reusable code with functions, understand scope, arguments, and return values. Explore Swift's module system and how to use external libraries.",
                        Order = 3,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Defining Basic Functions",
                                Description =
                                    "Learn how to define and call functions in Swift. Understand function syntax and basic parameter handling.",
                                LessonsCopy =
                                    "// Basic function definition\nfunc sayHello() {\n    print(\"Hello, Swift!\")\n}\n\n// Calling the function\nsayHello()\n\n// Function with a parameter\nfunc greet(person: String) {\n    print(\"Hello, \\(person)!\")\n}\n\n// Calling function with a parameter\ngreet(person: \"Alice\")\n\n// Function with multiple parameters\nfunc introduce(name: String, age: Int) {\n    print(\"\\(name) is \\(age) years old.\")\n}\n\nintroduce(name: \"Bob\", age: 25)",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Function Parameters and Return Values",
                                Description =
                                    "Explore how to pass parameters to functions and return values. Learn about parameter labels, default values, and variadic parameters.",
                                LessonsCopy =
                                    "// Function with return value\nfunc add(a: Int, b: Int) -> Int {\n    return a + b\n}\n\nlet sum = add(a: 5, b: 3)\nprint(\"5 + 3 = \\(sum)\")\n\n// Functions with default parameter values\nfunc greet(person: String, formally: Bool = false) {\n    if formally {\n        print(\"Good day, \\(person).\")\n    } else {\n        print(\"Hey, \\(person)!\")\n    }\n}\n\ngreet(person: \"Charlie\")  // Uses default value (false)\ngreet(person: \"Diana\", formally: true)  // Overrides default value\n\n// External and internal parameter names\nfunc calculateDistance(from startPoint: Int, to endPoint: Int) -> Int {\n    return abs(endPoint - startPoint)\n}\n\nlet distance = calculateDistance(from: 10, to: 25)\nprint(\"The distance is \\(distance)\")\n\n// Variadic parameters (variable number of parameters)\nfunc calculateAverage(of numbers: Double...) -> Double {\n    var total = 0.0\n    for number in numbers {\n        total += number\n    }\n    return total / Double(numbers.count)\n}\n\nlet avg = calculateAverage(of: 85.0, 90.5, 77.5, 92.0)\nprint(\"The average score is \\(avg)\")",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Closures and Functional Programming",
                                Description =
                                    "Master Swift closures - self-contained blocks of functionality that can be passed around. Learn about Swift's functional programming features.",
                                LessonsCopy =
                                    "// Basic closure syntax\nlet simpleClosure = { print(\"This is a closure\") }\nsimpleClosure()\n\n// Closure with parameters and return value\nlet multiply = { (a: Int, b: Int) -> Int in\n    return a * b\n}\nlet result = multiply(4, 5)\nprint(\"4 × 5 = \\(result)\")\n\n// Using closures with Swift standard library functions\nlet numbers = [5, 2, 8, 1, 9, 3]\n\n// Sorted with closure\nlet sortedNumbers = numbers.sorted { $0 < $1 }\nprint(\"Sorted numbers: \\(sortedNumbers)\")\n\n// Map with closure\nlet squares = numbers.map { $0 * $0 }\nprint(\"Squares: \\(squares)\")\n\n// Filter with closure\nlet evenNumbers = numbers.filter { $0 % 2 == 0 }\nprint(\"Even numbers: \\(evenNumbers)\")\n\n// Reduce with closure\nlet sum = numbers.reduce(0) { $0 + $1 }\nprint(\"Sum of all numbers: \\(sum)\")\n\n// Trailing closure syntax\nlet names = [\"Alice\", \"Bob\", \"Charlie\"]\nlet sortedNames = names.sorted { $0.count < $1.count }\nprint(\"Names sorted by length: \\(sortedNames)\")",
                                Order = 3,
                            }
                        ]
                    }
                ]
            },
            new()
            {
                Id = new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Name = "JavaScript for Web Development",
                Description =
                    "Master JavaScript to create interactive web applications. This course explores DOM manipulation, event handling, asynchronous programming with Promises, and modern ES6+ features. Includes practical projects to build your portfolio.",
                Chapters =
                [
                    new Chapter
                    {
                        Id = new Guid("a2e77982-7363-42b5-96d4-e608c1931205"),
                        Name = "JavaScript Fundamentals",
                        Description =
                            "Learn the core concepts of JavaScript including variables, data types, functions, and control flow. Master the foundation of modern web development.",
                        Order = 1,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Variables and Data Types",
                                Description =
                                    "Understand how to declare variables using let and const, and explore JavaScript's dynamic data types.",
                                LessonsCopy =
                                    "// Variable declaration\nlet name = 'JavaScript';\nconst version = 'ES6';\n\n// Basic data types\nlet stringValue = 'Hello World'; // String\nlet numberValue = 42; // Number\nlet booleanValue = true; // Boolean\nlet undefinedValue; // undefined\nlet nullValue = null; // null\n\n// Check type using typeof\nconsole.log(typeof stringValue); // 'string'\nconsole.log(typeof numberValue); // 'number'\nconsole.log(typeof booleanValue); // 'boolean'\n\n// Complex data types\nlet arrayValue = [1, 2, 3, 'four', true]; // Array\nlet objectValue = { // Object\n  name: 'JavaScript',\n  year: 1995,\n  isAwesome: true\n};\n\n// Accessing array and object properties\nconsole.log(arrayValue[0]); // 1\nconsole.log(objectValue.name); // 'JavaScript'\nconsole.log(objectValue['year']); // 1995",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Functions and Scope",
                                Description =
                                    "Learn to define and use functions in JavaScript. Understand function parameters, return values, and scope concepts.",
                                LessonsCopy =
                                    "// Function declaration\nfunction greet(name) {\n  return `Hello, ${name}!`;\n}\n\n// Function expression\nconst sayGoodbye = function(name) {\n  return `Goodbye, ${name}!`;\n};\n\n// Arrow function\nconst add = (a, b) => a + b;\n\n// Calling functions\nconsole.log(greet('World')); // 'Hello, World!'\nconsole.log(sayGoodbye('JavaScript')); // 'Goodbye, JavaScript!'\nconsole.log(add(5, 3)); // 8\n\n// Default parameters\nfunction welcome(name = 'Guest') {\n  return `Welcome, ${name}!`;\n}\n\nconsole.log(welcome()); // 'Welcome, Guest!'\nconsole.log(welcome('Developer')); // 'Welcome, Developer!'\n\n// Scope examples\nlet globalVar = 'I am global';\n\nfunction scopeDemo() {\n  let localVar = 'I am local';\n  console.log(globalVar); // 'I am global' (accessible)\n  console.log(localVar); // 'I am local' (accessible)\n}\n\nscopeDemo();\nconsole.log(globalVar); // 'I am global' (accessible)\n// console.log(localVar); // Error: localVar is not defined (not accessible)",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Control Flow and Loops",
                                Description =
                                    "Master conditional statements and loops in JavaScript to control the flow of your code execution.",
                                LessonsCopy =
                                    "// If-else statements\nlet temperature = 25;\n\nif (temperature > 30) {\n  console.log('It\\'s hot outside!');\n} else if (temperature > 20) {\n  console.log('It\\'s a pleasant day.');\n} else {\n  console.log('It\\'s cold today.');\n}\n\n// Ternary operator\nlet message = temperature > 20 ? 'It\\'s warm' : 'It\\'s cold';\nconsole.log(message);\n\n// Switch statement\nlet day = 'Monday';\n\nswitch (day) {\n  case 'Monday':\n    console.log('Start of the work week');\n    break;\n  case 'Friday':\n    console.log('End of the work week');\n    break;\n  case 'Saturday':\n  case 'Sunday':\n    console.log('It\\'s the weekend!');\n    break;\n  default:\n    console.log('It\\'s a weekday');\n}\n\n// For loop\nconsole.log('Counting from 1 to 5:');\nfor (let i = 1; i <= 5; i++) {\n  console.log(`Number ${i}`);\n}\n\n// For...of loop (for arrays)\nlet fruits = ['Apple', 'Banana', 'Orange'];\nconsole.log('Fruit list:');\nfor (let fruit of fruits) {\n  console.log(fruit);\n}\n\n// While loop\nlet countdown = 3;\nconsole.log('Countdown:');\nwhile (countdown > 0) {\n  console.log(`${countdown}...`);\n  countdown--;\n}\nconsole.log('Go!');",
                                Order = 3,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("b8bf4f57-0c8e-42e7-b0a1-4e878b324f93"),
                        Name = "DOM Manipulation",
                        Description =
                            "Learn to interact with web page elements using JavaScript. Master selecting, creating, and modifying HTML elements to build dynamic user interfaces.",
                        Order = 2,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Selecting DOM Elements",
                                Description =
                                    "Learn different ways to select and access HTML elements using JavaScript's DOM API.",
                                LessonsCopy =
                                    "// Selecting elements by ID\nconst header = document.getElementById('header');\n\n// Selecting elements by class name\nconst navItems = document.getElementsByClassName('nav-item');\n\n// Selecting elements by tag name\nconst paragraphs = document.getElementsByTagName('p');\n\n// QuerySelector methods (returns the first matching element)\nconst mainSection = document.querySelector('.main-section');\nconst firstButton = document.querySelector('button');\n\n// QuerySelectorAll (returns all matching elements)\nconst allButtons = document.querySelectorAll('button');\nconst navLinks = document.querySelectorAll('nav a');\n\n// Looping through NodeList returned by querySelectorAll\nnavLinks.forEach(link => {\n  console.log(link.textContent);\n});\n\n// Traversing the DOM\nconst parentElement = header.parentElement;\nconst nextSibling = header.nextElementSibling;\nconst previousSibling = header.previousElementSibling;\nconst children = header.children;\nconst firstChild = header.firstElementChild;\nconst lastChild = header.lastElementChild;",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Modifying DOM Elements",
                                Description =
                                    "Learn how to change HTML content, attributes, and styles using JavaScript.",
                                LessonsCopy =
                                    "// Change text content\nconst title = document.getElementById('title');\ntitle.textContent = 'Modified Title';\n\n// Change HTML content\nconst container = document.querySelector('.container');\ncontainer.innerHTML = '<h2>New Content</h2><p>This paragraph was created with JavaScript.</p>';\n\n// Working with attributes\nconst link = document.getElementById('main-link');\nlink.setAttribute('href', 'https://www.example.com');\nlink.setAttribute('target', '_blank');\n\n// Check if attribute exists\nif (link.hasAttribute('class')) {\n  console.log('Class attribute exists');\n}\n\n// Get attribute value\nconst linkUrl = link.getAttribute('href');\nconsole.log(`Link URL: ${linkUrl}`);\n\n// Remove attribute\nlink.removeAttribute('data-original');\n\n// Managing CSS classes\nconst card = document.querySelector('.card');\ncard.classList.add('highlighted'); // Add a class\ncard.classList.remove('hidden'); // Remove a class\ncard.classList.toggle('expanded'); // Toggle a class\ncard.classList.replace('small', 'large'); // Replace a class\n\n// Check if element has a class\nif (card.classList.contains('highlighted')) {\n  console.log('Card is highlighted');\n}\n\n// Working with inline styles\nconst box = document.querySelector('.box');\nbox.style.backgroundColor = '#3498db';\nbox.style.padding = '20px';\nbox.style.borderRadius = '8px';\nbox.style.boxShadow = '0 2px 5px rgba(0,0,0,0.2)';",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Creating and Removing Elements",
                                Description =
                                    "Learn how to dynamically create new DOM elements, add them to the document, and remove elements when needed.",
                                LessonsCopy =
                                    "// Create a new element\nconst newParagraph = document.createElement('p');\nnewParagraph.textContent = 'This paragraph was created with JavaScript.';\nnewParagraph.classList.add('dynamic-content');\n\n// Add the element to the DOM\nconst contentDiv = document.getElementById('content');\ncontentDiv.appendChild(newParagraph);\n\n// Create complex elements\nfunction createCard(title, description) {\n  const card = document.createElement('div');\n  card.classList.add('card');\n  \n  const cardTitle = document.createElement('h3');\n  cardTitle.textContent = title;\n  \n  const cardDesc = document.createElement('p');\n  cardDesc.textContent = description;\n  \n  const deleteBtn = document.createElement('button');\n  deleteBtn.textContent = 'Delete';\n  deleteBtn.addEventListener('click', function() {\n    card.remove(); // Self-remove when clicked\n  });\n  \n  card.appendChild(cardTitle);\n  card.appendChild(cardDesc);\n  card.appendChild(deleteBtn);\n  \n  return card;\n}\n\n// Add multiple elements\nconst cardsContainer = document.getElementById('cards-container');\ncardsContainer.appendChild(createCard('First Card', 'This is card number one'));\ncardsContainer.appendChild(createCard('Second Card', 'This is card number two'));\n\n// Insert before another element\nconst referenceElement = document.getElementById('reference-element');\nconst newElement = document.createElement('div');\nnewElement.textContent = 'Inserted before reference';\ndocument.body.insertBefore(newElement, referenceElement);\n\n// Remove elements\nconst elementToRemove = document.getElementById('remove-me');\nif (elementToRemove) {\n  elementToRemove.remove(); // Modern way\n}\n\n// Alternative way to remove (older browsers)\nconst oldElement = document.getElementById('old-element');\nif (oldElement && oldElement.parentNode) {\n  oldElement.parentNode.removeChild(oldElement);\n}\n\n// Replace an element\nconst oldHeading = document.getElementById('old-heading');\nconst newHeading = document.createElement('h2');\nnewHeading.textContent = 'New Improved Heading';\nif (oldHeading && oldHeading.parentNode) {\n  oldHeading.parentNode.replaceChild(newHeading, oldHeading);\n}",
                                Order = 3,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("d3f4ce76-9c43-4b06-a42f-814d6c0cce9b"),
                        Name = "Asynchronous JavaScript",
                        Description =
                            "Master JavaScript's asynchronous programming with callbacks, promises, and async/await. Learn to handle API requests and work with external data sources.",
                        Order = 3,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Introduction to Asynchronous JavaScript",
                                Description =
                                    "Learn about the asynchronous nature of JavaScript and why it's important for web development.",
                                LessonsCopy =
                                    "// Synchronous code example\nconsole.log('Start');\n\nfunction syncOperation() {\n  console.log('Synchronous operation');\n}\n\nsyncOperation();\nconsole.log('End');\n// Output: Start, Synchronous operation, End (in order)\n\n// Asynchronous code example with setTimeout\nconsole.log('Start');\n\nsetTimeout(() => {\n  console.log('Timeout completed after 2 seconds');\n}, 2000);\n\nconsole.log('End');\n// Output: Start, End, Timeout completed after 2 seconds\n\n// Example of a problem with synchronous thinking\nfunction simulateDataFetch() {\n  setTimeout(() => {\n    return { name: 'John', age: 30 };\n  }, 1000);\n}\n\nconst user = simulateDataFetch();\nconsole.log(user); // undefined! The data isn't ready yet\n\n// Solution with callbacks\nfunction fetchUserData(callback) {\n  console.log('Fetching user data...');\n  \n  setTimeout(() => {\n    const user = { name: 'John', age: 30 };\n    callback(user);\n  }, 1000);\n}\n\nconsole.log('Starting data fetch');\n\nfetchUserData((userData) => {\n  console.log('Data received:', userData);\n});\n\nconsole.log('Data fetch initiated');\n// Output: Starting data fetch, Data fetch initiated, Fetching user data..., Data received: { name: 'John', age: 30 }",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Working with Promises",
                                Description =
                                    "Learn to use Promises for cleaner asynchronous code. Understand promise states, chaining, and error handling.",
                                LessonsCopy =
                                    "// Creating a Promise\nconst myPromise = new Promise((resolve, reject) => {\n  // Simulate an asynchronous operation\n  const success = true;\n  \n  setTimeout(() => {\n    if (success) {\n      resolve('Operation completed successfully!');\n    } else {\n      reject('Operation failed!');\n    }\n  }, 1000);\n});\n\n// Using a Promise\nmyPromise\n  .then((result) => {\n    console.log(result); // 'Operation completed successfully!'\n  })\n  .catch((error) => {\n    console.error(error);\n  })\n  .finally(() => {\n    console.log('Promise completed (either succeeded or failed)');\n  });\n\n// Function returning a Promise\nfunction fetchUserData(userId) {\n  return new Promise((resolve, reject) => {\n    setTimeout(() => {\n      if (userId > 0) {\n        const user = {\n          id: userId,\n          name: `User ${userId}`,\n          email: `user${userId}@example.com`\n        };\n        resolve(user);\n      } else {\n        reject('Invalid user ID');\n      }\n    }, 1000);\n  });\n}\n\nfetchUserData(123)\n  .then(user => {\n    console.log('User data:', user);\n    return fetchUserData(456); // Chain another promise\n  })\n  .then(anotherUser => {\n    console.log('Another user:', anotherUser);\n  })\n  .catch(error => {\n    console.error('Error fetching user data:', error);\n  });\n\n// Promise.all - wait for multiple promises\nconst promise1 = fetchUserData(1);\nconst promise2 = fetchUserData(2);\nconst promise3 = fetchUserData(3);\n\nPromise.all([promise1, promise2, promise3])\n  .then(results => {\n    console.log('All users fetched:', results);\n    // results is an array containing all resolved values\n  })\n  .catch(error => {\n    console.error('At least one promise failed:', error);\n  });\n\n// Promise.race - resolves or rejects when the first promise resolves/rejects\nPromise.race([promise1, promise2, promise3])\n  .then(firstResult => {\n    console.log('First completed result:', firstResult);\n  })\n  .catch(error => {\n    console.error('First error:', error);\n  });",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Async/Await Pattern",
                                Description =
                                    "Master the modern async/await syntax for handling asynchronous operations with a synchronous code style.",
                                LessonsCopy =
                                    "// Basic async/await\nasync function getUserData() {\n  console.log('Fetching user data...');\n  \n  // Simulate API call\n  const response = await new Promise(resolve => {\n    setTimeout(() => {\n      resolve({ name: 'Alice', age: 28 });\n    }, 1000);\n  });\n  \n  console.log('User data received!');\n  return response;\n}\n\n// Using the async function\nconsole.log('Before calling async function');\n\nguserData = getUserData();\nconsole.log('After calling async function');\nconsole.log('getUserData returns a promise:', getUserData());\n\n// To use the result, we need to await it\nasync function displayUserData() {\n  const userData = await getUserData();\n  console.log('User data:', userData);\n}\n\ndisplayUserData();\n\n// Error handling with try/catch\nasync function fetchDataWithError() {\n  try {\n    console.log('Fetching data...');\n    \n    // Simulate API call that fails\n    const response = await new Promise((resolve, reject) => {\n      setTimeout(() => {\n        reject('Network error');\n      }, 1000);\n    });\n    \n    console.log('This line never executes if there's an error');\n    return response;\n  } catch (error) {\n    console.error('Error caught:', error);\n    return null; // Provide a fallback value\n  } finally {\n    console.log('Fetch operation complete (success or failure)');\n  }\n}\n\n// Multiple async operations in sequence\nasync function sequentialFetch() {\n  console.log('Starting sequential fetches...');\n  \n  const user = await fetchUserData(1);\n  console.log('First fetch complete:', user);\n  \n  const posts = await fetchUserPosts(user.id);\n  console.log('Second fetch complete:', posts);\n  \n  const comments = await fetchPostComments(posts[0].id);\n  console.log('Third fetch complete:', comments);\n  \n  return {\n    user,\n    posts,\n    comments\n  };\n}\n\n// Multiple async operations in parallel\nasync function parallelFetch() {\n  console.log('Starting parallel fetches...');\n  \n  const userPromise = fetchUserData(1);\n  const postsPromise = fetchUserPosts(1);\n  const commentsPromise = fetchPostComments(1);\n  \n  // Wait for all promises to resolve\n  const [user, posts, comments] = await Promise.all([\n    userPromise,\n    postsPromise,\n    commentsPromise\n  ]);\n  \n  console.log('All fetches complete!');\n  return {\n    user,\n    posts,\n    comments\n  };\n}",
                                Order = 3,
                            }
                        ]
                    }
                ]
            },
            new()
            {
                Id = new Guid("47111973-d176-4feb-848d-0ea22641c31a"),
                Name = "C# and .NET Core Essentials",
                Description =
                    "Comprehensive introduction to C# programming and the .NET Core framework. Learn about the C# type system, LINQ, asynchronous programming, and how to build web APIs with ASP.NET Core. Ideal for developers looking to build cross-platform applications.",
                Chapters =
                [
                    new Chapter
                    {
                        Id = new Guid("a31a73c1-f442-4bdc-9d5c-a3b8c5846b8f"),
                        Name = "C# Language Fundamentals",
                        Description =
                            "Learn the core features of the C# language including variables, data types, control flow, and basic syntax. Get comfortable with the foundation of C# development.",
                        Order = 1,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Getting Started with C#",
                                Description =
                                    "Learn about C# and the .NET ecosystem. Write and run your first C# program using the 'Hello World' example.",
                                LessonsCopy =
                                    "// C# program structure\nusing System; // Import namespace\n\n// Namespace declaration\nnamespace HelloWorldApp\n{\n    // Class declaration\n    class Program\n    {\n        // Main method - entry point of the program\n        static void Main(string[] args)\n        {\n            // Print a message to the console\n            Console.WriteLine(\"Hello, C# World!\");\n            \n            // Wait for a key press\n            Console.WriteLine(\"Press any key to exit...\");\n            Console.ReadKey();\n        }\n    }\n}\n\n/* Key concepts:\n   1. using directives - Import libraries\n   2. namespace - Organize code \n   3. class - Define objects\n   4. Main method - Entry point\n   5. Console.WriteLine - Output text\n*/",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Variables and Data Types",
                                Description =
                                    "Explore C#'s type system including value types, reference types, and variable declarations. Learn about type safety and conversions.",
                                LessonsCopy =
                                    "using System;\n\nclass DataTypes\n{\n    static void Main()\n    {\n        // Value types\n        \n        // Integer types\n        byte smallNumber = 255;             // 8-bit unsigned integer (0 to 255)\n        int regularNumber = 42;             // 32-bit signed integer\n        long largeNumber = 9876543210L;     // 64-bit signed integer (note the 'L' suffix)\n        \n        // Floating-point types\n        float singlePrecision = 3.14f;      // 32-bit floating-point (note the 'f' suffix)\n        double doublePrecision = 3.14159265359; // 64-bit floating-point\n        decimal moneyValue = 1234.56m;      // 128-bit high-precision decimal (note the 'm' suffix)\n        \n        // Boolean type\n        bool isActive = true;               // true or false\n        \n        // Character type\n        char letter = 'A';                  // Single Unicode character\n        \n        // Reference types\n        \n        // String type\n        string greeting = \"Hello, C#\";      // Sequence of characters\n        \n        // Object type (base type for all other types)\n        object anyValue = 42;               // Can hold any type\n        object anotherValue = \"Text\";       // Now holding a string\n        \n        // Type inference with var (compiler determines the type)\n        var inferredInt = 100;              // Compiler infers int\n        var inferredString = \"Auto-typed\";  // Compiler infers string\n        \n        // Display values\n        Console.WriteLine($\"Integer: {regularNumber}\");\n        Console.WriteLine($\"Floating-point: {doublePrecision}\");\n        Console.WriteLine($\"String: {greeting}\");\n        \n        // Type conversions\n        \n        // Implicit conversion (safe, no data loss)\n        int num = 10;\n        double widerNum = num;  // int → double is safe\n        \n        // Explicit conversion (casting)\n        double pi = 3.14159;\n        int roundedPi = (int)pi;  // double → int loses the decimal part\n        Console.WriteLine($\"Pi: {pi}, Rounded: {roundedPi}\");\n        \n        // Parse from string\n        string numberText = \"123\";\n        int parsedNumber = int.Parse(numberText);\n        \n        // TryParse (safer, handles errors)\n        string possibleNumber = \"456\";\n        if (int.TryParse(possibleNumber, out int result))\n        {\n            Console.WriteLine($\"Successfully parsed: {result}\");\n        }\n        else\n        {\n            Console.WriteLine(\"Parsing failed!\");\n        }\n        \n        // Constants\n        const double GravityConstant = 9.8;\n        // GravityConstant = 10.0; // Error! Cannot change a constant\n    }\n}",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Control Flow and Loops",
                                Description =
                                    "Master decision making with if-else statements, switch cases, and loop structures in C#. Learn how to control the flow of your program execution.",
                                LessonsCopy =
                                    "using System;\n\nclass ControlFlow\n{\n    static void Main()\n    {\n        // If-else statements\n        int temperature = 25;\n        \n        if (temperature > 30)\n        {\n            Console.WriteLine(\"It's hot outside!\");\n        }\n        else if (temperature > 20)\n        {\n            Console.WriteLine(\"It's a pleasant day.\");\n        }\n        else\n        {\n            Console.WriteLine(\"It's cold today.\");\n        }\n        \n        // Ternary operator\n        string message = temperature > 20 ? \"It's warm\" : \"It's cold\";\n        Console.WriteLine(message);\n        \n        // Switch statement\n        string day = \"Monday\";\n        \n        switch (day)\n        {\n            case \"Monday\":\n                Console.WriteLine(\"Start of the work week\");\n                break;\n            case \"Friday\":\n                Console.WriteLine(\"End of the work week\");\n                break;\n            case \"Saturday\":\n            case \"Sunday\":\n                Console.WriteLine(\"It's the weekend!\");\n                break;\n            default:\n                Console.WriteLine(\"It's a weekday\");\n                break;\n        }\n        \n        // Switch expression (C# 8.0+)\n        string dayType = day switch\n        {\n            \"Saturday\" or \"Sunday\" => \"Weekend\",\n            \"Monday\" => \"Start of week\",\n            \"Friday\" => \"End of week\",\n            _ => \"Weekday\"  // Default case\n        };\n        Console.WriteLine($\"{day} is a {dayType}\");\n        \n        // For loop\n        Console.WriteLine(\"\\nCounting from 1 to 5:\");\n        for (int i = 1; i <= 5; i++)\n        {\n            Console.WriteLine($\"Number {i}\");\n        }\n        \n        // Foreach loop\n        string[] fruits = { \"Apple\", \"Banana\", \"Orange\" };\n        Console.WriteLine(\"\\nFruit list:\");\n        foreach (string fruit in fruits)\n        {\n            Console.WriteLine(fruit);\n        }\n        \n        // While loop\n        int countdown = 3;\n        Console.WriteLine(\"\\nCountdown:\");\n        while (countdown > 0)\n        {\n            Console.WriteLine($\"{countdown}...\");\n            countdown--;\n        }\n        Console.WriteLine(\"Blast off!\");\n        \n        // Do-while loop\n        int number = 1;\n        int sum = 0;\n        Console.WriteLine(\"\\nAdding numbers:\");\n        do\n        {\n            sum += number;\n            number++;\n        } while (number <= 5);\n        Console.WriteLine($\"Sum of 1 to 5: {sum}\");\n        \n        // Break and continue\n        Console.WriteLine(\"\\nUsing break and continue:\");\n        for (int i = 1; i <= 10; i++)\n        {\n            if (i == 3)\n            {\n                continue; // Skip iteration when i is 3\n            }\n            \n            Console.WriteLine($\"Number: {i}\");\n            \n            if (i == 7)\n            {\n                break; // Exit loop when i is 7\n            }\n        }\n    }\n}",
                                Order = 3,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("b47c5fca-8dc5-4380-8b8b-2e21c4d2a71e"),
                        Name = "Object-Oriented Programming in C#",
                        Description =
                            "Learn how to use classes, inheritance, interfaces, and other object-oriented programming concepts in C#. Build maintainable and reusable code using OOP principles.",
                        Order = 2,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Classes and Objects",
                                Description =
                                    "Learn how to define classes, create objects, and work with properties, methods, and constructors in C#.",
                                LessonsCopy =
                                    "using System;\n\n// Basic class definition\nclass Person\n{\n    // Fields (usually private)\n    private string name;\n    private int age;\n    \n    // Properties (public interface to access fields)\n    public string Name\n    {\n        get { return name; }\n        set { name = value; }\n    }\n    \n    // Auto-implemented property (C# creates the backing field automatically)\n    public int Age { get; set; }\n    \n    // Read-only property\n    public bool IsAdult => Age >= 18;\n    \n    // Constructor\n    public Person(string name, int age)\n    {\n        this.name = name;\n        this.Age = age; // Using the auto-property\n    }\n    \n    // Default constructor\n    public Person()\n    {\n        name = \"Unknown\";\n        Age = 0;\n    }\n    \n    // Methods\n    public void Introduce()\n    {\n        Console.WriteLine($\"Hi, I'm {name} and I'm {Age} years old.\");\n    }\n    \n    public int YearsUntilRetirement(int retirementAge = 65)\n    {\n        return Math.Max(0, retirementAge - Age);\n    }\n}\n\n// Using static members\nclass MathHelper\n{\n    // Static field\n    public static readonly double PI = 3.14159;\n    \n    // Static method\n    public static double CalculateCircleArea(double radius)\n    {\n        return PI * radius * radius;\n    }\n}\n\nclass Program\n{\n    static void Main()\n    {\n        // Creating objects\n        Person person1 = new Person(\"Alice\", 30);\n        Person person2 = new Person { Name = \"Bob\", Age = 25 }; // Object initializer syntax\n        \n        // Using object methods and properties\n        person1.Introduce();\n        Console.WriteLine($\"{person1.Name} is {(person1.IsAdult ? \"an adult\" : \"not an adult\")}\");\n        Console.WriteLine($\"{person1.Name} has {person1.YearsUntilRetirement()} years until retirement\");\n        \n        // Using static members\n        double radius = 5.0;\n        double area = MathHelper.CalculateCircleArea(radius);\n        Console.WriteLine($\"Area of circle with radius {radius} is {area}\");\n        \n        // Value vs Reference types demonstration\n        int x = 10;\n        int y = x;   // Value is copied\n        y = 20;      // Only y changes\n        Console.WriteLine($\"x: {x}, y: {y}\"); // x remains 10\n        \n        Person p1 = new Person(\"Carol\", 35);\n        Person p2 = p1;   // Reference is copied (both point to same object)\n        p2.Age = 40;      // Changes affect the same object\n        Console.WriteLine($\"{p1.Name}'s age: {p1.Age}\"); // Carol's age is now 40\n    }\n}",
                                Order = 1,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Inheritance and Polymorphism",
                                Description =
                                    "Learn how to create class hierarchies, override methods, and utilize inheritance and polymorphism for more flexible code design.",
                                LessonsCopy =
                                    "using System;\n\n// Base class\npublic class Animal\n{\n    // Protected field - accessible in derived classes\n    protected string name;\n    \n    // Properties\n    public string Name { get { return name; } set { name = value; } }\n    public int Age { get; set; }\n    \n    // Constructor\n    public Animal(string name, int age)\n    {\n        this.name = name;\n        this.Age = age;\n    }\n    \n    // Virtual method (can be overridden by derived classes)\n    public virtual void MakeSound()\n    {\n        Console.WriteLine(\"The animal makes a sound\");\n    }\n    \n    // Non-virtual method\n    public void Sleep()\n    {\n        Console.WriteLine($\"{name} is sleeping\");\n    }\n}\n\n// Derived class\npublic class Dog : Animal\n{\n    public string Breed { get; set; }\n    \n    // Constructor that calls base constructor\n    public Dog(string name, int age, string breed) : base(name, age)\n    {\n        Breed = breed;\n    }\n    \n    // Override the virtual method\n    public override void MakeSound()\n    {\n        Console.WriteLine($\"{name} barks: Woof! Woof!\");\n    }\n    \n    // New method specific to Dog\n    public void Fetch()\n    {\n        Console.WriteLine($\"{name} fetches the ball\");\n    }\n}\n\n// Another derived class\npublic class Cat : Animal\n{\n    public bool IsIndoor { get; set; }\n    \n    public Cat(string name, int age, bool isIndoor) : base(name, age)\n    {\n        IsIndoor = isIndoor;\n    }\n    \n    public override void MakeSound()\n    {\n        Console.WriteLine($\"{name} meows: Meow!\");\n    }\n    \n    public void Climb()\n    {\n        Console.WriteLine($\"{name} climbs up the tree\");\n    }\n}\n\n// Abstract class - cannot be instantiated directly\npublic abstract class Shape\n{\n    // Abstract method - must be implemented by non-abstract derived classes\n    public abstract double CalculateArea();\n    \n    // Regular method\n    public void DisplayArea()\n    {\n        Console.WriteLine($\"The area is {CalculateArea()}\");\n    }\n}\n\n// Concrete class implementing the abstract class\npublic class Circle : Shape\n{\n    public double Radius { get; set; }\n    \n    public Circle(double radius)\n    {\n        Radius = radius;\n    }\n    \n    // Implementing the abstract method\n    public override double CalculateArea()\n    {\n        return Math.PI * Radius * Radius;\n    }\n}\n\n// Main program\nclass Program\n{\n    static void Main()\n    {\n        // Creating objects\n        Dog dog = new Dog(\"Rex\", 3, \"German Shepherd\");\n        Cat cat = new Cat(\"Whiskers\", 2, true);\n        \n        // Call methods on specific objects\n        dog.MakeSound();  // Uses overridden method\n        dog.Fetch();      // Dog-specific method\n        \n        cat.MakeSound();  // Uses overridden method\n        cat.Climb();      // Cat-specific method\n        \n        // Polymorphism - treating derived class objects as base class\n        Console.WriteLine(\"\\nPolymorphism Example:\");\n        Animal[] animals = { dog, cat };\n        \n        foreach (Animal animal in animals)\n        {\n            Console.WriteLine($\"Animal: {animal.Name}, Age: {animal.Age}\");\n            animal.MakeSound();  // Calls the override appropriate for each object type\n            animal.Sleep();      // Calls the base class implementation\n            \n            // Check type and cast to access specific methods\n            if (animal is Dog dogAnimal)\n            {\n                Console.WriteLine($\"Breed: {dogAnimal.Breed}\");\n                dogAnimal.Fetch();\n            }\n            else if (animal is Cat catAnimal)\n            {\n                Console.WriteLine($\"Indoor cat: {catAnimal.IsIndoor}\");\n                catAnimal.Climb();\n            }\n            \n            Console.WriteLine();\n        }\n        \n        // Abstract classes and methods\n        Circle circle = new Circle(5.0);\n        circle.DisplayArea();  // Uses the implemented abstract method\n    }\n}",
                                Order = 2,
                            },
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Interfaces and Advanced OOP",
                                Description =
                                    "Explore interfaces, generics, and advanced object-oriented programming concepts in C#. Learn how to create flexible and extensible code designs.",
                                LessonsCopy =
                                    "using System;\nusing System.Collections.Generic;\n\n// Interface definition\npublic interface IPlayable\n{\n    // Method declarations (no implementation)\n    void Play();\n    void Pause();\n    void Stop();\n    \n    // Property declaration\n    bool IsPlaying { get; }\n    \n    // Default implementation (C# 8.0+)\n    void Rewind()\n    {\n        Console.WriteLine(\"Rewinding to the beginning...\");\n        Stop();\n    }\n}\n\n// Another interface\npublic interface IStorable\n{\n    void Save(string filename);\n    void Load(string filename);\n}\n\n// Class implementing multiple interfaces\npublic class AudioPlayer : IPlayable, IStorable\n{\n    private bool isPlaying = false;\n    private string currentTrack = \"\";\n    \n    public bool IsPlaying => isPlaying;\n    \n    public void Play()\n    {\n        isPlaying = true;\n        Console.WriteLine($\"Playing audio: {currentTrack}\");\n    }\n    \n    public void Pause()\n    {\n        isPlaying = false;\n        Console.WriteLine(\"Audio paused\");\n    }\n    \n    public void Stop()\n    {\n        isPlaying = false;\n        Console.WriteLine(\"Audio stopped\");\n    }\n    \n    public void Save(string filename)\n    {\n        Console.WriteLine($\"Saving playlist to {filename}\");\n    }\n    \n    public void Load(string filename)\n    {\n        currentTrack = \"Track from \" + filename;\n        Console.WriteLine($\"Loaded playlist from {filename}\");\n    }\n    \n    // Class-specific method\n    public void SetVolume(int level)\n    {\n        Console.WriteLine($\"Setting volume to {level}\");\n    }\n}\n\n// Generic class example\npublic class Repository<T>\n{\n    private List<T> items = new List<T>();\n    \n    public void Add(T item)\n    {\n        items.Add(item);\n    }\n    \n    public T GetByIndex(int index)\n    {\n        if (index >= 0 && index < items.Count)\n        {\n            return items[index];\n        }\n        throw new IndexOutOfRangeException();\n    }\n    \n    public int Count => items.Count;\n    \n    public void DisplayAll(Action<T> displayAction)\n    {\n        foreach (T item in items)\n        {\n            displayAction(item);\n        }\n    }\n}\n\n// Extension method example\npublic static class StringExtensions\n{\n    public static bool IsPalindrome(this string str)\n    {\n        string normalized = str.ToLower().Replace(\" \", \"\");\n        int length = normalized.Length;\n        \n        for (int i = 0; i < length / 2; i++)\n        {\n            if (normalized[i] != normalized[length - i - 1])\n            {\n                return false;\n            }\n        }\n        \n        return true;\n    }\n}\n\n// Main program\nclass Program\n{\n    static void Main()\n    {\n        // Using interfaces\n        AudioPlayer player = new AudioPlayer();\n        player.Load(\"music.mp3\");\n        player.Play();\n        player.Pause();\n        player.SetVolume(80); // Class-specific method\n        \n        // Interface as a type\n        Console.WriteLine(\"\\nInterface as a type:\");\n        IPlayable playableDevice = player;\n        playableDevice.Play();\n        playableDevice.Rewind(); // Using default implementation\n        \n        // Cannot call SetVolume directly on interface reference\n        // playableDevice.SetVolume(70); // This would cause an error\n        \n        // Using generic collections\n        Console.WriteLine(\"\\nGeneric Repository:\");\n        Repository<string> stringRepo = new Repository<string>();\n        stringRepo.Add(\"First item\");\n        stringRepo.Add(\"Second item\");\n        stringRepo.Add(\"Third item\");\n        \n        Console.WriteLine($\"Repository count: {stringRepo.Count}\");\n        Console.WriteLine($\"Item at index 1: {stringRepo.GetByIndex(1)}\");\n        \n        stringRepo.DisplayAll(item => Console.WriteLine($\"- {item}\"));\n        \n        // Using extension method\n        Console.WriteLine(\"\\nExtension method:\");\n        string text1 = \"racecar\";\n        string text2 = \"hello\";\n        \n        Console.WriteLine($\"Is '{text1}' a palindrome? {text1.IsPalindrome()}\");\n        Console.WriteLine($\"Is '{text2}' a palindrome? {text2.IsPalindrome()}\");\n    }\n}",
                                Order = 3,
                            }
                        ]
                    },
                    new Chapter
                    {
                        Id = new Guid("c66e7cf8-6657-4a9c-ac8e-5c092a2d3f1e"),
                        Name = "LINQ and Collections",
                        Description =
                            "Learn how to work with collections and use Language Integrated Query (LINQ) to efficiently process data in C#. Master querying, filtering, and transforming data from various sources.",
                        Order = 3,
                        Lessons =
                        [
                            new Lesson
                            {
                                Id = Guid.NewGuid(),
                                Name = "Collections in C#",
                                Description =
                                    "Explore the collection types available in C#, including lists, dictionaries, sets, and more. Learn how to store and manipulate groups of objects.",
                                LessonsCopy =
                                    "using System;\nusing System.Collections.Generic;\nusing System.Collections;\nusing System.Linq;\n\nclass CollectionsDemo\n{\n    static void Main()\n    {\n        // Arrays - fixed size collection\n        int[] numbersArray = { 1, 2, 3, 4, 5 };\n        Console.WriteLine(\"Array elements:\");\n        for (int i = 0; i < numbersArray.Length; i++)\n        {\n            Console.Write($\"{numbersArray[i]} \");\n        }\n        Console.WriteLine(\"\\n\");\n        \n        // List<T> - dynamic size collection\n        List<string> names = new List<string>();\n        names.Add(\"Alice\");\n        names.Add(\"Bob\");\n        names.Add(\"Charlie\");\n        \n        // Alternative initialization\n        List<string> fruits = new List<string> { \"Apple\", \"Banana\", \"Orange\" };\n        \n        Console.WriteLine(\"List operations:\");\n        fruits.Insert(1, \"Mango\"); // Insert at specific position\n        fruits.Remove(\"Banana\");   // Remove specific element\n        \n        Console.WriteLine($\"Fruits count: {fruits.Count}\");\n        Console.WriteLine($\"Contains 'Apple'? {fruits.Contains(\"Apple\")}\");\n        Console.WriteLine(\"Fruits elements:\");\n        foreach (string fruit in fruits)\n        {\n            Console.WriteLine($\"- {fruit}\");\n        }\n        Console.WriteLine();\n        \n        // Dictionary<TKey, TValue> - key/value pairs\n        Dictionary<string, int> ages = new Dictionary<string, int>();\n        ages.Add(\"Alice\", 30);\n        ages.Add(\"Bob\", 25);\n        ages[\"Charlie\"] = 35; // Add or update using indexer\n        \n        Console.WriteLine(\"Dictionary operations:\");\n        Console.WriteLine($\"Bob's age: {ages[\"Bob\"]}\");\n        \n        // Check if key exists before accessing\n        if (ages.ContainsKey(\"Dave\"))\n        {\n            Console.WriteLine($\"Dave's age: {ages[\"Dave\"]}\");\n        }\n        else\n        {\n            Console.WriteLine(\"Dave is not in the dictionary\");\n        }\n        \n        // Using TryGetValue - safer way to get values\n        if (ages.TryGetValue(\"Alice\", out int aliceAge))\n        {\n            Console.WriteLine($\"Alice's age: {aliceAge}\");\n        }\n        \n        // Looping through dictionary\n        Console.WriteLine(\"\\nAll people and their ages:\");\n        foreach (KeyValuePair<string, int> pair in ages)\n        {\n            Console.WriteLine($\"{pair.Key} is {pair.Value} years old\");\n        }\n        \n        // Deconstruction (C# 7.0+)\n        foreach (var (name, age) in ages)\n        {\n            Console.WriteLine($\"{name} - {age}\");\n        }\n        Console.WriteLine();\n        \n        // HashSet<T> - collection of unique elements\n        HashSet<string> uniqueNames = new HashSet<string>();\n        uniqueNames.Add(\"Alice\");\n        uniqueNames.Add(\"Bob\");\n        uniqueNames.Add(\"Alice\"); // Duplicate, won't be added\n        \n        Console.WriteLine(\"HashSet operations:\");\n        Console.WriteLine($\"Count of unique names: {uniqueNames.Count}\");\n        Console.WriteLine($\"Contains 'Bob'? {uniqueNames.Contains(\"Bob\")}\");\n        \n        // HashSet set operations\n        HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };\n        HashSet<int> set2 = new HashSet<int> { 3, 4, 5, 6, 7 };\n        \n        // Make a copy of set1\n        HashSet<int> union = new HashSet<int>(set1);\n        union.UnionWith(set2);\n        \n        HashSet<int> intersection = new HashSet<int>(set1);\n        intersection.IntersectWith(set2);\n        \n        HashSet<int> difference = new HashSet<int>(set1);\n        difference.ExceptWith(set2);\n        \n        Console.WriteLine(\"\\nSet operations:\");\n        Console.Write(\"Set1: \"); PrintCollection(set1);\n        Console.Write(\"Set2: \"); PrintCollection(set2);\n        Console.Write(\"Union: \"); PrintCollection(union);\n        Console.Write(\"Intersection: \"); PrintCollection(intersection);\n        Console.Write(\"Difference (Set1-Set2): \"); PrintCollection(difference);\n        Console.WriteLine();\n        \n        // Queue<T> - First-In-First-Out (FIFO) collection\n        Queue<string> queue = new Queue<string>();\n        queue.Enqueue(\"First\");\n        queue.Enqueue(\"Second\");\n        queue.Enqueue(\"Third\");\n        \n        Console.WriteLine(\"Queue operations (FIFO):\");\n        Console.WriteLine($\"Front item (peek): {queue.Peek()}\");\n        Console.WriteLine($\"Dequeue: {queue.Dequeue()}\"); // Removes \"First\"\n        Console.WriteLine($\"Items count: {queue.Count}\");\n        Console.WriteLine();\n        \n        // Stack<T> - Last-In-First-Out (LIFO) collection\n        Stack<string> stack = new Stack<string>();\n        stack.Push(\"First\");\n        stack.Push(\"Second\");\n        stack.Push(\"Third\");\n        \n        Console.WriteLine(\"Stack operations (LIFO):\");\n        Console.WriteLine($\"Top item (peek): {stack.Peek()}\");\n        Console.WriteLine($\"Pop: {stack.Pop()}\"); // Removes \"Third\"\n        Console.WriteLine($\"Items count: {stack.Count}\");\n    }\n    \n    static void PrintCollection<T>(IEnumerable<T> collection)\n    {\n        Console.Write(\"{ \");\n        Console.Write(string.Join(\", \", collection));\n        Console.WriteLine(\" }\");\n    }\n}",
                                Order = 1,
                            }
                        ]
                    }
                ]
            },
        };
        
        context.AddRange(courses);
        context.SaveChanges();
    }

    private static void SeedUserData(MimoDbContext context)
    {
        if (context.Users.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var users = new List<User>
        {
            new()
            {
                Id = new Guid("dd4dba61-429c-4bbd-8db3-06fa3552223f"),
                Username = "john_doe",
                PasswordHash = "password"
            },
            new()
            {
                Id = new Guid("cf5f4020-430a-4cc9-a263-915453aca15f"),
                Username = "jane_doe",
                PasswordHash = "password"
            },
        };
        
        context.AddRange(users);
        context.SaveChanges();
    }
    
    private static void SeedAchievementData(MimoDbContext context)
    {
        if (context.Achievements.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var achievements = new List<Achievement>
        {
            new()
            {
                Id = new Guid("61cad9ac-c2cb-451c-be58-27752d386596"),
                Name = "Complete 5 lessons",
                AchievementType = AchievementType.LessonCount,
                Count = 5,
            },
            new()
            {
                Id = new Guid("2d7dc9ca-35f4-460a-a03d-787f13ea2f0f"),
                Name = "Complete 25 lessons",
                AchievementType = AchievementType.LessonCount,
                Count = 25,
            },
            new()
            {
                Id = new Guid("333bc7ef-37c0-41bb-b984-a8a7d50934db"),
                Name = "Complete 50 lessons",
                AchievementType = AchievementType.LessonCount,
                Count = 50,
            },
            new()
            {
                Id = new Guid("cd38173b-b6dd-4c94-b141-96f62f82b8a1"),
                Name = "Complete 1 chapter",
                AchievementType = AchievementType.ChapterCount,
                Count = 1,
            },
            new()
            {
                Id = new Guid("d6fe35d0-874a-4e0f-9010-f868c62d52fe"),
                Name = "Complete 5 chapters",
                AchievementType = AchievementType.ChapterCount,
                Count = 5,
            },
            new()
            {
                Id = new Guid("e0fb84b4-7d87-4609-a8f7-b0b8dbb09ec4"),
                Name = "Complete the Swift course",
                AchievementType = AchievementType.CourseCompletion,
                CourseId = new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
            },
            new()
            {
                Id = new Guid("8c489a6d-3741-433e-8469-0df0a63c6369"),
                Name = "Complete the Javascript course",
                AchievementType = AchievementType.CourseCompletion,
                CourseId = new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"),
            },
            new()
            {
                Id = new Guid("d26c3765-779e-492c-8cac-49c8018d8750"),
                Name = "Complete the C# course",
                AchievementType = AchievementType.CourseCompletion,
                CourseId = new Guid("47111973-d176-4feb-848d-0ea22641c31a"),
            }
        };
        
        context.AddRange(achievements);
        context.SaveChanges();
    }
}