using System.Collections.Generic;

namespace PL.ViewModels
{
    public class StatisticsViewModel
    {
        public IEnumerable<Statistics> StatisticsOfTests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}