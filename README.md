# APIPostsViewer

GENERAL:

API Posts Viewer is a simple WPF application completed as a test assignment. 

GOAL:

The main goal is to get JSON data (posts) from the REST service and display it as a set of tiles (NxM grid).
Each tile should be associated with a separate post and display its data, initially the post's ID.
Each tile should allow clicking on it with toggling displayed data between post's ID and post's USER ID.

DESCRIPTION:

The solution was developed at Visual Studio 2019.
Selected template: WPF application (.NET Framework 4.5). 
The project uses third-party library Newtonsoft.Json (https://www.newtonsoft.com/json) for JSON parsing.

USAGE:

By default, the application has all settings set. 
The only action required is to run File->Load posts.
Posts will be loaded and buttons-tiles will be created. 
Click on any tile and you will change displayed values for all tiles.

INPUT DATA:

API URL: a link to the API service GET method returning JSON with 100 posts elements. By default, URL is https://jsonplaceholder.typicode.com/posts
Rows: number of rows in UI grid. By default, it's 10.
Columns: number of columns in UI grid. By default, it's 10.

JSON post structure:

{
  "userId": 1,
  "id": 1,
  "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
  "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
}

UI:

The application consists of two windows - main windows and settings window.

The main window has a small menu File containing 4 options: Load posts, Clear posts, Settings and Exit. 
'Load posts' makes a call to API, downloading data, parsing it, generating required UI elements and linking data to them.
'Clear posts' just clears the application workspace removing old UI elements.
'Settings' opens settings modal window allowing to update parameters.
'Exit' terminates application

The main window has also a workspace built with UniformGrid and dynamically created buttons inside it.
Each button is a tile representing post. Click on any button toggling content for all buttons at workspace.

Settings window has 3 input textboxes for 3 parameters: API url, rows and columns. 
Added simple validation.
Application has an unique settings instance.

REST CALL:

REST service is called by standard WebRequest in an asynchronous mode.

DATA PARSING:

JSON is parsed by Newtonsoft library and is transformed to list of posts.

UNIT TESTS

The solution contains several simple unit tests (MS) covering most of the used methods. 
Tests are stored in an separate project.

NOTES/POSSIBLE ENHANCEMENTS:

1. ID and USER ID fields are stored as string values - just for conveniency to avoid extra .ToString() calls.
In real project probably it's better to use numeric types.
2. Settings are not stored in an external storage - file or database.
