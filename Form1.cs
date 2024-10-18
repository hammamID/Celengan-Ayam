using System;
using System.Windows.Forms;

namespace Celengan_Ayam
{
    public partial class Form1 : Form
    {
        private int totalAmount = 0;
        private Label resultLabel;
        private TextBox amountInput;
        private TextBox targetInput; // Input untuk target
        private Label summaryLabel;  // Label untuk menampilkan hasil

        public Form1()
        {
            InitializeComponent();
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void AddCelenganButton_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            CreateCelenganInput();
        }

        private void CreateCelenganInput()
        {
            // Label dan input untuk nama celengan
            Label nameLabel = new Label
            {
                Text = "Nama Celengan:",
                Location = new System.Drawing.Point(10, 10)
            };
            mainPanel.Controls.Add(nameLabel);

            TextBox nameInputBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 200,
                ForeColor = System.Drawing.Color.Gray,
                Text = "Misal: Buat Beli HP Tahun depan"
            };
            mainPanel.Controls.Add(nameInputBox);

            // Placeholder untuk input nama
            nameInputBox.Enter += (s, ev) =>
            {
                if (nameInputBox.Text == "Misal: Buat Beli HP Tahun depan")
                {
                    nameInputBox.Text = "";
                    nameInputBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            nameInputBox.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(nameInputBox.Text))
                {
                    nameInputBox.Text = "Misal: Buat Beli HP Tahun depan";
                    nameInputBox.ForeColor = System.Drawing.Color.Gray;
                }
            };

            // Label dan input untuk pendapatan
            Label incomeLabel = new Label
            {
                Text = "Pendapatan:",
                Location = new System.Drawing.Point(10, 80)
            };
            mainPanel.Controls.Add(incomeLabel);

            TextBox incomeInputBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 110),
                Width = 200
            };
            mainPanel.Controls.Add(incomeInputBox);

            // Event untuk memformat input angka dengan pemisah ribuan
            incomeInputBox.TextChanged += (s, ev) =>
            {
                if (string.IsNullOrEmpty(incomeInputBox.Text)) return;

                int selectionStart = incomeInputBox.SelectionStart;
                string rawText = incomeInputBox.Text.Replace(".", "");

                if (decimal.TryParse(rawText, out decimal value))
                {
                    incomeInputBox.Text = string.Format("{0:N0}", value);
                    incomeInputBox.SelectionStart = Math.Min(selectionStart, incomeInputBox.Text.Length);
                }
            };

            // Label dan input untuk target
            Label targetLabel = new Label
            {
                Text = "Target:",
                Location = new System.Drawing.Point(10, 140)
            };
            mainPanel.Controls.Add(targetLabel);

            TextBox targetInput = new TextBox
            {
                Location = new System.Drawing.Point(10, 170),
                Width = 200,
                ForeColor = System.Drawing.Color.Gray,
                Text = "Masukkan Target"  // Placeholder manual
            };
            mainPanel.Controls.Add(targetInput);

            targetInput.Enter += (s, ev) =>
            {
                if (targetInput.Text == "Masukkan Target")
                {
                    targetInput.Text = "";
                    targetInput.ForeColor = System.Drawing.Color.Black;
                }
            };

            targetInput.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(targetInput.Text))
                {
                    targetInput.Text = "Masukkan Target";
                    targetInput.ForeColor = System.Drawing.Color.Gray;
                }
            };


            // Button untuk simpan celengan
            Button saveButton = new Button
            {
                Text = "Simpan Celengan",
                Location = new System.Drawing.Point(10, 210)
            };
            saveButton.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(nameInputBox.Text) || nameInputBox.Text == "Misal: Buat Beli HP Tahun depan" ||
                    string.IsNullOrWhiteSpace(incomeInputBox.Text) || string.IsNullOrWhiteSpace(targetInput.Text))
                {
                    MessageBox.Show("Silakan isi semua field.");
                    return;
                }

                // Simpan data celengan ke tree view
                treeView1.Nodes[0].Nodes.Add(new TreeNode(nameInputBox.Text) { Tag = new Tuple<string, string>(incomeInputBox.Text, targetInput.Text) });
                mainPanel.Controls.Clear();
            };
            mainPanel.Controls.Add(saveButton);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                mainPanel.Controls.Clear();
                var tagData = e.Node.Tag as Tuple<string, string>;
                CreateDataCelenganUI(e.Node.Text, tagData.Item1, tagData.Item2);
            }
        }

        private void CreateDataCelenganUI(string celenganName, string incomeText, string targetText)
        {
            Label titleLabel = new Label
            {
                Text = $"Data Celengan: {celenganName}",
                Location = new System.Drawing.Point(10, 10)
            };
            mainPanel.Controls.Add(titleLabel);

            // Input untuk menambah jumlah
            amountInput = new TextBox
            {
                Location = new System.Drawing.Point(10, 70),
                Width = 200,
                ForeColor = System.Drawing.Color.Gray,
                Text = "Jumlah Masukan/Keluar"  // Placeholder manual
            };
            mainPanel.Controls.Add(amountInput);

            amountInput.Enter += (s, ev) =>
            {
                if (amountInput.Text == "Jumlah Masukan/Keluar")
                {
                    amountInput.Text = "";
                    amountInput.ForeColor = System.Drawing.Color.Black;
                }
            };

            amountInput.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(amountInput.Text))
                {
                    amountInput.Text = "Jumlah Masukan/Keluar";
                    amountInput.ForeColor = System.Drawing.Color.Gray;
                }
            };


            // Event untuk memformat input angka dengan pemisah ribuan
            amountInput.TextChanged += (s, ev) =>
            {
                if (string.IsNullOrEmpty(amountInput.Text)) return;

                int selectionStart = amountInput.SelectionStart;
                string rawText = amountInput.Text.Replace(".", "");

                if (decimal.TryParse(rawText, out decimal value))
                {
                    amountInput.Text = string.Format("{0:N0}", value);
                    amountInput.SelectionStart = Math.Min(selectionStart, amountInput.Text.Length);
                }
            };

            // Button untuk menambah uang
            Button addButton = new Button
            {
                Text = "Tambah",
                Location = new System.Drawing.Point(10, 120)
            };
            addButton.Click += AddAmount;
            mainPanel.Controls.Add(addButton);

            // Button untuk mengurangi uang
            Button subtractButton = new Button
            {
                Text = "Kurang",
                Location = new System.Drawing.Point(100, 120)
            };
            subtractButton.Click += SubtractAmount;
            mainPanel.Controls.Add(subtractButton);

            resultLabel = new Label
            {
                Text = "Hasil: 0",
                Location = new System.Drawing.Point(10, 170),
                Name = "resultLabel"
            };
            mainPanel.Controls.Add(resultLabel);

            summaryLabel = new Label
            {
                Text = "Dana Sudah Terkumpul: 0\nDana Kurang: 0\nSelesai pada: -",
                Location = new System.Drawing.Point(10, 200),
                AutoSize = true
            };
            mainPanel.Controls.Add(summaryLabel);
        }

        private void AddAmount(object sender, EventArgs e)
        {
            ProcessAmountChange(true);
        }

        private void SubtractAmount(object sender, EventArgs e)
        {
            ProcessAmountChange(false);
        }

        private void ProcessAmountChange(bool isAdding)
        {
            if (int.TryParse(amountInput.Text, out int amount) && int.TryParse(targetInput.Text, out int target))
            {
                totalAmount += isAdding ? amount : -amount;
                UpdateResultLabel();
                CalculateSummary(target);
            }
            else
            {
                MessageBox.Show("Input angka tidak valid.");
            }
        }

        private void UpdateResultLabel()
        {
            resultLabel.Text = $"Hasil: {totalAmount}";
        }

        private void CalculateSummary(int target)
        {
            int danaKurang = target - totalAmount;
            summaryLabel.Text = $"Dana Sudah Terkumpul: {totalAmount}\nDana Kurang: {danaKurang}";

            if (danaKurang <= 0)
            {
                summaryLabel.Text += "\nSelesai pada: Sekarang";
            }
            else
            {
                // Perhitungan kapan uang akan terkumpul (misal: setiap hari dengan pendapatan konstan)
                int daysToComplete = danaKurang / 1000;  // Contoh pendapatan harian sebesar 1000
                DateTime completionDate = DateTime.Now.AddDays(daysToComplete);
                summaryLabel.Text += $"\nSelesai pada: {completionDate.ToShortDateString()}";
            }
        }
    }
}
