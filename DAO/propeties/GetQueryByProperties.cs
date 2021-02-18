using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RESTful_Services.BusinessLayer.Entities.Enums;
using StackifyHttpTracer;

namespace RESTful_Services.DAO.propeties
{
    public class GetQueryByProperties
    //FirstName LastName UserEmail UserTypeId CreatedDate StatusCode
    {
        private IniParser parser = new IniParser(@"G:\Training\2_16_2021\RESTful_Services\DAO\propeties\sql.ini");
        public string GetDetailQuery(string proprtyName, UserStatus userStatus,string sortbyParameter,string sortbyDirection)
        {
            Debug.WriteLine("andar aave chhe");
            string query;
            switch (userStatus)
            {
                case UserStatus.All:
                    Debug.WriteLine("user status ma aay gayu");
                    switch (sortbyParameter)
                    {
                        case "firstname":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY {sortby}";
                                    // method create => string
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY firstname desc";
                                    return query;
                                default:
                                    return null;
                            }
                        case "lastname":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname desc";
                                    return query;
                                default:
                                    return null;
                            }
                        case "createdDate":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate desc";
                                    return query;
                                    break;
                                default:
                                    return null;
                            }
                            break;
                    }
                    return "not";
                case UserStatus.Deleted:
                    switch (sortbyParameter)
                    {
                        case "firstname":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY firstname asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY firstname desc";
                                    return query;
                                default:
                                    return null;
                            }
                            break;
                        case "lastname":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname desc";
                                    return query;
                                default:
                                    return null;
                            }
                            break;
                        case "createdDate":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 1 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate desc";
                                    return query;
                                    break;
                                default:
                                    return null;
                            }
                            break;
                    }
                    return "not";
                case UserStatus.Active:
                    Debug.WriteLine("Active ma aayo");
                    switch (sortbyParameter)
                    {
                        case "firstname":
                            Debug.WriteLine("case ma aay gayo");
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    Debug.WriteLine("return query");
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY firstname asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY firstname desc";
                                    return query;
                                default:
                                    return null;
                            }
                            break;
                        case "lastname":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY lastname desc";
                                    return query;
                                default:
                                    return null;
                            }
                            break;
                        case "createdDate":
                            switch (sortbyDirection)
                            {
                                case "asc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate asc";
                                    return query;
                                case "desc":
                                    query =
                                        "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails " +
                                        "INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId " +
                                        "WHERE UserDetails.IsDeleted = 0 AND UserTypeStatus.StatusCode = @UserType " +
                                        "AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) " +
                                        "ORDER BY createdDate desc";
                                    return query;
                                    break;
                                default:
                                    return null;
                            }
                            break;
                    }
                    return "not";
                default:
                    return null;
            }
        }
    }
}
