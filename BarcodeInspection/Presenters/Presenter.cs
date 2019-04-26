using BarcodeInspection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Presenters
{
    public class Presenter<T> where T : IView
    {
        static Presenter()
        {

        }

        public Presenter(T view)
        {
            View = view;
        }

        protected T View { get; private set; }
    }
}
