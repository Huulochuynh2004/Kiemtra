using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLTinhHinhDichBenh
{
    public partial class FrmMain : Form
    {
        string connStr =
            @"Data Source=LAPTOP-1VO28O2D\SQLEXPRESS;
              Initial Catalog=QLTinhHinh;
              Integrated Security=True";

        bool sortDesc = true;

        public FrmMain()
        {
            InitializeComponent();
            LoadData();
            LoadTrangThai();
        }

        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MaDP, TenDP, SoCaNhiemMoi, TenTT
                      FROM DiaPhuong dp
                      JOIN TrangThai tt ON dp.MaTT = tt.MaTT",
                    conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        void LoadTrangThai()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT MaTT, TenTT FROM TrangThai", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboTrangThai.DataSource = dt;
                cboTrangThai.DisplayMember = "TenTT";
                cboTrangThai.ValueMember = "MaTT";
                cboTrangThai.SelectedIndex = 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text == "" || txtTenDP.Text == "" || txtSoCa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (txtMaDP.Text.Length != 3 || int.Parse(txtSoCa.Text) < 0)
            {
                MessageBox.Show("Mã ĐP phải 3 ký tự và số ca ≥ 0");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO DiaPhuong(MaDP, TenDP, SoCaNhiemMoi, MaTT)
                      VALUES (@MaDP,@TenDP,@SoCa,@MaTT)", conn);

                cmd.Parameters.AddWithValue("@MaDP", txtMaDP.Text);
                cmd.Parameters.AddWithValue("@TenDP", txtTenDP.Text);
                cmd.Parameters.AddWithValue("@SoCa", int.Parse(txtSoCa.Text));
                cmd.Parameters.AddWithValue("@MaTT", cboTrangThai.SelectedValue);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm mới thành công!");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand checkCmd = new SqlCommand(
                    "SELECT MaTT FROM DiaPhuong WHERE MaDP=@MaDP", conn);
                checkCmd.Parameters.AddWithValue("@MaDP", txtMaDP.Text);

                object oldMaTT = checkCmd.ExecuteScalar();
                if (oldMaTT == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin địa phương");
                    return;
                }

                if (oldMaTT.ToString() != cboTrangThai.SelectedValue.ToString())
                {
                    DialogResult rs = MessageBox.Show(
                        "Địa phương có sự thay đổi trạng thái?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo);

                    if (rs == DialogResult.No) return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"UPDATE DiaPhuong
                      SET TenDP=@TenDP, SoCaNhiemMoi=@SoCa, MaTT=@MaTT
                      WHERE MaDP=@MaDP", conn);

                cmd.Parameters.AddWithValue("@TenDP", txtTenDP.Text);
                cmd.Parameters.AddWithValue("@SoCa", int.Parse(txtSoCa.Text));
                cmd.Parameters.AddWithValue("@MaTT", cboTrangThai.SelectedValue);
                cmd.Parameters.AddWithValue("@MaDP", txtMaDP.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            txtMaDP.Text = row.Cells["MaDP"].Value.ToString();
            txtTenDP.Text = row.Cells["TenDP"].Value.ToString();
            txtSoCa.Text = row.Cells["SoCaNhiemMoi"].Value.ToString();
            cboTrangThai.Text = row.Cells["TenTT"].Value.ToString();
        }

        // MENU F1
        private void mnuSort_Click(object sender, EventArgs e)
        {
            string order = sortDesc ? "DESC" : "ASC";
            sortDesc = !sortDesc;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    $@"SELECT MaDP, TenDP, SoCaNhiemMoi, TenTT
                       FROM DiaPhuong dp
                       JOIN TrangThai tt ON dp.MaTT = tt.MaTT
                       ORDER BY SoCaNhiemMoi {order}", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        // MENU F2
        private void mnuNguyCo_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MaDP, TenDP, SoCaNhiemMoi, TenTT
                      FROM DiaPhuong dp
                      JOIN TrangThai tt ON dp.MaTT = tt.MaTT
                      WHERE TenTT <> N'Bình thường'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        // MENU CTRL+R
        private void mnuReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xuất báo cáo tình hình dịch bệnh", "Báo cáo");
        }
    }
}
