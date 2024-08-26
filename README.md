<h1>Coding Tracker Project</h1>
<h3>Description</h3>
<p>Simple project made to track length of coding sessions using an sqlite database via a C# console application, similar to the habit tracker with a few additional challenges</p>
<h3>Assigned requirements</h3>
<ul>
  <li>This application has the same requirements as the previous project, except that now you'll be logging your daily coding time.</li>
  <li>To show the data on the console, you should use the "Spectre.Console" library.</li>
  <li>You're required to have separate classes in different files</li>
  <li>You should tell the user the specific format you want the date and time to be logged and not allow any other format.</li>
  <li>You'll need to create a configuration file that you'll contain your database path and connection strings.</li>
  <li>You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration</li>
  <li>The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.</li>
  <li>The user should be able to input the start and end times manually.</li>
  <li>You need to use Dapper ORM for the data access instead of ADO.NET.</li>
  <li>When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.</li>
</ul>
<h3>Additional Completed Challenges</h3>
<ul>
  <li>Add the possibility of tracking the coding time via a stopwatch so the user can track the session as it happens.</li>
  <li>Let the users filter their coding records per period</li>
</ul>
