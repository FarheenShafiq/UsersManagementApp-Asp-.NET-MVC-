using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersManagementApp.Models; // Namespace for your model
using System.Configuration;
using System.Web.Helpers;

namespace UsersManagementApp.Controllers
{
    public class UsersManagementController : Controller
    {
        // ✅ Using connection string from Web.config
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // ✅ GET: Home Page
        public ActionResult Index()
        {
            return View();
        }

        // ✅ GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // ✅ POST: Register User
        [HttpPost]
        public ActionResult Register(UsersModel user)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Users (Name, Email, Password, DateOfBirth, Department, Designation, CreatedAt)
                                     VALUES (@Name, @Email, @Password, @DateOfBirth, @Department, @Designation, GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password); 
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Department", user.Department);
                    cmd.Parameters.AddWithValue("@Designation", user.Designation);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    ViewBag.Message = "User registered successfully!";
                    ModelState.Clear();
                }
            }
            return RedirectToAction("Records");
        }

        // ✅ GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // ✅ POST: Process login form
        [HttpPost]
        public ActionResult Login(UsersModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Message = "Email and password are required.";
                return View(model);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", model.Password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session["UserEmail"] = model.Email;
                    TempData["Success"] = "Login successful! Welcome, " + model.Name;

                    return RedirectToAction("Records");
                }
                else
                {
                    ViewBag.Message = "Invalid email or password!";
                    return View(model);
                }
            }
        }

        // ✅ GET: Records
        public ActionResult Records()
        {
            List<UsersModel> users = new List<UsersModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UsersModel user = new UsersModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Department = reader["Department"].ToString(),
                        Designation = reader["Designation"].ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["UpdatedAt"])
                    };
                    users.Add(user);
                }

                conn.Close();
            }

            return View(users);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            UsersModel user = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new UsersModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Department = reader["Department"].ToString(),
                        Designation = reader["Designation"].ToString()
                    };
                }
            }

            return View(user);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(UsersModel user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users SET 
                         Name = @Name, Email = @Email, Password = @Password, 
                         DateOfBirth = @DateOfBirth, Department = @Department, 
                         Designation = @Designation, UpdatedAt = GETDATE()
                         WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Department", user.Department);
                cmd.Parameters.AddWithValue("@Designation", user.Designation);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Records");
        }

        //delete 
        public ActionResult Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Records");
        }
    }
}
