namespace SP3
{
    partial class MainForm
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
            this.TickerSymbol = new System.Windows.Forms.TextBox();
            this.StrikePrice = new System.Windows.Forms.TextBox();
            this.ExpiryDate = new System.Windows.Forms.TextBox();
            this.Ticker = new System.Windows.Forms.Label();
            this.StrikePriceLabel = new System.Windows.Forms.Label();
            this.Expiry = new System.Windows.Forms.Label();
            this.messageText = new System.Windows.Forms.TextBox();
            this.Decipher = new System.Windows.Forms.Button();
            this.AlertPriceLabel = new System.Windows.Forms.Label();
            this.UpperlimitLabel = new System.Windows.Forms.Label();
            this.LowerlimitLabel = new System.Windows.Forms.Label();
            this.orderType = new System.Windows.Forms.TextBox();
            this.BuyOption = new System.Windows.Forms.Button();
            this.alertPrice = new System.Windows.Forms.NumericUpDown();
            this.upperLimit = new System.Windows.Forms.NumericUpDown();
            this.lowerLimit = new System.Windows.Forms.NumericUpDown();
            this.buyStopLimit = new System.Windows.Forms.Button();
            this.numberOfContracts = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.alertPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TickerSymbol
            // 
            this.TickerSymbol.Location = new System.Drawing.Point(109, 147);
            this.TickerSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.TickerSymbol.Name = "TickerSymbol";
            this.TickerSymbol.Size = new System.Drawing.Size(132, 22);
            this.TickerSymbol.TabIndex = 2;
            // 
            // StrikePrice
            // 
            this.StrikePrice.Location = new System.Drawing.Point(109, 189);
            this.StrikePrice.Margin = new System.Windows.Forms.Padding(4);
            this.StrikePrice.Name = "StrikePrice";
            this.StrikePrice.Size = new System.Drawing.Size(132, 22);
            this.StrikePrice.TabIndex = 3;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Location = new System.Drawing.Point(109, 231);
            this.ExpiryDate.Margin = new System.Windows.Forms.Padding(4);
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.Size = new System.Drawing.Size(132, 22);
            this.ExpiryDate.TabIndex = 4;
            // 
            // Ticker
            // 
            this.Ticker.AutoSize = true;
            this.Ticker.Location = new System.Drawing.Point(10, 152);
            this.Ticker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ticker.Name = "Ticker";
            this.Ticker.Size = new System.Drawing.Size(47, 17);
            this.Ticker.TabIndex = 5;
            this.Ticker.Text = "Ticker";
            // 
            // StrikePriceLabel
            // 
            this.StrikePriceLabel.AutoSize = true;
            this.StrikePriceLabel.Location = new System.Drawing.Point(10, 194);
            this.StrikePriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StrikePriceLabel.Name = "StrikePriceLabel";
            this.StrikePriceLabel.Size = new System.Drawing.Size(80, 17);
            this.StrikePriceLabel.TabIndex = 6;
            this.StrikePriceLabel.Text = "Strike Price";
            // 
            // Expiry
            // 
            this.Expiry.AutoSize = true;
            this.Expiry.Location = new System.Drawing.Point(10, 236);
            this.Expiry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Expiry.Name = "Expiry";
            this.Expiry.Size = new System.Drawing.Size(46, 17);
            this.Expiry.TabIndex = 7;
            this.Expiry.Text = "Expiry";
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(13, 96);
            this.messageText.Margin = new System.Windows.Forms.Padding(4);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(248, 22);
            this.messageText.TabIndex = 8;
            // 
            // Decipher
            // 
            this.Decipher.Location = new System.Drawing.Point(286, 92);
            this.Decipher.Margin = new System.Windows.Forms.Padding(4);
            this.Decipher.Name = "Decipher";
            this.Decipher.Size = new System.Drawing.Size(100, 28);
            this.Decipher.TabIndex = 9;
            this.Decipher.Text = "Decipher";
            this.Decipher.UseVisualStyleBackColor = true;
            this.Decipher.Click += new System.EventHandler(this.Decipher_Click);
            // 
            // AlertPriceLabel
            // 
            this.AlertPriceLabel.AutoSize = true;
            this.AlertPriceLabel.Location = new System.Drawing.Point(10, 274);
            this.AlertPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlertPriceLabel.Name = "AlertPriceLabel";
            this.AlertPriceLabel.Size = new System.Drawing.Size(69, 17);
            this.AlertPriceLabel.TabIndex = 11;
            this.AlertPriceLabel.Text = "AlertPrice";
            // 
            // UpperlimitLabel
            // 
            this.UpperlimitLabel.AutoSize = true;
            this.UpperlimitLabel.Location = new System.Drawing.Point(10, 316);
            this.UpperlimitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpperlimitLabel.Name = "UpperlimitLabel";
            this.UpperlimitLabel.Size = new System.Drawing.Size(69, 17);
            this.UpperlimitLabel.TabIndex = 14;
            this.UpperlimitLabel.Text = "LimitPrice";
            // 
            // LowerlimitLabel
            // 
            this.LowerlimitLabel.AutoSize = true;
            this.LowerlimitLabel.Location = new System.Drawing.Point(10, 356);
            this.LowerlimitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LowerlimitLabel.Name = "LowerlimitLabel";
            this.LowerlimitLabel.Size = new System.Drawing.Size(69, 17);
            this.LowerlimitLabel.TabIndex = 15;
            this.LowerlimitLabel.Text = "StopPrice";
            // 
            // orderType
            // 
            this.orderType.Location = new System.Drawing.Point(286, 191);
            this.orderType.Margin = new System.Windows.Forms.Padding(4);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(100, 22);
            this.orderType.TabIndex = 16;
            // 
            // BuyOption
            // 
            this.BuyOption.Location = new System.Drawing.Point(13, 441);
            this.BuyOption.Margin = new System.Windows.Forms.Padding(4);
            this.BuyOption.Name = "BuyOption";
            this.BuyOption.Size = new System.Drawing.Size(100, 28);
            this.BuyOption.TabIndex = 17;
            this.BuyOption.Text = "Buy Option";
            this.BuyOption.UseVisualStyleBackColor = true;
            this.BuyOption.Click += new System.EventHandler(this.Buy_Click);
            // 
            // alertPrice
            // 
            this.alertPrice.DecimalPlaces = 2;
            this.alertPrice.Location = new System.Drawing.Point(109, 269);
            this.alertPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.alertPrice.Name = "alertPrice";
            this.alertPrice.Size = new System.Drawing.Size(132, 22);
            this.alertPrice.TabIndex = 18;
            // 
            // upperLimit
            // 
            this.upperLimit.DecimalPlaces = 2;
            this.upperLimit.Location = new System.Drawing.Point(109, 311);
            this.upperLimit.Name = "upperLimit";
            this.upperLimit.Size = new System.Drawing.Size(132, 22);
            this.upperLimit.TabIndex = 20;
            // 
            // lowerLimit
            // 
            this.lowerLimit.DecimalPlaces = 2;
            this.lowerLimit.Location = new System.Drawing.Point(109, 351);
            this.lowerLimit.Name = "lowerLimit";
            this.lowerLimit.Size = new System.Drawing.Size(132, 22);
            this.lowerLimit.TabIndex = 21;
            // 
            // buyStopLimit
            // 
            this.buyStopLimit.Location = new System.Drawing.Point(135, 441);
            this.buyStopLimit.Name = "buyStopLimit";
            this.buyStopLimit.Size = new System.Drawing.Size(106, 28);
            this.buyStopLimit.TabIndex = 22;
            this.buyStopLimit.Text = "BuyStopLimit";
            this.buyStopLimit.UseVisualStyleBackColor = true;
            this.buyStopLimit.Click += new System.EventHandler(this.buyStopLimit_Click);
            // 
            // numberOfContracts
            // 
            this.numberOfContracts.Location = new System.Drawing.Point(109, 391);
            this.numberOfContracts.Name = "numberOfContracts";
            this.numberOfContracts.Size = new System.Drawing.Size(132, 22);
            this.numberOfContracts.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Contracts";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(415, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(353, 574);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(788, 605);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfContracts);
            this.Controls.Add(this.buyStopLimit);
            this.Controls.Add(this.lowerLimit);
            this.Controls.Add(this.upperLimit);
            this.Controls.Add(this.alertPrice);
            this.Controls.Add(this.BuyOption);
            this.Controls.Add(this.orderType);
            this.Controls.Add(this.LowerlimitLabel);
            this.Controls.Add(this.UpperlimitLabel);
            this.Controls.Add(this.AlertPriceLabel);
            this.Controls.Add(this.Decipher);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.Expiry);
            this.Controls.Add(this.StrikePriceLabel);
            this.Controls.Add(this.Ticker);
            this.Controls.Add(this.ExpiryDate);
            this.Controls.Add(this.StrikePrice);
            this.Controls.Add(this.TickerSymbol);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "SavingsPlan";
            ((System.ComponentModel.ISupportInitialize)(this.alertPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TickerSymbol;
        private System.Windows.Forms.TextBox StrikePrice;
        private System.Windows.Forms.TextBox ExpiryDate;
        private System.Windows.Forms.Label Ticker;
        private System.Windows.Forms.Label StrikePriceLabel;
        private System.Windows.Forms.Label Expiry;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Button Decipher;
        private System.Windows.Forms.Label AlertPriceLabel;
        private System.Windows.Forms.Label UpperlimitLabel;
        private System.Windows.Forms.Label LowerlimitLabel;
        private System.Windows.Forms.TextBox orderType;
        private System.Windows.Forms.Button BuyOption;
        private System.Windows.Forms.NumericUpDown alertPrice;
        private System.Windows.Forms.NumericUpDown upperLimit;
        private System.Windows.Forms.NumericUpDown lowerLimit;
        private System.Windows.Forms.Button buyStopLimit;
        private System.Windows.Forms.NumericUpDown numberOfContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}