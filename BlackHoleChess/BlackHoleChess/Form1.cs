namespace BlackHoleChess
{
    public partial class Form1 : Form
    {
        Table table;
        EntryPage entryPage;
        Button startLocalGame = new Button();
        Button startLanGame = new Button();
        Button startAIGame = new Button();

        public Form1()
        {
            InitializeComponent();
        }

        //Load Dependencies on Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            table = new Table();
            entryPage = new EntryPage();
            setLocalButton();
            entryPage.showEntryPage();
        }


        private void startLocalGame_Click(object sender, EventArgs e)
        {
            if(entryPage.getDropBoxChoice() != String.Empty)
            {
                entryPage.hideEntryPage();
                this.Controls.Remove(startLocalGame);

                table.createTable(entryPage.getDropBoxChoice());
            }
            else
            {
                MessageBox.Show("Please Choose an option");
            }
            
        }

        private void setLocalButton()
        {
            startLocalGame.Text = "Start Local Game";
            startLocalGame.Location = new Point(this.Width / 2 - 100, 300);
            startLocalGame.Size = new Size(120, 100);
            startLocalGame.Click += startLocalGame_Click;
            this.Controls.Add(startLocalGame);
        }
    }
}