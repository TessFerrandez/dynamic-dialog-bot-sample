# Dynamic Dialog Bot Sample

Imagine a bot with hundreds of different responses, where each response is localized in different languages. Each response with multiple different possible answers (actions)...

Because of the number of dialogs and prompts this generates, hard-coding this isn't a viable option. Also, maintaining something like this would be difficult and time-consuming.

With that in mind, the best decision is to make the bot completely data driven. Store the responses and actions in a data storage, while allowing any editing to potentially be done through a management interface.

This sample covers building a dynamic bot, completely dependant on a seperate data storage.

> This project demonstrates the ability to provide a solution to customers, wherever they are. Not only does it have a great reach with Bot Framework, but it's also developed in a maintainable fashion with a common code base. It leverages technologies and development stacks which the customer can take care of - ensuring the future of the project.

## Project ###
Project | Author(s)
---------|----------
DynamicDialogApi, DynamicDialogBot | [Anders Thun](https://twitter.com/AndersThun), [Dag König](https://twitter.com/buzzfrog), [Peter Bryntesson](https://twitter.com/petbry57), [Simon Jäger](https://twitter.com/simonjaegr), [Tess Ferrandez](https://twitter.com/TessFerrandez)

### Version history ###
Version  | Date | Comments
---------| -----| --------
1.0  | March 22, 2017 | Initial release


### Disclaimer ###
**THIS CODE IN THIS REPOSITORY IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**

---

<a name="prerequisites"></a>
## Prerequisites ##

This sample requires the following:  

  * [Visual Studio 2017](https://www.visualstudio.com/downloads) 
  * [Bot Framework SDK](https://docs.botframework.com/en-us/downloads/)
  * [ASP.NET Core](https://www.asp.net/core)
  * [Azure Subscription](https://azure.microsoft.com/en-us/free/)
  
<a name="getting-started"></a>
## Getting started ##

To get started, clone this repository (```git clone https://github.com/simonjaeger/dynamic-dialog-bot-sample```) and follow the steps.

<a name="create-database"></a>
### Create the Azure SQL Database ###

1. Go to the [Azure Portal](http://portal.azure.com/) and sign into your subscription. 

1. Click on **New** to create a new resource.
    
    ![Create a new resource in Azure Portal](/Images/newresource.png)

1. Search for "SQL Database" and pick **SQL Database** by Microsoft. 

    ![Search for SQL Database](/Images/newazuresqldb.png)
    
1. Click **Create**. 

1. Finalize the configuration for the Azure SQL Database.
    1. Enter a database name. 
    1. Pick the subscription.
    1. Select a blank database.
    1. Configure the server settings, remember the user name and password.
    1. Pick a pricing tier.
    
1. Click **Create**.

    ![Create a new Azure SQL Database](/Images/createazuresqldb.png)
    
<a name="configure-web-api"></a>
### Configure the Web API ###

1. Launch the Web API project, **\DynamicDialogApi\DynamicDialogApi.sln** Visual Studio 2017.

1. Click on **View** in the top menu.

1. Click on **SQL Server Object Explorer**.

    ![Open the SQL Server Object Explorer](/Images/sqlserverexplorer.png)

1. Click on **Add SQL Server**.

1. Expand **Azure**.

1. Select the same account and subscription you signed into the Azure Portal with.

1. Select the Azure SQL Database that you created.

1. Enter the user name and password that you configured earlier.

1. Click on **Connect**.

    ![Connect to the the Azure SQL Server](/Images/connecttodb.png)

1. Add your client IP to the firewall if needed. Click on **OK**.

    ![Connect to the the Azure SQL Server](/Images/addipfirewall.png)

1. Right click on the Azure SQL Database in the SQL Server Object Explorer. 

1. Click on **Properties**.

1. Copy the **Connection string**.

    ![Copy the connection string](/Images/connectionstring.png)

1. Open **appsettings.json** in the DynamicDialogApi project.

1. Replace "YOUR CONNECTION STRING" with your connection string.

1. Locate the **Password=\*\*\*\*\*\*\*\*** part of the connection string. Replace the asterisks with the password that you configured earlier for your Azure SQL Database.

    ![Edit the connection string](/Images/connectionstringpassword.png)

1. Click on **Tools** in the top menu.
1. Expand **NuGet Package Manager** and click on **Package Manager Console**.

    ![Edit the connection string](/Images/packagemanagerconsole.png)
    
1. Run the following commands. This will prepare the Azure SQL Database with required schemas.
    1. Add-Migration "Initial"
    1. Update-Database
    
1. Right click on the Azure SQL Database in the SQL Server Object Explorer. 

1. Click on **New Query...**

1. Select your Azure SQL Database in the query window. 

1. Copy the contents of the script file, **\Scripts\db-script.sql** and paste it in the query window.

1. Click on **Execute**.

    ![Edit the connection string](/Images/sqlquery.png)
    
1. Right click on the Web API project, **DynamicDialogApi** in the Solution Explorer.

1. Click on **Properties**.

    ![Edit the connection string](/Images/projectproperties.png)

1. Click on **Debug**.

1. Copy the **App URL** (default http://localhost:8087/). This is the URL which the Web API will run at.

1. Click on the **Start Debugging** button to start the Web API.

    ![Edit the connection string](/Images/startdebuggingapi.png)

<a name="configure-bot"></a>
### Configure the Bot ###

1. Launch the bot project, **\DynamicDialogBot\DynamicDialogBot.sln** Visual Studio 2017.

1. Expand the **Services** folder.

1. Open the **ResponseService.cs** file.

1. Replace "&lt;YOUR API ENDPOINT&gt;" with the **App URL** of your Web API.

1. Open **Web.config**.

1. Replace "YOUR APP ID" and "YOUR APP PASSWORD" with your own configuration (see (https://docs.botframework.com/en-us/bot-framework-guide-id/)[https://docs.botframework.com/en-us/bot-framework-guide-id/]) or empty. Leaving the properties blank works for debugging and testing the sample.

    ```xml
    <appSettings>
        <!-- update these with your BotId, Microsoft App Id and your Microsoft App Password-->
        <add key="BotId" value="YourBotId" />
        <add key="MicrosoftAppId" value="" />
        <add key="MicrosoftAppPassword" value="" />
    </appSettings>
    ```   
    
    
1. Right click on the bot project, **DynamicDialogBot** in the Solution Explorer.

1. Click on **Properties**.

    ![Edit the connection string](/Images/projectpropertiesbot.png)

1. Click on **Web**.

1. Copy the **Project Url** (default http://localhost:3978/). This is the URL which the bot will run at.
    
1. Click on the **Start Debugging** button to start the bot.

    ![Edit the connection string](/Images/startdebuggingbot.png)

<a name="run-emulator"></a>
### Run the Bot Emulator ###

1. Launch the Bot Framework Channel Emulator.

1. Enter the **Project Url** and "/api/messages in the "Enter your endpoint URL" section. In example: http://localhost:3978/api/messages

1. Click on **Connect**. 

    ![Edit the connection string](/Images/emulatorconnect.png)
    
1. You can now try out the bot!

    ![Edit the connection string](/Images/emulatorconnected.png)


<a name="contributing"></a>
## Contributing ##

If you'd like to contribute to this sample, see [CONTRIBUTING.MD](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<a name="additional-resources"></a>
## Additional resources ##

- [Bot Framework](https://dev.botframework.com/)

- [AlarmBot Sample](https://github.com/Microsoft/BotBuilder/tree/master/CSharp/Samples/AlarmBot)

- [Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/?b=16.50)

## Copyright
Copyright (c) 2017 Microsoft. All rights reserved.