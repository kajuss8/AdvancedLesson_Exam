using Xunit;
using AdvancedLesson_Exam.repository;
using AdvancedLesson_Exam.ReadFromTxt;
using AdvancedLesson_Exam.Interfaces;
using AdvancedLesson_Exam.menu;

namespace AdvancedLesson_Exam.Test
{
    public class RestaurantTest
    {
        [Fact]
        public void ReadingDrinkTxtxFile_ReturnDrinkMenu_DrinkInterfaceAllMenuIsGood()
        {
            // Arrange
            IMenuRepository<DrinkMenu> menu = new DrinkMenuRepository();
            TxtFileReader reader = new TxtFileReader();
            var expected = menu.AllMenu().ToString();
            // Act
            var actual = reader.ReadingDrinkTxtFile().ToString();
            // Assert
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void ReadingFoodTxtxFile_ReturnFoodMenu_FoodInterfaceAllMenuIsGood()
        {
            // Arrange
            IMenuRepository<FoodMenu> menu = new FoodMenuRepository();
            TxtFileReader reader = new TxtFileReader();
            var expected = menu.AllMenu().ToString();
            // Act
            var actual = reader.ReadingFoodTxtFile().ToString();
            // Assert
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void PrintSelectedByIdMenu_ReturnDrinkMenuSelectedId_PrintSelectedByIdReturnsCorrect()
        {
            // Arrange
            DrinkMenuRepository drinkMenuRepository = new DrinkMenuRepository();
            var expected = 1;
            // Act
            var actual = drinkMenuRepository.PrintSelectedByIdMenu(expected).DrinkId;
            // Assert
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void PrintSelectedByIdMenu_ReturnFoodMenuSelectedId_PrintSelectedByIdReturnsCorrect()
        {
            // Arrange
            FoodMenuRepository foodMenuRepository = new FoodMenuRepository();
            var expected = 1;
            // Act
            var actual = foodMenuRepository.PrintSelectedByIdMenu(expected).FoodId;
            // Assert
            Assert.Equal(actual, expected);
        }
    }
}
