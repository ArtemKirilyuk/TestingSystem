
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class TestEditorViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
        [Display(Name = "Show only invalid tests:")]
        public bool ShowNotValid { get; set; }
    }
}