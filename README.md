📊 Database Relationship Diagram – AdventureWorks
This project visualizes the relationships between tables in the AdventureWorks database using Microsoft Automatic Graph Layout (MSAGL).

🧩 Features
Connects to SQL Server and fetches schema metadata.

Automatically builds a visual graph of table relationships.

Uses MSAGL to layout and render the graph.

Saves the result as an image (.png) for easy sharing.

🛠️ Technologies
Language: C# (.NET)

Graphing: MSAGL

Data Source: AdventureWorks SQL Server database

▶️ How to Run
Clone the repository:

bash
Copy
Edit
git clone https://github.com/your-username/adventureworks-graph.git
Open the project in Visual Studio.

Make sure you have MSAGL installed (via NuGet).

Update the connection string in Program.cs or App.config with your local SQL Server credentials.

Run the project.
An image file (graph.png) will be generated in the output directory.

📷 Output
Example graph output:

(or you can paste your actual image here or link it)

📎 Notes
The tool uses foreign key constraints to determine relationships.

Suitable for analyzing and documenting existing databases.

🤝 License
This project is for demonstration and assessment purposes.

