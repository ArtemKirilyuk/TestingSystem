using System.Collections.Generic;

namespace PL.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}