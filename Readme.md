# Framework.Utilities.Service 

## Introduction
The purpose of Framework.Utilities.Service is for calling external web services.


## How to install

To install [Framework.Utilities.Service](https://www.nuget.org/packages/Framework.Utilities.Services/), run the following command in the Package Manager Console .

Install-Package Framework.Utilities.Service 
 

## How to use
There are two main methods. 

### GetAuthenticateToken


1. Define your own AuthenticationToken model.
2. Call GetAuthenticateToken method by passing RequestMethod, ContentType, requestUri as well as requestBody if it is required. 

Example code:
 var token = MakeRequestsService.GetAuthenticateToken<AuthenticationToken>(RequestMethod.Post, RequestConstants.ContentType.Text, requestUri, requestBody);

### Get

1. Define your own response model i.e. Underwriting.
2. Call Get method by passing ContentType, requestUri as well as access token.

Example code:
var response  = MakeRequestsService.Get<List<Underwriting>>(RequestConstants.ContentType.Text, requestUri, token.AccessToken);