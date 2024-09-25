
# Student Information CRUD application

## Project Overview
This project demonstrates how to implement CRUD (Create, Read, Update, Delete) operations using C# and SQL Server within a Windows Forms Application. It provides a user-friendly interface for managing student records.

## Table of Contents

## Technologies Used
- **C#**: Core programming language
- **.NET Framework/Core**: Application framework
- **Entity Framework**: ORM for database access
- **SQL Server** or **SQLite**: Database (choose one based on my project)
- **Visual Studio**: IDE for development

  ### Prerequisites

- Visual Studio 2022 or later
- SQL Server (Express or any version)
- SQL Server Management Studio (SSMS)


  ## Features

- **Add New Students**: Users can input student details such as `ID`, `Name`, and `Salary`. When the "Insert" button is clicked, the new student is added to the list and the database.
  
- **View/Search Student Information**: The application displays all student records in a grid format, showing the student's ID, name, and Salary.

- **Update Student Information**: Users can select an existing student from the grid and update their details using the "Update" button. This will modify the selected student's information in the database.

- **Delete Student Records**: Select a student from the grid and click the "Delete" button to remove their record from the system. A confirmation can be implemented to avoid accidental deletions.

- **Search Students**: Users can search for a student by `ID`, `Name`, or `Salary` using the "Search" button, and the grid will update to show only the relevant records.

-  **Schema Diagram:**

![Screenshot (64)](https://github.com/user-attachments/assets/17ec10c0-f668-48f1-974c-9b9ad4185d88)


  

## Set Up SQL Server Database:
Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.

**Create the Database**:

- Open the `.sql` file located in folder.
    - Copy the queries from the `.sql` file and execute them in your new database to set up the schema and initial data.
    - Use `Ctrl+F` to search for `connectionString` within the project files.
        ```csharp
       SqlConnection con = new SqlConnection("Data Source=AKHIRUL/SQLEXPRESS;Initial Catalog=CRUD_OPERATION;Integrated Security=True");;
    - Update this to:
        ```csharp
        private readonly string connectionString = "Server=<YOUR DATABASE SERVER/SOURCE>;Database=<DATABASENAME>;Trusted_Connection=True;";
        
**Create a Table for Student Information:**

CREATE TABLE Students (

    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Salary INT NOT NULL
);
GO

This table will store Id, Name, and Salary.

**Create a C# Windows Forms Application:**

- Open Visual Studio.

**Create a New Project:**
- Select C# > Windows Forms App (.NET Framework).
- Choose a project name and location.

**Design Your Form:**
- Add text boxes for Id, Name, and Salary.
- Add buttons for Insert, Update, Delete, and Search.
- Add a DataGridView to display student records.

**Add SQL Server Connection:**
To connect your application to the SQL Server database, you need to configure a connection string.

**Install SQL Server NuGet Package (optional if not already available):**

- In Solution Explorer, right-click on the project and select Manage NuGet Packages.
- Search for System.Data.SqlClient and install it.

**Set up the Connection String in your C# code:**
In your code-behind file (e.g., Form1.cs), define the connection string:

- string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=StudentDB;Integrated Security=True;";
- Replace (YOUR_SERVER_NAME) with the actual name of your SQL Server (you can find this in SSMS).

### C# Code Implementation
#### insert data function sample
```csharp 
private void button1_Click(object sender, EventArgs e)
{
    SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
    con.Open();
    SqlCommand cmd = new SqlCommand("insert into empt values (@id,@name,@salary)", con);
    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
    cmd.Parameters.AddWithValue("@name", textBox2.Text);
    cmd.Parameters.AddWithValue("@salary", double.Parse(textBox3.Text));
    cmd.ExecuteNonQuery();
    con.Close();

    MessageBox.Show("Successfully Added");
}
```
#### Update data function sample
```csharp 
private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update empt set id=@id,name=@name,salary=@salary where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@salary", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated");
        }
```
**Delete Operation**
```csharp 
private void button3_Click(object sender, EventArgs e)
{
    SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
    con.Open();
    SqlCommand cmd = new SqlCommand("delete empt where id=@id",con);
    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

    cmd.ExecuteNonQuery();
    con.Close();

    MessageBox.Show("Successfully Deleted");
}
```
**Search Operation**
```csharp 
private void button4_Click(object sender, EventArgs e)
 {
     SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
     con.Open();
     SqlCommand cmd = new SqlCommand("select * from empt where id=@id", con);
     cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
     SqlDataAdapter da = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
    da.Fill(dt);

     dataGridView1.DataSource= dt;

    cmd.ExecuteNonQuery();
    con.Close();

    MessageBox.Show("Successfully Found");
}
```
**Load Data into DataGridView**
Call this method in the form's Load event to display the data when the application starts.
```csharp 
private void Form1_Load(object sender, EventArgs e)
{
    LoadStudents();
}
```
## Screenshots
Below is a screenshot of the application interface showing the CRUD operation functionality:
![Screenshot (59)](https://github.com/user-attachments/assets/a2111363-d861-4ed8-b335-279deead5e35)


### Event Handling
- Implement event handlers for each button (e.g., `Create`, `Edit`, `Delete`).
- When a button is clicked, the corresponding CRUD operation will be executed (e.g., creating a new record or deleting an existing one).

## User Flow
1. When the application is opened, existing records are displayed in the `DataGridView`.
2. Users can:
   - **Insert**: new records by clicking the "Insert" button and submitting the form.
   - **Delete**: records by selecting a row and confirming deletion.
   - **Update**: user can update any data from data grid view.

## Challenges and Considerations
- **Error Handling**: Implement error handling for database connection failures or invalid inputs.

## **Build and Run the Application**:
    Open the project in Visual Studio, build it, and run the application.

## How to Run the Project
1. **Clone the Repository**: Clone this repository to your local machine.
   ```bash
   git clone https://github.com/akhirulislam/CRUD-Application
   ```
2. **Set Up the Database**: Configure your SQL Server or SQLite database and update the connection according to the `script.sql` file.
3. **Build the Project**: Open the project in Visual Studio and build the solution.
4. **Run the Application**: Once built, run the application and manage records through the Windows Forms interface.
