using tugaspokta.Forms;
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

            if (string.IsNullOrEmpty(inputUser) || string.IsNullOrEmpty(inputEmail) || string.IsNullOrEmpty(inputPass))
            {
                MessageBox.Show("isiki", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User();
            bool isSuccess = user.ValidateLogin(inputUser, inputEmail, inputPass);

            if (user.role == "Siswa") { 
                SiswaDash dashsiswa = new SiswaDash();
                this.Hide();
                dashsiswa.Show();
            }

            if (user.role == "Admin")
            {
                AdminDash dashadmin = new AdminDash();
                this.Hide();
                dashadmin.Show();
            }

            if (user.role == "Guru")
            {
                GuruDash dashguru = new GuruDash();
                this.Hide();
                dashguru.Show();
            }

            if (isSuccess)
            {
                MessageBox.Show("berhasil", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("login gagal", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

