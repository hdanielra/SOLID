using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_L
{

    // Principios SOLID
    // SOLID tiene bastante relación con los patrones de diseño.


    // Single responsibility,       - responsabilidad única
    // Open-closed                  - abierto para su extensión pero cerrado para su modificación
    // Liskov substitution          - Bárbara Liskov: 1 clase padre que hereda a 1 clase hija,
    //                                la hija no debe alterar el funcionamiento del padre (no deben sobrar métodos del padre)
    // Interface segregation
    // Dependency inversion.



    // The Liskov Substitution Principle(LSP) states that "you should be able to use any
    // derived class instead of a parent class and have it behave in the same manner without
    // modification". It ensures that a derived class does not affect the behavior of the
    // parent class, in other words, that a derived class must be substitutable for its base class.
    // This principle is just an extension of the Open Closed Principle and it means that we
    // must ensure that new derived classes extend the base classes without changing their behavior.
    class Otro
    {
    }



    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------

    public class SqlFile1
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public string LoadText()
        {
            /* Code to read text from sql file */
            return "";
        }
        public void SaveText()
        {
            /* Code to save text into sql file */
        }
    }


    public class SqlFileManager1
    {
        List<SqlFile1> lstSqlFiles { get; set; }

        public string GetTextFromFiles()
        {
            StringBuilder ObjStringBuilder = new StringBuilder();

            foreach (var objFile in lstSqlFiles)
            {
                ObjStringBuilder.Append(objFile.LoadText());
            }

            return ObjStringBuilder.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var objFile in lstSqlFiles)
            {
                objFile.SaveText();
            }
        }
    }
    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------



    // OK.We are done with our part.The functionality looks good for now.After some time our leaders
    // might tell us that we may have a few read-only files in the application folder,
    // so we need to restrict the flow whenever it tries to do a save on them.


    // OK.We can do that by creating a "ReadOnlySqlFile" class that inherits the "SqlFile" class
    // and we need to alter the SaveTextIntoFiles() method by introducing a condition to prevent
    // calling the SaveText() method on ReadOnlySqlFile instances.



    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------
    public class SqlFile2
    {
        public string LoadText()
        {
            /* Code to read text from sql file */
            return "";
        }
        public void SaveText()
        {
            /* Code to save text into sql file */
        }
    }
    public class ReadOnlySqlFile2 : SqlFile2
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public string LoadText()
        {
            /* Code to read text from sql file */
            return "";
        }
        public void SaveText()
        {
            /* Code to save text into sql file */
            throw new IOException("Can't save");
        }
    }


    public class SqlFileManager2
    {
        List<SqlFile2> lstSlqFile { get; set; }

        public string GetTextFromFiles()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var sqlFile in lstSlqFile)
            {
                sb.Append(sqlFile.LoadText());
            }

            return sb.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var sqlFile in lstSlqFile)
            {
                // check whether current sqlFile is ReadOnly or not
                // if yes, skip calling it's SaveText() method 
                // to skip the exception

                if (!(sqlFile is ReadOnlySqlFile2))
                    sqlFile.SaveText();
            }
        }
    }
    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------



    // Here we altered the SaveTextIntoFiles() method in the SqlFileManager class to
    // determine whether or not the instance is of ReadOnlySqlFile to avoid the
    // exception.We can't use this ReadOnlySqlFile class as a substitute for its
    // parent without altering SqlFileManager code. So we can say that this design
    // is not following LSP. Let's make this design follow the LSP. Here we will
    // introduce interfaces to make the SqlFileManager class independent from the rest of the blocks.



    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------
    public interface IReadableSqlFile
    {
        public string LoadText();
    }

    public interface IWritableSqlFile
    {
        public void SaveText();
    }


    public class ReadOnlySqlFile : IReadableSqlFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }
        public string LoadText()
        {
            /* Code to read text from sql file */
            return "";
        }
    }


    public class SqlFile : IWritableSqlFile, IReadableSqlFile
    {
        public string LoadText()
        {
            /* Code to read text from sql file */
            return "";
        }
        public void SaveText()
        {
            /* Code to save text into sql file */
        }
    }


    // esta clase debe quedar lo suficientemente abstracta para que no sea modificada
    public class SqlFileManager
    {
        public string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var objFile in aLstReadableFiles)
            {
                stringBuilder.Append(objFile.LoadText());
            }

            return stringBuilder.ToString();
        }

        public void SaveTextIntoFiles(List<IWritableSqlFile> aLstWritableFiles)
        {
            foreach (var objFile in aLstWritableFiles)
            {
                objFile.SaveText();
            }
        }
    }

    //--------- --------- --------- --------- --------- --------- --------- --------- --------- ---------


    // Here the GetTextFromFiles() method gets only the list of instances of classes that
    // implement the IReadOnlySqlFile interface. That means the SqlFile and ReadOnlySqlFile
    // class instances. And the SaveTextIntoFiles() method gets only the list instances of
    // the class that implements the IWritableSqlFiles interface, in other words, SqlFile
    // instances in this case. Now we can say our design is following the LSP.And we fixed
    // the problem using the Interface segregation principle by(ISP) identifying
    // the abstraction and the responsibility separation method.
}
