using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using RawLauncherWPF.Xml;
using RawXmlLauncherGenerator.Xml;

namespace RawXmlLauncherGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbt_genType.SelectedIndex = 0;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please make sure the program in inside the Gits repository root folder of the branch you want to create the XML files for.",
                "XML Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (string.IsNullOrEmpty(tb_version.Text))
            {
                MessageBox.Show("Please type a version");
                return;
            }
            if (string.IsNullOrEmpty(tb_outDir.Text))
            {
                MessageBox.Show("Please select an Outputdir");
                return;
            }
            if (!Directory.Exists(tb_outDir.Text))
                Directory.CreateDirectory(tb_outDir.Text);
            if (!PreCheckCurrentDir())
            {
                MessageBox.Show(
                    "Please make sure the program in inside the Gits repository root folder of the branch you want to create the XML files for.",
                    "XML Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbt_genType.SelectedIndex == 0)
                GenerateCheckXml();
            if (cbt_genType.SelectedIndex == 1)
                GenerteRestoreXml();
        }

        private void GenerteRestoreXml()
        {
            if (string.IsNullOrEmpty(tb_modDir.Text))
            {
                MessageBox.Show("Please specify a mods directory");
                return;
            }
            var fileContainer = new FileContainer
            {
                Version = tb_version.Text,
                Files = new List<FileContainerFile>()
            };
            if (checkBox2.Checked)
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\XML"))
                    Parallel.ForEach(
                        Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\XML", "*",
                            SearchOption.AllDirectories),
                        x => AddFile(fileContainer.Files, x, TargetType.Ai, "\\"));
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\Scripts"))
                    Parallel.ForEach(
                        Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\Scripts", "*",
                            SearchOption.AllDirectories),
                        x => AddFile(fileContainer.Files, x, TargetType.Ai, "\\"));
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\CustomMaps"))
                    Parallel.ForEach(
                        Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\CustomMaps", "*",
                            SearchOption.AllDirectories),
                        x => AddFile(fileContainer.Files, x, TargetType.Ai, "\\"));
            }  
            Parallel.ForEach(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Mods\" + tb_modDir.Text, "*",
                    SearchOption.AllDirectories),
                x => AddFile(fileContainer.Files, x, TargetType.Mod, @"\Mods\" + tb_modDir.Text + "\\"));

            //Now replace dublicate files from previous versions
            if (File.Exists(tb_prevFile.Text))
            {
                var xmlObjectParser = new XmlObjectParser<FileContainer>(tb_prevFile.Text);
                var preVersionData = xmlObjectParser.Parse();

                List<FileContainerFile> newFiles =  new List<FileContainerFile>();

                foreach (var file in fileContainer.Files)
                {
                    FileContainerFile prefFile =
                        preVersionData.Files.Find(
                            f => f.Name == file.Name && file.TargetPath.Contains(f.TargetPath) && f.Hash == file.Hash);
                    if (prefFile != null)
                        file.SourcePath = prefFile.SourcePath;
                    else
                       newFiles.Add(new FileContainerFile {Name = file.Name, TargetPath = file.TargetPath, TargetType = file.TargetType});
                }
                var xmlNewString = newFiles.Serialize();
                var newDoc = XDocument.Parse(xmlNewString);
                File.WriteAllText(tb_outDir.Text + @"\\NewFiles.xml", newDoc.ToString());

                if (!Directory.Exists(tb_outDir.Text + "\\New Files\\"))
                    Directory.CreateDirectory(tb_outDir.Text + "\\New Files\\");

                if (checkBox1.Checked)
                    foreach (var newFile in newFiles)
                    {
                        try
                        {
                            if (newFile.TargetType == TargetType.Ai)
                            {
                                var i = Directory.GetCurrentDirectory();
                                var s = Path.Combine(i,newFile.TargetPath);
                                s = s.TrimEnd('\\');
                                s = Path.GetFullPath(s);
                                var t = tb_outDir.Text + "\\New Files\\AI" + "\\" + newFile.TargetPath;
                                t = t.TrimEnd('\\');
                                if (!Directory.Exists(new FileInfo(t).DirectoryName))
                                    Directory.CreateDirectory(new FileInfo(t).DirectoryName);
                                t = t.TrimEnd('\\');
                                File.Copy(s, t);
                            }

                            else
                            {
                                var s = Directory.GetCurrentDirectory() + @"\Mods\" + tb_modDir.Text + "\\" +  newFile.TargetPath;
                                s = s.TrimEnd('\\');
                                s = Path.GetFullPath(s);
                                var t = tb_outDir.Text + "\\New Files" + "\\" + newFile.TargetPath;
                                t = t.TrimEnd('\\');
                                if (!Directory.Exists(new FileInfo(t).DirectoryName))
                                    Directory.CreateDirectory(new FileInfo(t).DirectoryName);
                                t = t.TrimEnd('\\');
                                File.Copy(s, t);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("File " + newFile.Name + " could not be added.\r\n" + e.Message);
                        }
                    }

            }


            var xmlString = fileContainer.Serialize();
            var doc = XDocument.Parse(xmlString);
            File.WriteAllText(tb_outDir.Text + @"\\RestoreModFileContainer.xml", doc.ToString());
        }

        private bool PreCheckCurrentDir()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Mods\Republic_at_War\Data"))
                return false;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\"))
                return false;
            return true;
        }


        private void GenerateCheckXml()
        {

            if (string.IsNullOrEmpty(tb_modDir.Text))
            {
                MessageBox.Show("Please specify a mods directory");
                return;
            }

            var fileContainer = new FileContainer
            {
                Version = tb_version.Text,
                Folders = new List<FileContainerFolder>()
            };

            if (checkBox2.Checked)
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\XML"))
                {
                    AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\XML", TargetType.Ai);
                    Parallel.ForEach(
                        Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\XML", "*",
                            SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));
                }

                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\Scripts"))
                {
                    AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\Scripts", TargetType.Ai);
                    Parallel.ForEach(
                        Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\Scripts", "*",
                            SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));
                }

                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\CustomMaps"))
                {
                    AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\CustomMaps", TargetType.Ai);
                    Parallel.ForEach(
                        Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\CustomMaps", "*",
                            SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));
                }
            }           
            AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Mods\" + tb_modDir.Text,
                TargetType.Mod, @"\Mods\" + tb_modDir.Text);
            Parallel.ForEach(
                Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Mods\" + tb_modDir.Text, "*",
                    SearchOption.AllDirectories),
                x => AddFolder(fileContainer.Folders, x, TargetType.Mod, @"\Mods\" + tb_modDir.Text));

            var xmlString = fileContainer.Serialize();
            var doc = XDocument.Parse(xmlString);
            File.WriteAllText(tb_outDir.Text + @"\\CheckModFileContainer.xml", doc.ToString());
        }


        private static void AddFolder(List<FileContainerFolder> list, string directory, TargetType type, string cutoffPath = null)
        {
            var folderItem = new FileContainerFolder
            {
                Count = Directory.GetFiles(directory).Length.ToString(),
                Hash = Hash.FolderHash.CheckHashDir(directory),
                TargetPath = directory.Replace(Directory.GetCurrentDirectory() + cutoffPath, string.Empty) + @"\",
                TargetType = type
            };
            list.Add(folderItem);

        }

        private void AddFile(ICollection<FileContainerFile> files, string s, TargetType type, string cutoffPath = null)
        {
            var fileItem = new FileContainerFile
            {
                Name = Path.GetFileName(s),
                Hash = Hash.FileHash.CheckHashFile(s),
                TargetPath = s.Replace(Directory.GetCurrentDirectory() + cutoffPath, string.Empty),
                TargetType = type,
                SourcePath = tb_version.Text + s.Replace(Directory.GetCurrentDirectory(), string.Empty)
            };
            files.Add(fileItem);
        }

        private void btn_selDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tb_outDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cbt_genType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_selFile.Enabled = cbt_genType.SelectedIndex == 1;
        }

        private void btn_selFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(RestoreModFileContainer.xml)|RestoreModFileContainer.xml";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tb_prevFile.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loc = System.Reflection.Assembly.GetExecutingAssembly().Location;
            folderBrowserDialog2.SelectedPath = Path.GetDirectoryName(loc);
            if (folderBrowserDialog2.ShowDialog(this) == DialogResult.OK)
            {
                tb_modDir.Text = new DirectoryInfo(folderBrowserDialog2.SelectedPath).Name;
            }
        }
    }
}
