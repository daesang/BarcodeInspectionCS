using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection.Views
{
    public interface ILOBSC010View : IView
    {
        DateTime Rqshpd { get; }
        string Customer { get; }

        bool IsConfirm { get; }

        DataTable ExcelDataTable { get; }

        DataGridView ExcelDataGridView { get;}

    }
}
