using FluentAssertions;
using System;
using Xunit;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace YourOrderPlease
{
    public class Kata
    {
        public static string Order(string words)
        {
            if (string.IsNullOrEmpty(words)) return "";

            StringBuilder stringBuilder = new StringBuilder();

            var currentOrder = new List<int>();

            var wordsList = words.Split(" ");
            foreach (var word in wordsList)
            {
                var wordChars = word.ToCharArray();
                foreach (var character in wordChars)
                {
                    if (Char.IsDigit(character)) currentOrder.Add((int)Char.GetNumericValue(character));
                }
            }

            for (int i = 1; i < currentOrder.Count + 1; i++)
            {
                stringBuilder.Append(wordsList[currentOrder.IndexOf(i)]);
                if (i != currentOrder.Count) stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }

    public class KataTests
    {
        [Fact]
        public void Order_SampleTest1_Passes()
        {
            // Arrange
            // Act
            var result = Kata.Order("is2 Thi1s T4est 3a");

            // Assert
            result.Should().Be("Thi1s is2 3a T4est");
        }

        [Fact]
        public void Order_SampleTest2_Passes()
        {
            // Arrange
            // Act
            var result = Kata.Order("4of Fo1r pe6ople g3ood th5e the2");

            // Assert
            result.Should().Be("Fo1r the2 g3ood 4of th5e pe6ople");
        }

        [Fact]
        public void Order_SampleTest3_Passes()
        {
            // Arrange
            // Act
            var result = Kata.Order("");

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void Order_Performance_Test()
        {
            // Arrange
            var stopWatch = new Stopwatch();
            var random = new Random();
            const string validCharacters = "4of Fo1r pe6ople g3ood th5e the2";

            var nastehString = new string(Enumerable.Repeat(validCharacters, 100).Select(s => s[random.Next(s.Length)]).ToArray());

            // Act
            stopWatch.Start();
            var result = Kata.Order(nastehString);
            stopWatch.Stop();

            // Assert
            var timeTaken = stopWatch.ElapsedMilliseconds;

            timeTaken.Should().BeLessThan(1000);
        }
    }
}
