using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace InventoryManagementSystem
{
    public partial class DBIMSEntities : DbContext
    {
       //implementation of the database connection
        public DBIMSEntities()
            : base(new SQLiteConnection() //constructor of SQLite database connection
            {   //connection string that holds the relative path of the database, which means the database can be accessed easily
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Database\\DBIMS.db", ForeignKeys = true, BinaryGUID=false }.ConnectionString
            }, true)
        {
        }

        //auto-generated method when the entity framework model was created
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  throw new UnintentionalCodeFirstException();
        }

        /*DbSet is the collections of all entities that the model consists of;
          tbCategory, tbProduct, tbUser are the classes that implement every parameter of their respective tables;
          tbCategories, tbProducts, tbUsers are the database tables, thier names are pluralized in the code because of the pluralization convention*/
        public virtual DbSet<tbCategory> tbCategories { get; set; }
        public virtual DbSet<tbProduct> tbProducts { get; set; }
        public virtual DbSet<tbUser> tbUsers { get; set; }
    }

    [Table("tbCategory")] //table annotation for Category Table

    //class of the category table
    public partial class tbCategory
    {
        [Key] //annotating the primary key which is the category Id
        public Guid CatId { get; set; } //getters and setters for the CatId parameter (category Id)
        public string CatName { get; set; } //getters and setters for the CatName parameter (category name)
    }

    [Table("tbProduct")] //table annotation for Product Table

    //class of the category table
    public partial class tbProduct
    {
        [Key] //annotating the primary key which is the product Id
        public Guid pid { get; set; } //getters and setters for the pid parameter (product Id)
        public string pname { get; set; } //getters and setters for the pname parameter (product name)
        public long pqty { get; set; } //getters and setters for the pqty parameter (product quantity)
        public long pprice { get; set; } //getters and setters for the pprice parameter (product price)
        public string pdescription { get; set; } //getters and setters for the pdescription parameter (product description)
        public string pcategory { get; set; } //getters and setters for the pcategory parameter (product category)
    }

    [Table("tbUser")] //table annotation for Product Table

    //table annotation for User Table
    public partial class tbUser
    {
        [Key] //annotating the primary key which is the user Id
        public Guid Id { get; set; } //getters and setters for the Id parameter (user Id)
        public string Username { get; set; } //getters and setters for the Username parameter (user username)
        public string Fullname { get; set; } //getters and setters for the Fullname parameter (user fullname)
        public string Password { get; set; } //getters and setters for the password parameter (user password)
        public string Phone { get; set; } //getters and setters for the Phone parameter (user phone)
        public string Type { get; set; } //getters and setters for the Type parameter (user type)
    }
}