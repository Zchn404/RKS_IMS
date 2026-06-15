using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RKS_Inventory
{
    public partial class Login : MaterialForm
    {
        SqlConnection cn = DatabaseManager.GetConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green700, Primary.BlueGrey100, Accent.Green700, TextShade.WHITE);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbUser.Focus();
            if (Properties.Settings.Default.Remember)
            {
                tbUser.Text = Properties.Settings.Default.Username;
                tbPass.Text = EncryptionHelper.Decrypt(Properties.Settings.Default.Password);
                cbRemember.Checked = true;               
            }
        }


        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _username = "", _name = "", _role = "", _pass = "";
            bool _status = false;

            try
            {
                if (string.IsNullOrEmpty(tbUser.Text) || string.IsNullOrEmpty(tbPass.Text))
                {
                    MessageBox.Show("Please Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "SELECT Username, FullName, Role, Password, Status FROM [User] WHERE Username = @Username";

                using (SqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@Username", tbUser.Text);

                        using (SqlDataReader dr = comm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                _username = dr["Username"].ToString();
                                _name = dr["FullName"].ToString();
                                _role = dr["Role"].ToString();
                                _pass = dr["Password"].ToString();

                                string statusString = dr["Status"].ToString();
                                _status = statusString.Equals("Active", StringComparison.OrdinalIgnoreCase);

                                if (!_status)
                                {
                                    MessageBox.Show("Account has been resigned. Unable to log in.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string decryptedPassword = EncryptionHelper.Decrypt(_pass);

                               
                                if (cbRemember.Checked)
                                {
                                    Properties.Settings.Default.Username = tbUser.Text;
                                    Properties.Settings.Default.Password = EncryptionHelper.Encrypt(tbPass.Text);
                                    Properties.Settings.Default.Remember = true;
                                    Properties.Settings.Default.Save();
                                }
                                else
                                {
                                    Properties.Settings.Default.Username = string.Empty;
                                    Properties.Settings.Default.Password = string.Empty;
                                    Properties.Settings.Default.Remember = false;
                                    Properties.Settings.Default.Save();
                                }

                                if (tbPass.Text == decryptedPassword)
                                {
                                    MessageBox.Show("Welcome " + _username, "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbUser.Clear();
                                    tbPass.Clear();
                                    this.Hide();

                                    if (_role == "Staff")
                                    {
                                        Staff staff = new Staff
                                        {
                                            labelUser = "Welcome: " + _username,
                                            labelRole = _role,
                                            StockInByy = _username,
                                            UserSA = _username,
                                            _pass = _pass
                                        };
                                       
                                        DateTime now = DateTime.Now;
                                        TimeSpan currentTime = now.TimeOfDay;

                                        using (SqlConnection connection = DatabaseManager.GetConnection())
                                        {
                                            connection.Open();

                                            string insertLoginQuery = "INSERT INTO AccessLogs ([User], Date, TimeIn, Action) VALUES (@User, @Date, @TimeIn, 'Login')";

                                            using (SqlCommand insertCommand = new SqlCommand(insertLoginQuery, connection))
                                            {
                                                insertCommand.Parameters.AddWithValue("@User", _username);
                                                insertCommand.Parameters.AddWithValue("@Date", now.Date);
                                                insertCommand.Parameters.AddWithValue("@TimeIn", currentTime);
                                                insertCommand.ExecuteNonQuery();
                                            }
                                        }
                                        staff.ShowDialog();
                                    }
                                    else
                                    {
                                        MainForm main = new MainForm
                                        {
                                            labelUserMain = "Welcome: " + _username,
                                            labelUserMain1 = _username,
                                            labelRoleMain = _role,
                                            labelResetMain = _username,
                                            StockInByy = _username,
                                            UserSA = _username,
                                            _pass = _pass
                                        };
                                       
                                        DateTime now = DateTime.Now;
                                        TimeSpan currentTime = now.TimeOfDay;

                                        using (SqlConnection connection = DatabaseManager.GetConnection())
                                        {
                                            connection.Open();

                                            string insertLoginQuery = "INSERT INTO AccessLogs ([User], Date, TimeIn, Action) VALUES (@User, @Date, @TimeIn, 'Login')";

                                            using (SqlCommand insertCommand = new SqlCommand(insertLoginQuery, connection))
                                            {
                                                insertCommand.Parameters.AddWithValue("@User", _username);
                                                insertCommand.Parameters.AddWithValue("@Date", now.Date);
                                                insertCommand.Parameters.AddWithValue("@TimeIn", currentTime);
                                                insertCommand.ExecuteNonQuery();
                                            }
                                        }
                                        main.ShowDialog();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbUser.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbUser.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenEyes_Click(object sender, EventArgs e)
        {
            if (tbPass.Password == true)
            {
                btnCloseEyes.BringToFront();
                tbPass.Password = false;
                tbPass.Focus();
            }
        }

        private void btnCloseEyes_Click(object sender, EventArgs e)
        {
            if (tbPass.Password == false)
            {
                btnOpenEyes.BringToFront();
                tbPass.Password = true;
                tbPass.Focus();
            }
        }

        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
