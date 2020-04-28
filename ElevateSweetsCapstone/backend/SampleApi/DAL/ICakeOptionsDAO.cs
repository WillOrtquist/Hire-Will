using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for cake options.
    /// </summary>
    public interface ICakeOptionsDAO
    {

        /// <summary>
        /// adds a style to our database so that is available for customers in the drop down menu
        /// </summary>
        /// <returns></returns>
        bool AddStyleOption(Styles newStyle);
        
        ///<Summary>
        /// Returns a list of cake styles stored in our SQL database
        ///</Summary>
        List<Styles> GetAllCakeStyles();

        List<Sizes> GetAllCakeSizesFiltered(int styId);

        /// <summary>
        /// adds a size to our database so that is available for customers in the drop down menu
        /// </summary>
        /// <returns></returns>
        bool AddSizeOption(Sizes newSize);
        bool UpdateStyleAvailability(Styles updatedStyle);
        bool UpdateSizeAvailability(Sizes updatedSize);
        bool SizeRemove(Styles sizeRemove);

        bool SizeAdd(Styles sizeAdd);

        bool UpdateFrostingAvailability(Frostings updatedFrosting);
        bool UpdateFlavorAvailability(Flavors updatedFlavor);
        bool UpdateFillingAvailability(Fillings updatedFilling);


        ///<Summary>
        /// Returns a list of cake sizes stored in our SQL database
        ///</Summary>
        List<Sizes> GetAllCakeSizes();

        /// <summary>
        /// adds a frosting to our database so that is available for customers in the drop down menu
        /// </summary>
        /// <returns></returns>
        bool AddFrostingOption(Frostings newFrosting);

        /// <summary>
        /// adds a filling to our database so that is available for customers in the drop down menu
        /// </summary>
        /// <returns></returns>
        bool AddFillingOption(Fillings newfilling);

        /// <summary>
        /// adds a flavor to our database so that is available for customers in the drop down menu
        /// </summary>
        /// <returns></returns>
        bool AddFlavorOption(Flavors newFlavor);

        ///<Summary>
        /// Returns a list of cake frostings stored in our SQL database
        ///</Summary>
        List<Frostings> GetAllCakeFrostings();

        ///<Summary>
        /// Returns a list of cake flavors stored in our SQL database
        ///</Summary>
        List<Flavors> GetAllCakeFlavors();

        ///<Summary>
        /// Returns a list of cake fillings stored in our SQL database
        ///</Summary>
        List<Fillings> GetAllCakeFillings();


    }
}
