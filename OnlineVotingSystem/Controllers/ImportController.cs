using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(postedFile.FileName);

                    //Validate uploaded file and return error.
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ViewBag.Message = "Please select the excel file with .xls or .xlsx extension";
                        return View();
                    }

                    string folderPath = Server.MapPath("~/UploadedFiles/");
                    //Check Directory exists else create one
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save file to folder
                    var filePath = folderPath + Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    //Get file extension

                    string excelConString = "";

                    //Get connection string using extension 
                    switch (fileExtension)
                    {
                        //If uploaded file is Excel 1997-2007.
                        case ".xls":
                            excelConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        //If uploaded file is Excel 2007 and above
                        case ".xlsx":
                            excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }

                    //Read data from first sheet of excel into datatable
                    DataTable dt = new DataTable();
                    excelConString = string.Format(excelConString, filePath);

                    using (OleDbConnection excelOledbConnection = new OleDbConnection(excelConString))
                    {
                        using (OleDbCommand excelDbCommand = new OleDbCommand())
                        {
                            using (OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter())
                            {
                                excelDbCommand.Connection = excelOledbConnection;

                                excelOledbConnection.Open();
                                //Get schema from excel sheet
                                DataTable excelSchema = GetSchemaFromExcel(excelOledbConnection);
                                //Get sheet name
                                string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                                excelOledbConnection.Close();

                                //Read Data from First Sheet.
                                excelOledbConnection.Open();
                                excelDbCommand.CommandText = "SELECT * From [" + sheetName + "]";
                                excelDataAdapter.SelectCommand = excelDbCommand;
                                //Fill datatable from adapter
                                excelDataAdapter.Fill(dt);
                                excelOledbConnection.Close();
                            }
                        }
                    }

                    //Insert records to Employee table.
                    using (var db = new OnlineVotingSystemEntities())
                    {
                        //Loop through datatable and add employee data to employee table. 
                        foreach (DataRow row in dt.Rows)
                        {
                            db.Voters.Add(GetVoterFromExcelRow(row));
                        }
                        db.SaveChanges();
                    }
                    ViewBag.Message = "Voter Information Imported Successfully.";
                }
                //catch (Exception ex)
                //{
                //    ViewBag.Message = ex.Message;
                //}

                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
            return View();
        }

        private static DataTable GetSchemaFromExcel(OleDbConnection excelOledbConnection)
        {
            return excelOledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        }

        //Convert each datarow into employee object
        private Voter GetVoterFromExcelRow(DataRow row)
        {
            return new Voter
            {
                Name = row[0].ToString(),
                ServiceId = row[1].ToString(),
                MobileNo = row[2].ToString(),
                Email = row[3].ToString(),
                BloodGroup= row[4].ToString()
            };
        }
    }
}



        //[HttpPost]
        //public ActionResult Index(ImportExcelFile importExcelFile)
        //{
        //    OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();

        //    if (ModelState.IsValid)
        //    {
        //        string path = Server.MapPath("~/Content/UploadedFiles/" + importExcelFile.file.FileName);
        //        importExcelFile.file.SaveAs(path);

        //        string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
        //        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

        //        //Sheet Name
        //        excelConnection.Open();
        //        string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
        //        excelConnection.Close();
        //        //End

        //        OleDbCommand cmd = new OleDbCommand("Select * from [" + tableName + "]", excelConnection);

        //        excelConnection.Open();

        //        OleDbDataReader dReader;
        //        dReader = cmd.ExecuteReader();
        //        //SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["OnlineVotingSystemEntities"].ConnectionString);
        //        //SqlBulkCopy sqlBulk = new SqlBulkCopy(db.Database.Connection)

        //        var mustOpen = db.Database.Connection.State != ConnectionState.Open;
        //        try
        //        {
        //            if (mustOpen)
        //                db.Database.Connection.Open();
        //            var connection = db.Database.Connection as SqlConnection;
        //            using (var bulkCopy = new SqlBulkCopy(connection))
        //            {
        //                //Give your Destination table name
        //                bulkCopy.DestinationTableName = "Voter";

        //                //Mappings
        //                bulkCopy.ColumnMappings.Add("Name", "Name");
        //                bulkCopy.ColumnMappings.Add("ServiceId", "ServiceId]");
        //                bulkCopy.ColumnMappings.Add("MobileNo", "MobileNo");
        //                bulkCopy.ColumnMappings.Add("Email", "Email");
        //                bulkCopy.ColumnMappings.Add("BloodGroup", "BloodGroup");

        //                bulkCopy.WriteToServer(dReader);
        //                excelConnection.Close();

        //                ViewBag.Result = "Voter information successfully imported!";
        //            }
        //        }
        //        finally
        //        {
        //            if (mustOpen)
        //                db.Database.Connection.Close();
        //        }               
        //    }

        //    return View();
        //}        
   // }
//}
