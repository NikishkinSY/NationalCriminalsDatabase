Prerequisites:
- Visual Studio 2015 Update 3. 
- MS SQL server (express) 2008R2+.
- .Net Framework 4.6.1.
- SQL Server managment studio 2008R2+.
- IISExpress 10.

Before run solution:
1. In projects NCD_Web/NCD_WebService in web.configs you need to write correct sqlConnectionString.

After run solution (after entity framework code first completes):
1. With the help of managment studio run sql script NCD_Model/TestData.sql