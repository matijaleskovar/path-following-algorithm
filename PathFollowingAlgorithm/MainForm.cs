using PathFollowingAlgorithm.Helpers;
using PathFollowingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PathFollowingAlgorithm.Helpers.PathFollowingUtilities;

namespace PathFollowingAlgorithm
{
    public partial class MainForm : Form
    {
        private string _fileString = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        //Events
        private void btnAddASCIIMap_Click(object sender, EventArgs e)
        {
            Position currentPosition = new Position();

            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                tbFilePath.Text = file;
                try
                {
                    _fileString = File.ReadAllText(file);
                }
                catch (IOException)
                {
                    MessageBox.Show("There was a file read error", "File read error");
                }

                ClearResultLbl();
            }
        }

        private void btnProcessMap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(_fileString))
            {
                MessageBox.Show("File path not specified", "File path error");
                return;
            }

            char[][] char2DArray = ConvertStringTo2DCharArray(_fileString);

            var result = new PathSolver().FollowPath(char2DArray);

            if (result != null)
            {
                ShowResultLbl(result);
            }
            else
            {
                MessageBox.Show("Error ocurred", "Error");
            }
        }

        //UI methods
        public void ShowResultLbl(PathResult result)
        {
            tbPath.Text = result.Path;
            tbLetters.Text = result.Letters;
        }

        public void ClearResultLbl()
        {
            tbPath.Text = string.Empty;
            tbLetters.Text = string.Empty;
        }
    }
}
