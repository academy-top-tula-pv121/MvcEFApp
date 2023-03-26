namespace MvcEFApp.Models
{
    public class SortViewModel
    {
        public SortProp NameSort { get; set; } // значение для сортировки по имени
        public SortProp BirthDateSort { get; set; }    // значение для сортировки по возрасту
        public SortProp CompanySort { get; set; }   // значение для сортировки по компании
        public SortProp Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortProp sortOrder)
        {
            NameSort = sortOrder == SortProp.NameAsc ? SortProp.NameDesc : SortProp.NameAsc;
            BirthDateSort = sortOrder == SortProp.BirthDateAsc ? SortProp.BirthDateDesc : SortProp.BirthDateAsc;
            CompanySort = sortOrder == SortProp.CompanyAsc ? SortProp.CompanyDesc : SortProp.CompanyAsc;
            Current = sortOrder;

            Up = true;

            if (sortOrder == SortProp.BirthDateDesc || sortOrder == SortProp.NameDesc
                || sortOrder == SortProp.CompanyDesc)
            {
                Up = false;
            }
        }
    }
}
