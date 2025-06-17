# How to Run the Cycode Vulnerability Scanner

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A valid GitHub personal access token with access to the GitHub Advisory Database

## Configuration

Before running, configure your GitHub GraphQL API credentials in `appsettings.json` or `appsettings.Development.json`:


- **Endpoint**: Must be `https://api.github.com/graphql`
- **GithubAccessToken**: Replace with your GitHub personal access token

> **Assumption:**  
> The configuration section above must be present and valid. The token must have the necessary permissions to access the GitHub Advisory Database.

## Running the Application

1. Restore dependencies:
   
2. Build the project:

3. Run the service:
 

The service will start and listen on the ports defined in `launchSettings.json` (typically `https://localhost:5001` and `http://localhost:5000`).

## Testing

- Ensure your GitHub token is valid and not rate-limited.
- The service exposes API endpoints (see `ScanController.cs` for details).
- Use tools like Postman or `curl` to send requests to the API.

## Notes

- The HTTP client is configured with a `User-Agent` and the GitHub token for authentication.
- If you receive a 400 Bad Request from GitHub, check your query payload and token.
- All dependencies are registered via dependency injection.

**If you encounter issues, check the logs for error details.**
 
   