using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Constants
{
    public static class ModelValidationConstants
    {
        public static class UserConstants
        {
            public const int UserNameMaxLength = 50;
            public const int UserNameMinLength = 2;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 5;

            public const int CityMaxLength = 169;
            public const int CityMinLength = 1;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 4;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 10;

        }
        public static class CategoryConstants 
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 2;
        }

        public static class DishConstants
        {
            public const int DishNameMaxLength = 70;
            public const int DishNameMinLength = 2;

            public const int DishDescriptionMaxLength = 250;
            public const int DishDescriptionMinLength = 10;

            public const int DishIngredientsMaxLength = 200;
            public const int DishIngredientsMinLength = 3;


        }

        public static class OrdersConstants
        {
            public const int OrderDeliveryAddressMaxLength = 100;
            public const int OrdersDeliveryAddressMinLength = 5;
        }

    }
}
