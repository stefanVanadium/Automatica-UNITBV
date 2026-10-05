using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab5.Services;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private GradeBook _gradeBook = new GradeBook();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetStatistics();
            tbNume.Focus();
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                _gradeBook.Add(tbNume.Text, tbNota.Text);
                RefreshStudentList();
                ClearInputFields();
                UpdateStatistics();
            }
            catch (Exception ex) when (ex is ArgumentException
            || ex is ArgumentOutOfRangeException)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void btnCalculeazaMedia_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatistics();
            }
            catch (InvalidOperationException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void btnMinMax_Click(object sender, EventArgs e)
        {
            try
            {
                var maxEntry = _gradeBook.GetMaxGradeEntry();
                var minEntry = _gradeBook.GetMinGradeEntry();
                lbNotaMax.Text =
                $"Nota maximă: {maxEntry.Grade:F2} - {maxEntry.StudentName}";
                lbNotaMin.Text =
                $"Nota minimă: {minEntry.Grade:F2} - {minEntry.StudentName}";
            }
            catch (InvalidOperationException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (lbxNote.SelectedIndex < 0)
            {
                ShowValidationError(
                "Selectați un student din listă pentru ștergere.");
                return;
            }
            try
            {
                _gradeBook.RemoveAt(lbxNote.SelectedIndex);
                RefreshStudentList();
                RefreshStudentsBelowAverage();
                if (_gradeBook.Count == 0)
                {
                    ResetStatistics();
                }
                else
                {
                    UpdateStatistics();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void btnStudentiSubMedie_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshStudentsBelowAverage();
            }
            catch (InvalidOperationException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void btnStudentiPesteMedie_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshStudentsAboveAverage();
            }
            catch (InvalidOperationException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
        private void RefreshStudentList()
        {
            lbxNote.BeginUpdate();
            lbxNote.Items.Clear();
            foreach (var entry in _gradeBook.Entries)
            {
                lbxNote.Items.Add(entry);
            }
            lbxNote.EndUpdate();
        }
        private void RefreshStudentsBelowAverage()
        {
            lvStudentiSubMedie.BeginUpdate();
            lvStudentiSubMedie.Items.Clear();
            foreach (var entry in _gradeBook.GetStudentsBelowAverage())
            {
                lvStudentiSubMedie.Items.Add(entry.ToString());
            }
            lvStudentiSubMedie.EndUpdate();
        }
        private void RefreshStudentsAboveAverage()
        {
            lvStudentiPesteMedie.BeginUpdate();
            lvStudentiPesteMedie.Items.Clear();
            foreach (var entry in _gradeBook.GetStudentsAboveAverage())
            {
                lvStudentiPesteMedie.Items.Add(entry.ToString());
            }
            lvStudentiPesteMedie.EndUpdate();
        }
        private void UpdateStatistics()
        {
            var average = _gradeBook.GetAverage();
            lbNrStudenti.Text = $"Număr total studenți: {_gradeBook.Count}";
            lbMedia.Text = $"Media notelor: {average:F2}";
        }
        private void ResetStatistics()
        {
            lbNrStudenti.Text = "Număr total studenți: 0";
            lbMedia.Text = "Media notelor: -";
            lbNotaMax.Text = "Nota maximă: -";
            lbNotaMin.Text = "Nota minimă: -";
            lvStudentiSubMedie.Items.Clear();
        }
        private void ClearInputFields()
        {
            tbNume.Clear();
            tbNota.Clear();
            tbNume.Focus();
        }
        private static void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Date invalide",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSortare_Click(object sender, EventArgs e)
        {
            try {
            _gradeBook.SortItems();
            RefreshStudentList();
            }
            catch (InvalidOperationException ex)
            {
                ShowValidationError(ex.Message);
            }
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            try
            {
                string textToFind = tbCautare.Text;
                int locationIndex = _gradeBook.SearchByName(textToFind);
                lbxNote.SelectedIndex = locationIndex;
            }
            catch (ArgumentException ex)
            {
                ShowValidationError(ex.Message);
            }
        }
    }
}