using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Common
{
    public static class ValidationConstants
    {
        //Boardgame
        public const int BoardgameNameMinLength = 10;
        public const int BoardgameNameMaxLength = 20;
        public const double BoardgameRatingMinLength = 1.00;
        public const double BoardgameRatingMaxLength = 10.00;
        public const int BoardgameYearPublishedMinLength = 2018;
        public const int BoardgameYearPublishedMaxLength = 2023;
        public const int BoardgameCategoryTypeMaxLength = 4;
        public const int BoardgameCategoryTypeMinLength = 0;

        //Seller
        public const int SellerNameMinLength = 5;
        public const int SellerNameMaxLength = 20;
        public const int SellerAddressMinLength = 2;
        public const int SellerAddressMaxLength = 30;
        public const string SellerWebsiteRegex = @"www.[a-zA-Z0-9-]+.com";

        //Creator
        public const int CreatorNameMinLength = 2;
        public const int CreatorNameMaxLength = 7;
    }
}
