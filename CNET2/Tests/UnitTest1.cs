using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        static string directory = @"C:\Programovani\bigfiles";
        // soubory, kde o�ek�v�me
        [TestMethod]
        public void FilesExists()
        {
            
            var files = Directory.EnumerateFiles(directory, "*.txt");
            Assert.IsTrue(files != null && files.Count() > 0);
        }
        [TestMethod]
        public void LoadBigFile()
        {
            var file = Path.Combine(directory, "words01.txt");
            var lines =File.ReadAllLines(file);
            Assert.IsTrue(lines.Any());
            //Assert.
        }

    }
}