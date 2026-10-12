using C1_TiemTapHoa.Models;

namespace C1_TiemTapHoa
{
    public partial class Form1 : Form
    {
        private BindingSource bds = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new TiemTapHoaContext())
            {
                var data = db.HangHoas.ToList();
                bds.DataSource = data;
                dgvHangHoa.DataSource = bds;
            }
        }
    }
}
