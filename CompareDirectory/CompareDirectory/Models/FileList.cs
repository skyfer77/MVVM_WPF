using CompareDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WinForms = System.Windows.Forms;

namespace CompareDirectory.Models
{
    public class FileList
    {
        public static string Directory1 { get; set; }
        public static string Directory2 { get; set; }

        public string ShowDialog()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Directory1 = dialog.SelectedPath;
                    GenerateList();
                    return Directory1;
                }
            }
            return string.Empty;
        }

        public string ShowDialog2()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Directory2 = dialog.SelectedPath;
                    GenerateList();
                    return Directory2;
                }
            }
            return string.Empty;
        }

        public static List<FileModel> file_from_direction(string path)
        {
            List<FileModel> files = new List<FileModel>();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fiArr = di.GetFiles();
            foreach (FileInfo f in fiArr)
            {
                FileModel file = new FileModel();
                file.Name = f.Name;
                file.Size = f.Length;
                file.LastChange = f.LastWriteTime;
                files.Add(file);
            }
            return files;
        }

        public static string Compare_File(FileModel from1dir, FileModel from2dir)
        {
            if(from1dir.Name == from2dir.Name && from1dir.Size == from2dir.Size)
            {
                return "Absolute_Equal";
            }
            else if (from1dir.Name == from2dir.Name)
            {
                return "Name_Equal";
            }
            return "Only_dir1";
        }




        public static List<FileModel> GenerateList()
        {

            List<FileModel> result = new List<FileModel>();
            try
            {
                if (Directory1 == null)
                    Directory1 = Directory.GetCurrentDirectory();
                if (Directory2 == null)
                    Directory2 = Directory.GetCurrentDirectory();
                //Directory1 = @"I:\AntiPlagiat1_1\Plagnot\AntiPlagiat";
                //Directory2 = @"I:\AntiPlagiat1_1\Plagnot\AntiPlagiat\bin\Debug";
                List<FileModel> dir1 = file_from_direction(Directory1);
                List<FileModel> dir2 = file_from_direction(Directory2);
                foreach (var item in dir1)
                {
                    foreach (var item2 in dir2)
                    {
                        if (Compare_File(item, item2) == "Absolute_Equal")
                        {
                            item.Status = "Файл найден в обеих директориях и имеет одинаковый размер";
                            result.Add(item);
                            dir2.Remove(item2);
                            break;
                        }
                        else if (Compare_File(item, item2) == "Name_Equal")
                        {
                            item.Status = "Файл найден в обеих директориях, но имеет разный размер";
                            result.Add(item);
                            dir2.Remove(item2);
                            break;
                        }
                        else if (Compare_File(item, item2) == "Only_dir1")
                        {
                            item.Status = "Файл существует только в первой директории";
                            result.Add(item);
                            break;
                        }
                    }
                }
                foreach (var item2 in dir2)
                {
                    item2.Status = "Файл существует только во второй директории";
                    result.Add(item2);
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return result;
        }
    }
}
