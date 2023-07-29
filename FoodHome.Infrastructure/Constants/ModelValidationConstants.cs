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

            public const int PasswordMinLength = 3;
            public const int PasswordMaxLength = 16;

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

        public static class RestaurantConstants
        {
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;
        }

        public static class PaymentConstants
        {
            public const int CardNumberMinLength = 17;
            public const int CardNumberMaxLength = 25;

            public const int SecurityCodeMinLength = 3;
            public const int SecurityCodeMaxLength = 8;

            public const int ZipCodeMinLength = 4;
            public const int ZipCodeMaxLength = 10;

            public const int CardHolderMaxLength = 20;
            public const int CardHolderMinLength = 4;
        }
    }
}
