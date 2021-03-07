using System.Linq;
using System.Text.RegularExpressions;

namespace BlazorApp
{
    public static class Constants
    {
        //ConnectionString Constants
        public const string ConfigurationConnectionStringKey = "SqlServerConnectionString";
        
        //Sql Constants
        public const string UrlParamName = "@Url";
        public const string AliasParamName = "@Alias";
        public const int UrlParamSize = 2000;
        public const int AliasParamSize = 15;
        public const string GeneratedAliasParamName = "@GeneratedAlias";
        public const string GetAliasProcedure = "GetAlias";
        public const string GetUrlProcedure = "GetUrl";
        public const string AliasAlreadyUsed = "Alias Already Used";
        public const string AliasNotFound = "Record Not Found";
        
        //AliasGenerator Constants
        public static readonly char[] ValidCharArray = new[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public static readonly int ValidCharArrayMaxPosition = ValidCharArray.Length - 1;
        public const int AliasLength = 15;
        
        //Validation Constants
        public const string ValidUrlRegex =
            "^(http:\\/\\/www\\.|https:\\/\\/www\\.|http:\\/\\/|https:\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$";
        
        // Warnings
        public const string ValidUrlWarning = "Please enter a valid url";
        public const string UnexpectedErrorWarning = "Something went wrong, please try again";
    }
}