
namespace WindowsFormsApp1
{
    partial class cardOfPet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.label_breed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_ownerName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_passportNumber = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_dateRegistry = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_birthday = new System.Windows.Forms.Label();
            this.label_wool = new System.Windows.Forms.Label();
            this.label_size = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_category = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(944, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "В реестр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.event_Click_CloseWindow);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сформировать паспорт ДЖ в Word";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Экспорт записей в Excel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1006, 339);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Фото/документы";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1006, 339);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ветеренарные назначения";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1006, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Дегельминтизация/Обработка от экто- и эндопаразитов";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1006, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вакцинация";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox_photo);
            this.tabPage1.Controls.Add(this.label_breed);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label_ownerName);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label_passportNumber);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label_dateRegistry);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label_birthday);
            this.tabPage1.Controls.Add(this.label_wool);
            this.tabPage1.Controls.Add(this.label_size);
            this.tabPage1.Controls.Add(this.label_gender);
            this.tabPage1.Controls.Add(this.label_category);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label_name);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1006, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные характеристики животного";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_photo.Location = new System.Drawing.Point(357, 29);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(253, 255);
            this.pictureBox_photo.TabIndex = 46;
            this.pictureBox_photo.TabStop = false;
            // 
            // label_breed
            // 
            this.label_breed.AutoSize = true;
            this.label_breed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_breed.Location = new System.Drawing.Point(75, 87);
            this.label_breed.Name = "label_breed";
            this.label_breed.Size = new System.Drawing.Size(34, 17);
            this.label_breed.TabIndex = 45;
            this.label_breed.Text = "null";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(9, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Порода:";
            // 
            // label_ownerName
            // 
            this.label_ownerName.AutoSize = true;
            this.label_ownerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ownerName.Location = new System.Drawing.Point(128, 267);
            this.label_ownerName.Name = "label_ownerName";
            this.label_ownerName.Size = new System.Drawing.Size(34, 17);
            this.label_ownerName.TabIndex = 43;
            this.label_ownerName.Text = "null";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(9, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "Имя владельца:";
            // 
            // label_passportNumber
            // 
            this.label_passportNumber.AutoSize = true;
            this.label_passportNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_passportNumber.Location = new System.Drawing.Point(136, 239);
            this.label_passportNumber.Name = "label_passportNumber";
            this.label_passportNumber.Size = new System.Drawing.Size(86, 17);
            this.label_passportNumber.TabIndex = 41;
            this.label_passportNumber.Text = "№0000000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(9, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 40;
            this.label10.Text = "Номер паспорта:";
            // 
            // label_dateRegistry
            // 
            this.label_dateRegistry.AutoSize = true;
            this.label_dateRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateRegistry.Location = new System.Drawing.Point(148, 212);
            this.label_dateRegistry.Name = "label_dateRegistry";
            this.label_dateRegistry.Size = new System.Drawing.Size(90, 17);
            this.label_dateRegistry.TabIndex = 39;
            this.label_dateRegistry.Text = "00.00.0000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Дата регистрации:";
            // 
            // label_birthday
            // 
            this.label_birthday.AutoSize = true;
            this.label_birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_birthday.Location = new System.Drawing.Point(122, 186);
            this.label_birthday.Name = "label_birthday";
            this.label_birthday.Size = new System.Drawing.Size(90, 17);
            this.label_birthday.TabIndex = 37;
            this.label_birthday.Text = "00.00.0000";
            // 
            // label_wool
            // 
            this.label_wool.AutoSize = true;
            this.label_wool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_wool.Location = new System.Drawing.Point(75, 161);
            this.label_wool.Name = "label_wool";
            this.label_wool.Size = new System.Drawing.Size(34, 17);
            this.label_wool.TabIndex = 36;
            this.label_wool.Text = "null";
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_size.Location = new System.Drawing.Point(75, 137);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(34, 17);
            this.label_size.TabIndex = 35;
            this.label_size.Text = "null";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gender.Location = new System.Drawing.Point(51, 113);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(34, 17);
            this.label_gender.TabIndex = 34;
            this.label_gender.Text = "null";
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_category.Location = new System.Drawing.Point(96, 61);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(34, 17);
            this.label_category.TabIndex = 33;
            this.label_category.Text = "null";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Дата рождения:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Шерсть:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Размер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Пол:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Категория:";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(6, 15);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(105, 31);
            this.label_name.TabIndex = 22;
            this.label_name.Text = "Кличка";
            this.label_name.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1014, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // cardOfPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 418);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "cardOfPet";
            this.Text = "Учетная карточка домашнего животного";
            this.Load += new System.EventHandler(this.event_cardOfPet_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.Label label_breed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_ownerName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_passportNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_dateRegistry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_birthday;
        private System.Windows.Forms.Label label_wool;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TabControl tabControl1;
    }
}