using System;
using System.Collections.Generic;
using System.IO;
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
            var t = new FileContainer
            {
                Version = tb_version.Text,
                Folders = new List<FileContainerFolder>()
            };


            AddFolder(t.Folders, Directory.GetCurrentDirectory() + @"\Data\XML");
            foreach (var dir in Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + @"\Data\XML", "*", SearchOption.AllDirectories))
            {
                AddFolder(t.Folders, dir);
            }

            // TODO: Add Scripts and Other 

            var xmlString = t.Serialize();
            var doc = XDocument.Parse(xmlString);
            File.WriteAllText(tb_outDir.Text + @"\\Test.xml", doc.ToString());
            MessageBox.Show(new XmlValidator(tb_outDir.Text + @"\\FileContainer.xsd").Validate(tb_outDir.Text + @"\\Test.xml").ToString());
        }


        private void AddFolder(List<FileContainerFolder> list, string directory)
        {
            var folderItem = new FileContainerFolder
            {
                Count = Directory.GetFiles(directory).Length.ToString(),
                Hash = Hash.FolderHash.CheckHashDir(directory),
                TargetPath = directory.Replace(Directory.GetCurrentDirectory(), string.Empty) + @"\",
                TargetType = TargetType.Ai
            };
            list.Add(folderItem);

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
