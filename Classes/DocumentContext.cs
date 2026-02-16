using Konevskii_PR21.Interface;
using Konevskii_PR21.Model;
using Konevskii_PR21.Classes.Common;
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

            OleDbCommand connection = DBConnection.Connection();
            OleDbCommand dataDocuments = DBConnection.Query("Select * FROM [Документы]", connection);
            while (dataDocuments.Read())
            {
                allDocuments.Add(new Document());
                {
                    Id = dataDocuments.GetInt32(0);
                    Src = dataDocuments.GetString(1);
                    Name = dataDocuments.GetString(2);
                    User = dataDocuments.GetString(3);
                    IdDocument = dataDocuments.GetInt32(4);
                    Date = dataDocuments.GetDateTime(5);
                    Status = dataDocuments.GetInt32(6);
                    Direction = dataDocuments.GetInt32(7);

                }
            }
            DbConnection.CloseConnection(connection);

            return allDocuments;
        }

        public void Delete()
        {
            OleDbCommand connection = DBConnection.Connection();

            DBConnection.Query(
                    $"DELETE FROM [Документы] WHERE" +
                        $"[Код] = {this.Id}", connection);

            DBConnection.CloseConnection(connection);
        }

        public void Save(bool update = false)
        { 
            OleDbCommand connection = DBConnection.Connection();
            if (update)
            {
                DBConnection.Query(
                    $"UPDATE" +
                        $"[Документы]" +
                    $"SET" +
                        $"[Изображение] = '{this.Src}', " +
                        $"[Наименование] = '{this.Name}', " +
                        $"[Ответственный] = '{this.User}', " +
                        $"[Код документа] = '{this.IdDocument}', " +
                        $"[Дата поступления] = '{this.Date.ToString("dd.MM.yyyy")}', " +
                        $"[Статус] = {this.Status}," +
                        $"[Направление] = '{this.Direction}'" +
                    $"WHERE" +
                        $"[Код] = {this.Id}", connection);
            }
            else
            {
                DBConnection.Query(
                    $"INSERT INTO" +
                        $"[Документы](" +
                            $"[Изображение], " +
                            $"[Наименование], " +
                            $"[Ответственный], " +
                            $"[Код документа] , " +
                            $"[Дата поступления], " +
                            $"[Статус], " +
                            $"[Направление]) " +
                    $"VALUES (" +
                        $"'{this.Src}', " +
                        $"'{this.Name}', " +
                        $"'{this.User}', " +
                        $"'{this.Id_document}', " +
                        $"'{this.Date.ToString("dd.MM.yyyy")}', " +
                        $"{this.Status}, " +
                        $"'{this.Direction}')", connection );

            }
            DBConnection.CloseConnection(connection );
        }
    }
}
