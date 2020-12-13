// Amber Holcomb-Stone
// CITC 2311: Lab 1 Part B
// Description: Create an application that allows the user to enter the number
// of tickets sold for each class. The application should be able to display 
// the amount of income generated from each class of ticket sales and the total revenue generated.
// This application should use data validation to make sure that the data given is in an acceptable format.
// Code partially adapted from: https://www.homeworklib.com/questions/315642/create-stadium-seating-visual-basic
// and Murach's Book Applications Files


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StadiumSeating
{
    public partial class StadiumSeatingForm : Form
    {
        public StadiumSeatingForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Declare variables
            Int32 ClassAPurchased;
            Int32 ClassBPurchased;
            Int32 ClassCPurchased;
            int revenueTotal;

            //Checks for Valid Data and Completes Exception Handling if needed
            try
            {
                if (IsValidData())
                {

                    //Read tickets sold from corresponding textbox
                    ClassAPurchased = Int32.Parse(textBoxA1.Text);
                    ClassBPurchased = Int32.Parse(textBoxB1.Text);
                    ClassCPurchased = Int32.Parse(textBoxC1.Text);

                    //Calculate revenue for each ticket class
                    ClassAPurchased = ClassAPurchased * 15;
                    ClassBPurchased = ClassBPurchased * 12;
                    ClassCPurchased = ClassCPurchased * 9;

                    //calculate total revenue
                    revenueTotal = ClassAPurchased + ClassBPurchased + ClassCPurchased;

                    //Display calculations to corresponding revenue textbox with formatting
                    textBoxA2.Text = ClassAPurchased.ToString("c");
                    textBoxB2.Text = ClassBPurchased.ToString("c");
                    textBoxC2.Text = ClassCPurchased.ToString("c");
                    textBoxTotal.Text = revenueTotal.ToString("c");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
        }
            //Checks if user input has been entered and if input is correct data type
            public bool IsValidData()
        {
            return
                // Validate the Class A text box
                IsPresent(textBoxA1, "Class A") &&
                IsInteger(textBoxA1, "Class A") &&


                // Validate the Class B text box
                IsPresent(textBoxB1, "Class B") &&
                IsInteger(textBoxB1, "Class B") &&


                // Validate the Class C text box
                IsPresent(textBoxC1, "Class C") &&
                IsInteger(textBoxC1, "Class C");
                
        }

        // Checks if user has entered input and returns error message if no input has been entered
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        // Checks input for integer and returns error message if input is not an integer
        public bool IsInteger(TextBox textBox, string name)
        {
            Int32 number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        // 'Clear' Button code
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the form
            textBoxA1.Text = "";
            textBoxB1.Text = "";
            textBoxC1.Text = "";
            textBoxA2.Text = "";
            textBoxB2.Text = "";
            textBoxC2.Text = "";
            textBoxTotal.Text = "";
        }

        // Close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

