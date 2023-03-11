namespace BlackHoleChess
{
    public partial class Form1 : Form
    {
        Table table;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            table = new Table();
            table.createTable2();
        }
    }
}