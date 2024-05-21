using Bochaterowie;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CharacterCreator
{
    partial class Form1
    {
       
        // Deklaracje kontrolek
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btnCreateCharacter;
        private System.Windows.Forms.ListBox lstCharacters;
        private ListBox lstQuests;
        // Lista przechowująca postacie
        private List<Character> charactersList = new List<Character>();

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnCreateCharacter = new System.Windows.Forms.Button();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.btnFight = new System.Windows.Forms.Button();
            this.lstQuests = new System.Windows.Forms.ListBox();
            this.lblAvailableTokens = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.zapiszLog = new System.Windows.Forms.Button();
            this.lstBuffs = new System.Windows.Forms.ListBox();
            this.lblAvailableCoins = new System.Windows.Forms.Label();
            this.Shop = new System.Windows.Forms.Button();
            this.lblWarriorCount = new System.Windows.Forms.Label();
            this.lblWizardCount = new System.Windows.Forms.Label();
            this.lblArcherCount = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Zapisz = new System.Windows.Forms.Button();
            this.Wcztaj = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblJednorozecCount = new System.Windows.Forms.Label();
            this.lblZabojcaCount = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(50, 100);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(200, 21);
            this.cmbClass.TabIndex = 1;
            // 
            // btnCreateCharacter
            // 
            this.btnCreateCharacter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCreateCharacter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateCharacter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreateCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCharacter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateCharacter.Location = new System.Drawing.Point(50, 143);
            this.btnCreateCharacter.Name = "btnCreateCharacter";
            this.btnCreateCharacter.Size = new System.Drawing.Size(200, 30);
            this.btnCreateCharacter.TabIndex = 2;
            this.btnCreateCharacter.Text = "Create Character";
            this.btnCreateCharacter.UseVisualStyleBackColor = true;
            this.btnCreateCharacter.Click += new System.EventHandler(this.btnCreateCharacter_Click);
            // 
            // lstCharacters
            // 
            this.lstCharacters.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.ItemHeight = 16;
            this.lstCharacters.Location = new System.Drawing.Point(712, 50);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(500, 484);
            this.lstCharacters.TabIndex = 3;
            // 
            // btnFight
            // 
            this.btnFight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFight.Enabled = false;
            this.btnFight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFight.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnFight.Location = new System.Drawing.Point(506, 363);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(200, 30);
            this.btnFight.TabIndex = 12;
            this.btnFight.Text = "Rozpocznij walkę";
            this.btnFight.UseVisualStyleBackColor = true;
            this.btnFight.Click += new System.EventHandler(this.btnFight_Click);
            // 
            // lstQuests
            // 
            this.lstQuests.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lstQuests.FormattingEnabled = true;
            this.lstQuests.ItemHeight = 15;
            this.lstQuests.Location = new System.Drawing.Point(506, 50);
            this.lstQuests.Name = "lstQuests";
            this.lstQuests.Size = new System.Drawing.Size(200, 289);
            this.lstQuests.TabIndex = 11;
            this.lstQuests.SelectedIndexChanged += new System.EventHandler(this.lstQuests_SelectedIndexChanged);
            // 
            // lblAvailableTokens
            // 
            this.lblAvailableTokens.AutoSize = true;
            this.lblAvailableTokens.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvailableTokens.Location = new System.Drawing.Point(319, 150);
            this.lblAvailableTokens.Name = "lblAvailableTokens";
            this.lblAvailableTokens.Size = new System.Drawing.Size(27, 16);
            this.lblAvailableTokens.TabIndex = 13;
            this.lblAvailableTokens.Text = "----";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(506, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "Reset Box";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // zapiszLog
            // 
            this.zapiszLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.zapiszLog.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.zapiszLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.zapiszLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zapiszLog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.zapiszLog.Location = new System.Drawing.Point(506, 525);
            this.zapiszLog.Name = "zapiszLog";
            this.zapiszLog.Size = new System.Drawing.Size(200, 23);
            this.zapiszLog.TabIndex = 15;
            this.zapiszLog.Text = "Zapisz Logi";
            this.zapiszLog.UseVisualStyleBackColor = true;
            this.zapiszLog.Click += new System.EventHandler(this.btnExportToFile_Click);
            // 
            // lstBuffs
            // 
            this.lstBuffs.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lstBuffs.FormattingEnabled = true;
            this.lstBuffs.ItemHeight = 14;
            this.lstBuffs.Location = new System.Drawing.Point(50, 190);
            this.lstBuffs.Name = "lstBuffs";
            this.lstBuffs.Size = new System.Drawing.Size(200, 88);
            this.lstBuffs.TabIndex = 16;
            // 
            // lblAvailableCoins
            // 
            this.lblAvailableCoins.AutoSize = true;
            this.lblAvailableCoins.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvailableCoins.Location = new System.Drawing.Point(319, 171);
            this.lblAvailableCoins.Name = "lblAvailableCoins";
            this.lblAvailableCoins.Size = new System.Drawing.Size(27, 16);
            this.lblAvailableCoins.TabIndex = 17;
            this.lblAvailableCoins.Text = "----";
            // 
            // Shop
            // 
            this.Shop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Shop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Shop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Shop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Shop.Location = new System.Drawing.Point(50, 291);
            this.Shop.Name = "Shop";
            this.Shop.Size = new System.Drawing.Size(200, 27);
            this.Shop.TabIndex = 18;
            this.Shop.Text = "Kup Buffa";
            this.Shop.UseVisualStyleBackColor = true;
            this.Shop.Click += new System.EventHandler(this.btnBuyBuffForGroup_Click);
            // 
            // lblWarriorCount
            // 
            this.lblWarriorCount.AutoSize = true;
            this.lblWarriorCount.Location = new System.Drawing.Point(132, 766);
            this.lblWarriorCount.Name = "lblWarriorCount";
            this.lblWarriorCount.Size = new System.Drawing.Size(19, 13);
            this.lblWarriorCount.TabIndex = 19;
            this.lblWarriorCount.Text = "----";
            // 
            // lblWizardCount
            // 
            this.lblWizardCount.AutoSize = true;
            this.lblWizardCount.Location = new System.Drawing.Point(636, 766);
            this.lblWizardCount.Name = "lblWizardCount";
            this.lblWizardCount.Size = new System.Drawing.Size(19, 13);
            this.lblWizardCount.TabIndex = 20;
            this.lblWizardCount.Text = "----";
            // 
            // lblArcherCount
            // 
            this.lblArcherCount.AutoSize = true;
            this.lblArcherCount.Location = new System.Drawing.Point(393, 766);
            this.lblArcherCount.Name = "lblArcherCount";
            this.lblArcherCount.Size = new System.Drawing.Size(19, 13);
            this.lblArcherCount.TabIndex = 21;
            this.lblArcherCount.Text = "----";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CharacterCreator.Properties.Resources.magg;
            this.pictureBox3.Location = new System.Drawing.Point(531, 567);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(206, 185);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CharacterCreator.Properties.Resources.rang;
            this.pictureBox2.Location = new System.Drawing.Point(299, 567);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 185);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CharacterCreator.Properties.Resources.woj;
            this.pictureBox1.Location = new System.Drawing.Point(50, 567);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(274, 190);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 92);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "Buffy - 20 coinów\r\nSuper Siła - 5\r\nSuper Zręczność - 5\r\nSuper Inteligencja - 5 \r\n" +
    "Zwiększone Zdrowie - 20\r\nDodatkowy Damage - 10\r\nZwiększona Odporność - 5\r\n\r\n";
            // 
            // Zapisz
            // 
            this.Zapisz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Zapisz.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Zapisz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Zapisz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Zapisz.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Zapisz.Location = new System.Drawing.Point(50, 420);
            this.Zapisz.Name = "Zapisz";
            this.Zapisz.Size = new System.Drawing.Size(75, 23);
            this.Zapisz.TabIndex = 26;
            this.Zapisz.Text = "Zapisz Gre";
            this.Zapisz.UseVisualStyleBackColor = true;
            this.Zapisz.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // Wcztaj
            // 
            this.Wcztaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Wcztaj.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Wcztaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Wcztaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wcztaj.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Wcztaj.Location = new System.Drawing.Point(175, 420);
            this.Wcztaj.Name = "Wcztaj";
            this.Wcztaj.Size = new System.Drawing.Size(75, 23);
            this.Wcztaj.TabIndex = 27;
            this.Wcztaj.Text = "Wczytaj Gre";
            this.Wcztaj.UseVisualStyleBackColor = true;
            this.Wcztaj.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CharacterCreator.Properties.Resources.sin;
            this.pictureBox4.Location = new System.Drawing.Point(783, 567);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(206, 185);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CharacterCreator.Properties.Resources.UNICORN;
            this.pictureBox5.Location = new System.Drawing.Point(1034, 567);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(206, 185);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // lblJednorozecCount
            // 
            this.lblJednorozecCount.AutoSize = true;
            this.lblJednorozecCount.Location = new System.Drawing.Point(1124, 766);
            this.lblJednorozecCount.Name = "lblJednorozecCount";
            this.lblJednorozecCount.Size = new System.Drawing.Size(19, 13);
            this.lblJednorozecCount.TabIndex = 30;
            this.lblJednorozecCount.Text = "----";
            // 
            // lblZabojcaCount
            // 
            this.lblZabojcaCount.AutoSize = true;
            this.lblZabojcaCount.Location = new System.Drawing.Point(881, 766);
            this.lblZabojcaCount.Name = "lblZabojcaCount";
            this.lblZabojcaCount.Size = new System.Drawing.Size(19, 13);
            this.lblZabojcaCount.TabIndex = 31;
            this.lblZabojcaCount.Text = "----";
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.richTextBox.Location = new System.Drawing.Point(712, 50);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(500, 484);
            this.richTextBox.TabIndex = 32;
            this.richTextBox.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(274, 50);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(214, 92);
            this.textBox2.TabIndex = 33;
            this.textBox2.Text = "Wojownik - 1 token\r\nŁucznik - 2 tokeny\r\nMag - 2 tokeny\r\nZabójca - 3 tokeny\r\nPotęż" +
    "ny naładowany miłością JEDNOROŻEC - 20 TOKENÓW AAAAA!\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterCreator.Properties.Resources.hand;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 1000);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.lblZabojcaCount);
            this.Controls.Add(this.lblJednorozecCount);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Wcztaj);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblArcherCount);
            this.Controls.Add(this.lblWizardCount);
            this.Controls.Add(this.lblWarriorCount);
            this.Controls.Add(this.Shop);
            this.Controls.Add(this.lblAvailableCoins);
            this.Controls.Add(this.lstBuffs);
            this.Controls.Add(this.zapiszLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAvailableTokens);
            this.Controls.Add(this.lstCharacters);
            this.Controls.Add(this.btnCreateCharacter);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnFight);
            this.Controls.Add(this.lstQuests);
            this.Name = "Form1";
            this.Text = "Hobby Unicorn Land";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    
        private Button btnFight;
        private Label lblAvailableTokens;
        private Button button1;
        private Button zapiszLog;
        private ListBox lstBuffs;
        private Label lblAvailableCoins;
        private Button Shop;
        private Label lblWarriorCount;
        private Label lblWizardCount;
        private Label lblArcherCount;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox textBox1;
        private Button Zapisz;
        private Button Wcztaj;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Label lblJednorozecCount;
        private Label lblZabojcaCount;
        private RichTextBox richTextBox;
        private TextBox textBox2;
    }

    }
