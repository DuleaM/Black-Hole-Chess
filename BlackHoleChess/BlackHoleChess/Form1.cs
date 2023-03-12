namespace BlackHoleChess
{
    public partial class Form1 : Form
    {
        Table table;
        EntryPage entryPage;
        Button startButton = new Button();

        public Form1()
        {
            InitializeComponent();
        }

        //Load Dependencies on Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            table = new Table();
            entryPage = new EntryPage();
            setStartButtonDetails();
            entryPage.showEntryPage();
        }


        //Start Game Button
        private void startButton_Click(object sender, EventArgs e)
        {
            if(entryPage.getDropBoxChoice() != String.Empty)
            {
                entryPage.hideEntryPage();
                this.Controls.Remove(startButton);
                table.createTable();
            }
            else
            {
                MessageBox.Show("Please Choose an option");
            }
            
        }

        //Set The start button details
        private void setStartButtonDetails()
        {
            startButton.Text = "Start The Game";
            startButton.Location = new Point(this.Width / 2, 300);
            startButton.Click += startButton_Click;
            this.Controls.Add(startButton);
        }
    }
}