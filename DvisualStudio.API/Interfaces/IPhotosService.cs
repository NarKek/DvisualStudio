using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DvisualStudio.API.Interfaces
{
    public interface IPhotosService
    {
        string GetImageByReference(string photoReferences,string maxHeight, string maxWidth);
    }
}
