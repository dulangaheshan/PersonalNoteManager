/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:26:53
 * @modify date 2021-01-09 17:26:53
 * @desc [Manage Static files ]
 */
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.utils
{
    public class FileManager
    {   
        /**
            * GenerateTxt
            * * generate txt file from note object
            * @ params{Note note}
        */

        public String GenerateTxt(Note note)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\ArchivedNotes", "temp.txt");
            string zippath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\ArchivedNotes", note.Title + note.DateCreated.ToString("yyyyMMddHHmmssfff") + "test.zip");
            //string path = @"C:\Users\D.ShaN\source\repos\CordFortPersonalNoteManager\CordFortPersonalNoteManager\StaticFiles\ArchivedNotes";
            if (!File.Exists(path))
            {

                using (StreamWriter sw = File.CreateText(path))
                {
                sw.WriteLine("Title :" +  note.Title);
                sw.WriteLine(note.Content);
                sw.WriteLine("Welcome");
                }
       
            }

            AddFileToZip(zippath, path);
            DeleteFiles(path);

            return zippath;
        }


        /**
            * AddFileToZip
            * * make zip file from txt file
            * @ params{zipFilename, fileToAdd}
        */
        private const long BUFFER_SIZE = 4096;

        private void AddFileToZip(string zipFilename, string fileToAdd)
        {
            using (Package zip = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
            {
                string destFilename = ".\\" + Path.GetFileName(fileToAdd);
                Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                if (zip.PartExists(uri))
                {
                    zip.DeletePart(uri);
                }
                PackagePart part = zip.CreatePart(uri, "", CompressionOption.Normal);
                using (FileStream fileStream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                {
                    using (Stream dest = part.GetStream())
                    {
                        CopyStream(fileStream, dest);
                    }
                }
            }
        }
        /**
            * CopyStream
            * * copy txt as stream in to zip
            * @ params{inputStream, outputStream}
        */
        private static void CopyStream(FileStream inputStream, Stream outputStream)
        {
            long bufferSize = inputStream.Length < BUFFER_SIZE ? inputStream.Length : BUFFER_SIZE;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            long bytesWritten = 0;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bytesRead;
            }
        }


        /**
            * DeleteFiles
            * * Delete file with path
            * @ params{path}
        */
        public void DeleteFiles(String path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
