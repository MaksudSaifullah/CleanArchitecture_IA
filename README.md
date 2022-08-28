# Internal Audit

Internal audits evaluate a company's internal controls, including its corporate governance and accounting processes. These audits ensure compliance with laws and regulations and help to maintain accurate and timely financial reporting and data collection.  

Internal audits also provide management with the tools necessary to attain operational efficiency by identifying problems and correcting lapses before they are discovered in an external audit. 

## Getting started

### Choose a terminal
To execute Git commands on your computer, you must open a terminal (also known as command prompt, command shell, and command line). Here are some options:

- For macOS users:
  - Built-in Terminal. Press ⌘ command + space and type terminal.
  - iTerm2. You can integrate it with Zsh and Oh My Zsh for color highlighting and other advanced features.
- For Windows users:
  - Built-in command line. On the Windows taskbar, select the search icon and type cmd.
  - PowerShell.
  - Git Bash. It is built into Git for Windows.
- For Linux users:
  - Built-in Linux Terminal

### Confirm Git is installed
You can determine if Git is already installed on your computer by opening a terminal and running this command:
``` git --version ```

If Git is installed, the output is:
``` git version X.Y.Z ```

If your computer doesn't recognize git as a command, you must install Git.
### Configure Git
To start using Git from your computer, you must enter your credentials to identify yourself as the author of your work. The username and email address should match the ones you use in GitLab.
- In your shell, add your user name:
``` git config --global user.name "your_username" ```
- Add your email address:
``` git config --global user.email "your_email_address@example.com" ```
- To check the configuration, run:
``` git config --global --list ```

The ```--global``` option tells Git to always use this information for anything you do on your system. If you omit ```--global``` or use ```--local```, the configuration applies only to the current repository.
You can read more on how Git manages configurations in the Git configuration documentation.


### Clone a repository
When you clone a repository, the files from the remote repository are downloaded to your computer, and a connection is created.

This connection requires you to add credentials. You can either use SSH or HTTPS. SSH is recommended.

#### Clone with SSH
Clone with SSH when you want to authenticate only one time.

- Authenticate with GitLab by following the instructions in the SSH documentation.
- Go to your project’s landing page and select Clone. Copy the URL for Clone with SSH.
- Open a terminal and go to the directory where you want to clone the files. Git automatically creates a folder with the repository name and downloads the files there.
- Run this command: ``` git clone git@gitlab.com:gitlab-tests/sample-project.git ```
- To view the files, go to the new directory: ``` cd sample-project ```

You can also clone a repository and open it directly in Visual Studio Code.

#### Clone with HTTPS
Clone with HTTPS when you want to authenticate each time you perform an operation between your computer and GitLab.

- Go to your project’s landing page and select Clone. Copy the URL for Clone with HTTPS.
- Open a terminal and go to the directory where you want to clone the files.
- Run the following command. Git automatically creates a folder with the repository name and downloads the files there. ``` git clone https://gitlab.com/gitlab-tests/sample-project.git ```
- GitLab requests your username and password:
  - If you have 2FA enabled for your account, you must use a Personal Access Token with read_repository or write_repository permissions instead of your account’s password.
  - If you don’t have 2FA enabled, use your account’s password.
- To view the files, go to the new directory: ``` cd sample-project ```


# Development Guidelines
## Required technologies
The solution is built with using 
- Microsoft technologies
- .NET core, Web Services
- SQL Server
- Angular 13
- HTML5
- CSS
- Typescript  
## Backend
Pre-requisites
- Visual Studio 2022
- .NET 6 core

Clone the project repo:

```
git clone http://192.168.100.42/team-ia/internal-audit.git
```
Move to API directory:

```
cd internal-audit/src/api/Internal.Audit
```
Open the solution with visual studio, then build & run the project.

## Frontend
Pre-requisites
- Visual Studio Code
- **Node** To install : 
[Node](https://phoenixnap.com/kb/install-node-js-npm-on-windows) 
- **Angular 13+** To install run command ``` npm install -g @angular/cli ```


Move to UI directory:
```
cd internal-audit/src/ui/internal.audit
```



Open the angular project with visual studio code to edit & run these commands to start the project:
```
npm install
ng serve -o
```
If you are running any angular command e.g. ng serve, ng build, ng new, ng generate etc. from Visual Studio Code Terminal or from command prompt and getting a error related to execution policy, then you can go through the below solution to fix above issue.

Solution: Run the following command from the same terminal or command prompt and re-run the ng command to check if it works on your machine:
```
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

## Architecture Overview

![](img/architecture.png)

### Backend
- CQRS – Command Query Responsibility Segregation is used here, for insert, update, delete system will use Entity framework core and for selecting data it will use Dapper. CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level. 


- Mediator – For loosely couple and easy readability mediator pattern is followed here. The Mediator design pattern defines an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently. 

 

- Auto Mapper – Data transfer object (DTO) is used for so that we don’t expose our table structure to client. It is a popular object-to-object mapping library that can be used to map objects belonging to dissimilar types. As an example, you might need to map the DTOs (Data Transfer Objects) in your application to the model objects. Auto Mapper saves the tedious effort of having to manually map one or more properties of such incompatible types 


- Fluent API – For model validation and sending mail fluent API is used. Fluent API is an advanced way of specifying model configuration that covers everything that data annotations can do in addition to some more advanced configuration not possible with data annotations. Data annotations and the fluent API can be used together, but Code First gives precedence to Fluent API > data annotations > default conventions. 

 

  - Fluent API is another way to configure your domain classes. 

  - The Code First Fluent API is most commonly accessed by overriding the OnModelCreating method on your derived DbContext. 

  - Fluent API provides more functionality for configuration than DataAnnotations. Fluent API supports the following types of mappings. 

![](img/backend_architecture.pdf)

### Frontend
- User Interface – The user interface has built with using HTML5, CSS, JavaScript, Bootstrap. The main application targeted for desktops, Laptops and Mobile. 
![](img/user_interface.png))

- APP – This is the mother module of Internal-Audit Frontend. It is the root module of Internal-Audit Application. App Routing mapping the URLs to a specific function that will handle the logic for that URL. 

   - Example: In our application, the URL (“/”) is associated with the root URL. So if our site’s domain was www.internalaudit.com and we want to add routing to “www.internalaudit.com/ #/dashboard”, we would use “#/dashboard”. To bind a function to an URL path we use the app route decorator. Here we will decide which module will open first. 


- Core – This is the main module for all kind of services where back end api will be connected with front end. Currently this module is divided into five parts. which are AUTH, CONSTANTS, GUARDS, INTERCEPTORS, SERVICES. 
  - AUTH -- Here JSON Web Tokens can be used to establish a user session, JWTs are digitally signed JSON payloads, encoded in a URL-friendly string format. If JWTs are used for Authentication, they will contain at least a user ID and an expiration timestamp. 

  - CONSTANTS –  All kind of constant policies would be written here. Like Email or Phone Regular Expression are written here in a class 

  - GUARDS –  Authentication Guard, Role Guard, User Guard etc. are stored in this folder. The guard is use to check the user or role is valid or not.   

  - INTERCEPTORS – HttpInterceptor will be implemented here using jwtInterceptor. Authorization header will be built here with jwt token. 

  - SERVICES -- All type of service will be implemented here with a common service. Common service will handle most of the api. If any service cannot perform with common service, then the service will be created in this folder individually 

- Views – All the Modules views, component and typescript will be held in this portion. One stage of routing will be implemented here and the main routing will be covered by app-routing.  
 

- Model – All the database table and property are here in the model folder. 

# Deployment Guidelines
### Prerequisite to install
- IIS
- .NET 6 SDK for hosting. You can install it from here: [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.6-windows-hosting-bundle-installer)

## Publish Backend
- Step 1: Open the source code with Visual Studio on your local machine
- Step 2: Right click on the API project (Internal.Audit.Api), then select "Publish".
- Step 3: Select Target folder, some files will be published to the folder. Later, you will copy these file from your local machine to the server. 

- Step 4: Open IIS in your desired server where you want to host the API
- Step 5: Add a website by right click on sites with a application pool that contains .NET 6 sdk, you have to give a path while adding the website. Copy the files generated in Step 3 to this folder. You also need to specify the port number in this step.
  - If there is no application pool with .NET 6 sdk, create one first as per the screenshot. Also enable 32-bit applications for this application pool from advanced setting by right clicking the application pool.
  ![](img/apk_pool.png)
- Step 6: Now just start the Site. You can verify by accessing http://serverIp:port/swagger/index.html if the swagger is kept on.

## Publish Frontend

- Step 1: Just run the coomand ``` ng build --prod ```, it will create a folder named "dist" in the source folder. Copy these files.
- Step 2: Open IIS in your desired server where you want to host the API
- Step 3: Add a website by right click on sites with any application pool with a port number.
- Step 4: Now just start the Site and access the UI. [Use the port number specified in Step 3]

### Configuration guideline
- For the API connection use the address of API (where you already had published the API) port number specified in the Step 5 of publishing the Backend API. You can set the API address & IP in the following file of Frontend:
  ![](img/UIconfiguration.png)
- You can also change the connection string before publishing the source code in the following file: (appsettings.json)
  ![](img/databaseConfiguration.png)

## IMPORTANT NOTES!


**Note for Pull Requests (PRs)**: We accept pull requests from the community. When doing it, please do it onto the **DEV branch** which is the consolidated work-in-progress branch. Do not request it onto **master** branch.

## Usage



## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.