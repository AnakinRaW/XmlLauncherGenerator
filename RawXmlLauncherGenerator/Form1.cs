using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
                "Please make sure the program in in FoC root and foc is installed in the same version you typed in",
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
                    "Please make sure the program in in FoC root and foc is installed in the same version you typed in",
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
            var fileContainer = new FileContainer
            {
                Version = tb_version.Text,
                Files = new List<FileContainerFile>()
            };
            Parallel.ForEach(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\XML", "*", SearchOption.AllDirectories),
                x => AddFile(fileContainer.Files, x, TargetType.Ai));
            Parallel.ForEach(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\Scripts", "*", SearchOption.AllDirectories),
                x => AddFile(fileContainer.Files, x, TargetType.Ai));
            Parallel.ForEach(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Data\CustomMaps", "*", SearchOption.AllDirectories),
                x => AddFile(fileContainer.Files, x, TargetType.Ai));

            Parallel.ForEach(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\Mods\Republic_at_War", "*", SearchOption.AllDirectories),
                x => AddFile(fileContainer.Files, x, TargetType.Mod));

            var xmlString = fileContainer.Serialize();
            var doc = XDocument.Parse(xmlString);
            File.WriteAllText(tb_outDir.Text + @"\\RestoreModFileContainer.xml", doc.ToString());
        }

        private bool PreCheckCurrentDir()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\swfoc.exe"))
                return false;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Mods\Republic_at_War\Data"))
                return false;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Data\XML\"))
                return false;
            return true;
        }


        private void GenerateCheckXml()
        {
            var fileContainer = new FileContainer
            {
                Version = tb_version.Text,
                Folders = new List<FileContainerFolder>()
            };

            AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\XML", TargetType.Ai);
            Parallel.ForEach(
                Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\XML", "*",
                    SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));

            AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\Scripts", TargetType.Ai);
            Parallel.ForEach(
                Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\Scripts", "*",
                    SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));

            AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Data\CustomMaps", TargetType.Ai);
            Parallel.ForEach(
                Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\CustomMaps", "*",
                    SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Ai));


            if (string.IsNullOrEmpty(tb_customModDir.Text))
            {
                AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Mods\Republic_At_War\Data", TargetType.Mod, @"\Mods\Republic_At_War\Data");
                Parallel.ForEach(
                    Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Mods\Republic_At_War\Data", "*",
                        SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Mod, @"\Mods\Republic_At_War\Data"));
            }
            else
            {
                AddFolder(fileContainer.Folders, Directory.GetCurrentDirectory() + @"\Mods\" + tb_customModDir.Text + @"\Data", TargetType.Mod, @"\Mods\" + tb_customModDir.Text + @"\Data");
                Parallel.ForEach(
                    Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Mods\" + tb_customModDir.Text + @"\Data", "*", SearchOption.AllDirectories), x => AddFolder(fileContainer.Folders, x, TargetType.Mod, @"\Mods\" + tb_customModDir.Text + @"\Data"));
            }

            var xmlString = fileContainer.Serialize();
            var doc = XDocument.Parse(xmlString);
            File.WriteAllText(tb_outDir.Text + @"\\CheckModFileContainer.xml", doc.ToString());
        }


        private void AddFolder(List<FileContainerFolder> list, string directory, TargetType type, string cutoffPath = null)
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

        private void AddFile(List<FileContainerFile> files, string s, TargetType type, string cutoffPath = null)
        {
            var fileItem = new FileContainerFile
            {
                Name = Path.GetFileName(s),
                Hash = Hash.FileHash.CheckHashFile(s),
                TargetPath = s.Replace(Directory.GetCurrentDirectory() + cutoffPath, string.Empty) + @"\",
                TargetType = type,
                SourcePath = @"\" + tb_version.Text + s.Replace(Directory.GetCurrentDirectory() + cutoffPath, string.Empty) + @"\",
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
    }
}
