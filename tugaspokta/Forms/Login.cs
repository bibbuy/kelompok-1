using tugaspokta.Model;

namespace tugaspokta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
            {
            string inputUser = textBox1.Text.Trim();
            string inputEmail = textBox2.Text.Trim();
            string inputPass = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(inputUser) || string.IsNullOrEmpty(inputEmail) || string.IsNullOrEmpty(inputPass) ) 
            {
                MessageBox.Show("isiki", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User();
            bool isSuccess = user.ValidateLogin(inputUser, inputEmail, inputPass);

            if (isSuccess)
            {
                MessageBox.Show("berhasil", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("login gagal", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

