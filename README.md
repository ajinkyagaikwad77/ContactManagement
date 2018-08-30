# ContactManagement
Created By: Ajinkya Gaikwad

1. I have provided Database Script to create database, don't forget to execute the Database scripts.
	
2. Change in Web.Config under DependencyInjection Project.
	<connectionStrings>
		<add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=PTPL-HPLP-13\MSSQLSERVER11;Database=ContactDB;UID=sa;Password=Ajinkya@1234" />
	</connectionStrings>
	Don't forget to change the DataSource, DatabaseName, UID and Password
	
3. Folder Structure
	DependencyInjection
		DAL (class library)
		DependencyInjection (MVC Web Application)
		packages
		Services (class library)
		DependencyInjection.sln
		
4. Project Tools:
	Visual Studio 2017 (Project franmework used 4.5.2)
	Microsoft SQL Server 2012
	