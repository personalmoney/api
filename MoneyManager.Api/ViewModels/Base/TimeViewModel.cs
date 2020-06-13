using System;

namespace MoneyManager.Api.ViewModels.Base
{
    public class TimeViewModel : BaseViewModel
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}