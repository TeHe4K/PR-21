using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konevskii_PR21.Interface
{
    public interface IDocument
    {
        void Save(bool Update = false);
        List<Model.Document> AllDocuments();
        void Delete();
    }
}
