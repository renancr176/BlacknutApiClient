# About

Development in progress.

Unofficial client for DotNet,  [Blacknut API](http://www.blacknut.com)

This project uses [Flurl](https://flurl.dev/) as HTTP client to easily headle the requests see [Flurl Docs](https://flurl.dev/docs/fluent-url/).

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
