using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace MVC_1.Models.ViewModels
{
    public class ExpenseCateVM
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> ExpenseCate { get; set; }

    }
}
