# Fetch NASA Astronomy Image of the Day API DATA

## App written in ASP.NET Core for fetching NASA Astronomy Image of the Day API data and displaying it on the page.

The app can fetch data for any date from 16th June 1995 to the current date. The data is fetched from the NASA API and displayed on the page. App has also a feature to display the data for a random date. 

The implementation strictly adheres to MVC pattern and N-tier architecture, by using service layer and DTO (DAO is not used since there are not any CRUD operations ... yet). 

It uses the DEMO_KEY for the API key, which is limited to 30 requests per hour and 50 requests per day. If you want to use it more often, you need to get your own API key from [NASA API](https://api.nasa.gov/) and modify accordingly the Models/NasaAPIRequestParams.cs file (in the future I will probably add an implementation to be able to do it during runtime and save the configuration, for now it has to be done manually).

 All the data is fetched from [NASA API](https://api.nasa.gov/) which is free to use.
### The copyright of the data belongs to NASA and their respective owners. I do not own any. I have only written the code for fetching and displaying the data.

### To Do:

- [ ] Add crud operations for the data.
- [ ] Improve UI/UX.  
- [ ] Minor Bug Fixes and logging.  
