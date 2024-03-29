﻿# Fetch NASA Astronomy Picture of the Day

## App written in ASP.NET Core for fetching NASA Astronomy Image of the Day API data and displaying it on the page.

The app can fetch data for any date from 16th June 1995 to the current date. The data is fetched from the NASA API and displayed on the page. App has also a feature to display the data for a random date. 

The implementation strictly adheres to MVC pattern and N-tier architecture, by using service layer and DTO <s>(DAO is not used since there are not any CRUD operations ... yet)</s>. There is also DAO implementation, which will be updated as more CRUD operations are being added. 

It uses the DEMO_KEY for the API key, which is limited to 30 requests per hour and 50 requests per day. If you want to use it more often, you need to get your own API key from [NASA API](https://api.nasa.gov/) <s>and modify accordingly the Models/NasaAPIRequestParams.cs file (in the future I will probably add an implementation to be able to do it during runtime and save the configuration, for now it has to be done manually)</s>. Now you can enter your API KEY during runtime (if none is provided, the defalut "DEMO_KEY" is being used). 

 All the data is fetched from [NASA API](https://api.nasa.gov/) which is free to use.
### The copyright of the data belongs to NASA and their respective owners. I do not own any. I have only written the code for fetching and displaying the data.

### To Do:

- [ ] Add crud operations for the data.
- [ ] Improve UI/UX.  
- [ ] Minor Bug Fixes and logging.

- DbContext added. You can create a local db by using a migration. 
- Added an implementation to store data in local db. It will soon be updated with design patterns, and ability to search, display and delete records. 