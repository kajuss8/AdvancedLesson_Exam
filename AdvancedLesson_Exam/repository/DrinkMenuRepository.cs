using AdvancedLesson_Exam.Interfaces;
using AdvancedLesson_Exam.menu;
using AdvancedLesson_Exam.ReadFromTxt;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLesson_Exam.repository
{
    public class DrinkMenuRepository : IMenuRepository<DrinkMenu>
    {
        TxtFileReader txtFileReader = new TxtFileReader();
        public List<DrinkMenu> drinkMenu { get; set; }
        public DrinkMenuRepository()
        {
            drinkMenu = txtFileReader.ReadingDrinkTxtFile();
        }
        public List<DrinkMenu> AllMenu()
        {
            return drinkMenu;
        }
        public DrinkMenu PrintSelectedByIdMenu(int menuId)
        {
            return drinkMenu.Where(i => i.DrinkId == menuId).FirstOrDefault();
        }
    }
}