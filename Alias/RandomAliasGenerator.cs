using System;
using System.Text;

namespace BlazorApp.Alias {
    public class RandomAliasGenerator : IAliasGenerator {

        public string GenerateAlias() {
            var sb = new StringBuilder();
            var rando = new Random();
            for (int i = 0; i < Constants.AliasLength; i++) {
                sb.Append(Constants.ValidCharArray[rando.Next(Constants.ValidCharArrayMaxPosition)]);
            }

            return sb.ToString();
        }
    }
}