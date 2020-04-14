# VerkstedFinder

Project description for project in ITF11012 .NET
Name: Andreas Mikalsen
Student number: 173040
Project title: Workshop Finder
Requirements:
- To get the full potential of the application you need to sign in as an administrator. If you register
through the application you will register as a user, therefor there is not possible to register as an
administrator yourself.
Administrator details:
Username: admin
Password: password
- To use the application, you need to be connected to the HiOf internet directly or via VPN. The
application uses the Donau database and won’t work without the schools internet.
- The log files are created in installation folder for the application, the path should be:
o C:\Users\~Username~\AppData\Local\Packages\3B9DE111-3FDE-413B-A484-
FEC6D23D3500_sd040xvzwhp5g\LocalState\~Todays Date~_Logs.txt
It will create a new log file for every day, and append to that file
Not fully completed parts:
- The map part is part functional. I have not put in all of the markers for the workshops, but this is
due to limitations of the API I’m using. It’s the Geocode API from Google, but since there is so
many workshops I risk to need to upgrade to a payed plan. However, you should be fine to add
new workshops without exceeding the limit. It will return the correct position in 90% of the
time. If you don’t see your newly added location in the map, then you may need to restart it.
This would be a bug fix for further development.
Description:
The application is made to have a list of all certified workshops in Norway, in addition to the once the
users would create. In the map sections of the application, you will be able to see the location off all
workshops. In the list section you will get an entire list of all workshops. This will contain the name of
the workshop, the address, postal code and city.
If you register, you will be able to create new workshops but nothing else. If you sign in as an
administrator you will be able to do CRUD operations on all of the tables, however you will not be able
to edit the password for the users, this is because of security reasons. The tables you can do CRUD
operations on are workshops, users, roles and poststeds.
