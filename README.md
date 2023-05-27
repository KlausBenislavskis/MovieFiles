# MovieFiles

Welcome to the MovieFiles project. We've created an interactive movie database and user community, leveraging cutting-edge technologies including Blazor for the frontend and Azure Functions for the backend. The app is hosted on Azure and accessible at [moviefiles.klavs.dev](https://moviefiles.klavs.dev) for as long as the free hosting period allows.

## Technologies and Services

Our project utilizes a range of technologies and services:

- **Blazor Server**: This powers our frontend, offering a robust, feature-rich user interface.
- **Azure Functions**: We use this for serverless computation, providing the backend functions of our app.
- **Azure App Service**: Our Blazor Server application is hosted here, offering a scalable platform that handles infrastructure management.
- **Azure Database for PostgreSQL**: This fully-managed service is where we store our application data.
- **Azure Active Directory B2C Tenant**: We use this service for user authentication and management.
- **Azure Front Door and CDN profile**: These optimize network performance and provide security for our application.
- **Azure Storage account**: This is used to store large amounts of unstructured data.
- **Docker**: We use Docker to create containerized versions of our application.
- **GitHub Actions**: This tool automates our build and deployment process, creating a smooth CI/CD pipeline.

## Project Structure

Our project is split into several main parts:

1. **Frontend**: Developed with Blazor, this part of our application is responsible for user interaction.
2. **Backend**: This part of the application handles business logic and is developed using Azure Functions.
3. **Database**: We use Azure Database for PostgreSQL to store and manage our application data.
4. **Authentication**: User management and authentication capabilities are provided by Azure Active Directory B2C Tenant.
5. **Hosting and Deployment**: All parts of our application are hosted on Azure and deployment is managed through GitHub Actions.

The app is currently hosted for free on Azure, so it is accessible as long as the free hosting period hasn't ended. Please feel free to explore the codebase and reach out with any questions or suggestions.
