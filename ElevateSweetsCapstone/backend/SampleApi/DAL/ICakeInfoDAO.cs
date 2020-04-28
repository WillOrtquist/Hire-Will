using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for cake objects.
    /// </summary>
    public interface ICakeInfoDAO
    {
        ///<Summary>
        /// Returns a list of every cake stored in our SQL database
        ///</Summary>
        List<Cake> GetAllCakes();

        /// <summary>
        /// Adds a cake into our SQL database
        /// </summary>
        bool AddCake(Cake cake);

        Cake GetCake(int id);

        bool UpdateCakeAvailability(Cake cake);

    }
}
