using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection.Views
{
    public interface ILOBSC020View : IView
    {
        DateTime Rqshpd { get; }
        string Customer { get; }
        string Wavecd { get; }

        DataGridView ExcelDataGridView { get; }
    }
}
