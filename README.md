# HomeDrive
An easy-to-use, self-hosted cloud space solution.

## Important
This project is *almost* finished, which means there are still sth need to make.  
Also, the user login password is **WEAK PASSWORD**, you can change the code if you care about security.  
(I'll fix it later.)

Although the configure app provides api server,  
I still suggest you lauch the api program directly for debug information.  
For users who use release package, you can check "ApiServer" folder.

## Frameworks
* Database - Microsoft SQL Server 2025 Developer Edition
* Configure Application - Electron
* API - ASP.NET Web API (.NET 8)
* Desktop Application - Windows Form Apps (.NET 8)
* Mobile Application - Planning

## Setup Guide
To get started, please follow the steps below:  
1. Install MSSQL with default installation.
2. Remeber to setup your SQL System Admin account & password.
3. Open SQL Server Configuration Manager and enable TPC/IP in SQL Server Network Configuration.
4. Set port to 1433 in TCP/IP Properties.
5. Open configure app.
6. Create database in configure app.
7. Setup connection string in HomeDriveConfigure/api_prgram/ConnProp.hddata.
8. Create user account in configure app.
9. Run API program (run directly instead of running it from configure app is recommanded).
10. Run main app. (Done)

For those who don't know, MSSQL & configure app can run on Linux.

## Desktop Application
Only support Windows now. I planned to make it cross-platform in the future.

## Mobile Application
Planned.

&copy; 2026 Lonely Acheng. All rights. Reserved.