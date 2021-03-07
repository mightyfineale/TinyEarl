using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BlazorApp.Alias;
using NUnit.Framework;

namespace BlazorApp.UnitTests {
    
    [TestFixture]
    public class RandomAliasGeneratorTests {
        
        private RandomAliasGenerator generator;

        [SetUp]
        public void Setup() {
            generator = new RandomAliasGenerator();
        }
        
        [Test]
        public void GenerateAlias_Should_GenerateValidAlias() {
            var alias = generator.GenerateAlias();
            
            Assert.True(!string.IsNullOrWhiteSpace(alias));
            Assert.True(alias.Length == Constants.AliasLength);
            Assert.True(Regex.IsMatch(alias,CreateValidCharRegex()));
        }
        
        [Test]
        [Ignore("Ran only for initial verification strings were different, though can be deemed as flaky but chances are minuscule for match")]
        public void GenerateAlias_x10000_Should_GenerateValidDifferentAlias() {
            var aliases = new List<string>();
            for (int i = 0; i <= 10000; i++) {
                var alias = generator.GenerateAlias();
                
                Assert.True(!string.IsNullOrWhiteSpace(alias));
                Assert.True(alias.Length == Constants.AliasLength);
                Assert.True(Regex.IsMatch(alias,CreateValidCharRegex()));
                Assert.True(!aliases.Contains(alias));
                aliases.Add(alias);
                Console.WriteLine(i);
            }
            
        }
        
        [Test]
        public void GenerateAlias_AdditionOfValidCharacter_Should_NotMatchRegex() {
            var alias = generator.GenerateAlias();
            alias = alias + Constants.ValidCharArray[Constants.ValidCharArrayMaxPosition];
            
            Assert.True(!string.IsNullOrWhiteSpace(alias));
            Assert.False(Regex.IsMatch(alias,CreateValidCharRegex()));
        }
        

        //In theory this should work regardless of what the valid char array is.
        private static string CreateValidCharRegex() {
            var sb = new StringBuilder();
            sb.Append("\\b[");
            for (var i = 0; i < Constants.ValidCharArrayMaxPosition; i++) {
                sb.Append($"{Constants.ValidCharArray[i]}|");
            }

            sb.Append($"{Constants.ValidCharArray[Constants.ValidCharArrayMaxPosition]}]{{{Constants.AliasLength}}}\\b");
            return sb.ToString();
        }
    }
}