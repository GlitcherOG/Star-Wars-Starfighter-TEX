namespace Star_Wars_Starfighter_TEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameCombobox.SelectedIndex = 0;
            imageComboBox.SelectedIndex = 0;
        }
        TexHandler texHandler = new TexHandler();
        private void LoadTex_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Starwars Texture (*.tex)|*.tex|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string mainPath = Path.GetDirectoryName(openFileDialog.FileName);
                //string[] strings = Directory.GetFiles(mainPath, "*.tex", SearchOption.TopDirectoryOnly);
                //for (int i = 0; i < strings.Length; i++)
                //{
                //    texHandler = new TexHandler();
                //    texHandler.Load(openFileDialog.FileName);
                //}

                texHandler = new TexHandler();
                texHandler.Load(openFileDialog.FileName);
                pictureBox1.Image = texHandler.bitmap;

                this.Text = "Tex Editor - "+ openFileDialog.FileName;

                gameCombobox.SelectedIndex = texHandler.Game;
                if (texHandler.Game == 0)
                {
                    if (texHandler.ImageType == 0)
                        imageComboBox.SelectedIndex = 0;
                    if (texHandler.ImageType == 2)
                        imageComboBox.SelectedIndex = 1;
                    if (texHandler.ImageType == 3)
                        imageComboBox.SelectedIndex = 2;
                }
                if (texHandler.Game == 1)
                {
                    if (texHandler.ImageType == 1)
                        imageComboBox.SelectedIndex = 0;
                    if (texHandler.ImageType == 3)
                        imageComboBox.SelectedIndex = 1;
                    if (texHandler.ImageType == 4)
                        imageComboBox.SelectedIndex = 2;
                    if (texHandler.ImageType == 5)
                        imageComboBox.SelectedIndex = 3;
                }
                U0Tex.Value = texHandler.U1;

                GC.Collect();
            }
        }

        private void ExportTex_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog
            {
                Filter = "Png File (*.png)|*.png|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                texHandler.bitmap.Save(openFileDialog.FileName);
                GC.Collect();
            }
        }

        private void gameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameCombobox.SelectedIndex == 0)
            {
                imageComboBox.Items.Clear();

                imageComboBox.Items.Add("0 - 8 bit, 256 RGBA indexed");
                imageComboBox.Items.Add("2 - 24 bit RGB image");
                imageComboBox.Items.Add("3 - 32 bit RGBA image");
            }
            else if (gameCombobox.SelectedIndex == 1)
            {
                imageComboBox.Items.Clear();
                imageComboBox.Items.Add("1 - 8 bit, 256 RGBA indexed");
                imageComboBox.Items.Add("3 - 24 bit RGB image");
                imageComboBox.Items.Add("4 - 32 bit RGBA image");
                imageComboBox.Items.Add("5 - 4 bit, 16 RGBA indexed");
            }
            else
            {
                imageComboBox.Items.Clear();
                imageComboBox.Items.Add("Error Unknown Game");
            }
        }

        private void SaveTex_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog
            {
                Filter = "Starwars Texture (*.tex)|*.tex|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                texHandler.SetGame(gameCombobox.SelectedIndex);
                texHandler.ImageType = int.Parse(imageComboBox.Text.Substring(0, 1));
                texHandler.U1 = (int)U0Tex.Value;

                string ErrorTest = texHandler.CheckForError();
                if (ErrorTest == "")
                {
                    texHandler.Save(openFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show(ErrorTest);
                }
                GC.Collect();
            }
        }

        private void ImportTex_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Texture (*.png)|*.png|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                texHandler.bitmap = (Bitmap)Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = texHandler.bitmap;

                GC.Collect();
            }
        }

        private void blackCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(blackCheck.Checked)
            {
                pictureBox1.BackColor = Color.Black;
            }
            else
            {
                pictureBox1.BackColor = Color.Transparent;
            }
        }
    }
}