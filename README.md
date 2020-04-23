# DemoApi
demo in Asp.netcore 3.0 and Angular 8
First run this command for create the DataBase: create database DemoDB 
after creating DataBase execute PreDeployment.sql from DB folder. 
after completion of pre script then execute PostDeployment.sql 
open api solution in visualstudio 2019 make sure asp.net core 3.0 is installed 
change Data Source name in appsetting.json file "DBConnection": "Data Source=4895PV2\SQLEXPRESS;Initial Catalog=DemoDB;Integrated Security=True" 
First build and run the api solution pressing F5 button. 
Make sure angular 8 is installed on PC. 
download the ui project and open in visual studio code and run below command on terminal 
npm i 
after run above command run below command 
npm start 
copy and paste below url on browser http://localhost:4200/ your application will start.
