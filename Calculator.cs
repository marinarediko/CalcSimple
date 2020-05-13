﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcSimple
{
    public partial class CalcSimple : Form
    {

        char decimalSeperator;
        double numOne = 0;
        double numTwo = 0;
        string operation;
        public CalcSimple()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decimalSeperator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            this.BackColor = Color.LightSeaGreen;

            string buttonName = null;
            Button button = null;
            for (int i=0; i<10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                //button.Font = new Font("Tahome", 22f);
                Display.Text = "0";
            }
           
        }

        private void Button_Click(object sender, EventArgs e)
        {
          
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else if (Display.Text == "-0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(decimalSeperator);
            if (!weHaveDot) 
            {  
                if (Display.Text == "")
            {
                Display.Text += "0" + decimalSeperator;
            }
            else
                Display.Text += decimalSeperator;
            }
          
            
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
                string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "0";
            }    
                Display.Text = s;

        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
           /* string s = Display.Text;
              if (s.Substring(0, 1) != "-")
                  Display.Text = "-" + Display.Text;
              else
                  Display.Text = s.Substring(1, s.Length-1);*/
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = Convert.ToString(number);
            }
            catch 
            { 
            
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
            operation = ((Button)sender).Text;
        }
      
        private void buttonResult_Click(object sender, EventArgs e)
        {
            numTwo = Convert.ToDouble(Display.Text);
            

            if (operation == "+")
            {
                Display.Text = Convert.ToString(numOne + numTwo);
            }
            else if (operation == "-")
            {
                Display.Text = Convert.ToString(numOne - numTwo);
            }
            else if (operation == "x")
            {
                Display.Text = Convert.ToString(numOne * numTwo);
            }
            else if (operation == "/")
            {
                Display.Text = Convert.ToString(numOne / numTwo);
            }
        }

    }

}
