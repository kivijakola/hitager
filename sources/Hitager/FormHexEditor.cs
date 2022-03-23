using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Globalization;

namespace Hitager
{
    public partial class FormHexEditor : Core.FormEx
    {
		FormFind _formFind;
		FindOptions _findOptions = new FindOptions();
        FormGoTo _formGoto = new FormGoTo();
        string _fileName;
        PortHandler portHandler = new PortHandler();


        public FormHexEditor()
        {
            InitializeComponent();

			Init();

            hexBox.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, SystemFonts.MessageBoxFont.Size, SystemFonts.MessageBoxFont.Style);

			this.toolStrip.Renderer.RenderToolStripBorder += new ToolStripRenderEventHandler(Renderer_RenderToolStripBorder);
        }

		/// <summary>
		/// Removes the border on the right of the tool strip
		/// </summary>
		/// <param name="sender">the renderer</param>
		/// <param name="e">the event args</param>
		void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip.GetType() != typeof(ToolStrip))
				return;

			e.Graphics.DrawLine(new Pen(new SolidBrush(SystemColors.Control)), new Point(toolStrip.Width - 1, 0),
				new Point(toolStrip.Width - 1, toolStrip.Height));
		}

        /// <summary>
        /// Initializes the hex editor´s main form
        /// </summary>
        void Init()
        {
            DisplayText();

            ManageAbility();

			UpdateBitControlVisibility();

			//var selected = ;
			var defConverter = new DefaultByteCharConverter();
			ToolStripMenuItem miDefault = new ToolStripMenuItem();
			miDefault.Text = defConverter.ToString();
			miDefault.Tag = defConverter;
			miDefault.Click += new EventHandler(encodingMenuItem_Clicked);

			var ebcdicConverter = new EbcdicByteCharProvider();
			ToolStripMenuItem miEbcdic = new ToolStripMenuItem();
			miEbcdic.Text = ebcdicConverter.ToString();
			miEbcdic.Tag = ebcdicConverter;
			miEbcdic.Click += new EventHandler(encodingMenuItem_Clicked);

			encodingToolStripComboBox.Items.Add(defConverter);
			encodingToolStripComboBox.Items.Add(ebcdicConverter);

			encodingToolStripMenuItem.DropDownItems.Add(miDefault);
			encodingToolStripMenuItem.DropDownItems.Add(miEbcdic);
			encodingToolStripComboBox.SelectedIndex = 0;

            UpdateFormWidth();
        }

		void encodingMenuItem_Clicked(object sender, EventArgs e)
		{
			var converter = ((ToolStripMenuItem)sender).Tag;
			encodingToolStripComboBox.SelectedItem = converter;
		}

        /// <summary>
        /// Updates the File size status label
        /// </summary>
        void UpdateFileSizeStatus()
        {
            if (this.hexBox.ByteProvider == null)
                this.fileSizeToolStripStatusLabel.Text = string.Empty;
            else
                this.fileSizeToolStripStatusLabel.Text = Util.GetDisplayBytes(this.hexBox.ByteProvider.Length);
        }

        /// <summary>
        /// Displays the file name in the Form´s text property
        /// </summary>
        /// <param name="fileName">the file name to display</param>
        void DisplayText()
        {
            if (_fileName != null && _fileName.Length > 0)
            {
                string textFormat = "{0}{1} - {2}";
                string readOnly = ((DynamicFileByteProvider)hexBox.ByteProvider).ReadOnly
                    ? strings.Readonly : "";
                string text = Path.GetFileName(_fileName);
                this.Text = string.Format(textFormat, text, readOnly, Program.SoftwareName);
            }
            else
            {
                this.Text = Program.SoftwareName;
            }
        }

        /// <summary>
        /// Manages enabling or disabling of menu items and toolstrip buttons.
        /// </summary>
        void ManageAbility()
        {
            if (hexBox.ByteProvider == null)
            {
                saveToolStripMenuItem.Enabled = saveToolStripButton.Enabled = false;

                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
                goToToolStripMenuItem.Enabled = false;

                selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveToolStripMenuItem.Enabled = saveToolStripButton.Enabled = true;// hexBox.ByteProvider.HasChanges();

                findToolStripMenuItem.Enabled = true;
                findNextToolStripMenuItem.Enabled = true;
                goToToolStripMenuItem.Enabled = true;

                selectAllToolStripMenuItem.Enabled = true;
            }

            ManageAbilityForCopyAndPaste();
        }

        /// <summary>
        /// Manages enabling or disabling of menustrip items and toolstrip buttons for copy and paste
        /// </summary>
        void ManageAbilityForCopyAndPaste()
        {
            copyHexStringToolStripMenuItem.Enabled = 
                copyToolStripSplitButton.Enabled = copyToolStripMenuItem.Enabled = hexBox.CanCopy();

            cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled = hexBox.CanCut();
            pasteToolStripSplitButton.Enabled = pasteToolStripMenuItem.Enabled = hexBox.CanPaste();
            pasteHexToolStripMenuItem.Enabled = pasteHexToolStripMenuItem1.Enabled = hexBox.CanPasteHex();
        }

        /// <summary>
        /// Shows the open file dialog.
        /// </summary>
        void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }
            if (tabControl.SelectedIndex == 0 && hexBox.ByteProvider.Length >= 48)
            {
                string pages = "";
                for (int i = 0; i < 48; i++)
                {
                    pages += hexBox.ByteProvider.ReadByte(i).ToString("X2");
                }
                hitag2.setFields(pages);
            }
        }

        /// <summary>
        /// Opens a file.
        /// </summary>
        /// <param name="fileName">the file name of the file to open</param>
        public void OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Program.ShowMessage(strings.FileDoesNotExist);
                return;
            }

            if (CloseFile() == DialogResult.Cancel)
                return;

            try
            {
                DynamicFileByteProvider dynamicFileByteProvider;
                try
                {
                    // try to open in write mode
                    dynamicFileByteProvider = new DynamicFileByteProvider(fileName);
                    dynamicFileByteProvider.Changed += new EventHandler(byteProvider_Changed);
                    dynamicFileByteProvider.LengthChanged += new EventHandler(byteProvider_LengthChanged);
                }
                catch (IOException) // write mode failed
                {
                    try
                    {
                        // try to open in read-only mode
                        dynamicFileByteProvider = new DynamicFileByteProvider(fileName, true);
                        if (Program.ShowQuestion(strings.OpenReadonly) == DialogResult.No)
                        {
                            dynamicFileByteProvider.Dispose();
                            return;
                        }
                    }
                    catch (IOException) // read-only also failed
                    {
                        // file cannot be opened
                        Program.ShowError(strings.OpenFailed);
                        return;
                    }
                }

                hexBox.ByteProvider = dynamicFileByteProvider;
                _fileName = fileName;

                DisplayText();

                UpdateFileSizeStatus();

                RecentFileHandler.AddFile(fileName);
            }
            catch (Exception ex1)
            {
                Program.ShowError(ex1);
                return;
            }
            finally
            {

                ManageAbility();
            }
        }

        /// <summary>
        /// Saves the current file.
        /// </summary>
        void SaveFile()
        {
            if (hexBox.ByteProvider == null)
                return;

            try
            {
                IByteProvider byter = hexBox.ByteProvider;
                int length = (int)byter.Length;
                byte[] bytes = new byte[length];
                for (int i = 0; i < byter.Length; i++)
                    bytes[i] = byter.ReadByte(i);

                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.DefaultExt = "bin";
                saveFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Write(bytes, 0, length);
                        myStream.Close();
                    }
                }
            }
            catch (Exception ex1)
            {
                Program.ShowError(ex1);
            }
            finally
            {
                ManageAbility();
            }
        }

        /// <summary>
        /// Closes the current file
        /// </summary>
        /// <returns>OK, if the current file was closed.</returns>
        DialogResult CloseFile()
        {
            if (hexBox.ByteProvider == null)
                return DialogResult.OK;

            try

            {
                if (hexBox.ByteProvider != null && hexBox.ByteProvider.HasChanges())
                {
                    DialogResult res = MessageBox.Show(strings.SaveChangesQuestion,
                        Program.SoftwareName,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        SaveFile();
                        CleanUp();
                    }
                    else if (res == DialogResult.No)
                    {
                        CleanUp();
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        return res;
                    }

                    return res;
                }
                else
                {
                    CleanUp();
                    return DialogResult.OK;
                }
            }
            finally
            {
                ManageAbility();
            }
        }

        void CleanUp()
        {
            if (hexBox.ByteProvider != null)
            {
                IDisposable byteProvider = hexBox.ByteProvider as IDisposable;
                if (byteProvider != null)
                    byteProvider.Dispose();
                hexBox.ByteProvider = null;
            }
            _fileName = null;
            DisplayText();
        }

        /// <summary>
        /// Opens the Find dialog
        /// </summary>
        void Find()
        {
			ShowFind();
        }

		/// <summary>
		/// Creates a new FormFind dialog
		/// </summary>
		/// <returns>the form find dialog</returns>
		FormFind ShowFind()
		{
			if (_formFind == null || _formFind.IsDisposed)
			{
				_formFind = new FormFind();
				_formFind.HexBox = this.hexBox;
				_formFind.FindOptions = _findOptions;
				_formFind.Show(this);
			}
			else
			{
				_formFind.Focus();
			}
			return _formFind;
		}

        /// <summary>
        /// Find next match
        /// </summary>
        void FindNext()
        {
			ShowFind().FindNext();
        }

        /// <summary>
        /// Aborts the current find process
        /// </summary>
        void FormFindCancel_Closed(object sender, EventArgs e)
        {
            hexBox.AbortFind();
        }

        /// <summary>
        /// Displays the goto byte dialog.
        /// </summary>
        void Goto()
        {
            _formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
            _formGoto.SetDefaultValue(hexBox.SelectionStart);
            if (_formGoto.ShowDialog() == DialogResult.OK)
            {
                hexBox.SelectionStart = _formGoto.GetByteIndex();
                hexBox.SelectionLength = 1;
                hexBox.Focus();
            }
        }

        /// <summary>
        /// Enables drag&drop
        /// </summary>
        void hexBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        /// <summary>
        /// Processes a file drop
        /// </summary>
        void hexBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            object oFileNames = e.Data.GetData(DataFormats.FileDrop);
            string[] fileNames = (string[])oFileNames;
            if (fileNames.Length == 1)
            {
                OpenFile(fileNames[0]);
            }
        }

        void hexBox_Copied(object sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_CopiedHex(object sender, EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_SelectionLengthChanged(object sender, System.EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void hexBox_SelectionStartChanged(object sender, System.EventArgs e)
        {
            ManageAbilityForCopyAndPaste();
        }

        void Position_Changed(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = string.Format("Ln {0}    Col {1}",
                hexBox.CurrentLine, hexBox.CurrentPositionInLine);

			string bitPresentation = string.Empty;

			byte? currentByte = hexBox.ByteProvider != null && hexBox.ByteProvider.Length > hexBox.SelectionStart
				? hexBox.ByteProvider.ReadByte(hexBox.SelectionStart)
				: (byte?)null;

			BitInfo bitInfo = currentByte != null ? new BitInfo((byte)currentByte, hexBox.SelectionStart) : null;

			if (bitInfo != null)
			{
				byte currentByteNotNull = (byte)currentByte;
				bitPresentation = string.Format("Bits of Byte {0}: {1}"
					, hexBox.SelectionStart
					, bitInfo.ToString()
					);
			}

			this.bitToolStripStatusLabel.Text = bitPresentation;

			this.bitControl1.BitInfo = bitInfo;
        }

        void byteProvider_Changed(object sender, EventArgs e)
        {
            ManageAbility();
        }

        void byteProvider_LengthChanged(object sender, EventArgs e)
        {
            UpdateFileSizeStatus();
        }

        void open_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        void save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        void cut_Click(object sender, EventArgs e)
        {
            this.hexBox.Cut();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            this.hexBox.Copy();
        }

        void paste_Click(object sender, EventArgs e)
        {
            this.hexBox.Paste();
        }

        private void copyHex_Click(object sender, EventArgs e)
        {
            this.hexBox.CopyHex();
        }

        private void pasteHex_Click(object sender, EventArgs e)
        {
            this.hexBox.PasteHex();
        }

        void find_Click(object sender, EventArgs e)
        {
            this.Find();
        }

        void findNext_Click(object sender, EventArgs e)
        {
            this.FindNext();
        }

        void goTo_Click(object sender, EventArgs e)
        {
            this.Goto();
        }

        void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hexBox.SelectAll();
        }

        void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void about_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        void recentFiles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            RecentFileHandler.FileMenuItem fmi = (RecentFileHandler.FileMenuItem)e.ClickedItem;
            this.OpenFile(fmi.FileName);
        }

        void options_Click(object sender, EventArgs e)
        {
            new FormOptions().ShowDialog();
        }

        void FormHexEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = CloseFile();
            if (result == DialogResult.Cancel)
                e.Cancel = true;
		}

		void toolStripEncoding_SelectedIndexChanged(object sender, EventArgs e)
		{
			hexBox.ByteCharConverter = encodingToolStripComboBox.SelectedItem as IByteCharConverter;

			foreach (ToolStripMenuItem encodingMenuItem in encodingToolStripMenuItem.DropDownItems)
				encodingMenuItem.Checked = (encodingMenuItem.Tag == hexBox.ByteCharConverter);
		}

		void bitsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			UpdateBitControlVisibility();
		}

		void UpdateBitControlVisibility()
		{
            if (Util.DesignMode)
                return;

			if (bitsToolStripMenuItem.Checked)
			{
                hexBox.Height -= bitControl1.Height;
				bitControl1.Visible = true;
			}
			else
			{
                hexBox.Height += bitControl1.Height;
				bitControl1.Visible = false;
			}
		}

		void bitControl1_BitChanged(object sender, EventArgs e)
		{
			hexBox.ByteProvider.WriteByte(bitControl1.BitInfo.Position, bitControl1.BitInfo.Value);
			hexBox.Invalidate();
		}

        void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        void hexBox_RequiredWidthChanged(object sender, EventArgs e)
        {
            UpdateFormWidth();
        }

        void UpdateFormWidth()
        {
            //this.Width = this.hexBox.RequiredWidth + 100;
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void portList_Click(object sender, EventArgs e)
        {

        }


        private void FormHexEditor_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portList.Items.Clear();
            foreach (var a in ports)
            {
                portList.Items.Add(a);
            }
            portList.SelectedIndex = portList.Items.Count-1;
            hitag2.SetPortHandler(ref portHandler);
            hitag2.setHexbox(ref hexBox);
            portHandler.setPort(portList.SelectedItem.ToString());
            this.portHandler.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            hitagAes.SetPortHandler(ref portHandler);
            hitagAes.setHexbox(ref hexBox);
            hitag2EEapp.setHexbox(ref hexBox);
            hitag2EEapp.SetPortHandler(ref portHandler);
            serialDebugger1.SetPortHandler(ref portHandler);
            hitagPro.SetPortHandler(ref portHandler);
            hitagPro.setHexbox(ref hexBox);

            hitagExtended.SetPortHandler(ref portHandler);
            hitagExtended.setHexbox(ref hexBox);

            hitag3.SetPortHandler(ref portHandler);
            hitag3.setHexbox(ref hexBox);

            bmwHt2.SetPortHandler(ref portHandler);
            bmwHt2.setHexbox(ref hexBox);

            superChip.SetPortHandler(ref portHandler);
            superChip.setHexbox(ref hexBox);
        }

  

        private void portList_SelectedIndexChanged(object sender, EventArgs e)
        {
            portHandler.setPort(portList.SelectedItem.ToString());
        }

        private void portList_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portList.Items.Clear();
            foreach (var a in ports)
            {
                portList.Items.Add(a);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            portOutput.AppendText("Selected tool: " + tabControl.SelectedIndex + Environment.NewLine);
            if (tabControl.SelectedIndex == 1)
                this.hitagAesTab.Controls.Add(this.hexPanel);
            else if(tabControl.SelectedIndex == 2)
                this.hitag2EE.Controls.Add(this.hexPanel);
            else if (tabControl.SelectedIndex == 3)
                this.hitagExtended.Controls.Add(this.hexPanel);
            else if (tabControl.SelectedIndex == 4)
                this.hitag3.Controls.Add(this.hexPanel);
            else if (tabControl.SelectedIndex == 5)
                this.hitagPro.Controls.Add(this.hexPanel);
            else if (tabControl.SelectedIndex == 6)
                this.tabPageBmw.Controls.Add(this.hexPanel);
            else if (tabControl.SelectedIndex == 7)
                this.tabVvdiSuperChip.Controls.Add(this.hexPanel);
        }

        private void serialDebugger1_Load(object sender, EventArgs e)
        {

        }

        private void hitagAes_Load(object sender, EventArgs e)
        {

        }


        private void Controlapp_HexUpdated(object sender, EventArgs e)
        {
            ManageAbility();
        }

        private void hitag2_debugUpdated(object sender, EventArgs e)
        {

        }

        private void debugUpdatedEventHandler(object sender, EventArgs e)
        {
            DebugmessageEventArgs de = e as DebugmessageEventArgs;
            string message = de.Message;
            portOutput.AppendText(message);
            

            if (message.Contains("adapt target"))
            {
                string[] sub = message.Split(':');
                if(sub.Length==2)
                {
                    int adaptTarget = 0;
                    adaptTarget = int.Parse(sub[1], System.Globalization.NumberStyles.HexNumber);
                    if (adaptTarget > 0x10 && adaptTarget < 0x1b)
                    {
                        statusTransponder.BackColor = Color.Green;
                        statusReader.BackColor = Color.Green;
                    }
                    else if (adaptTarget > 0x0 && adaptTarget < 0xff)
                    {
                        statusTransponder.BackColor = Color.Orange;
                        statusReader.BackColor = Color.Green;
                    }
                    else
                    {
                        statusTransponder.BackColor = Color.Red;
                        statusReader.BackColor = Color.Red;
                    }

                }

            }
            else if (message.Contains("ISRcnt"))
            {
                string[] sub = message.Split(':');
                if (sub.Length == 2)
                {
                    int isrcnt = int.Parse(sub[1], System.Globalization.NumberStyles.HexNumber);
                    if (isrcnt == 0)
                    {
                        statusReceiver.BackColor = Color.Red;
                    }
                    else
                    {
                        statusReceiver.BackColor = Color.Green;
                    }

                }

            }
            else if (message.Contains("Hitager version"))
            {
                string[] sub = message.Split(':');
                if (sub.Length == 2)
                {
                    int version = int.Parse(sub[1], System.Globalization.NumberStyles.HexNumber);
                    if (version <2)
                    {
                        statusArduino.BackColor = Color.Red;
                    }
                    else
                    {
                        statusArduino.BackColor = Color.Green;
                    }

                }

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            portOutput.Clear();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if(portOutput.Text.Length >0)
                Clipboard.SetText(portOutput.Text);
        }

        private void gainBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void gainNum_ValueChanged(object sender, EventArgs e)
        {
            portHandler.portWR("g0" + ((int)gainNum.Value & 0x03));
        }

        private void phaseNum_ValueChanged(object sender, EventArgs e)
        {
            portHandler.portWR("a0" + ((int)phaseNum.Value & 0x0f).ToString("X1"));
        }

        private void hysteresisCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bmwHt2_Load(object sender, EventArgs e)
        {

        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message = "If you found this software useful please send some interesting" +
                " (car) remote to address below. Add also some description of remote type and features and" +
                " how this remote should possible be supported in Hitager future releases.\n\n" +
                "We can't however promise that all requests will be implemented (or even possible to implement).\n\n" +
                "Janne Kivijakola\n" +
                "Erilanperantie 7B\n" +
                "91900 Liminka\n" +
                "Finland";
            string title = "Donate";
            MessageBox.Show(message, title);

        }
    }
}