using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class ShapeDrawingForm : Form
{
	private List<Shape> shapes;

	public ShapeDrawingForm()
	{
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();

        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
		menu.DropDownItems.Add("Open...", null, this.openFileHandler);
		menu.DropDownItems.Add("Export...", null, this.exportHandler);
        menu.DropDownItems.Add("Exit", null, this.closeHandler);
        menuStrip.Items.Add(menu);

        this.Controls.Add(menuStrip);
		// Some basic settings
		Text = "Shape Drawing and Converter";
		Size = new Size(400, 400);
		CenterToScreen();
		SetStyle(ControlStyles.ResizeRedraw, true);
		
		// Initialize shapes
        shapes = new List<Shape>();
		
		// Listen to Paint event to draw shapes
		this.Paint += new PaintEventHandler(this.OnPaint); 
	}

    // What to do when the user closes the program
    private void closeHandler(object sender, EventArgs e)
    {
        this.Close();
    }

    // What to do when the user opens a file
    private void openFileHandler(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "";
        dialog.Title = "Open file...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            shapes = Parser.ParseShapes(dialog.FileName);
            this.Refresh();
        }

    }

    // What to do when the user wants to export a SVG file
	private void exportHandler (object sender, EventArgs e)
	{
		ShapeConverter converter;
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "SVG files|*.svg|TikZ files|*.tikz";
		saveFileDialog.RestoreDirectory = true;
		
		if(saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if((stream = saveFileDialog.OpenFile()) != null)
			{
				string[] str = saveFileDialog.FileName.Split('.');
				string st = str[str.Length - 1];

				if (st == "svg")
                {
					converter = new SVGConverter();
                } 
				else if (st == "tikz")
                {
					converter = new TikZConverter();
                }
                else
                {
					throw new Exception("No svg or tikz file.");
                }
				using (StreamWriter writer = new StreamWriter(stream))
                {
					foreach (Shape shape in shapes)
						shape.Draw(converter);
					converter.EndFile();
					
					for (int i = 0; i < converter.shapeStrings.Count; i++)
                    {
						writer.WriteLine(converter.shapeStrings[i]);
                    }
				}				
			}
		}
	}

    private void OnPaint(object sender, PaintEventArgs e)
	{
		// Draw all the shapes
		foreach(Shape shape in shapes)
			shape.Draw(new Drawdapter(e.Graphics));
	}
}