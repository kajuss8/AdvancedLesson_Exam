using System.Collections.Generic;

namespace AdvancedLesson_Exam.Interfaces
{
    public interface IMenuRepository<T>
    {
        public List<T> AllMenu();
        public T PrintSelectedByIdMenu(int menuId);
    }
}
