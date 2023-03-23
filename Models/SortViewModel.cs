namespace MvcEFApp.Models
{
    public class SortViewModel
    {
        public SortProp NameSort { get; set; } // значение для сортировки по имени
        public SortProp AgeSort { get; set; }    // значение для сортировки по возрасту
        public SortProp CompanySort { get; set; }   // значение для сортировки по компании
        public SortProp Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortProp sortOrder)
        {
            // значения по умолчанию
            NameSort = SortProp.NameAsc;
            AgeSort = SortProp.BirthDateAsc;
            CompanySort = SortProp.CompanyAsc;
            Up = true;

            if (sortOrder == SortProp.BirthDateAsc || sortOrder == SortProp.NameDesc
                || sortOrder == SortProp.CompanyDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortProp.NameDesc:
                    Current = NameSort = SortProp.NameAsc;
                    break;
                case SortProp.BirthDateAsc:
                    Current = AgeSort = SortProp.BirthDateAsc;
                    break;
                case SortProp.BirthDateDesc:
                    Current = AgeSort = SortProp.BirthDateDesc;
                    break;
                case SortProp.CompanyAsc:
                    Current = CompanySort = SortProp.CompanyDesc;
                    break;
                case SortProp.CompanyDesc:
                    Current = CompanySort = SortProp.CompanyAsc;
                    break;
                default:
                    Current = NameSort = SortProp.NameDesc;
                    break;
            }
        }
    }
}
