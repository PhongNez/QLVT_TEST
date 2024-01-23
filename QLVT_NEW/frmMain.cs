using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_NEW
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //public void HienThiMenu()
        //{
        //    MANV.Text = "Mã NV: " + Program.username;
        //    HOTEN.Text = "Họ tên: " + Program.mHoten;
        //    NHOM.Text = "Nhóm: " + Program.mGroup;

        //    rib_DanhMuc.Visible = true;
        //}

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            //this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            //this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.nhanVienBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void nhanVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            //this.nhanVienBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS);

        }
    }
}
