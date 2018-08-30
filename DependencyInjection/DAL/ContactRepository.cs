using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ContactRepository : IContactRespository
    {
        // Create New Customer
        /// <summary>
        /// Creates a new Contact
        /// </summary>
        /// <param name="_Contact"></param>
        public void Add(Contact _Contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    var param = new DynamicParameters();
                    param.Add("@ContactId", _Contact.ContactId);
                    param.Add("@FirstName", _Contact.FirstName);
                    param.Add("@LastName", _Contact.LastName);
                    param.Add("@Email", _Contact.Email);
                    param.Add("@PhoneNumber", _Contact.PhoneNumber);
                    param.Add("@Status", _Contact.Status);
                    var result = con.Execute("sprocContactTBInsertUpdateSingleItem",
                          param,
                          sqltans,
                          0,
                          commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }

                }
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Updates the Contact details
        /// </summary>
        /// <param name="_Contact"></param>
        public void Update(Contact _Contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    var param = new DynamicParameters();
                    param.Add("@ContactId", _Contact.ContactId);
                    param.Add("@FirstName", _Contact.FirstName);
                    param.Add("@LastName", _Contact.LastName);
                    param.Add("@Email", _Contact.Email);
                    param.Add("@PhoneNumber", _Contact.PhoneNumber);
                    param.Add("@Status", _Contact.Status);
                    var result = con.Execute("sprocContactTBInsertUpdateSingleItem",
                        param,
                        sqltans,
                        0,
                        commandType: CommandType.StoredProcedure);


                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the Contact you want to delete.
        /// </summary>
        /// <param name="_Contact"></param>
        public void Delete(Contact _Contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    var param = new DynamicParameters();
                    param.Add("@ContactId", _Contact.ContactId);
                    var result = con.Execute("sprocContactTBDeleteSingleItem",
                        param,
                        sqltans,
                        0,
                        commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the Contact on the row.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    var param = new DynamicParameters();
                    param.Add("@ContactId", id);
                    return con.Query<Contact>("sprocContactTBsSelectSingleItem",
                        param,
                        null,
                        true,
                        0,
                        commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // Gets All Customer details
        /// <summary>
        /// Gets all the available contacts from the DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetAll()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    var param = new DynamicParameters();
                    return con.Query<Contact>("sprocContactTBSelectList",
                        null,
                        null,
                        true,
                        0,
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
