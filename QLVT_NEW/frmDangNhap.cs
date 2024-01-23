using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLVT_NEW
{
    public partial class frmDangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN"; cmbChiNhanh.ValueMember = "TENSERVER";

        }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
                conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối về CSDL gốc" + e.Message);
                return 0;
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("select * from Get_Subscribes");
            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
                //MessageBox.Show("SelectChange: " + cmbChiNhanh.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Login name và mật khẩu không được bỏ trống!");
                return;
            }
            Program.mlogin = txtLogin.Text; Program.password = txtPassword.Text;

            if (Program.KetNoi() == 0) return;
            Program.mChiNhanh = cmbChiNhanh.SelectedIndex;
            Program.mLoginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            MessageBox.Show("Chi nhánh bạn chọn là: " + cmbChiNhanh.SelectedIndex);
            string strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
            MessageBox.Show(Program.myReader.GetString(1));
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password");
                return;
            }

            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            //Program.frmChinh.MANV.Text = "Mã NV = " + Program.username;
            //Program.frmChinh.HOTEN.Text = "Họ tên =" + Program.mHoten;
            //Program.frmChinh.NHOM.Text = "Nhóm =" + Program.mGroup;
            //Program.frmChinh.HienThiMenu();
        }
    }
}
