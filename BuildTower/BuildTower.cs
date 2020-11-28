using FluentAssertions;
using System;
using Xunit;
using System.Linq;

namespace BuildTower
{
    public class Kata
    {
        //1 = * 2 = *, *** 3 = *, ***, *****
        public static string[] TowerBuilder(int nFloors)
        {
            var tower = new string[nFloors];
            var floorWidths = (nFloors + nFloors) - 1;

            int floorMultiplier = 0;
            for (int i = 0; i < tower.Length; i++)
            {
                var floorNumber = (i + 1);
                var floor = i == 0 ? floorNumber : (floorNumber + floorMultiplier);
                var floorAsterisks = string.Concat(Enumerable.Repeat("*", floor));
                tower[i] = CentreAlign(floorAsterisks, floorWidths);

                floorMultiplier++;
            }

            return tower;
        }

        public static string CentreAlign(string asterisks, int floorWidth)
        {
            var centeredString = new char[floorWidth];

            var centreIndex = floorWidth / 2;
            centeredString[centreIndex] = '*';
            int remainingAsterisks = asterisks.Length - 1;

            // TODO - Run simulatenously somehow left, right, left, right order rather than all left first then all right

            for (int leftPointer = centreIndex - 1; leftPointer >= 0; leftPointer--)
            {
                if (remainingAsterisks != 0)
                {
                    centeredString[leftPointer] = '*';
                    remainingAsterisks--;
                }
                else
                {
                    centeredString[leftPointer] = ' ';
                }
            }

            for (int rightPointer = centreIndex + 1; rightPointer < floorWidth; rightPointer++)
            {
                if (remainingAsterisks != 0)
                {
                    centeredString[rightPointer] = '*';
                    remainingAsterisks--;
                }
                else
                {
                    centeredString[rightPointer] = ' ';
                }
            }

            return new string(centeredString);
        }
    }

    public class KataTests
    {
        [Fact]
        public void TowerBuilder_SampleTest1_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(1));

            // Assert
            result.Should().Be(string.Join(",", new[] { "*" }));
        }

        [Fact]
        public void TowerBuilder_SampleTest1WithoutSpaces_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(1));

            // Assert
            result.Should().Be(string.Join(",", new[] { "*" }));
        }

        [Fact]
        public void TowerBuilder_SampleTest2_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(2));

            // Assert
            result.Should().Be(string.Join(",", new[] { " * ", "***" }));
        }

        [Fact]
        public void TowerBuilder_SampleTest2WithoutSpaces_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(2));

            // Assert
            result.Should().Be(string.Join(",", new[] { "*", "***" }));
        }


        [Fact]
        public void TowerBuilder_SampleTest3_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(3));

            // Assert
            result.Should().Be(string.Join(",", new[] { "  *  ", " *** ", "*****" }));
        }

        [Fact]
        public void TowerBuilder_SampleTest3WithoutSpaces_Passes()
        {
            // Arrange
            // Act
            var result = string.Join(",", Kata.TowerBuilder(3));

            // Assert
            result.Should().Be(string.Join(",", new[] { "*", "***", "*****" }));
        }

    }
}
