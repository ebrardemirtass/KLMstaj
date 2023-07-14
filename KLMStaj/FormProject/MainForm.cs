using UtilityProject;

namespace FormProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedComboBoxItem = (ComboBoxItem)cmbProcessSelect.SelectedItem;
            int selectedValue = selectedComboBoxItem.ValueMember;

            string? result = ProcessOperation(selectedValue, txtCommand.Text);

            txtCommand.Text = result;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbProcessSelect.DisplayMember = "DisplayMember";
            cmbProcessSelect.ValueMember = "ValueMember";
            cmbProcessSelect.DataSource = GetComboBoxData();
        }

        private List<ComboBoxItem> GetComboBoxData()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();

            comboBoxItems.Add(new ComboBoxItem("CustomAlgorithm", 0));
            comboBoxItems.Add(new ComboBoxItem("PrintStarts", 1));
            comboBoxItems.Add(new ComboBoxItem("DivideByThree", 2));
            comboBoxItems.Add(new ComboBoxItem("CompanyMode", 3));

            return comboBoxItems;
        }

        private void cmbProcessSelect_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBoxItem selectedComboBoxItem = (ComboBoxItem)cmbProcessSelect.SelectedItem;
            int selectedValue = selectedComboBoxItem.ValueMember;
        }

        private string? ProcessOperation(int selectedValue, string input)
        {
            AlgorithmHelper algorithmHelper = new AlgorithmHelper();
            string? result = null;

            switch (selectedValue)
            {
                case 0:
                    if (ValidateInput(input, out int number, out int repeatCount))
                    {
                        result = algorithmHelper.CustomAlgorithm(number, repeatCount);
                    }
                    else
                    {
                        result = "CustomAlgorithm i�in ge�ersiz girdi bi�imi. Beklenen bi�im: [say�] [tekrar say�s�]";
                    }
                    break;
                case 1:
                    if (int.TryParse(input, out int starsNumber))
                    {
                        result = algorithmHelper.PrintStars(starsNumber);
                    }
                    else
                    {
                        result = "PrintStars i�in ge�ersiz girdi bi�imi. Beklenen bi�im: [say�]";
                    }
                    break;
                case 2:
                    if (int.TryParse(input, out int divideNumber))
                    {
                        result = algorithmHelper.DivideByThree(divideNumber);
                    }
                    else
                    {
                        result = "DivideByThree i�in ge�ersiz girdi bi�imi. Beklenen bi�im: [say�]";
                    }
                    break;
                case 3:
                    string filePath = txtCommand.Text;
                    result = algorithmHelper.CompanyMode(filePath);
                    break;
                default:
                    break;
            }

            return result;
        }

        private bool ValidateInput(string input, out int number, out int repeatCount)
        {
            number = 0;
            repeatCount = 0;

            string[] inputValues = input.Split(' ');

            if (inputValues.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(inputValues[0], out number) || !int.TryParse(inputValues[1], out repeatCount))
            {
                return false;
            }

            return true;
        }

        private void txtCommand_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
