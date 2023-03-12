using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHoleChess
{
    internal class EntryPage
    {
        private Label label = new Label();
        private ComboBox comboBox = new ComboBox();
        private Form activeForm = Form.ActiveForm;

        public EntryPage() {
            //Label
            label.Text = "BLACK HOLE CHESS";
            label.Location = new Point(activeForm.Width / 2, 200);


            //Drop Box
            comboBox.Location = new Point(activeForm.Width / 2, 400);
            comboBox.BackColor = System.Drawing.Color.Orange;
            comboBox.ForeColor = System.Drawing.Color.Black;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.Add("Black");
            comboBox.Items.Add("White");
        }

        public void showEntryPage()
        {
            activeForm.Controls.Add(label);
            activeForm.Controls.Add(comboBox);
        }
        
        public void hideEntryPage()
        {
            activeForm.Controls.Remove(label);
            activeForm.Controls.Remove(comboBox);
        }

        public string getDropBoxChoice()
        {
            return comboBox.Text;
        }
    }
}
