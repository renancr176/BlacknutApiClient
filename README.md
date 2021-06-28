# About

> :warning: **Development in progress.**

Unofficial client for DotNet, this project map all [Blacknut API](http://www.blacknut.com) endpoints described on documentation version 1.12 from 18-02-2021.

This project uses [Flurl](https://flurl.dev/) as HTTP client to easily handle the requests.

## Configuration

Follow below instructions to easily configure the client using [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)

### 1st - Appsettings

On appsettings.json add the Blacknut credentials config as follow

    {
	    "Blacknut": {
		    // In appsettings.Development.json use https://staging-api.blacknut.net
		    "ApiUrl": "https://api.blacknut.com",
		    // X-Blk-Partner-Secret
		    "Secret": "",
		    "PartnerCredentials": {
			    "PartnerCode": "",
			    // The password
			    "PartnetSecret": ""
		    },
		    // Optionals
		    "AcceptLanguage": "en-US",
		    "XBlkUserAgent": "Blacknut/5.0.0 <PartnerCode>/1.0.0"
	    }
    }

### 2nd - API Startup

On Startup add to the ConfigureServices this tow code lines as follow

    public void ConfigureServices(IServiceCollection services)
    {
		services.Configure<BlacknutCredentials>(Configuration.GetSection(BlacknutCredentials.configSection));
		services.BlacknutApiClientRegisterServices();
	}


## Available services

 - [User](src/BlacknutApiClient/Interfaces/Services/IUserService.cs)
 - [Subscription](src/BlacknutApiClient/Interfaces/Services/ISubscriptionService.cs)
 - [Stream](src/BlacknutApiClient/Interfaces/Services/IStreamService.cs)
 - [Game](src/BlacknutApiClient/Interfaces/Services/IGameService.cs)

## Test Authentication

[Blacknut API.postman_collection.json](docs/Blacknut%20API.postman_collection.json)

## For test

Use this branch only for testing configuration, see Swagger documentation (Maped all client services methods) and see services usage example.

[Test Branch](https://github.com/renancr176/BlacknutApiClient/tree/ToTestOnly)

Documentation via Postman collection

[Blacknut API Client.postman_collection.json](https://github.com/renancr176/BlacknutApiClient/blob/ToTestOnly/docs/Blacknut%20API%20Client.postman_collection.json)