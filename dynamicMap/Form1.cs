using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamicMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillmap();
            liveDash.Text = "Map Details";
            profile.Text = "Profile";

            // add pages to tab control
            myTab.Controls.Add(liveDash);
            myTab.Controls.Add(profile);

            profile.Controls.Add(gymCount);

            //this is for testing purposes
            //toggle.Show();
            //toggle.Controls.Add(gymCount);
            //listBox1.Items.Add(myBiome.BackColor.ToString());
        }

        //form 2 stuff WORK IN PROGRESS - disreguard for now
        Form toggle = new Form();
        bool[] badges = new bool[88];
        int badgeCount = 0;
        bool winner = false;
        Label gymCount = new Label();
        bool overworld = true;
        TabControl myTab = new TabControl();
        TabPage liveDash = new TabPage();
        TabPage profile = new TabPage();

        private void gymThings()
        {
            // clear the dash controls
            liveDash.Controls.Clear();
            Button enter = new Button();
            enter.Dock = DockStyle.Bottom;
            enter.Height = sizeVar * 2;

            if (mySq[whereImAt].Name == "city")
            {
                if (badges[badgeCount] != true)
                {
                    //initiate gym battle
                    enter.Text = "Enter Battle!";
                    liveDash.Controls.Add(enter);
                    enter.Click += (s, e) =>
                    {
                        enterBattle();
                    };
                }
                else
                {
                    enter.Text = "You've already won this battle!";
                    enter.Enabled = false;
                }
                
            }
        }

        private void enterBattle()
        {
            // clear the dash controls
            liveDash.Controls.Clear();

            // hide map
            for (int i = 0; i < num; i++)
            {
                mySq[i].Visible = false;
            }

            //disable keys
            overworld = false;

            Button myBtn = new Button();
            myBtn.Text = "Click to win this battle!";
            myBtn.Dock = DockStyle.Fill;
            Controls.Add(myBtn);
            myBtn.Click += (s, e) =>
            {
                // reshow map
                for (int i = 0; i < num; i++)
                {
                    mySq[i].Visible = true;
                }
                //enable keys
                overworld = true;
                winner = true;
                checkForWinner();
            };

        }

        private void checkForWinner()
        {
            if (winner == true)
            {
                badges[badgeCount] = true;
                badgeCount = badgeCount + 1;
                gymCount.Text = "Badges" + badgeCount.ToString();
                winner = false;
            }
        }
        // disreguard ^^


        

        

        // self explainatory
        string avatar = "https://cdn.bulbagarden.net/upload/9/93/RedRGBwalkdown.png";
        int whereImAt = 224; // starting picturebox on load *pallet town*

        // coordinates for positioning the sqaures in a map format
        int x = 0;
        int y = 0;

        // size of each of the squares in pixels
        int sizeVar = 25;
        
        // variable controls for loops when making the map
        // side note: i made these as globals so that i could mess around with size and not have to dig through code
        int ColNum = 0;
        int numOfCols = 20;

        // total number of squares
        int num = 1360 / 4;
        PictureBox[] mySq = new PictureBox[1360 / 4];


        private void fillmap()
        {
            

            //load the image (for background)
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            //for every integer up to the number of pictureBoxes **mysq[]** created, give me a color from my image
            for (int i = 0; i < num; i++)
            {
                //need a control
                PictureBox myBiome = new PictureBox();

                //grab & set the color from my image
                Color gotColor = bmp.GetPixel(x + 5, y + 5);
                gotColor = Color.FromArgb(gotColor.R, gotColor.G, gotColor.B);
                
                //set the control backcolor to the color we got
                myBiome.BackColor = gotColor;

                //name the boxes by color generated
                if (myBiome.BackColor == Color.FromArgb(0,0,255))
                {
                    //blue
                    myBiome.Name = "no"; //no currently means "not walkable" i use it for pathing
                }
                else if (myBiome.BackColor == Color.FromArgb(0,128,0))
                {
                    //green
                    myBiome.Name = "no";
                }
                else if (myBiome.BackColor == Color.FromArgb(128,128,128))
                {
                    //grey
                    myBiome.Name = "city";
                }
                else if (myBiome.BackColor ==Color.FromArgb(255,255,255))
                {
                    //white
                    myBiome.Name = "route";
                }
                else
                {
                    //will add more colors for snorlax, team rocket, etc..
                    myBiome.Name = "waterRoute";
                }
                
                // get the square at the current integer, and set it equal to our control we just created
                // this comes in handy later on when moving around the map...
                mySq[i] = myBiome;

                //place our newly created control
                myBiome.Location = new Point(x, y);
                ColNum = ColNum + 1;
                x = x + sizeVar;
                if (ColNum == numOfCols)
                {
                    x = 0;
                    y = y + sizeVar;
                    ColNum = 0;
                }
                
                //obvious
                myBiome.Width = sizeVar;
                myBiome.Height = sizeVar;
                Controls.Add(myBiome);
            }

            //whereImAt is set as a global. placing the avatar image onto the created map
            mySq[whereImAt].ImageLocation = avatar;
            mySq[whereImAt].SizeMode = PictureBoxSizeMode.Zoom;

            // adding a dashboard for statistics, badges, dex...
            
            myTab.Location = new Point(numOfCols * sizeVar, 0);
            myTab.Height = y;
            myTab.Width = (y / 3)*2;
            Controls.Add(myTab);


            //size of the form
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (overworld == true)
            {
                if (keyData == Keys.Up)
                {
                    // ONLY IMPLEMENTED HERE: if where im at is LESS than the number of coloums, dont move.
                    // otherwise we will get an out of bounds exception when trying to go UP (used for the top of the map bounds)
                    if (whereImAt < numOfCols)
                        return true;

                    // if the square im going to is not equal to no, then its pathable, and execute my code.
                    if (mySq[whereImAt - numOfCols].Name != "no")
                    {
                        // move avatar to new location
                        mySq[whereImAt - numOfCols].ImageLocation = mySq[whereImAt].ImageLocation;
                        mySq[whereImAt - numOfCols].SizeMode = PictureBoxSizeMode.Zoom;

                        // remove avatar from old location
                        mySq[whereImAt].ImageLocation = "";

                        // set the new position
                        whereImAt = whereImAt - numOfCols;
                    }
                    gymThings();
                    return true;
                }

                if (keyData == Keys.Down)
                {
                    //easy
                    if (mySq[whereImAt + numOfCols].Name != "no")
                    {
                        mySq[whereImAt + numOfCols].ImageLocation = mySq[whereImAt].ImageLocation;
                        mySq[whereImAt + numOfCols].SizeMode = PictureBoxSizeMode.Zoom;
                        mySq[whereImAt].ImageLocation = "";
                        whereImAt = whereImAt + numOfCols;
                    }
                    gymThings();
                    return true;
                }

                if (keyData == Keys.Left)
                {
                    //peasy
                    if (mySq[whereImAt - 1].Name != "no")
                    {
                        mySq[whereImAt - 1].ImageLocation = mySq[whereImAt].ImageLocation;
                        mySq[whereImAt - 1].SizeMode = PictureBoxSizeMode.Zoom;
                        mySq[whereImAt].ImageLocation = "";
                        whereImAt = whereImAt - 1;
                    }
                    gymThings();
                    return true;
                }

                if (keyData == Keys.Right)
                {
                    //lemon
                    if (mySq[whereImAt + 1].Name != "no")
                    {
                        mySq[whereImAt + 1].ImageLocation = mySq[whereImAt].ImageLocation;
                        mySq[whereImAt + 1].SizeMode = PictureBoxSizeMode.Zoom;
                        mySq[whereImAt].ImageLocation = "";
                        whereImAt = whereImAt + 1;
                    }
                    gymThings();
                    return true;
                }

                
            }

            //squeezy
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}
