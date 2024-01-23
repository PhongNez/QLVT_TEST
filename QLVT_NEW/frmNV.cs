using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_NEW
{
    public partial class frmNV : Form
    {
        public frmNV()
        {
            InitializeComponent();
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            //DS.EnforceConstraints = false;

            ////Dòng này quan trọng
            //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            //this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.datHangTableAdapter.Fill(this.DS.DatHang);

            //this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            ////this.
            ////this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();//Tiềm ẩn lỗi chưa sửa
            //cmbChiNhanh.DataSource = Program.bds_dspm;
            //cmbChiNhanh.DisplayMember = "TENCN";
            //cmbChiNhanh.ValueMember = "TENSERVER";
            //cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            //if (Program.mGroup == "CONGTY")
            //{
            //    cmbChiNhanh.Enabled = false;
            //    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            //}
            //else
            //{
            //    cmbChiNhanh.Enabled = true;
            //    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
            //}

        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
