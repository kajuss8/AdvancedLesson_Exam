using AdvancedLesson_Exam.Interfaces;
using AdvancedLesson_Exam.menu;
using AdvancedLesson_Exam.ReadFromTxt;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLesson_Exam.repository
{
    public class FoodMenuRepository : IMenuRepository<FoodMenu>
    {
        TxtFileReader txtFileReader = new TxtFileReader();
        public List<FoodMenu> foodMenu { get; set; }
        public FoodMenuRepository()
        {
            foodMenu = txtFileReader.ReadingFoodTxtFile();
        }
        public List<FoodMenu> AllMenu()
        {
            return foodMenu;
        }
        public FoodMenu PrintSelectedByIdMenu(int menuId)
        {
            return foodMenu.Where(i => i.FoodId == menuId).FirstOrDefault();
        }
    }
}