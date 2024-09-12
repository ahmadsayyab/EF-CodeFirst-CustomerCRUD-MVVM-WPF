using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.EF.CodeFirst.WPF.Services
{
    public interface IAlertService
    {
        bool Confirm(string message, string title = "Confirmation");
    }
}
