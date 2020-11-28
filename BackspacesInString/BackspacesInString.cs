using FluentAssertions;
using System;
using Xunit;
using System.Linq;
using System.Diagnostics;

namespace SixthKyu
{
    public class Kata
    {
        public static string CleanString(string s)
        {
            // Performance: 
            var characters = s.ToCharArray().ToList();

            while(characters.Contains('#'))
            {
                if (characters.First() == '#')
                {
                    characters.RemoveAt(characters.IndexOf('#'));
                    continue;
                }

                characters.RemoveAt(characters.IndexOf('#') - 1);
                characters.RemoveAt(characters.IndexOf('#'));
            }

            return new string(characters.ToArray());
        }
    }

    public class KataTests
    {
        [Fact]
        public void CleanString_CalledWithHashtags_Removes()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("abc#d##c");

            // Assert
            result.Should().Be("ac");
        }

        [Fact]

        public void CleanString_CalledWithHashtags_Removes1()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("abc##d######");

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void CleanString_CalledWithHashtags_Removes2()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("#######");

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void CleanString_CalledWithHashtags_Removes3()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("");

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void CleanString_CalledWithHashtags_Removes4()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("#");

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void CleanString_CalledWithHashtags_Removes5()
        {
            // Arrange
            // Act
            var result = Kata.CleanString("#abc#");

            // Assert
            result.Should().Be("ab");
        }


        [Fact]
        public void CleanString_CalledWithHashtags_Performance()
        {
            // Arrange
            var stopWatch = new Stopwatch();
            var random = new Random();
            const string validCharacters = "abcdefghijklmnopqrstuvwxyz#";

            var nastehString =  new string(Enumerable.Repeat(validCharacters, 100).Select(s => s[random.Next(s.Length)]).ToArray());

            // Act
            stopWatch.Start();
            var result = Kata.CleanString(nastehString);
            stopWatch.Stop();

            // Assert
            var timeTaken = stopWatch.ElapsedMilliseconds;

            timeTaken.Should().BeLessThan(1000);
        }

    }
}
