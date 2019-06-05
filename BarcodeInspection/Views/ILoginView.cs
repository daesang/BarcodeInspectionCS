using BarcodeInspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Views
{
    public interface ILoginView : IView
    {
        string Compky { get; }
        string Wareky { get; }
        string Userid { get; }
        string Passwd { get; }
    }
}
