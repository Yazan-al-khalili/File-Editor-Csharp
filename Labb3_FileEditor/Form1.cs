namespace Labb3_FileEditor
{
    public partial class Form1 : Form
    {
        private string currentFilePath = "dok1.txt";
        private bool isTextChanged = false;
        public Form1()
        {
            InitializeComponent();
            InitializeStatusBar();
            UpdateTitle();
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void InitializeStatusBar() //antal text, osv
        {
            StatusStrip statusBar = new StatusStrip();
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            this.Controls.Add(statusBar);
            statusBar.Items.Add(statusLabel);
            text_box.Tag = statusLabel;
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            if (text_box.Tag is ToolStripStatusLabel statusLabel)
            {
                string text = text_box.Text;
                int charWithSpaces = text.Length;
                int charWithoutSpaces = text.Replace(" ", "").Length;
                int wordCount = text.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                int lineCount = text.Split('\n').Length;

                statusLabel.Text = $"Tecken med mellanslag: {charWithSpaces} | Tecken utan mellanslag: {charWithoutSpaces} | Ord: {wordCount} | Rader: {lineCount}";
            }
        }

        private void UpdateTitle()
        {
            this.Text = (isTextChanged ? "*" : "") + Path.GetFileName(currentFilePath);
        }

        private void save_button_Click(object sender, EventArgs e) => SaveFile();

        private void remove_button_Click(object sender, EventArgs e) => NewFile();

        private void SaveAs_button_Click(object sender, EventArgs e) => SaveFileAs();

        private void open_button_Click(object sender, EventArgs e) => OpenFile();

        private void SaveFile() //Save
        {
            if (currentFilePath == "dok1.txt")
                SaveFileAs();
            else
                File.WriteAllText(currentFilePath, text_box.Text);

            isTextChanged = false;
            UpdateTitle();
            UpdateStatusBar();
        }

        private void SaveFileAs() //Save as
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Text Files|*.txt|All Files|*.*" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    SaveFile();
                }
            }
        }

        private void NewFile() //Remove
        {
            if (ConfirmUnsavedChanges())
            {
                text_box.Clear();
                currentFilePath = "dok1.txt";
                isTextChanged = false;
                UpdateTitle();
                UpdateStatusBar();
            }
        }

        private void OpenFile() //Open
        {
            if (ConfirmUnsavedChanges())
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Text Files|*.txt|All Files|*.*" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = openFileDialog.FileName;
                        text_box.Text = File.ReadAllText(currentFilePath);
                        isTextChanged = false;
                        UpdateTitle();
                        UpdateStatusBar();
                    }
                }
            }
        }

        private bool ConfirmUnsavedChanges()
        {
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("Vill du spara ändringar?", "Osparade ändringar", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFile();
                    return true;
                }
                return result == DialogResult.No;
            }
            return true;
        }

        private void text_box_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
            UpdateTitle();
            UpdateStatusBar();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!ConfirmUnsavedChanges())
                e.Cancel = true;
            base.OnFormClosing(e);
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                string fileContent = File.ReadAllText(filePath);

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    text_box.AppendText(fileContent);
                }
                else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    text_box.Text = text_box.Text.Insert(text_box.SelectionStart, fileContent);
                }
                else if (ConfirmUnsavedChanges())
                {
                    currentFilePath = filePath;
                    text_box.Text = fileContent;
                    isTextChanged = false;
                    UpdateTitle();
                    UpdateStatusBar();
                }
            }
        }

    }
}
