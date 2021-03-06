﻿using System;
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
            loadThings();
        }

        private void loadThings()
        {
            liveDash.Text = "Map Details";
            profile.Text = "Profile";

            // add pages to tab control
            myTab.Controls.Add(liveDash);
            myTab.Controls.Add(profile);
            

            firstPosMon.ImageLocation = "https://cdn.bulbagarden.net/upload/a/a3/Spr_1b_001.png";
            SecPosMon.ImageLocation = "https://cdn.bulbagarden.net/upload/9/9d/Spr_1b_004.png";
            thirdPosMon.ImageLocation = "https://cdn.bulbagarden.net/upload/3/30/Spr_1b_007.png";
            opponent.ImageLocation = "https://cdn.bulbagarden.net/upload/thumb/3/30/FireRed_LeafGreen_Professor_Oak.png/180px-FireRed_LeafGreen_Professor_Oak.png";

            eventName.Text = "Pallet Town";
            eventName.Font = new Font("", 16.0f);
            leaderName.Text = "Professor Oak";
            type.Text = "Type...";
            quote.Text = "Hey! Wait! Don't go out! It's unsafe! Wild Pokémon live in tall grass! You need your own Pokémon for your protection. I know! Here, come with me!";
            quote.AutoSize = true;
            enterEvent.Text = "Follow Professor Oak!";
            opponent.BackColor = Color.White;
            firstPosMon.BackColor = Color.White;
            SecPosMon.BackColor = Color.White;
            thirdPosMon.BackColor = Color.White;

            //ground.RowCount = 3;
            //ground.ColumnCount = 1;
            //inner.RowCount = 2;
            //inner.ColumnCount = 2;
            //right.RowCount = 3;
            //right.ColumnCount = 1;
            //pictures.RowCount = 1;
            //pictures.ColumnCount = 4;

            ground.Dock = DockStyle.Fill;
            inner.Dock = DockStyle.Fill;
            right.Dock = DockStyle.Fill;
            pictures.Dock = DockStyle.Fill;
            eventName.Dock = DockStyle.Bottom;
            leaderName.Dock = DockStyle.Fill;
            type.Dock = DockStyle.Fill;
            enterEvent.Dock = DockStyle.Fill;
            opponent.Dock = DockStyle.Fill;
            quote.Dock = DockStyle.Bottom;
            firstPosMon.SizeMode = PictureBoxSizeMode.StretchImage;
            SecPosMon.SizeMode = PictureBoxSizeMode.StretchImage;
            thirdPosMon.SizeMode = PictureBoxSizeMode.StretchImage;
            opponent.SizeMode = PictureBoxSizeMode.StretchImage;

            //ground.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //inner.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //right.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //pictures.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            ground.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ground.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            ground.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ground.BackColor = Color.White;

            inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            inner.RowStyles.Add(new RowStyle(SizeType.Percent, 5f));
            inner.RowStyles.Add(new RowStyle(SizeType.Percent, 95f));

            right.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            pictures.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            pictures.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            pictures.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            pictures.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            ground.Controls.Add(eventName, 0, 0);
            ground.Controls.Add(inner, 0, 1);
            ground.Controls.Add(enterEvent, 0, 2);

            inner.Controls.Add(leaderName, 0, 0);
            inner.Controls.Add(opponent, 0, 1);
            inner.Controls.Add(type, 1, 0);
            inner.Controls.Add(right, 1, 1);
            
            right.Controls.Add(pictures, 0, 0);
            right.Controls.Add(quote, 0, 2);

            pictures.Controls.Add(firstPosMon, 0, 0);
            pictures.Controls.Add(SecPosMon, 1, 0);
            pictures.Controls.Add(thirdPosMon, 2, 0);
            
            liveDash.Controls.Add(ground);
            

        }

        //form 2 stuff WORK IN PROGRESS - disreguard for now
        //Form toggle = new Form();
        //bool[] badges = new bool[88];
        //int badgeCount = 0;
        //bool winner = false;
        //Label gymCount = new Label();
        bool overworld = true;


        //TabControl myTab = new TabControl();
        //TabPage liveDash = new TabPage();
        //TabPage profile = new TabPage();

        //private void gymThings()
        //{
        //    // clear the dash controls
        //    liveDash.Controls.Clear();
        //    Button enter = new Button();
        //    enter.Dock = DockStyle.Bottom;
        //    enter.Height = sizeVar * 2;

        //    if (mySq[whereImAt].Name == "city")
        //    {
        //        if (badges[badgeCount] != true)
        //        {
        //            //initiate gym battle
        //            enter.Text = "Enter Battle!";
        //            liveDash.Controls.Add(enter);
        //            enter.Click += (s, e) =>
        //            {
        //                enterBattle();
        //            };
        //        }
        //        else
        //        {
        //            enter.Text = "You've already won this battle!";
        //            enter.Enabled = false;
        //        }
                
        //    }
        //}

        //private void enterBattle()
        //{
        //    myTab.Visible = false;
        //    // clear the dash controls
        //    liveDash.Controls.Clear();

        //    // hide map
        //    for (int i = 0; i < num; i++)
        //    {
        //        mySq[i].Visible = false;
        //    }

        //    //disable keys
        //    overworld = false;

        //    Button myBtn = new Button();
        //    myBtn.Text = "Click to win this battle!";
        //    myBtn.Dock = DockStyle.Fill;
        //    Controls.Add(myBtn);
        //    myBtn.Click += (s, e) =>
        //    {
        //        myTab.Visible = true;
        //        // reshow map
        //        for (int i = 0; i < num; i++)
        //        {
        //            mySq[i].Visible = true;
        //        }
        //        //enable keys
        //        overworld = true;
        //        winner = true;
        //        checkForWinner();
        //    };

        //}

        //private void checkForWinner()
        //{
        //    if (winner == true)
        //    {
        //        badges[badgeCount] = true;
        //        badgeCount = badgeCount + 1;
        //        gymCount.Text = "Badges" + badgeCount.ToString();
        //        winner = false;
        //    }
        //}
        //// disreguard ^^


        TableLayoutPanel ground = new TableLayoutPanel();
        TableLayoutPanel inner = new TableLayoutPanel();
        TableLayoutPanel right = new TableLayoutPanel();
        TableLayoutPanel pictures = new TableLayoutPanel();
        Label eventName = new Label();
        Label leaderName = new Label();
        Label type = new Label();
        Label quote = new Label();
        Button enterEvent = new Button();
        PictureBox opponent = new PictureBox();
        PictureBox firstPosMon = new PictureBox();
        PictureBox SecPosMon = new PictureBox();
        PictureBox thirdPosMon = new PictureBox();


        bool[] isEvent = new bool[340];

        TabControl myTab = new TabControl();
        TabPage liveDash = new TabPage();
        TabPage profile = new TabPage();

        // check for event
        private void eventLogic()
        {
            // is this an event?
            if (isEvent[whereImAt] == true)
            {
                // what type of event is it
                eventType();
            }
            else
            {
                // do nothing
            }
        }

        private void eventType()
        {
            dashboardItems();
            if (mySq[whereImAt].Name == "city")
            {
                cityEvent();
            }
            else if (mySq[whereImAt].Name == "route")
            {
                routeEvent();
            }
        }

        private void dashboardItems()
        {
            eventName.Text = mySq[whereImAt].Name;
            eventName.Enabled = true;
            enterEvent.Text = "Enter " + eventName.Text + " battle!";
        }

        private void cityEvent()
        {
            //firstPosMon.ImageLocation = avatar;
            //SecPosMon.ImageLocation = avatar;
            //thirdPosMon.ImageLocation = avatar;
            //enterEvent.Click += (s, e) =>
            //{
            //    //
            //};
        }

        private void routeEvent()
        {
            //firstPosMon.ImageLocation = avatar;
            //SecPosMon.ImageLocation = avatar;
            //thirdPosMon.ImageLocation = avatar;
            //enterEvent.Click += (s, e) =>
            //{
            //    //
            //};
        }

        
        

        

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
                    isEvent[i] = true;
                }
                else if (myBiome.BackColor ==Color.FromArgb(255,255,255))
                {
                    //white
                    myBiome.Name = "route";
                    isEvent[i] = true;
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
                    eventLogic();
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
                    eventLogic();
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
                    eventLogic();
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
                    eventLogic();
                    return true;
                }

                
            }

            //squeezy
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}
