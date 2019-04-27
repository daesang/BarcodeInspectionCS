using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Common
{
    public interface ITopButton
    {
        Task Search();
        Task Save();
        Task Confirm();
        void Download();
        void Upload();
        void Print();
        void Close();

        void Clear();
    }
}
