# calendar
This program outlines a simple calendar program that has both one time and recurring events. These events are stored in two tables, one is Single_Events, and the other Recurrance_Events, respectively

The calendar has a cleanup routine set for one time events, that after the day the event is set to happen, on the next launch of the calendar, will delete the event. This keeps the database clean. Recurring events are deleted manually only

When setting a one time, calendar, the calendar sets the rundate for the next occurance of that day. Let's say today is Monday, the first of any month and you want to set a schedule for friday. Friday's schedule for one time events will run ONCE on Friday the fifth. If the program is launched on Saturday, the Friday one time event is deleted.

For a repeating event, simply check the box for Repeating event to add the event to repeating. It will assign for the selected day, and run every x day (ie repeating Tuesday at 2 pm to 4 will run every Tuesday between 2pm to 4 pm.)

To delete a function, simply right click your entry and delete

To edit a schedule, just double click it.

IT IS RECCOMENDED TO USE THIS CODE AS A STARTING POINT ONLY, DO NOT USE AS IS IN A PRODUCTION SETUP.




Things that could be improved/issues:

Could organize the code a bit more/ its a bit scattered around

Some repetitive lines that could be moved to methods

Add logic for checking for overlapping schedules (again this is a startoff boilerplate, not meant for real world)

More error checking logic. Please dont use it as is in prod without proper checks and balances. We have a using statment protecting against crashing during access. But this needs more error checking.
