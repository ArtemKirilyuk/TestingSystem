using System.Collections.Generic;

namespace PL.ViewModels
{
    public class UserEditorVIewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}