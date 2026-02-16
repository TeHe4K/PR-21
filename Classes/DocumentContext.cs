using Konevskii_PR21.Interface;
using Konevskii_PR21.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konevskii_PR21.Classes
{
    internal class DocumentContext : Document, IDocument
    {
        public List<Document> AllDocuments()
        {
            List<Document> allDocuments = new List<Document>();

            OleDbCommand connection = DbConnection.cON
        }
    }
}
